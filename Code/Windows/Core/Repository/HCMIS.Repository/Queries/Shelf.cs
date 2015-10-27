using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HCMIS.Repository.Queries
{
    public class Shelf
    {
        public static string SelectGetShelves()
        {
            string query = String.Format("SELECT * FROM vwGetShelfStore");
            return query;
        }


        public static string DeleteSavePalletLocationsInShelf(int rows, int id)
        {
            string query = String.Format("delete from PalletLocation where ShelfID = {0} and [Row] >= {1}", id, rows);
            return query;
        }

        public static string DeleteShelfRowColumnSavePalletLocationsInShelf(int rows, int id)
        {
            string query = String.Format("delete from ShelfRowColumn where ShelfID = {0} and [Index] >= {1} and Type = 'Row'", id, rows);
            return query;
        }

        public static string DeletePalletLocationSavePalletLocationsInShelf(int cols, int id)
        {
            string query = String.Format("delete from PalletLocation where ShelfID = {0} and [Column] >= {1}", id, cols);
            return query;
        }

        public static string DeleteFromShelfRowColumnSavePalletLocationsInShelf(int cols, int id)
        {
            string query = String.Format("delete from ShelfRowColumn where ShelfID = {0} and [Index] >= {1} and Type = 'Column'", id, cols);
            return query;
        }

        public static string SelectSavePalletLocationsInShelf(int id)
        {
            string query = String.Format("Select * from PalletLocation where ShelfID = {0}", id);
            return query;
        }

     

        public static string SelectSaveDimentions(double width, int id)
        {
            string query = String.Format("Update PalletLocation set Width = {1} where ShelfID = {0}", id, width);
            return query;
        }

        public static string UpdateFixHeightOfPalletLocations(int id, double palletHeight)
        {
            string query = String.Format("update ShelfRowColumn set Dimension = {1} where ShelfID = {0} and Type = 'Row'", id, palletHeight);
            return query;
        }

        public static string UpdateUpdatePalletLocationFixHeightOfPalletLocations(int id, double palletHeight)
        {
            string query = String.Format("update PalletLocation set Height = {1} where ShelfID = {0}", id, palletHeight);
            return query;
        }

        public static string UpdatePalletLocationFixLengthOfPalletLocations(int id, double palletLength)
        {
            string query = String.Format("update PalletLocation set Length = {1} where ShelfID = {0}", id, palletLength);
            return query;
        }

        public static string UpdateShelfRowColumnFixLengthOfPalletLocations(int id, double palletLength)
        {
            string query = String.Format("update ShelfRowColumn set Dimension = {1} where ShelfID = {0} and Type = 'Column'", id, palletLength);
            return query;
        }

        public static string SelectLoadShelvesByStorageType(string StorageType,int storeID=0)
        {
            string query = String.Format(@" select   s.ID,
											 s.StoreID,
											 s.ShelfCode,
											 s.ShelfType,
											 s.[Rows],
											 s.[Columns],
											 s.CoordinateX,
											 s.CoordinateY,
											 s.Rotation,
											 s.[Length],
											 s.Width,
											 s.Height,
											 s.ShelfStorageType,
	                                         (st.Prefix + ' - ' + s.ShelfCode) as SName,
	                                         (st.Prefix + ' - ' + s.ShelfCode) as ShelfLabel  
                                        from Shelf s 
	                                         join PalletLocation pl on s.ID = pl.ShelfID
                                             join StorageType st on pl.StorageTypeID = st.ID 
                                            where pl.StorageTypeID = {0} {1}
                                            group by  s.ID,
													 s.StoreID,
													 s.ShelfCode,
													 s.ShelfType,
													 s.[Rows],
													 s.[Columns],
													 s.CoordinateX,
													 s.CoordinateY,
													 s.Rotation,
													 s.[Length],
													 s.Width,
													 s.Height,
													 s.ShelfStorageType,
                                                   (st.Prefix + ' - ' + s.ShelfCode),(st.Prefix + ' - ' + s.ShelfCode), s.ID,s.storeID,s.ShelfCode                                                                                         
													                                   
                                                ", StorageType, storeID == 0 ? "" : string.Format("and S.storeID = {0}", storeID));
            return query;
        }

        public static string SelectLoadForMergedView()
        {
            string query = String.Format("select *,pl.ID PalletLocationID, pl.Label PalletLocationLabel, pl.StorageTypeID STI , sr.Label RowLabel, sc.Label ColumnLabel from Shelf s join PalletLocation pl on s.ID = pl.ShelfID join ShelfRowColumn sr on sr.ShelfID = pl.ShelfID and sr.[Index] = pl.Row and sr.Type= 'Row' join ShelfRowColumn sc on sc.ShelfID = pl.ShelfID and sc.[Index] = pl.[Column] and sc.Type = 'Column' order by pl.ShelfID,  pl.[Column],pl.[Row]");
            return query;
        }

        public static string SelectLoadForMergedView(string storageType)
        {
            string query = String.Format("select *, pl.ID PalletLocationID, pl.Label PalletLocationLabel, pl.StorageTypeID STI , sr.Label RowLabel, sc.Label ColumnLabel from Shelf s join PalletLocation pl on s.ID = pl.ShelfID join ShelfRowColumn sr on sr.ShelfID = pl.ShelfID and sr.[Index] = pl.Row and sr.Type= 'Row' join ShelfRowColumn sc on sc.ShelfID = pl.ShelfID and sc.[Index] = pl.[Column] and sc.Type = 'Column' where s.ShelfStorageType = {0} order by pl.ShelfID, pl.[Column], pl.[Row]", storageType);
            return query;
        }

        public static string SelectLoadForMergedViewByShelfID(int shelfID)
        {
            string query = String.Format("select *, pl.ID PalletLocationID, pl.Label PalletLocationLabel, pl.StorageTypeID STI , sr.Label RowLabel, sc.Label ColumnLabel from Shelf s join PalletLocation pl on s.ID = pl.ShelfID join ShelfRowColumn sr on sr.ShelfID = pl.ShelfID and sr.[Index] = pl.Row and sr.Type= 'Row' join ShelfRowColumn sc on sc.ShelfID = pl.ShelfID and sc.[Index] = pl.[Column] and sc.Type = 'Column' where s.ID = {0} order by pl.ShelfID,  pl.[Column], pl.[Row]", shelfID);
            return query;
        }

        public static string SelectLoadAllShelves()
        {
            string query = "select *, ps.Name + ' ' + st.Prefix + ' ' + s.ShelfCode as ShelfLabel  from Shelf s join StorageType st on s.ShelfStorageType = st.ID join PhysicalStore ps on ps.ID = s.StoreID";
            return query;
        }

        public static string SelectLoadAllShelves(int storeID)
        {
            string query = String.Format("select *, ps.Name + ' ' + st.Prefix + ' ' + s.ShelfCode as ShelfLabel  from Shelf s join StorageType st on s.ShelfStorageType = st.ID join PhysicalStore ps on ps.ID = s.StoreID where StoreID = {0}", storeID);
            return query;
        }

        public static string SelectGetUtilization(int storageTypeID)
        {
            string query = String.Format("select ( ps.Name + ' ' + st.Prefix + ' '+ s.ShelfCode ) as ShelfLabel, s.ID , Value = 0.0  from Shelf s join StorageType st on s.ShelfStorageType = st.ID join PhysicalStore ps on ps.ID = s.StoreID where s.ShelfStorageType = {0}", storageTypeID);
            return query;
        }

        public static string SelectGetItemsOnShelf(int selectedRackID)
        {
            string query = String.Format("select distinct vw.ID, vw.FullItemName from PalletLocation pl join ReceivePallet rp on pl.PalletID = rp.PalletID join ReceiveDoc rd on rp.ReceiveID = rd.ID join vwGetAllItems vw on rd.ItemID = vw.ID where pl.ShelfID = {0} order by vw.FullItemName", selectedRackID);
            return query;
        }
    }
}
