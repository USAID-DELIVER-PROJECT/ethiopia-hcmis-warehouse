using System;
using System.Collections.Generic;
using System.Linq;
using HCMIS.Security.Models;
using System.ComponentModel;

namespace HCMIS.Security.UserManagement.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        private bool _allowed;
        public MenuViewModel()
        {

        }

        public MenuViewModel(MenuItem menuItem)
        {
            MenuItemID = menuItem.MenuItemID;
            Text = menuItem.Text;
            URL = menuItem.URL;
            ToolTip = menuItem.ToolTip;
            ParentMenuItemID = menuItem.ParentID;
            Icon = menuItem.Icon;
            Order = menuItem.Order;
        }

        public int MenuItemID { get; set; }
        public string Text { get; set; }
        public string URL { get; set; }
        public int Order { get; set; }
        public string ToolTip { get; set; }
        public string Icon { get; set; }
        public bool Allowed 
        {
            get { return this._allowed; }
            set
            {
                if(_allowed == value)
                    return;
                _allowed = value;
                this.OnPropertyChanged("Allowed");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {            
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public int? ParentMenuItemID { get; set; }

        public List<MenuViewModel> SubMenus { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}