using VideoOS.Platform.Admin;

namespace Admin_Summary_Tab.Admin
{
    public partial class Admin_Summary_TabToolsOptionDialogUserControl : ToolsOptionsDialogUserControl
    {
        public Admin_Summary_TabToolsOptionDialogUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        public string MyPropValue
        {
            set { textBoxPropValue.Text = value ?? ""; }
            get { return textBoxPropValue.Text; }
        }
    }
}
