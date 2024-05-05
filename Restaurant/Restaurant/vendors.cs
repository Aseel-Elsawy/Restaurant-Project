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
    public partial class vendors : Form
    {
        public vendors()
        {
            InitializeComponent();
            bindcombo();
        }
        #region bindcombo
        void bindcombo()
        {
            DataTable dt = new DataTable();
            dt=RetrieveData.executequery("sp_vendor_selectall", CommandType.StoredProcedure);
          
            searchcombo.DisplayMember = "vendor_name";
            searchcombo.ValueMember = "vendor_id";
            searchcombo.DataSource = dt;
            searchcombo.Text = "";
        }
        #endregion
        private void vendors_Load(object sender, EventArgs e)
        {
          
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            #region save
            validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == validation.i)
            {
                if (MessageBox.Show("هل تريد حفظ المورد؟", "الموردين", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RetrieveData.executeNonquery("sp_vendors_insert", CommandType.StoredProcedure,
                        new RetrieveData.parameter("@ven_name", SqlDbType.NVarChar, vendortxt.Text),
                        new RetrieveData.parameter("@phone", SqlDbType.NVarChar, phonetxt.Text));
                    MessageBox.Show("تم الحفظ", "الموردين");
                    bindcombo();
                    validation.txtclear(this, groupBox1);
                }
            }

            #endregion
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            #region update
            validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == validation.i)
            {
                if (MessageBox.Show("هل تريد تعديل المورد؟", "الموردين", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RetrieveData.executeNonquery("sp_vendors_update", CommandType.StoredProcedure,
                         new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(labelid.Text)),
                        new RetrieveData.parameter("@ven_name", SqlDbType.NVarChar, vendortxt.Text),
                        new RetrieveData.parameter("@phone", SqlDbType.NVarChar, phonetxt.Text));
                    MessageBox.Show("تم التعديل", "الموردين");
                    bindcombo();
                    validation.txtclear(this, groupBox1);
                }
            }

            #endregion
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            #region delete
            if (MessageBox.Show("هل تريد حذف المورد؟", "الموردين", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RetrieveData.executeNonquery("sp_vendors_delete", CommandType.StoredProcedure,
                     new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(searchcombo.SelectedValue.ToString())));
                MessageBox.Show("تم الحذف", "الموردين");
                bindcombo();
                labelid.Text = "0";
                validation.txtclear(this, groupBox1);
            }

            #endregion
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
           
        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region search
           labelid.Text=searchcombo.SelectedValue.ToString();
            if (labelid.Text != "0")
            {
                
                DataTable dt = new DataTable();
                dt = RetrieveData.executequery("sp_vendor_selectbyid", CommandType.StoredProcedure,
                        new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(labelid.Text)));
              
                vendortxt.Text = dt.Rows[0][1].ToString();
                phonetxt.Text = dt.Rows[0][2].ToString();

            }

            #endregion
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            validation.txtclear(this, groupBox1);
        }
    }
}
