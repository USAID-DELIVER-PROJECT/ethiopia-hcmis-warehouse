using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-SR-SU-RP","Storage Reports","")]
    public partial class LocationReports : DevExpress.XtraEditors.XtraForm
    {
        public LocationReports()
        {
            InitializeComponent();
        }

        int selectedRackID = 0;

        private void LocationReports_Load(object sender, EventArgs e)
        {
            StorageType stt = new StorageType();
            stt.LoadAll();
            
            lkStorageType.Properties.DataSource = stt.DefaultView;
            lkStorageType2.Properties.DataSource = stt.DefaultView;

            lkStorageType.ItemIndex = 0;
            lkStorageType2.EditValue = 1;
        }

        private void lkStorageType_EditValueChanged(object sender, EventArgs e)
        {
            int storageTypeID = Convert.ToInt32(lkStorageType.EditValue);
            Shelf shlf = new Shelf();
            chartControl1.DataSource = shlf.GetUtilization(storageTypeID);
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            selectedRackID = Convert.ToInt32(lkRackID2.EditValue);
            //gridControl1.DataSource = null;
            //gridView1.Columns.Clear();

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            DataTable dtbl = PalletLocation.GetIDItemDataTableFor(selectedRackID, bw);

            gridView2.Columns.Clear();

            ShelfRowColumn src = new ShelfRowColumn();
            src.LoadColumnsForShelf(selectedRackID);
            while (!src.EOF)
            {
               GridColumn gc =  gridView2.Columns.Add();
               gc.FieldName = src.Index.ToString();
               gc.Caption = src.Label;
               gc.Visible = true;
               gc.ColumnEdit = repositoryItemButtonEdit1;
               src.MoveNext();
            }

            gridItemDetailByLocation.DataSource = dtbl;
           
            // bind 
            lkHighlightItems.Properties.DataSource = Shelf.GetItemsOnShelf( selectedRackID );

        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(e.RowHandle);

            int index = Convert.ToInt32(e.Column.Caption) - 1;

            string palletField = string.Format("Pallet{0}", index);
            if (dr[String.Format("Item{0}", index)] != DBNull.Value)
            {
                e.DisplayText = String.Format("{0}:{1}", dr["Pallet" + index], dr["Item" + index]);
            }
            else
            {
                e.DisplayText = dr[String.Format("Pallet{0}", index)].ToString();
            }
            if (radioHiglight.EditValue.ToString() == "Utilization")
            {

                Rectangle box = e.Bounds;
                if (dr.IsNull(String.Format("PercentageUsed{0}", index)))
                {
                    box.Width = 0;
                }
                else
                {
                    int width = Convert.ToInt32(Convert.ToDouble(box.Width) * Convert.ToDouble(dr[String.Format("PercentageUsed{0}", index)]) / 100);
                    if (width > box.Width)
                    {
                        width = box.Width;
                    }
                    box.Width = width;
                }
                if (box.Width > 0)
                {
                    Brush b = new SolidBrush(Color.FromArgb(51, 153, 255));
                    e.Graphics.FillRectangle(b, box);
                    box.X += box.Width;
                    box.Width = e.Bounds.Width - box.Width;
                    b = new SolidBrush(Color.FromArgb(173, 216, 239));
                    e.Graphics.FillRectangle(b, box);
                }
                else if (box.Width == 0 && dr[palletField] != DBNull.Value && Convert.ToInt32(dr[palletField]) > 0)
                {
                    // this is when we are not sure abou the volume of the items
                    Brush b = new SolidBrush(Color.FromArgb(173, 216, 239));
                    e.Graphics.FillRectangle(b, e.Bounds);
                }
            }
            else if (radioHiglight.EditValue.ToString() == "ExpiredItems")
            {
                if (!dr.IsNull(String.Format("ExpiryStatus{0}", index)))
                {
                    int expStatus = Convert.ToInt32(dr["ExpiryStatus"+index]);
                    if (expStatus == 0)
                    {
                        e.Graphics.FillRectangle(Brushes.SeaGreen, e.Bounds);
                    }
                    else if (expStatus == 1)
                    {
                        e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
                    }
                }
            }
            else if (radioHiglight.EditValue.ToString() == "Confirmation")
            {
                if (!dr.IsNull("Confirmed" + index))
                {
                    Boolean confirmed = Convert.ToBoolean(dr["Confirmed" + index]);

                    if (confirmed)
                    {
                        e.Graphics.FillRectangle(Brushes.DarkGray, e.Bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                    }
                }
            }
            else
            {
                int SelectedItemID = 0;
                if (lkHighlightItems.EditValue != null)
                {
                    SelectedItemID = Convert.ToInt32(lkHighlightItems.EditValue);
                }
                if (SelectedItemID != 0 && !dr.IsNull(String.Format("ItemID{0}", index)))
                {
                    int cellItemId = Convert.ToInt32(dr[String.Format("ItemID{0}", index)]);
                    if (cellItemId == SelectedItemID)
                    {
                        e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                    }
                }
            }
            e.Handled = false;
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                ShelfRowColumn srr = new ShelfRowColumn();
                srr.LoadRowForShelf(selectedRackID, (gridView2.DataRowCount - e.RowHandle)-1);
                if (srr.RowCount > 0)
                {
                    e.Info.DisplayText = srr.Label;
                }
            }
        }

        private void lkStorageType2_EditValueChanged(object sender, EventArgs e)
        {
            Shelf shlf = new Shelf();
            int storageType = Convert.ToInt32(lkStorageType2.EditValue);
            shlf.LoadShelvesByStorageType(storageType.ToString());
            lkRackID2.Properties.DataSource = shlf.DefaultView;
            if (shlf.RowCount > 0)
            {
                lkRackID2.EditValue = shlf.ID;
                //lookUpEdit1_EditValueChanged(new object(), new EventArgs());
            }
        }

       


        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            Pallet pallet = new Pallet();
            PalletLocation pl = new PalletLocation();
            if (gridView2.EditingValue != DBNull.Value)
            {
                pl.LoadByPrimaryKey(Convert.ToInt32(gridView2.EditingValue));
                if (!pl.IsColumnNull("PalletID"))
                {
                    pallet.GetAllItemsInPallet(pl.PalletID);
                    gridControl2.DataSource = pallet.DefaultView;
                    pallet.GetAllItemsInPalletSKUTotal(pl.PalletID);
                    Label l = new Label();
                    l.Dock = DockStyle.Bottom;
                    
                    XtraForm f = new XtraForm();
                    //gridControl2.Parent = null;
                    f.ShowInTaskbar = false;
                    f.Width = gridControl2.Width;
                    if (pallet.RowCount > 0 && !pallet.IsColumnNull("Total"))
                    {

                        l.Text = string.Format("Total SKU: {0}",pallet.GetColumn("Total").ToString());
                    }
                    else
                    {
                        l.Text = "Total SKU: 0";
                    }
                    l = new Label();
                    l.Dock = DockStyle.Top;
                    pallet.LoadByPrimaryKey(pl.PalletID);
                    if (!pallet.IsColumnNull("PalletNo"))
                    {
                        l.Text = String.Format("Pallet Number: {0}", pallet.PalletNo);
                        f.Controls.Add(l);
                    }
                    f.Controls.Add(gridControl2);
                    f.Controls.Add(l);
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
        }

        private void lookUpEdit1_EditValueChanged_1(object sender, EventArgs e)
        {
            gridItemDetailByLocation.Refresh();
        }

        private void radioHiglight_EditValueChanged(object sender, EventArgs e)
        {
            gridItemDetailByLocation.Refresh();
            if (radioHiglight.EditValue.ToString() == "Items")
            {
                lblHighlightItems.Visible = true;
                lkHighlightItems.Visible = true;
            }
            else
            {
                lblHighlightItems.Visible = false;
                lkHighlightItems.Visible = false;
            }
        }

        private void radioHiglight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (lkStorageType2.EditValue == null)
            {
                lkStorageType2.ItemIndex = 1;
            }
        }

        


      
    }
}