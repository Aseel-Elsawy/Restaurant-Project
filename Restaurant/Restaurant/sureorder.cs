using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ElmasryCsharp
{
    public partial class sureorder : Form
    {
        public sureorder()
        {
            InitializeComponent();
            bindcombodelivery();
        }
        #region
        void bindcombodelivery()
        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_employee_select_Deleivery", CommandType.StoredProcedure);
            deliverynametxt.ValueMember = "emp_id";
            deliverynametxt.DisplayMember = "emp_name";
            deliverynametxt.DataSource = dt;
            deliverynametxt.Text = "";
        }
        #endregion
        private void savebtn_Click(object sender, EventArgs e)
        {
            #region
            validation.suretxt(this, groupBox3);
            int z = 0;
            if (z == validation.i)
            {
                RetrieveData.executeNonquery("sp_delivery_insert", CommandType.StoredProcedure,
                new RetrieveData.parameter("@receipt_id", SqlDbType.Int, int.Parse(label2.Text)),
                  new RetrieveData.parameter("@delivery_name", SqlDbType.NVarChar, deliverynametxt.Text),
                  new RetrieveData.parameter("@delivery_phone", SqlDbType.NVarChar, deliveryphonetxt.Text),
             new RetrieveData.parameter("@client_phone", SqlDbType.NVarChar, label3.Text),
             new RetrieveData.parameter("@client_address", SqlDbType.NVarChar, label4.Text),
                 new RetrieveData.parameter("@client_name", SqlDbType.NVarChar, clientnametxt.Text));
                MessageBox.Show("تم حفظ البيانات","الدليفري");
                validation.txtclear(this, groupBox2);
                validation.txtclear(this, groupBox3);
            }
            #endregion
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void addresstxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void sureorder_Load(object sender, EventArgs e)
        {

        }
    }
}
