using ElmasryCsharp.classes;
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
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            bindcombo();
            bindcombocategory();
            bindcombostore();
            getid();
           
        }
        #region bindcombo
        void bindcombostore()
        {
            componentcombo.DataSource = RetrieveData.executequery("sp_store_selectall", CommandType.StoredProcedure);
            componentcombo.DisplayMember = "item_name";
            componentcombo.ValueMember = "item_id";
            componentcombo.Text = "";
        }
        void bindcombo()
        {
            DataTable dt = new DataTable();
           dt= RetrieveData.executequery("sp_item_selectall", CommandType.StoredProcedure);
            searchcombo.DisplayMember = "item_name";
            searchcombo.ValueMember = "item_id";
            searchcombo.DataSource = dt;
            searchcombo.Text = "";
        }
        void bindcombocategory()
        {
            DataTable dt = new DataTable();
            dt = Categories.showall();
           itmtypetxt.ValueMember = "id";
            itmtypetxt.DisplayMember = "category_name";
            itmtypetxt.DataSource = dt;
        }
        #endregion
        #region get id
        void getid()

        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_get_item_id", CommandType.StoredProcedure);

            label11.Text = dt.Rows[0][0].ToString();
        }
        #endregion
        #region prepare data
        DataTable PrepareData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                DataRow dr;
            
                dt.Columns.Add("item_id", typeof(int)); 
                dt.Columns.Add("store_id", typeof(int));
                dt.Columns.Add("quantity", typeof(decimal));
           
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr[0] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    dr[1] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    dr[2] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    

                    dt.Rows.Add(dr);
                }
                return dt;

            }
            else
            {
                return null;
            }
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
                    DataTable dt = PrepareData();
                if (dataGridView1.Rows.Count < 0)
                {

                    MessageBox.Show("من فضلك ادخل بيانات ", "الاصناف");
                    return;

                }
                    if (MessageBox.Show("هل تريد حفظ الصنف؟", "الاصناف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        RetrieveData.executeNonquery("sp_item_insert", CommandType.StoredProcedure,
                            new RetrieveData.parameter("@item_name", SqlDbType.NVarChar, itmtxt.Text),
                            new RetrieveData.parameter("@price", SqlDbType.Int, decimal.Parse(pricetxt.Text)),
                            new RetrieveData.parameter("@category_id", SqlDbType.Int, int.Parse(itmtypetxt.SelectedValue.ToString())),

                                       new RetrieveData.parameter("@itm_comp", SqlDbType.Structured, dt));




                        MessageBox.Show("تم الحفظ", "الاصناف");
                        validation.txtclear(this, groupBox1);
                        validation.txtclear(this, groupBox3);
                        dataGridView1.Rows.Clear();
                        bindcombo();
                        getid();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error"); }
        }

            #endregion
       

        private void editbtn_Click(object sender, EventArgs e)
        {
            #region update
            if (labelid.Text != "0")
            {
                if (MessageBox.Show("هل تريد تعديل الصنف؟", "الاصناف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    validation.suretxt(this, groupBox1);
                    int z = 0;
                    if (z == validation.i)
                    {
                        DataTable dt = PrepareData();
                        if (dataGridView1.Rows.Count < 0)
                        {
                            MessageBox.Show("من فضلك ادخل بيانات ", "الاصناف");
                            return;

                        }
                        RetrieveData.executeNonquery("sp_item_update", CommandType.StoredProcedure,
                            new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(labelid.Text)),
                            new RetrieveData.parameter("@item_name", SqlDbType.NVarChar, itmtxt.Text),
                            new RetrieveData.parameter("@price", SqlDbType.Decimal, decimal.Parse(pricetxt.Text)),   
                            new RetrieveData.parameter("@category_id", SqlDbType.Int, int.Parse(itmtypetxt.SelectedValue.ToString())),
                            new RetrieveData.parameter("@itm_comp", SqlDbType.Structured, dt));
                         
                        validation.txtclear(this, groupBox1);
                        validation.txtclear(this, groupBox3);
                        dataGridView1.Rows.Clear();

                        MessageBox.Show("تم التعديل", "الاصناف");
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
                if (MessageBox.Show("هل تريد حذف الصنف؟", "الاصناف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RetrieveData.executeNonquery("sp_item_delete", CommandType.StoredProcedure,
                        new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(searchcombo.SelectedValue.ToString())));
                    MessageBox.Show("تم الحذف", "الاصناف");
                    bindcombo();
                    validation.txtclear(this, groupBox1);
                    validation.txtclear(this, groupBox3);
                    dataGridView1.Rows.Clear();
                    labelid.Text = "0";
                }
            }

            #endregion
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void itmtypetxt_SelectedIndexChanged(object sender, EventArgs e)
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
                    dt = RetrieveData.executequery("sp_item_selectbyid", CommandType.StoredProcedure,
                            new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(labelid.Text)));

                    itmtxt.Text = dt.Rows[0][5].ToString();
                    pricetxt.Text = dt.Rows[0][6].ToString();
                    itmtypetxt.SelectedValue = dt.Rows[0][7].ToString();
                  
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][9].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][2].ToString();
                   


                    }
                }
            }
            catch { }
            #endregion
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            validation.txtclear(this, groupBox1);
            validation.txtclear(this, groupBox3);
            dataGridView1.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(label11.Text, componentcombo.SelectedValue.ToString(),componentcombo.Text, quantity2.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(labelid.Text, componentcombo.SelectedValue.ToString(), componentcombo.Text, quantity2.Text);
        }
    }
}
