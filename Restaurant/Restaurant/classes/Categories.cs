using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmasryCsharp.classes
{
    class Categories
    {

        #region save
        public static void save(string category_name)
        {
            RetrieveData.executeNonquery("sp_category_insert", CommandType.StoredProcedure,
                new RetrieveData.parameter("@category_name", SqlDbType.NVarChar, category_name));

        }

        #endregion
        #region update
        public static void update(int id, string category_name)
        {
            RetrieveData.executeNonquery("sp_category_update", CommandType.StoredProcedure,
                 new RetrieveData.parameter("@id", SqlDbType.Int, id),
                new RetrieveData.parameter("@category_name", SqlDbType.NVarChar, category_name));

        }
        #endregion
        #region delete
        public static void delete(int id)
        {
            RetrieveData.executeNonquery("sp_category_delete", CommandType.StoredProcedure,
                 new RetrieveData.parameter("@id", SqlDbType.Int, id));
        }
        #endregion
        #region show all
        public static DataTable showall()
        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_category_selectall", CommandType.StoredProcedure);
            return dt;

        }
        #endregion
        #region show by id
        public static DataTable showbyid(int id)
        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_category_selectbyid", CommandType.StoredProcedure, new RetrieveData.parameter("@id", SqlDbType.Int, id));
            return dt;

        }
        #endregion
    }
}
