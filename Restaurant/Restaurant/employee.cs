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
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
           
            bindcombo();
        }
        #region bindcombo
        void bindcombo() {
            DataTable dt = new DataTable(); 
            dt=RetrieveData.executequery("sp_emp_selectall", CommandType.StoredProcedure);
           
            searchcombo.DisplayMember = "emp_name";
            searchcombo.ValueMember = "emp_id";
            searchcombo.DataSource = dt;
           searchcombo.Text = "";
        }
        #endregion
        private void savebtn_Click(object sender, EventArgs e)
        {
            #region save
            if (MessageBox.Show("هل تريد حفظ موظف؟", "الموظفين", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                validation.suretxt(this, groupBox3);
                int z = 0;
                if (z == validation.i)
                {
                    RetrieveData.executeNonquery("sp_emp_insert", CommandType.StoredProcedure,
                    new RetrieveData.parameter("@emp_name", SqlDbType.NVarChar, nametxt.Text),
                    new RetrieveData.parameter("@salary", SqlDbType.Int, int.Parse(salarytxt.Text)),
                    new RetrieveData.parameter("@phone", SqlDbType.NVarChar, phonetxt.Text),
                    new RetrieveData.parameter("@work", SqlDbType.NVarChar, worktxt.Text));
                    MessageBox.Show("تم الحفظ", "الموظفين");
                    validation.txtclear(this, groupBox3);
                    bindcombo();
                }
            }
          
            #endregion
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            #region update
            if (MessageBox.Show("هل تريد تعديل بيانات موظف", "الموظفين", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                validation.suretxt(this, groupBox3);
                int z = 0;
                if (z == validation.i)
                {
                    if (labelid.Text != "0")
                    {
                        RetrieveData.executeNonquery("sp_emp_update", CommandType.StoredProcedure,
                            new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(labelid.Text)),
                            new RetrieveData.parameter("@emp_name", SqlDbType.NVarChar, nametxt.Text),
                            new RetrieveData.parameter("@salary", SqlDbType.Int, int.Parse(salarytxt.Text)),
                            new RetrieveData.parameter("@phone", SqlDbType.NVarChar, phonetxt.Text),
                            new RetrieveData.parameter("@work", SqlDbType.NVarChar, worktxt.Text));
                        MessageBox.Show("تم التعديل", "الموظفين");
                        validation.txtclear(this, groupBox3);
                        bindcombo();
                    }
                }
            }
          
            #endregion
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            #region delete
            if (labelid.Text != "0")
            {
                if (MessageBox.Show("هل تريد حذف موظف", "الموظفين", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RetrieveData.executeNonquery("sp_emp_update", CommandType.StoredProcedure,
                        new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(searchcombo.SelectedValue.ToString())));
 MessageBox.Show("تم الحذف", "الموظفين");
                    bindcombo();
                    labelid.Text = "0";
                    validation.txtclear(this, groupBox3);
                }
            }
           
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void employee_Load(object sender, EventArgs e)
        {
        
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            validation.txtclear(this, groupBox3);
        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void searchcombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            #region search
            labelid.Text = searchcombo.SelectedValue.ToString();
            if (labelid.Text != "0")
            {
                DataTable dt = new DataTable();
                dt = RetrieveData.executequery("sp_emp_selectbyid", CommandType.StoredProcedure,
                        new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(labelid.Text)));

                nametxt.Text = dt.Rows[0][1].ToString();
                salarytxt.Text = dt.Rows[0][2].ToString();
                phonetxt.Text = dt.Rows[0][3].ToString();
                worktxt.Text = dt.Rows[0][4].ToString();
            }

            #endregion
        }

        private void salarytxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
