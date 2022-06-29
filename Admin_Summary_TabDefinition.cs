using Admin_Summary_Tab.Admin;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using VideoOS.Platform;
using VideoOS.Platform.Admin;
using VideoOS.Platform.Background;
using VideoOS.Platform.Client;

namespace Admin_Summary_Tab
{
    /// <summary>
    /// The PluginDefinition is the ‘entry’ point to any plugin.  
    /// This is the starting point for any plugin development and the class MUST be available for a plugin to be loaded.  
    /// Several PluginDefinitions are allowed to be available within one DLL.
    /// Here the references to all other plugin known objects and classes are defined.
    /// The class is an abstract class where all implemented methods and properties need to be declared with override.
    /// The class is constructed when the environment is loading the DLL.
    /// </summary>
    public class Admin_Summary_TabDefinition : PluginDefinition
    {
        private static System.Drawing.Image _treeNodeImage;
        private static System.Drawing.Image _topTreeNodeImage;

        internal static Guid Admin_Summary_TabPluginId = new Guid("09340598-3c3e-4757-8326-a12c87ab0eb0");
        internal static Guid Admin_Summary_TabKind = new Guid("747126d3-88fe-4ade-8556-f77fd2c6756c");
        internal static Guid Admin_Summary_TabSidePanel = new Guid("9960224c-af83-43c7-ae8e-a1afcf467c63");
        internal static Guid Admin_Summary_TabViewItemPlugin = new Guid("ff90bd45-9f8a-4e7d-b034-13988c29e1a6");
        internal static Guid Admin_Summary_TabSettingsPanel = new Guid("e0b5daaf-573d-43bd-aaac-7ca5e0567431");
        internal static Guid Admin_Summary_TabBackgroundPlugin = new Guid("3d8b07ce-edfc-47d2-bf94-35686b470126");
        internal static Guid Admin_Summary_TabWorkSpacePluginId = new Guid("6d5736b4-aba9-4dac-a6f6-9e6cedcda404");
        internal static Guid Admin_Summary_TabWorkSpaceViewItemPluginId = new Guid("823ccce3-2099-42bd-95db-a12fd4277f1f");
        internal static Guid Admin_Summary_TabTabPluginId = new Guid("b6b8568b-ca5d-45bf-aa5a-2e47619c3811");
        internal static Guid Admin_Summary_TabTabPluginId2 = new Guid("b6b8568b-ca5d-45bf-aa5a-2e47619c3812");
        internal static Guid Admin_Summary_TabTabPluginId3 = new Guid("b6b8568b-ca5d-45bf-aa5a-2e47619c3813");
        internal static Guid Admin_Summary_TabTabPluginId4 = new Guid("b6b8568b-ca5d-45bf-aa5a-2e47619c3814");
        internal static Guid Admin_Summary_TabTabPluginId5 = new Guid("b6b8568b-ca5d-45bf-aa5a-2e47619c3815");
        internal static Guid Admin_Summary_TabTabPluginId6 = new Guid("b6b8568b-ca5d-45bf-aa5a-2e47619c3816");
        internal static Guid Admin_Summary_TabTabPluginId7 = new Guid("b6b8568b-ca5d-45bf-aa5a-2e47619c3817");
        internal static Guid Admin_Summary_TabViewLayoutId = new Guid("898dc233-f951-434c-b456-a43c984bd003");
        // IMPORTANT! Due to shortcoming in Visual Studio template the below cannot be automatically replaced with proper unique GUIDs, so you will have to do it yourself
        internal static Guid Admin_Summary_TabWorkSpaceToolbarPluginId = new Guid("22222222-9871-2222-2222-222222222222");
        internal static Guid Admin_Summary_TabViewItemToolbarPluginId = new Guid("33333333-9871-3333-3333-333333333333");
        internal static Guid Admin_Summary_TabToolsOptionDialogPluginId = new Guid("44444444-9871-4444-4444-444444444444");

        #region Private fields

        private UserControl _treeNodeInofUserControl;

        //
        // Note that all the plugin are constructed during application start, and the constructors
        // should only contain code that references their own dll, e.g. resource load.

