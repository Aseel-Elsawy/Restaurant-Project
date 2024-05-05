using ElmasryCsharp.classes;
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
    public partial class store : Form
    {
        public store()
        {
            InitializeComponent();
            bindcomboitems();
            bindcombovendors();
            bindcombounits();
         
            
        }
        #region bindcombo
        void bindcomboitems()
        {DataTable dt = new DataTable();
            dt= RetrieveData.executequery("sp_store_selectall", CommandType.StoredProcedure);
           
            searchcombo.DisplayMember = "item_name";
            searchcombo.ValueMember = "item_id"; 
            searchcombo.DataSource = dt;
            searchcombo.Text = "";
        }
        void bindcombovendors()
        {
            vendorcombo.DataSource = RetrieveData.executequery("sp_vendor_selectall", CommandType.StoredProcedure);
            vendorcombo.DisplayMember = "vendor_name";
            vendorcombo.ValueMember = "vendor_id";
            vendorcombo.Text = "";
        }
        void bindcombounits()
        {
            DataTable dt = new DataTable();
            dt = units.showall();
            itmunitxt.ValueMember = "ID";
            itmunitxt.DisplayMember = "Unit Type";
            itmunitxt.DataSource = dt;
        }
       
      
        #endregion
        private void savebtn_Click(object sender, EventArgs e)
        {
            #region save
            if (MessageBox.Show("هل تريد حفظ الصنف؟", "المخازن", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                validation.suretxt(this, groupBox1);
                int z = 0;
                if (z == validation.i)
                {
                    RetrieveData.executeNonquery("sp_store_insert", CommandType.StoredProcedure,
                    new RetrieveData.parameter("@item_name", SqlDbType.NVarChar, itmname.Text),
                    new RetrieveData.parameter("@price", SqlDbType.Decimal, int.Parse(pricetxt.Text)),
                      new RetrieveData.parameter("@quantity", SqlDbType.Int, int.Parse(quantitytxt.Text)),
                    new RetrieveData.parameter("@total", SqlDbType.Decimal, int.Parse(totaltxt.Text)),
                    new RetrieveData.parameter("@date", SqlDbType.Date, DateTime.Parse(datetxt.Text)),
                    new RetrieveData.parameter("@vendor_id", SqlDbType.Int, int.Parse(vendorcombo.SelectedValue.ToString())),
                      new RetrieveData.parameter("@unit_id", SqlDbType.Int, int.Parse(itmunitxt.SelectedValue.ToString())));
                MessageBox.Show("تم الحفظ", "المخازن");
                validation.txtclear(this, groupBox1);
                bindcomboitems();
            }
            }

            #endregion
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            #region update
            if (MessageBox.Show("هل تريد تعديل الصنف؟", "المخازن", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                validation.suretxt(this, groupBox1);
                int z = 0;
                if (z == validation.i)
                {
                    RetrieveData.executeNonquery("sp_store_update", CommandType.StoredProcedure,
                      new RetrieveData.parameter("@item_id", SqlDbType.Int, int.Parse(labelid.Text)),
                    new RetrieveData.parameter("@item_name", SqlDbType.NVarChar, itmname.Text),
                    new RetrieveData.parameter("@price", SqlDbType.Decimal, decimal.Parse(pricetxt.Text)),
                      new RetrieveData.parameter("@quantity", SqlDbType.Int, int.Parse(quantitytxt.Text)),
                    new RetrieveData.parameter("@total", SqlDbType.Decimal, decimal.Parse(totaltxt.Text)),
                    new RetrieveData.parameter("@date", SqlDbType.Date, DateTime.Parse(datetxt.Text)),
                    new RetrieveData.parameter("@vendor_id", SqlDbType.Int, int.Parse(vendorcombo.SelectedValue.ToString())),
                      new RetrieveData.parameter("@unit_id", SqlDbType.Int, int.Parse(itmunitxt.SelectedValue.ToString())));
                    MessageBox.Show("تم التعديل", "المخازن");
                    validation.txtclear(this, groupBox1);
                    bindcomboitems();
                }
            }

            #endregion
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            #region delete
            if (MessageBox.Show("هل تريد حذف الصنف؟", "المخازن", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RetrieveData.executeNonquery("sp_store_delete", CommandType.StoredProcedure,
                      new RetrieveData.parameter("@item_id", SqlDbType.Int, int.Parse(labelid.Text)));
                MessageBox.Show("تم الحذف", "المخازن");
                bindcomboitems();
                validation.txtclear(this, groupBox1);
                labelid.Text = "0";
            }

            #endregion
        }

        private void store_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region search
            labelid.Text =searchcombo.SelectedValue.ToString();
            if (labelid.Text != "0")
            {
                DataTable dt = new DataTable();
                dt = RetrieveData.executequery("sp_store_selectbyid", CommandType.StoredProcedure,
                        new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(labelid.Text)));

                itmname.Text = dt.Rows[0][1].ToString();
                quantitytxt.Text = dt.Rows[0][2].ToString();
                pricetxt.Text = dt.Rows[0][3].ToString();
                totaltxt.Text = dt.Rows[0][4].ToString();
                datetxt.Text = dt.Rows[0][5].ToString();
                vendorcombo.SelectedValue = dt.Rows[0][6].ToString();
                itmunitxt.SelectedValue = dt.Rows[0][8].ToString();


            }

            #endregion
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            validation.txtclear(this, groupBox1);
        }
    }
}
