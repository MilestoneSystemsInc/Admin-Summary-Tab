using System;
using System.Drawing;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Admin;


namespace Admin_Summary_Tab.Admin
{
    public class Admin_Summary_TabTabPlugin : TabPlugin
    {
        private Item _associatedItem = null;
        public Guid TabGuid = Guid.Empty;
        public Guid myID= Guid.Empty;
        /// <summary>
        /// This plugin tab is visible when a camera is selected. Change to any other device type guid.
        /// </summary>
        public override Guid AssociatedKind
        {
            get { return TabGuid; }
           
        }

        public override Guid Id
        {
            get { return myID; }
        }
        public void setID(Guid id)
        {
            myID = id;
        }
        public void setkind(Guid mykind)
        {
            TabGuid= mykind;
        }
        public override Image Icon
        {
            get { return Admin_Summary_TabDefinition.TreeNodeImage; }
        }

        public override string Name
        {
            get { return "Device Log"; }
        }

        /// <summary>
        /// This method is called when the user has logged in and configuration is accessible.<br/>
        /// </summary>
        public override void Init()
        {

        }

        public override void Close()
        {
        }

        public override TabUserControl GenerateUserControl(Item item)
        {
            _associatedItem = item;
            return new Admin_Summary_TabTabUserControl(item);
        }

        /// <summary>
        /// Check to see if this plugin tab should be visible.
        /// </summary>
        /// <param name="associatedItem">The currently selected device</param>
        /// <returns></returns>
        public override bool IsVisible(Item associatedItem)
        {
            return true;
        }
    }
}