        private List<BackgroundPlugin> _backgroundPlugins = new List<BackgroundPlugin>();
        private Collection<SettingsPanelPlugin> _settingsPanelPlugins = new Collection<SettingsPanelPlugin>();
        private List<ViewItemPlugin> _viewItemPlugins = new List<ViewItemPlugin>();
        private List<ItemNode> _itemNodes = new List<ItemNode>();
        private List<SidePanelPlugin> _sidePanelPlugins = new List<SidePanelPlugin>();
        private List<String> _messageIdStrings = new List<string>();
        private List<SecurityAction> _securityActions = new List<SecurityAction>();
        private List<WorkSpacePlugin> _workSpacePlugins = new List<WorkSpacePlugin>();
        private List<TabPlugin> _tabPlugins = new List<TabPlugin>();
        private List<ViewItemToolbarPlugin> _viewItemToolbarPlugins = new List<ViewItemToolbarPlugin>();
        private List<WorkSpaceToolbarPlugin> _workSpaceToolbarPlugins = new List<WorkSpaceToolbarPlugin>();
        private List<ToolsOptionsDialogPlugin> _toolsOptionsDialogPlugins = new List<ToolsOptionsDialogPlugin>();

        #endregion

        #region Initialization

        /// <summary>
        /// Load resources 
        /// </summary>
        static Admin_Summary_TabDefinition()
        {
            _treeNodeImage = Properties.Resources.DummyItem;
            _topTreeNodeImage = Properties.Resources.Server;
        }


        /// <summary>
        /// Get the icon for the plugin
        /// </summary>
        internal static Image TreeNodeImage
        {
            get { return _treeNodeImage; }
        }

        #endregion

        /// <summary>
        /// This method is called when the environment is up and running.
        /// Registration of Messages via RegisterReceiver can be done at this point.
        /// </summary>
        public override void Init()
        {
            // Populate all relevant lists with your plugins etc.
            //_itemNodes.Add(new ItemNode(Admin_Summary_TabKind, Guid.Empty,
            //"Admin_Summary_Tab", _treeNodeImage,
            //"Admin_Summary_Tabs", _treeNodeImage,
            //Category.Text, true,
            //ItemsAllowed.One,
            //new Admin_Summary_TabItemManager(Admin_Summary_TabKind),
            //null
            //                             ));
            // Populate all relevant lists with your plugins etc.
            AdminPlacementHint = AdminPlacementHint.Root;
            if (EnvironmentManager.Instance.EnvironmentType == EnvironmentType.Administration)
            {
                Admin_Summary_TabTabPlugin cameratab = new Admin_Summary_TabTabPlugin();
                cameratab.setkind(Kind.Camera);
                cameratab.setID(Admin_Summary_TabTabPluginId);
                _tabPlugins.Add(cameratab) ;
                Admin_Summary_TabTabPlugin metadatatab = new Admin_Summary_TabTabPlugin();
                metadatatab.setkind(Kind.Metadata);
                metadatatab.setID(Admin_Summary_TabTabPluginId2);
                _tabPlugins.Add(metadatatab);
                Admin_Summary_TabTabPlugin speakertab = new Admin_Summary_TabTabPlugin();
                speakertab.setkind(Kind.Speaker);
                speakertab.setID(Admin_Summary_TabTabPluginId3);
                _tabPlugins.Add(speakertab);
                Admin_Summary_TabTabPlugin microphonetab = new Admin_Summary_TabTabPlugin();
                microphonetab.setkind(Kind.Microphone);
                speakertab.setID(Admin_Summary_TabTabPluginId4);
                _tabPlugins.Add(microphonetab);
                Admin_Summary_TabTabPlugin Outputtab = new Admin_Summary_TabTabPlugin();
                Outputtab.setkind(Kind.Output);
                Outputtab.setID(Admin_Summary_TabTabPluginId5);
                _tabPlugins.Add(Outputtab);
                Admin_Summary_TabTabPlugin Inputtab = new Admin_Summary_TabTabPlugin();
                Inputtab.setkind(Kind.InputEvent);
                Inputtab.setID(Admin_Summary_TabTabPluginId6);
                _tabPlugins.Add(Inputtab);

                //Admin_Summary_TabTabPlugin FolderTab = new Admin_Summary_TabTabPlugin();
                //FolderTab.setkind(Kind.Folder);
                //FolderTab.setID(Admin_Summary_TabTabPluginId7);
                //_tabPlugins.Add(FolderTab);

                //Admin_Summary_TabTabPlugin hardwaretab = new Admin_Summary_TabTabPlugin();
                //hardwaretab.setkind(Kind.Hardware);
                //hardwaretab.setID(Admin_Summary_TabTabPluginId3);
                //_tabPlugins.Add(hardwaretab);

            }

        }

