using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElmasryCsharp
{
    public partial class vendordebitsreport : Form
    {
        public vendordebitsreport()
        {
            InitializeComponent();
            bindcombo();
        }
        #region bindcombo
        void bindcombo()
        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_vendor_selectall", CommandType.StoredProcedure);

            searchcombo.DisplayMember = "vendor_name";
            searchcombo.ValueMember = "vendor_id";
            searchcombo.DataSource = dt;
            searchcombo.Text = "";
        }
        #endregion
        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region search
            try
            {

                labelid.Text = searchcombo.SelectedValue.ToString();
                if (labelid.Text != "0")
                {

                    DataTable dt = new DataTable();
                    dt = RetrieveData.executequery("sp_vendor_debits_report", CommandType.StoredProcedure,
                            new RetrieveData.parameter("@ven_id", SqlDbType.Int, int.Parse(labelid.Text)));


                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][2].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][5].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][6].ToString();
                      


                    }
                }
            }
            catch { }
            #endregion
        }
    }
}
