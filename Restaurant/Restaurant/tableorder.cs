using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElmasryCsharp
{
    public partial class tableorder : Form
    {
        public tableorder()
        {
            InitializeComponent();
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            categories();
            getid();
           
        }
        #region clear groupbox
        void ClearControls(GroupBox groupBox)
        {
            while (groupBox.Controls.Count > 0)
            {
                Control control = groupBox.Controls[0];
                groupBox.Controls.RemoveAt(0);
                control.Dispose();
            }
        }
        #endregion

        #region make buttons
        void itemButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string ItemName = clickedButton.Text;
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("get_item", CommandType.StoredProcedure,
                    new RetrieveData.parameter("@item_name", SqlDbType.NVarChar, ItemName));

            label13.Text = dt.Rows[0][0].ToString();

            double price = 0;

            dt = RetrieveData.executequery("sp_select_dishes", CommandType.StoredProcedure,
                    new RetrieveData.parameter("@id", SqlDbType.Int, int.Parse(label13.Text)));
            price = double.Parse(dt.Rows[0][2].ToString());


            dataGridView1.Rows.Add(label11.Text, label13.Text, ItemName, price, 1, price);


        }

        void CategoryButtonClick(object sender, EventArgs e)
        {
            ClearControls(groupBox1);
            Button clickedButton = (Button)sender;
            string categoryName = clickedButton.Text;
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("items_button", CommandType.StoredProcedure, new RetrieveData.parameter("@category_name", SqlDbType.NVarChar, categoryName));

            int startX = 77;
            int startY = 110;

            int buttonWidth = 150;
            int buttonHeight = 35;



            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string itmName = dt.Rows[i][4].ToString();

                Button button = new Button();
                button.Text = itmName;
                button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                button.Location = new System.Drawing.Point(startX, startY + i * (buttonHeight + 30));
                button.Click += itemButtonClick;
                groupBox1.Controls.Add(button);
            }

        }

     
        void categories()
        {



            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("select category_name from category", CommandType.Text);


            int startX = 60;
            int startY = 110;

            int buttonWidth = 150;
            int buttonHeight = 35;



            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string categoryName = dt.Rows[i][0].ToString();

                Button button = new Button();
                button.Text = categoryName;
                button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                button.Location = new System.Drawing.Point(startX, startY + i * (buttonHeight + 30)); // Use i1 as the vertical offset
                button.Click += CategoryButtonClick;
                groupBox2.Controls.Add(button);
            }
        }
        #endregion
        #region calculate total
        double calculatetotal(double price, double quantity)
        {
            double total = 0;
            total = price * quantity;
            return total;
        }
        #endregion
        #region make check
        void makecheck()
        {
           
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (item.Cells[1].Value.ToString() == label13.Text)
                    {
                        MessageBox.Show("This item already found");
                        return;
                    }

                }
           
               
            }

        }
        #endregion
        #region calculate check
        void calculatecheck()
        {
            try
            {
                double total1 = 0;
                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {

                        total1 += double.Parse(item.Cells[5].Value.ToString());
                    }
                    total.Text = finaltotal.Text = total1.ToString();
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error"); }
        }
        #endregion
        #region calculate discount
        void calcdiscount()
        {
            double finaltotal1 = 0;
            finaltotal1 = double.Parse(total.Text) - double.Parse(discount.Text);
            finaltotal.Text = finaltotal1.ToString();
        }
        #endregion
        #region get id
       void getid()
            
        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_get_id", CommandType.StoredProcedure);
         
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
                dt.Columns.Add("receipt_id", typeof(int));
                dt.Columns.Add("item_id", typeof(int));
                dt.Columns.Add("price", typeof(decimal));
                dt.Columns.Add("quantity", typeof(int));
                dt.Columns.Add("total", typeof(decimal));
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr[0] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    dr[1] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    dr[2] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    dr[3] = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    dr[4] = dataGridView1.Rows[i].Cells[5].Value.ToString();


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
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            
        }

        private void tableorder_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            getid();
         
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grilledcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
       
        }

        private void stuffedcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void saladscombo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void casserolecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void maindishcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void specialdishcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void price1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void price2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void price3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void price4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void price5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void price6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void quantity1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void price1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void quantity2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void quantity3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void quantity4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void quantity5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void quantity6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          

        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculatecheck();
          
        }

        private void discount_TextChanged(object sender, EventArgs e)
        {
            calcdiscount();
        }

        private void discount_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void total_TextChanged(object sender, EventArgs e)
        {
            calcdiscount();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            #region sure order
            try
            {
                DataTable dt = PrepareData();
            if (dataGridView1.Rows.Count < 0)
            {
                MessageBox.Show("please enter item");
                return;

            }
            DataTable dt2=new DataTable();

             dt2=   RetrieveData.executequery("sp_insert_receipt2", CommandType.StoredProcedure,
                    new RetrieveData.parameter("@total", SqlDbType.Decimal, total.Text),
                    new RetrieveData.parameter("@discount", SqlDbType.Decimal, discount.Text),
                    new RetrieveData.parameter("@final_total", SqlDbType.Decimal, finaltotal.Text),

                    new RetrieveData.parameter("@receipt_type", SqlDbType.NVarChar, label9.Text),

                    new RetrieveData.parameter("@rcp", SqlDbType.Structured, dt));
                string message = dt2.Rows[0][0].ToString();
                MessageBox.Show(message,"الطاولات");
                dataGridView1.Rows.Clear();
                total.Text = "0";
                finaltotal.Text = "0";
                discount.Text = "0";
                getid();

        }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error"); }


    #endregion
}

        private void total_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void finaltotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            
             
             



            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns[3].Index || e.ColumnIndex == dataGridView1.Columns[4].Index) && e.RowIndex >= 0)
            {
               
                object priceCellValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                object quantityCellValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value;

               
                if (priceCellValue != null && quantityCellValue != null)
                {
                    decimal price = Convert.ToDecimal(priceCellValue);
                    decimal quantity = Convert.ToDecimal(quantityCellValue);

                   
                    decimal total = price * quantity;

                 
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = total;
                }
            }
        }
    }
}