        /// <summary>
        /// The main application is about to be in an undetermined state, either logging off or exiting.
        /// You can release resources at this point, it should match what you acquired during Init, so additional call to Init() will work.
        /// </summary>
        public override void Close()
        {
            _itemNodes.Clear();
            _sidePanelPlugins.Clear();
            _viewItemPlugins.Clear();
            _settingsPanelPlugins.Clear();
            _backgroundPlugins.Clear();
            _workSpacePlugins.Clear();
            _tabPlugins.Clear();
            _viewItemToolbarPlugins.Clear();
            _workSpaceToolbarPlugins.Clear();
            _toolsOptionsDialogPlugins.Clear();
        }

        /// <summary>
        /// Return any new messages that this plugin can use in SendMessage or PostMessage,
        /// or has a Receiver set up to listen for.
        /// The suggested format is: "YourCompany.Area.MessageId"
        /// </summary>
        public override List<string> PluginDefinedMessageIds
        {
            get
            {
                return _messageIdStrings;
            }
        }

        /// <summary>
        /// If authorization is to be used, add the SecurityActions the entire plugin 
        /// would like to be available.  E.g. Application level authorization.
        /// </summary>
        public override List<SecurityAction> SecurityActions
        {
            get
            {
                return _securityActions;
            }
            set
            {
            }
        }

        #region Identification Properties

        /// <summary>
        /// Gets the unique id identifying this plugin component
        /// </summary>
        public override Guid Id
        {
            get
            {
                return Admin_Summary_TabPluginId;
            }
        }

        /// <summary>
        /// This Guid can be defined on several different IPluginDefinitions with the same value,
        /// and will result in a combination of this top level ProductNode for several plugins.
        /// Set to Guid.Empty if no sharing is enabled.
        /// </summary>
        public override Guid SharedNodeId
        {
            get
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Define name of top level Tree node - e.g. A product name
        /// </summary>
        public override string Name
        {
            get { return "Device Log Tab"; }
        }

        /// <summary>
        /// Your company name
        /// </summary>
        public override string Manufacturer
        {
            get
            {
                return "4JS";
            }
        }

        /// <summary>
        /// Version of this plugin.
        /// </summary>
        public override string VersionString
        {
            get
            {
                return "1.0.0.0";
            }
        }

        /// <summary>
        /// Icon to be used on top level - e.g. a product or company logo
        /// </summary>
        public override System.Drawing.Image Icon
        {
            get { return _topTreeNodeImage; }
        }

        #endregion


        #region Administration properties

        /// <summary>
        /// A list of server side configuration items in the administrator
        /// </summary>
        public override List<ItemNode> ItemNodes
        {
            get { return _itemNodes; }
        }

        /// <summary>
        /// An extension plug-in running in the Administrator to add a tab for built-in devices and hardware.
        /// </summary>
        public override ICollection<TabPlugin> TabPlugins
        {
            get { return _tabPlugins; }
        }

        /// <summary>
        /// An extension plug-in running in the Administrator to add more tabs to the Tools-Options dialog.
        /// </summary>
        public override List<ToolsOptionsDialogPlugin> ToolsOptionsDialogPlugins
        {
            get { return _toolsOptionsDialogPlugins; }
        }

        /// <summary>
        /// A user control to display when the administrator clicks on the top TreeNode
        /// </summary>
        public override UserControl GenerateUserControl()
        {
            _treeNodeInofUserControl = new HelpPage();
            return _treeNodeInofUserControl;
        }

        /// <summary>
        /// This property can be set to true, to be able to display your own help UserControl on the entire panel.
        /// When this is false - a standard top and left side is added by the system.
        /// </summary>
        public override bool UserControlFillEntirePanel
        {
            get { return false; }
        }
        #endregion






        /// <summary>
        /// Create and returns the background task.
        /// </summary>
        public override List<BackgroundPlugin> BackgroundPlugins
        {
            get { return _backgroundPlugins; }
        }

    }
}
