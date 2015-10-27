using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class User
    {
        public User()
        {
            this.ChangeLogs = new List<ChangeLog>();
            this.ErrorLogs = new List<ErrorLog>();
            this.IssueDocs = new List<IssueDoc>();
            this.IssueDocDeleteds = new List<IssueDocDeleted>();
            this.LoginLogs = new List<LoginLog>();
            this.Orders = new List<Order>();
            this.Orders1 = new List<Order>();
            this.PickLists = new List<PickList>();
            this.POes = new List<PO>();
            this.Receipts = new List<Receipt>();
            this.ReceiptConfirmationPrintouts = new List<ReceiptConfirmationPrintout>();
            this.ReceiptConfirmationPrintouts1 = new List<ReceiptConfirmationPrintout>();
            this.ReceiptConfirmationPrintouts2 = new List<ReceiptConfirmationPrintout>();
            this.ReceiveDocConfirmations = new List<ReceiveDocConfirmation>();
            this.ReceiveDocConfirmations1 = new List<ReceiveDocConfirmation>();
            this.ReceiveDocConfirmations2 = new List<ReceiveDocConfirmation>();
            this.ReceiveDocConfirmations3 = new List<ReceiveDocConfirmation>();
            this.ReceiveDocConfirmations4 = new List<ReceiveDocConfirmation>();
            this.ReceiveDocConfirmations5 = new List<ReceiveDocConfirmation>();
            this.ReceiveDocDeleteds = new List<ReceiveDocDeleted>();
            this.STVLogs = new List<STVLog>();
            this.STVLogs1 = new List<STVLog>();
            this.STVLogs2 = new List<STVLog>();
            this.UserPaymentTypes = new List<UserPaymentType>();
            this.UserPhysicalStores = new List<UserPhysicalStore>();
            this.UserStores = new List<UserStore>();
        }

        public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> UserType { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }
        public virtual ICollection<ErrorLog> ErrorLogs { get; set; }
        public virtual ICollection<IssueDoc> IssueDocs { get; set; }
        public virtual ICollection<IssueDocDeleted> IssueDocDeleteds { get; set; }
        public virtual ICollection<LoginLog> LoginLogs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Order> Orders1 { get; set; }
        public virtual ICollection<PickList> PickLists { get; set; }
        public virtual ICollection<PO> POes { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<ReceiptConfirmationPrintout> ReceiptConfirmationPrintouts { get; set; }
        public virtual ICollection<ReceiptConfirmationPrintout> ReceiptConfirmationPrintouts1 { get; set; }
        public virtual ICollection<ReceiptConfirmationPrintout> ReceiptConfirmationPrintouts2 { get; set; }
        public virtual ICollection<ReceiveDocConfirmation> ReceiveDocConfirmations { get; set; }
        public virtual ICollection<ReceiveDocConfirmation> ReceiveDocConfirmations1 { get; set; }
        public virtual ICollection<ReceiveDocConfirmation> ReceiveDocConfirmations2 { get; set; }
        public virtual ICollection<ReceiveDocConfirmation> ReceiveDocConfirmations3 { get; set; }
        public virtual ICollection<ReceiveDocConfirmation> ReceiveDocConfirmations4 { get; set; }
        public virtual ICollection<ReceiveDocConfirmation> ReceiveDocConfirmations5 { get; set; }
        public virtual ICollection<ReceiveDocDeleted> ReceiveDocDeleteds { get; set; }
        public virtual ICollection<STVLog> STVLogs { get; set; }
        public virtual ICollection<STVLog> STVLogs1 { get; set; }
        public virtual ICollection<STVLog> STVLogs2 { get; set; }
        public virtual UserType UserType1 { get; set; }
        public virtual ICollection<UserPaymentType> UserPaymentTypes { get; set; }
        public virtual ICollection<UserPhysicalStore> UserPhysicalStores { get; set; }
        public virtual ICollection<UserStore> UserStores { get; set; }
    }
}
