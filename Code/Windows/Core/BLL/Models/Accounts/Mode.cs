using System.Data;
using DAL;


namespace BLL
{
	public class Mode : _Mode
	{
	
        public static class Constants
        {
            public static int HEALTH_PROGRAM;
            public static int RDF;
        }

        public void LoadByUser(int userID)
        {
            LoadFromRawSql(HCMIS.Repository.Queries.Mode.SelectByUserID(userID));
        }

        public static Mode SelectAllowedMode(int userId)
        {
            var storeType = new Mode();
            storeType.LoadFromRawSql(HCMIS.Repository.Queries.Mode.SelectModesForAUser(userId));
            return storeType;
        }
    }
}
