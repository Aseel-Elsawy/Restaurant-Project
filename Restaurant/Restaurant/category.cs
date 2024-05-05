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
    public partial class category : Form
    {
        public category()
        {
            InitializeComponent();
            bindcomboitems();
        }
        #region bind combo
        void bindcomboitems()
        {
            DataTable dt = new DataTable();
            dt = Categories.showall();
            searchcombo.ValueMember = "id";
            searchcombo.DisplayMember = "category_name";
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

                    Categories.save(typetxt.Text);
                    MessageBox.Show("تم الحفظ", "الفئات");
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

                    Categories.update(int.Parse(labelid.Text), typetxt.Text);
                    MessageBox.Show("تم التعديل", "الفئات");
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
                if (labelid.Text != "0")
                {
                    Categories.delete(int.Parse(labelid.Text));
                    MessageBox.Show(" تم الحذف", "الفئات");
                    bindcomboitems();
                    validation.txtclear(this, groupBox1);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error"); }
            #endregion
        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            #region search
            validation.suretxt(this, groupBox2);
            int z = 0;
            if (z == validation.i)
            {
                labelid.Text = searchcombo.SelectedValue.ToString();
                DataTable dt = new DataTable();
                dt = Categories.showbyid(int.Parse(labelid.Text));
                typetxt.Text = dt.Rows[0][1].ToString();
            }
            #endregion
        }

        private void category_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            validation.txtclear(this, groupBox1);
        }
    }
}
