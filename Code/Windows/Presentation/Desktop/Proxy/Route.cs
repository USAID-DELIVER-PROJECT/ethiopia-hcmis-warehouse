
// Generated by MyGeneration Version # (1.3.0.9)

using System;
using System.Collections.Generic;

namespace Proxy
{
	public class Route 
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

		private  string _Name;
		public  string Name
	    {
			get
	        {
				return _Name;
			}
			set
	        {
				_Name = value;
			}
		}

		private  int? _HubID;
		public  int? HubID
	    {
			get
	        {
				return _HubID;
			}
			set
	        {
				_HubID = value;
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
		
		public static List<Route> GetAll()
        {
            BLL.Route v = new BLL.Route();
            v.LoadAll();
			return ToList(v);
        }
		
		public static List<Route> GetUpdatesAfter(long? lastVersion,DateTime? lastUpdateTime)
        {
            BLL.Route v = new BLL.Route();
            if(lastVersion.HasValue && lastVersion.Value != 0)
            {
                v.LoadUpdatesAfter( Convert.ToInt32(lastVersion.Value) );    
            }else if(lastUpdateTime.HasValue)
            {
               // v.LoadUpdatesAfterByTime(lastUpdateTime.Value);
            }else
            {
                v.LoadAll();
            }
			return ToList(v);
        }
		
        public static List<int> GetDeletedIDsAfter(long LastVersion)
        {
             BLL.Route v = new BLL.Route();
           // v.LoadDeletedIDs(LastVersion);
            List<int> list = new List<int>();
            while (!v.EOF)
            {
                list.Add((int)v.GetColumn("ID"));
                v.MoveNext();
            }
            return list;
        }
		
	#endregion
	
	
	
	#region Utilities
	
		public static List<Route> ToList(BLL.Route v){
			List<Route> list = new List<Route>();
            while (!v.EOF)
            {
                Route t = new Route();
              if(!v.IsColumnNull("ID"))
				    t.ID = v.RouteID;
              if(!v.IsColumnNull("Name"))
				    t.Name = v.Name;
              //if(!v.IsColumnNull("HubID"))
              //      t.HubID = v.HubID;
              //if(!v.IsColumnNull("IsDeleted"))
              //      t.IsDeleted = v.IsDeleted;
              //if(!v.IsColumnNull("UpdateTime"))
              //      t.UpdateTime = v.UpdateTime;

				list.Add(t);
                v.MoveNext();
            }
            return list;
		}
	
		#endregion
		
		
		#region Web service Saving
	
		public static void SaveList(List<Route> list)
        {
            BLL.Route bv = new BLL.Route();
            foreach (Route v in list)
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
				   bv.RouteID = v.ID.Value;
              if( v.Name != "" && v.Name != null )
				   bv.Name = v.Name;
              //if( v.HubID.HasValue )
              //     bv.HubID = v.HubID.Value;
              //if( v.IsDeleted.HasValue )
              //     bv.IsDeleted = v.IsDeleted.Value;
              //if( v.UpdateTime.HasValue )
              //     bv.UpdateTime = v.UpdateTime.Value;

                bv.Save();
            }


        }
	
	public static void DeleteList(List<int> list)
        {
            BLL.Route bv = new BLL.Route();
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