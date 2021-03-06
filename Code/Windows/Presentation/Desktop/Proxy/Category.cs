
// Generated by MyGeneration Version # (1.3.0.9)

using System.Collections.Generic;

namespace Proxy
{
	public class Category 
	{
	
    //#region Web Service Getters
		
    //    public static List<Proxy.Category> GetAll()
    //    {
    //        BLL.Category v = new BLL.Category();
    //        v.LoadAll();
    //        return ToList(v);
    //    }
		
    //    public static List<Proxy.Category> GetUpdatesAfter(int LastVersion)
    //    {
    //        BLL.Category v = new BLL.Category();
    //        v.LoadUpdatesAfter( LastVersion );
    //        return ToList(v);
    //    }
		
    //#endregion
	
	
	
	#region Utilities
	
		public static List<Proxy.DrugCategory> ToList(BLL.Category v){
			List<Proxy.DrugCategory> list = new List<Proxy.DrugCategory>();
            while (!v.EOF)
            {
                Proxy.DrugCategory t = new Proxy.DrugCategory();
              if(!v.IsColumnNull("ID"))
				     t.ID = v.ID;
              if(!v.IsColumnNull("CategoryName"))
				     t.CategoryName = v.CategoryName;
              if(!v.IsColumnNull("CategoryCode"))
				     t.CategoryCode = v.CategoryCode;
              if(!v.IsColumnNull("Description"))
				     t.Description = v.Description;

				list.Add(t);
                v.MoveNext();
            }
            return list;
		}
	
		#endregion
		
		
		#region Web service Saving
	
		public static void SaveList(List<Proxy.DrugCategory> list)
        {
            BLL.Category bv = new BLL.Category();
            foreach (Proxy.DrugCategory v in list)
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
              if( v.CategoryName != "" && v.CategoryName != null )
				   bv.CategoryName = v.CategoryName;
              if( v.CategoryCode != "" && v.CategoryCode != null )
				   bv.CategoryCode = v.CategoryCode;
              if( v.Description != "" && v.Description != null )
				   bv.Description = v.Description;

                bv.Save();
            }


        }
	
	#endregion
	}
}
