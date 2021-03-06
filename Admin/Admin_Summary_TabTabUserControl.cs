using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using VideoOS.Platform;
using System.ComponentModel;
using VideoOS.Platform.Admin;
using VideoOS.Platform.UI;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using VideoOS.Platform.Login;
using VideoOS.Platform.Messaging;
using VideoOS.Platform.Resources;
using VideoOS.Platform.Util;
using VideoOS.Platform.ConfigurationItems;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Admin_Summary_Tab.Admin
{
    public partial class Admin_Summary_TabTabUserControl : VideoOS.Platform.Admin.TabUserControl
    {
        private Dictionary<string, string> HardwareMAP = new Dictionary<string, string>();
        private System.Collections.ArrayList _result;
        private System.Collections.ArrayList _names;
        private Item _associatedItem;
        private bool _ignoreChanged = false;
        private AssociatedProperties _associatedProperties;

        public Admin_Summary_TabTabUserControl(Item item)
        {
            InitializeComponent();
            bool isInitialized = VideoOS.Platform.Log.LogClient.Instance.Initialized;
            System.Collections.ArrayList groups = VideoOS.Platform.Log.LogClient.Instance.ReadGroups(VideoOS.Platform.EnvironmentManager.Instance.MasterSite.ServerId);

            fillGrid("System", item, dGridViewLogSystem, decodenumberofdays(cmbSearchPeriod.Text));
            fillGrid("Audit", item, dGridViewLogAudit, decodenumberofdays(cmbSearchPeriod.Text));
            populate_graph(chart1, "Log Level", dGridViewLogSystem, "Pie");
            populate_graph(chart2, "Source Name", dGridViewLogSystem, "Pie");
            populate_graph(chart3, "Event Type", dGridViewLogSystem, "Pie");
            _associatedItem = item;
            labelItemName.Text = item.Name;

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void fillGrid(string group, Item item, DataGridView mydatagrid, int numofdaysback)
        {
            mydatagrid.Columns.Clear();
            String mypath = "";

            if (numofdaysback == 0)
            {
                VideoOS.Platform.Log.LogClient.Instance.ReadLog(VideoOS.Platform.EnvironmentManager.Instance.MasterSite.ServerId, 1, out _result, out _names, group);
            }
            else
            {
                VideoOS.Platform.Log.LogClient.Instance.ReadLog(VideoOS.Platform.EnvironmentManager.Instance.MasterSite.ServerId, 1, out _result, out _names, group, DateTime.Now.AddDays(numofdaysback * -1), DateTime.Now);
            }
            int colnumber = 0;
            var colNum = new DataGridViewTextBoxColumn { HeaderText = "Number" };

            mydatagrid.Columns.Add(colNum);
            foreach (string name in _names)
            {
                var col = new DataGridViewTextBoxColumn { HeaderText = name, Width = 150 };
                mydatagrid.Columns.Add(col);
                if (col.HeaderText.ToLower() == "source name")
                {
                    colnumber = col.Index;
                }
            }

            if (item.FQID.Kind.ToString().ToUpper() == "5135BA21-F1DC-4321-806A-6CE2017343C0" || item.FQID.Kind.ToString().ToUpper() == "DF6284F6-18EE-4506-B8C4-65B5F31A140C" || item.FQID.Kind.ToString().ToUpper() == "B77D68FC-B231-441B-8EB5-901C89234111" || item.FQID.Kind.ToString().ToUpper() == "CBAAA726-A089-4DB6-8F0D-48772E595B1B" || item.FQID.Kind.ToString().ToUpper() == "5FC737A9-BBF6-4473-A421-7E8075D45D9C" || item.FQID.Kind.ToString().ToUpper() == "3C829278-37AE-4EE8-8C1D-D94412CEEB74") {

                ManagementServer managementserver = new ManagementServer(item.GetParent().GetParent().FQID);
                switch (item.FQID.Kind.ToString().ToUpper())
                {
                    case "5135BA21-F1DC-4321-806A-6CE2017343C0":
                        Camera mycamera = new Camera(item.FQID);
                        mypath = mycamera.ParentItemPath;
                        break;
                    case "DF6284F6-18EE-4506-B8C4-65B5F31A140C":
                        Microphone mymic = new Microphone(item.FQID);
                        mypath = mymic.ParentItemPath;
                        break;
                    case "B77D68FC-B231-441B-8EB5-901C89234111":
                        Speaker myspeaker = new Speaker(item.FQID);
                        mypath = myspeaker.ParentItemPath;
                        break;
                    case "CBAAA726-A089-4DB6-8F0D-48772E595B1B":
                        Output myoutput = new Output(item.FQID);
                        mypath = myoutput.ParentItemPath;
                        break;
                    case "5FC737A9-BBF6-4473-A421-7E8075D45D9C":
                        InputEvent myinput = new InputEvent(item.FQID);
                        mypath = myinput.ParentItemPath;
                        break;
                    case "3C829278-37AE-4EE8-8C1D-D94412CEEB74":
                        Metadata mymetadata = new Metadata(item.FQID);
                        mypath = mymetadata.ParentItemPath;
                        break;
                }

                Hardware hardware = new Hardware(managementserver.ServerId, mypath);


                foreach (System.Collections.ArrayList arrayList in _result)
                {
                    Item parentserver = item.GetParent();


                    if (arrayList[colnumber].ToString().ToLower() == item.Name.ToLower() || (checkBox1.Checked && (hardware.DisplayName.ToLower() == arrayList[colnumber].ToString().ToLower() || parentserver.Name.ToLower() == arrayList[colnumber].ToString().ToLower())))
                    {
                        DataGridViewRow row = (DataGridViewRow)mydatagrid.RowTemplate.Clone();
                        row.CreateCells(mydatagrid, arrayList.ToArray());

                        mydatagrid.Rows.Add(row);
                    }

                }
            } else if (item.FQID.Kind.ToString().ToUpper() == "F0E91DE0-4E81-4f00-8BB6-B9C932D5B598")
            {
                var mychildren = item.GetChildren();
                foreach (System.Collections.ArrayList arrayList in _result)
                {
                    foreach (var mychild in mychildren)
                    {

                        if (arrayList[colnumber].ToString().ToLower() == mychild.Name.ToLower())
                        {
                            DataGridViewRow row = (DataGridViewRow)mydatagrid.RowTemplate.Clone();
                            row.CreateCells(mydatagrid, arrayList.ToArray());

                            mydatagrid.Rows.Add(row);
                        }
                    }
                }
            }
            mydatagrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            mydatagrid.Columns[0].Visible = false;
            mydatagrid.RowHeadersVisible = false;

        }
        public override void Init()
        {
            base.Init();
            _ignoreChanged = true;

        }

        public override void Close()
        {

            base.Close();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fillGrid("System", _associatedItem, dGridViewLogSystem, decodenumberofdays(cmbSearchPeriod.Text));
            fillGrid("Audit", _associatedItem, dGridViewLogAudit, decodenumberofdays(cmbSearchPeriod.Text));
            populate_graph(chart1, "Log Level", dGridViewLogSystem, "Pie");
            populate_graph(chart2, "Source Name", dGridViewLogSystem, "Pie");
            populate_graph(chart3, "Event Type", dGridViewLogSystem, "Pie");
        }
        private int decodenumberofdays(string textdays)
        {
            string[] numdays = textdays.Split(' ');
            if (int.TryParse(numdays[0], out int result))
            {
                return result;
            }
            else { return 0; };
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            BackgroundWorker helperBW = sender as BackgroundWorker;

            e.Result = BackgroundProcessLogicMethod(helperBW);
            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {

                Log_Message("Assigning Values to UI", false);
                SafeInvoke(checkBox1, () => { checkBox1.Enabled = true; });
                Log_Message("Assigned Values to UI", false);
            }

        }
        public static void SafeInvoke(System.Windows.Forms.Control control, System.Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(new System.Windows.Forms.MethodInvoker(() => { action(); }));
            else
                action();
        }
        private int BackgroundProcessLogicMethod(BackgroundWorker bw)
        {
            int counter = 0;
            int Total = 0;

            Log_Message("building hardware list", false);


            bw.ReportProgress(0);
            Configuration.Instance.RefreshConfiguration(Kind.Server);
            List<Item> sites = Configuration.Instance.GetItemsByKind(Kind.Server, ItemHierarchy.SystemDefined);
            Log_Message("Hardware List pull started", false);
            bw.ReportProgress(50);

            foreach (Item site in sites)
            {
                ManagementServer managementServer = new ManagementServer(site.FQID);

                ICollection<RecordingServer> servers = managementServer.RecordingServerFolder.RecordingServers;
                Log_Message("recording servers Pulled:" + servers.Count, false);
                foreach (RecordingServer server in servers)
                {
                    Total = sites.Count * servers.Count;
                    counter = +1;

                    bw.ReportProgress(50 + (50 * (counter / Total)));
                    ICollection<Hardware> hardwares = server.HardwareFolder.Hardwares;

                    foreach (Hardware hardware in hardwares)
                    {
                        HardwareMAP.Add(hardware.Address, hardware.Name);

                    }

                }
            }
            Log_Message("Hardware List pull finished: Total hardware : " + HardwareMAP.Count, false);

            return 0;
        }


        private void Log_Message(string mymessage, Boolean error)
        {
            EnvironmentManager.Instance.Log(false, "4Js - Log Tab Plugin", mymessage); ;
        }

        private void Export_CSV(SaveFileDialog sfd, string type, DataGridView dataGridView1)
        {
            bool fileError = false;
            string origpath = Path.GetDirectoryName(sfd.FileName);
            string origFilename = Path.GetFileNameWithoutExtension(sfd.FileName.ToString());
            string[] filepath = { origpath, "\\", origFilename, type, Path.GetExtension(sfd.FileName.ToString()) };

            // Concatenate all strings of an array into one string
            string FullFileName = string.Concat(filepath);
            if (File.Exists(FullFileName))
            {
                try
                {
                    File.Delete(FullFileName);
                }
                catch (IOException ex)
                {
                    fileError = true;
                    MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                }
            }
            if (!fileError)
            {
                try
                {
                    int columnCount = dataGridView1.Columns.Count;
                    string columnNames = "";
                    string[] outputCsv = new string[dataGridView1.Rows.Count + 1];
                    for (int i = 0; i < columnCount; i++)
                    {
                        columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                    }
                    outputCsv[0] += columnNames;

                    for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            outputCsv[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                        }
                    }

                    File.WriteAllLines(FullFileName, outputCsv, Encoding.UTF8);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(dGridViewLogSystem.Rows.Count == 0 && dGridViewLogAudit.Rows.Count == 0))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Export_CSV(sfd, "System", dGridViewLogSystem);
                    Export_CSV(sfd, "Audit", dGridViewLogAudit);

                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dGridViewLogSystem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbSearchPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid("System", _associatedItem, dGridViewLogSystem, decodenumberofdays(cmbSearchPeriod.Text));
            fillGrid("Audit", _associatedItem, dGridViewLogAudit, decodenumberofdays(cmbSearchPeriod.Text));
            populate_graph(chart1, "Log Level", dGridViewLogSystem, "Pie");
            populate_graph(chart2, "Source Name", dGridViewLogSystem, "Pie");
            populate_graph(chart3, "Event Type", dGridViewLogSystem, "Pie");

        }
        private void populate_graph(System.Windows.Forms.DataVisualization.Charting.Chart mychart,string mycolumn, DataGridView mydataViewGrid, string mycharttype, string mycolumn2 = "none")
        {
            mychart.Series.Clear();
            mychart.Legends.Clear();
            //ChartArea chartArea1 = new ChartArea();
            //chartArea1.AxisX.MajorGrid.LineColor = Color.LightGray;
            //chartArea1.AxisY.MajorGrid.LineColor = Color.LightGray;
            //chartArea1.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            //chartArea1.AxisY.LabelStyle.Font = new Font("Consolas", 8);

            //chart1.ChartAreas.Add(chartArea1);
            //Add a new chart-series
            var series = new Series();
            series.Name= mycolumn;
            series.ChartType = SeriesChartType.Pie;
            mychart.Series.Add(series);
            int mycolumnindex = 0;
            
            while (mycolumnindex < mydataViewGrid.Columns.Count)
            {
                if (mydataViewGrid.Columns[mycolumnindex].HeaderText.ToLower() == mycolumn.ToLower())
                {
                    break;
                }
                mycolumnindex++;
            }

          
            
            
            var result = mydataViewGrid.Rows.Cast<DataGridViewRow>()
       .Where(r => r.Cells[mycolumnindex].Value != null)
       .Select(r => r.Cells[mycolumnindex].Value)
       .GroupBy(id => id)
           .OrderByDescending(id => id.Count())
           .Select(g => new { Id = g.Key, Count = g.Count() });

       
            foreach (var s in result)
            {
                mychart.Legends.Add(s.Id.ToString());
                mychart.Series[0].Points.AddXY(s.Id,s.Count);
            }
            

            mychart.Series[0].ChartType = SeriesChartType.Pie;
            mychart.Series[0].IsValueShownAsLabel = true;

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
