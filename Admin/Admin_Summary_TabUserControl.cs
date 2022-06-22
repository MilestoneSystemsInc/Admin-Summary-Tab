using System;
using System.Windows.Forms;
using VideoOS.Platform;
using VideoOS.Platform.Admin;
using VideoOS.Platform.UI;

namespace Admin_Summary_Tab.Admin
{
    /// <summary>
    /// This UserControl only contains a configuration of the Name for the Item.
    /// The methods and properties are used by the ItemManager, and can be changed as you see fit.
    /// </summary>
    public partial class Admin_Summary_TabUserControl : UserControl
    {
        internal event EventHandler ConfigurationChangedByUser;


        public Admin_Summary_TabUserControl()
        {
            InitializeComponent();
        }

        internal String DisplayName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        /// <summary>
        /// Ensure that all user entries will call this method to enable the Save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void OnUserChange(object sender, EventArgs e)
        {
            if (ConfigurationChangedByUser != null)
                ConfigurationChangedByUser(this, new EventArgs());
        }

        internal void FillContent(Item item)
        {
        }

        internal void UpdateItem(Item item)
        {
            item.Name = DisplayName;
            // Fill in any propertuies that should be saved:
            //item.Properties["AKey"] = "some value";
        }

        internal void ClearContent()
        {
            textBoxName.Text = "";
        }

    }
}
