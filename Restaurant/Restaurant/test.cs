using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElmasryCsharp
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            categories();
            getid();
         
        }
        #region get id
        void getid()

        {
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("sp_get_id", CommandType.StoredProcedure);

            label1.Text = dt.Rows[0][0].ToString();
        }
        #endregion
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


            dataGridView1.Rows.Add(label1.Text, label13.Text, ItemName, price, 1, price);
          

        }

        void CategoryButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string categoryName = clickedButton.Text;
            DataTable dt = new DataTable();
            dt = RetrieveData.executequery("items_button", CommandType.StoredProcedure,new RetrieveData.parameter("@category_name",SqlDbType.NVarChar,categoryName));

            int startX = 60;
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
        
        #region get categories
        void categories()
        {

          

            DataTable dt =new DataTable();
            dt=RetrieveData.executequery("select category_name from category", CommandType.Text);
          

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
        private void test_Load(object sender, EventArgs e)
        {
            
        }
    }
}
