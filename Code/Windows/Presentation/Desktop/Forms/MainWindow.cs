using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraBars;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Properties;
using HCMIS.Desktop.ViewModels;
using HCMIS.Security.Common;
using DevExpress.XtraNavBar;
using DevExpress.XtraEditors;
using HCMIS.Shared.Connection;
using HCMIS.Desktop.Forms.Modals;
using HCMIS.Desktop.Helpers;

namespace HCMIS.Desktop.Views
{
    public partial class MainWindow : XtraForm
    {
        #region Properties 
            public bool ShowLoginWindowOnClose { get; set; }
            public IEnumerable<MenuViewModel> menuItems { get; set; }
            public string CurrentFormIdentifier { get; set; }
        #endregion

        public MainWindow(IEnumerable<MenuViewModel> menus)
        {
            InitializeComponent();
            menuItems = menus;
            Instance = this;
        }

        // keep a reference to the instance
        public static MainWindow Instance { get; set; }

        public Form OpenPage(string formIdentifier)
        {
            CurrentFormIdentifier = formIdentifier;

                dockPanel1.Options.ShowAutoHideButton = false;
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                adjustLeftNavigation(formIdentifier);
                var window = HCMIS.Desktop.Helpers.ViewHelper.OpenLink(formIdentifier);
                window.ShowInPanel(mainPanel);
                return window;

        }

        private void LoadMenuItems(IEnumerable<MenuViewModel> menuItems)
        {
            
            foreach (var menuItem in menuItems)
            {
                // top-most menuStrip
                var toolStripItem = new BarSubItem(barManager1, menuItem.Text);


                // left-side navControl
                var navGroup = navBarControl.Groups.Add();
                navGroup.Caption = menuItem.Text.Replace("&","");
                navGroup.Name = "navGroup" + menuItem.URL;
                navGroup.LargeImage = navGroup.SmallImage = HCMIS.Desktop.Helpers.ViewHelper.LoadImageFromResource(menuItem.Icon,24,24);
                 
                foreach (var subMenu in menuItem.SubMenus)
                {
                    // top-most menuStrip 
                    var subToolStripMenu = new BarButtonItem(barManager1, subMenu.Text);
                    subToolStripMenu.ItemClick += new ItemClickEventHandler(subToolStripMenu_ItemClick);
                    subToolStripMenu.Glyph = subToolStripMenu.LargeGlyph = HCMIS.Desktop.Helpers.ViewHelper.LoadImageFromResource(subMenu.Icon, 16, 16);
                    
                    
                    ;// new EventHandler(commonHandler  );
                    subToolStripMenu.Tag = subMenu.URL;

                    // left-side navigation
                    var navLink = navBarControl.Items.Add();
                    navLink.Caption = subMenu.Text.Replace("&", ""); 
                    navLink.Name = "navLink" + subMenu.URL;
                    navLink.SmallImage = navLink.LargeImage = HCMIS.Desktop.Helpers.ViewHelper.LoadImageFromResource(subMenu.Icon,40,40);
                  
                    navLink.Tag = subMenu.URL;
                    navLink.LinkClicked += new NavBarLinkEventHandler(commonEventHandler);
                    if (subMenu.URL == "UM-MA-LO-FR") //Special Handler for logout
                    {
                        navLink.LinkClicked -= new NavBarLinkEventHandler(commonEventHandler);
                        navLink.LinkClicked += new NavBarLinkEventHandler(logOutEventHandler);

                        subToolStripMenu.ItemClick -= new ItemClickEventHandler(subToolStripMenu_ItemClick);
                        subToolStripMenu.ItemClick +=new ItemClickEventHandler(logoutStripMenu_ItemClick);
                    }
                    navGroup.ItemLinks.Add(navLink);
                    toolStripItem.AddItem(subToolStripMenu);
                }
                toolStripItem.Alignment = BarItemLinkAlignment.Left;
                menuBar.AddItem( toolStripItem );
            }
            menuBar.AddItem(barVersionInfo2);

        }

        private void subToolStripMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenPage(e.Item.Tag.ToString());
            lblActiveWindowTitle.Text = e.Link.Caption;
        }

        private void logoutStripMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            logOutEventHandler(null, null);
        }

        private void commonEventHandler(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var clickedItem = (NavBarItem)sender;
            OpenPage(clickedItem.Tag.ToString());
            lblActiveWindowTitle.Text = clickedItem.Caption;
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
            // Initialize the menu items
            
            
            LoadMenuItems(menuItems);
            PaintApplicationContext();
        }

        public void PaintApplicationContext()
        {
            if (!File.Exists(BLL.GeneralInfo.Current.LogoUrl))
            {
                var image = GeneralInfo.Current.GetLogo();
                if(image == null)
                {
                   image = Resources.Default;
                   GeneralInfo.Current.SaveImage(image);
                }
                string DirectoryPath = Directory.GetParent(BLL.GeneralInfo.Current.LogoUrl).FullName;
                if (!Directory.Exists(DirectoryPath))
                {
                   Directory.CreateDirectory(DirectoryPath);
                }
                image.Save(BLL.GeneralInfo.Current.LogoUrl, image.RawFormat);
            }

            pictureBox1.ImageLocation = GeneralInfo.Current.LogoUrl;

            barVersionInfo2.Caption = string.Format("Logged in at: {0} v-{1}", DateTimeHelper.ServerDateTime.ToShortTimeString(),HCMIS.Desktop.Program.HCMISVersionStringShort);
            if (System.Diagnostics.Debugger.IsAttached || !ConnectionHelper.IsLiveInstallation)
            {
                barStatusLeft1.Caption = string.Format("{0} - {1} : {2} ", ConnectionHelper.CurrentConnection.Name, ConnectionHelper.CurrentConnection.DataSource, GeneralInfo.Current.HospitalName);
            }
            // print the caption - site name
            CaptionSiteName.Text = GeneralInfo.Current.HospitalName;
            barStatusRigth2.Caption = Security.Helper.CurrentUser.FullName;

        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TODO: Record that dude just closed it.
            if (!ShowLoginWindowOnClose)
            {
                Application.Exit();
    
            }else
            {
                HCMIS.Desktop.LoginForm.Instance.Show();
            }
            
        }

        private void btnJIRA_ItemClick(object sender, ItemClickEventArgs e)
        {
            JiraHelper.TakeScreenshot(this);
            // Show the Isssue Dialog Box.
            JiraIssue issue = new JiraIssue();
            issue.ShowDialog(this);
           
        }

        private void hideContainerLeft_Click(object sender, EventArgs e)
        {

        }

        private void hideContainerLeft_Click_1(object sender, EventArgs e)
        {

        }

      

    }
}
