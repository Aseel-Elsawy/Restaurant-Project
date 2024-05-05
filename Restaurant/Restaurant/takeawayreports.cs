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
    public partial class takeawayreports : Form
    {
        public takeawayreports()
        {
            InitializeComponent();
            bindgrid();
            bindcombo();
        }
        #region bind grid
        void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_reports_takeaway", CommandType.StoredProcedure);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][9].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][7].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][6].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][1].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][3].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][4].ToString();

            }
        }
        #endregion
        #region bindcombo
        void bindcombo()
        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_item_selectall", CommandType.StoredProcedure);
            searchcombo.DisplayMember = "item_name";
            searchcombo.ValueMember = "item_id";
            searchcombo.DataSource = dt;
            searchcombo.Text = "";
        }
        #endregion
        private void takeawayreports_Load(object sender, EventArgs e)
        {

        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region search
            try
            {

                labelid.Text = searchcombo.SelectedValue.ToString();
                if (labelid.Text != "0")
                {

                    DataTable dt = new DataTable();
                    dt = RetrieveData.executequery("sp_reports_takeaway_byitem_id", CommandType.StoredProcedure,
                            new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(labelid.Text)));


                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][9].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][7].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][6].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][3].ToString();
                        dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][4].ToString();



                    }
                }
            }
            catch { }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindgrid();
        }
    }
}
