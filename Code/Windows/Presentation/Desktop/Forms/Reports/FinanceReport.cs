using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using HCMIS.Desktop.ViewHelpers;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;

namespace HCMIS.Desktop.Forms.Reports
{
    public partial class FinanceReport : DevExpress.XtraEditors.XtraForm
    {
        PO Order = new PO();
        ReceiptInvoice Voucher = new ReceiptInvoice();
       BLL.Receipt GRV = new BLL.Receipt();
        DataSet dataSet;
        public FinanceReport()
        {
            InitializeComponent();
        }

        private void FinanceReport_Load(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.LoadAll();
            lkSupplier.Properties.DataSource = supplier.DefaultView;

            lkAccount.SetupActivityEditor().SetDefaultActivity();
            LoadStatusGrid();
        }
        private void LoadStatusGrid()
        {
            //To be changed to InvoiceID

            //Add Master and detail to dataset
            //Create and add Master Table (Bind Data)
            dataSet = new DataSet();

            Order.LoadAll();
            DataTable dvOrder = Order.GetDataTable();
            dvOrder.TableName = "Order";
            dataSet.Tables.Add(dvOrder);

            //Create and add Detail Table to dataset
            Voucher.LoadAll();
            DataTable dvVoucher = Voucher.GetDataTable();
            dvVoucher.TableName = "Voucher";
            dataSet.Tables.Add(dvVoucher);

            GRV.LoadAll();
            DataTable dvGRV = GRV.GetDataTable();
            dvGRV.TableName = "GRV";
            dataSet.Tables.Add(dvGRV);


            //Get List Of Column to relate
            DataColumn keyColumn1 = dataSet.Tables[dvOrder.TableName].Columns["ID"] ;
            DataColumn foreignKeyColumn1 = dataSet.Tables[dvVoucher.TableName].Columns["POID"];
            DataColumn keyColumn2 = dataSet.Tables[dvVoucher.TableName].Columns["ID"];
            DataColumn foreignKeyColumn2  = dataSet.Tables[dvGRV.TableName].Columns["ReceiptInvoiceID"];


            //Create Master-detail relation (Bind Tables)
            dataSet.Relations.Add("OrderVoucher", keyColumn1, foreignKeyColumn1);
            dataSet.Relations.Add("VoucherGRV", keyColumn2 , foreignKeyColumn2 );

            //Bind to Grid:Tables and Relation
            gridMain.LevelTree.Nodes.Add("OrderVoucher", gridVoucherView);
            gridMain.LevelTree.Nodes.Add("VoucherGRV",gridGRVView);
            gridMain.DataSource = dataSet.Tables[dvOrder.TableName];

        }

    }
}