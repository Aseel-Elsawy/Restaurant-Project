using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmasryCsharp.classes
{
     class units
    {
        #region save
        public static void save( string unit_type)
        {
            RetrieveData.executeNonquery("sp_units_insert", CommandType.StoredProcedure,
               
                  new RetrieveData.parameter("@unit_type", SqlDbType.NVarChar, unit_type));

        }
        #endregion
        #region update
        public static void update(int id, string unit_type)
        {
            RetrieveData.executeNonquery("sp_units_update", CommandType.StoredProcedure,
                    new RetrieveData.parameter("@id", SqlDbType.Int, id),
               
                  new RetrieveData.parameter("@unit_type", SqlDbType.NVarChar, unit_type));

        }
        #endregion
        #region delete
        public static void delete(int id)
        {
            RetrieveData.executeNonquery("sp_units_delete", CommandType.StoredProcedure,
                    new RetrieveData.parameter("@id", SqlDbType.Int, id));
        }
        #endregion
        #region show all
        public static DataTable showall()
        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_units_selectall", CommandType.StoredProcedure);
            return dt;
        }
        #endregion
        #region show by
        public static DataTable showby(int id)
        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_units_selectbyid", CommandType.StoredProcedure, new RetrieveData.parameter("@id", SqlDbType.Int, id));
            return dt;

        }
        #endregion
    }
}
