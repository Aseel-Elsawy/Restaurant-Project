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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ElmasryCsharp
{
    public partial class Units : Form
    {
        public Units()
        {
            InitializeComponent();
            bindcomboitems();
        }
        #region bind combo
        void bindcomboitems()
        {
            DataTable dt = new DataTable();
            dt = units.showall();
           searchcombo.ValueMember = "ID";
            searchcombo.DisplayMember = "Unit Type";
            searchcombo.DataSource = dt;
        }
        #endregion
        private void savebtn_Click(object sender, EventArgs e)
        {
            #region save
            try
            {
                validation.suretxt(this, groupBox1);
                int z = 0;
                if (z == validation.i)
                {

                    units.save(typetxt.Text);
                    MessageBox.Show("تم الحفظ", "الوحدات");
                    bindcomboitems();
                    validation.txtclear(this, groupBox1);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error"); }
            #endregion
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            #region update
            try
            {
                validation.suretxt(this, groupBox1);
                int z = 0;
                if (z == validation.i)
                {

                    units.update(int.Parse(labelid.Text), typetxt.Text);
                    MessageBox.Show("تم التعديل", "الوحدات");
                    bindcomboitems();
                    validation.txtclear(this, groupBox1);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error"); }
            #endregion
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            #region delete
            try
            {

                units.delete(int.Parse(labelid.Text));
                MessageBox.Show("تم الحذف", "الوحدات");
                validation.txtclear(this, groupBox1);
                bindcomboitems();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error"); }
            #endregion
        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region search
            labelid.Text = searchcombo.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = units.showby(int.Parse(labelid.Text));
            typetxt.Text = dt.Rows[0][1].ToString();
            #endregion
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            validation.txtclear(this, groupBox1);
        }

        private void Units_Load(object sender, EventArgs e)
        {

        }
    }
}
