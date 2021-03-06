
// Generated by MyGeneration Version # (1.3.0.9)

using System;
using System.Collections.Generic;

namespace Proxy
{
	public class ItemSupplyCategory 
	{
	
	#region Properties
	
		private  int? _ID;
		public  int? ID
	    {
			get
	        {
				return _ID;
			}
			set
	        {
				_ID = value;
			}
		}

		private  int? _ItemID;
		public  int? ItemID
	    {
			get
	        {
				return _ItemID;
			}
			set
	        {
				_ItemID = value;
			}
		}

		private  int? _CategoryID;
		public  int? CategoryID
	    {
			get
	        {
				return _CategoryID;
			}
			set
	        {
				_CategoryID = value;
			}
		}

		private  bool? _IsDeleted;
		public  bool? IsDeleted
	    {
			get
	        {
				return _IsDeleted;
			}
			set
	        {
				_IsDeleted = value;
			}
		}

		private  DateTime? _UpdateTime;
		public  DateTime? UpdateTime
	    {
			get
	        {
				return _UpdateTime;
			}
			set
	        {
				_UpdateTime = value;
			}
		}


	#endregion
	
	#region Web Service Getters
		
		public static List<ItemSupplyCategory> GetAll()
        {
            BLL.ItemSupplyCategory v = new BLL.ItemSupplyCategory();
            v.LoadAll();
			return ToList(v);
        }
		
	#endregion
	
	
	
	#region Utilities
	
		public static List<ItemSupplyCategory> ToList(BLL.ItemSupplyCategory v){
			List<ItemSupplyCategory> list = new List<ItemSupplyCategory>();
            while (!v.EOF)
            {
                ItemSupplyCategory t = new ItemSupplyCategory();
              if(!v.IsColumnNull("ID"))
				    t.ID = v.ID;
              if(!v.IsColumnNull("ItemID"))
				    t.ItemID = v.ItemID;
              if(!v.IsColumnNull("CategoryID"))
				    t.CategoryID = v.CategoryID;
              

				list.Add(t);
                v.MoveNext();
            }
            return list;
		}
	
		#endregion
		
		
		#region Web service Saving

        public static void SaveList(List<HCMIS.Desktop.DirectoryServices.ItemSupplyCategory> list)
        {
            BLL.ItemSupplyCategory bv = new BLL.ItemSupplyCategory();
            foreach (HCMIS.Desktop.DirectoryServices.ItemSupplyCategory v in list)
            {
                // try to load by primary key
                bv.LoadByPrimaryKey(v.ID.Value);

                // if the entry doesn't exist, create it
                if (bv.RowCount == 0)
                {
                    bv.AddNew();
                }
                // populate the contents of v on the to the database list
              if( v.ID.HasValue )
				   bv.ID = v.ID.Value;
              if( v.ItemID.HasValue )
				   bv.ItemID = v.ItemID.Value;
              if( v.CategoryID.HasValue )
				   bv.CategoryID = v.CategoryID.Value;
              
                bv.Save();
            }


        }
	
	public static void DeleteList(List<int> list)
        {
            BLL.ItemSupplyCategory bv = new BLL.ItemSupplyCategory();
            foreach (int v in list)
            {
                // try to load by primary key
                bv.LoadByPrimaryKey(v);
                // if the entry doesn't exist, create it
                if (bv.RowCount > 0)
                {
                    bv.MarkAsDeleted();
					bv.Save();
                }
                // populate the contents of v on the to the database list

            }


        }
	
	
	#endregion
	}
}
