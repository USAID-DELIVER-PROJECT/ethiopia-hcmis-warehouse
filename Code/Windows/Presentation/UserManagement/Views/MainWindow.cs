using System;
using System.Collections.Generic;
using System.Threading;
using DevExpress.XtraBars;
using HCMIS.Security.Common;
using HCMIS.Security.Helpers;
using HCMIS.Security.UserManagement.Helpers;
using DevExpress.XtraNavBar;
using HCMIS.Security.UserManagement.ViewModels;
using DevExpress.XtraEditors;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class MainWindow : XtraForm
    {
        public bool ShowLoginWindowOnClose { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //DisplayUsersList();
           
            var menuItems = MenuListViewModel.GenerateMenuForUser(((UserIdentity)Thread.CurrentPrincipal.Identity).UserID);
            LoadMenuItems(menuItems);
        }

        private void LoadMenuItems(IEnumerable<MenuViewModel> menuItems)
        {
            foreach (var menuItem in menuItems)
            {
                // top-most menuStrip
                var toolStripItem = new BarSubItem(barManager1, menuItem.Text);


                // left-side navControl
                var navGroup = navBarControl.Groups.Add();
                navGroup.Caption = menuItem.Text;
                navGroup.Name = "navGroup" + menuItem.URL;
                navGroup.SmallImage = Helpers.ViewHelper.LoadImageFromResource(menuItem.Icon);
                navGroup.LargeImage = Helpers.ViewHelper.LoadImageFromResource(menuItem.Icon);
                foreach (var subMenu in menuItem.SubMenus)
                {
                    // top-most menuStrip 
                    var subToolStripMenu = new BarButtonItem(barManager1, subMenu.Text);
                    subToolStripMenu.ItemClick += new ItemClickEventHandler(subToolStripMenu_ItemClick);
                        ;// new EventHandler(commonHandler  );
                    subToolStripMenu.Tag = subMenu.URL;
                    // left-side navigation
                    var navLink = navBarControl.Items.Add();
                    navLink.Caption = subMenu.Text;
                    navLink.Name = "navLink" + subMenu.URL;
                    navLink.LargeImage = Helpers.ViewHelper.LoadImageFromResource(subMenu.Icon);
                    navLink.SmallImage = Helpers.ViewHelper.LoadImageFromResource(subMenu.Icon);
                    navLink.Tag = subMenu.URL;
                    navLink.LinkClicked += new NavBarLinkEventHandler(commonEventHandler);
                    if (subMenu.URL == "UM-MA-LO-FR") //Special Handler for logout
                    {
                        navLink.LinkClicked -= new NavBarLinkEventHandler(commonEventHandler);
                        navLink.LinkClicked += new NavBarLinkEventHandler(logOutEventHandler);

                    }
                    navGroup.ItemLinks.Add(navLink);
                    toolStripItem.AddItem(subToolStripMenu);
                }
                menuBar.AddItem(toolStripItem);
            }
        }

        private void subToolStripMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag.ToString() == "UM-MA-LO-FR")
            {
                logOutEventHandler(null, null);
                return;
            }
            openForm(e.Item.Tag.ToString());
        }


        private void commonEventHandler(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var clickedItem = (NavBarItem)sender;
            openForm(clickedItem.Tag.ToString());
            lblActiveWindowTitle.Text = clickedItem.Caption;
        }

        private void openForm(string formIdentifier)
        {
            adjustLeftNavigation(formIdentifier);            
            var window = Helpers.ViewHelper.OpenLink(formIdentifier);
            window.ShowInPanel(mainPanel);
        }

        private void logOutEventHandler(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ShowLoginWindowOnClose = true;
            this.Close();
        }

        private void adjustLeftNavigation(string identifier)
        {
            foreach (DevExpress.XtraNavBar.NavBarGroup group in navBarControl.Groups)
            {
                foreach (DevExpress.XtraNavBar.NavBarItemLink link in group.ItemLinks)
                {
                    if (link.Item.Tag.ToString().Equals(identifier))
                    {
                        //group.SelectedLink = link.Links[0];
                        navBarControl.SelectedLink = link;
                        navBarControl.ActiveGroup = group;
                        return;
                    }
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Write out the name of the hub
            UnitOfWork uow = UnitOfWork.CreateInstance();
            txtDBnameBottom.Caption = uow.GeneralInfo.GetInstance().HospitalName;
        }

    }
}
