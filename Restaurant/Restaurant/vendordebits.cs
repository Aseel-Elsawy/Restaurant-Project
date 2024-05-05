using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElmasryCsharp
{
    public partial class vendordebits : Form
    {
        public vendordebits()
        {
            InitializeComponent();
            dateTimePicker2.Value = DateTime.Now;
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
        private void newbtn_Click(object sender, EventArgs e)
        {
            validation.txtclear(this, groupBox3);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            #region save
            if (MessageBox.Show("هل تريد اضافة حساب مورد", "الموردين", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                validation.suretxt(this, groupBox3);
                int z = 0;
                if (z == validation.i)
                {
                    RetrieveData.executeNonquery("sp_vendors_debits_insert", CommandType.StoredProcedure,
                        new RetrieveData.parameter("@ven_id",SqlDbType.Int,int.Parse(labelid.Text)),
                        new RetrieveData.parameter("@payed_value", SqlDbType.Money, SqlMoney.Parse(payedtxt.Text)),
                     
                          new RetrieveData.parameter("@date", SqlDbType.Date, DateTime.Parse(dateTimePicker2.Text)));
                       
                 validation.txtclear(this, groupBox3);
                    MessageBox.Show("تم الحفظ", "الموردين");
                }
            }
                       
            #endregion
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
          
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
           
        }

        private void vendordebits_Load(object sender, EventArgs e)
        {

        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region search
            labelid.Text = searchcombo.SelectedValue.ToString();
            if (labelid.Text != "0")
            {

                DataTable dt = new DataTable();
                dt = RetrieveData.executequery("sp_vendor_selectbyid", CommandType.StoredProcedure,
                        new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(labelid.Text)));
                if (dt.Rows.Count > 0)
                {
                   
               
                    remaintxt.Text = dt.Rows[0][4].ToString();
                    
                }
                else
                {
                    
                    payedtxt.Text = "0";
                    remaintxt.Text = "0";
                  
                }


            }

            #endregion
        }
    }
}
