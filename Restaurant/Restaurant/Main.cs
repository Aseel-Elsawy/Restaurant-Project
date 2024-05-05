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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void الطاولاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableorder tr = new tableorder();
      tr.MdiParent = this;
            tr.Show();
        }

        private void الدليفريToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delivery dv = new delivery();
      dv.MdiParent = this;
            dv.Show();
        }

        private void اوردرجاهزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            takeawayorder tk= new takeawayorder();
      tk.MdiParent= this;
            tk.Show();
        }

        private void اضافةصنفجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Items fm = new Items();
           fm.MdiParent=this;
            fm.Show();
        }

        private void المخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            store store= new store();
       store.MdiParent=this;
            store.Show();
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void اضافةموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employee emp= new employee();
            emp.MdiParent = this;
            emp.Show();
        }

        private void الوحداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Units un = new Units();
          un.MdiParent=this;
            un.Show();
        }

        private void الفئاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            category category = new category();
      category.MdiParent=this;
            category.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void التقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void التيكاوايToolStripMenuItem_Click(object sender, EventArgs e)
        {
           takeawayreports tk = new takeawayreports();
          tk.MdiParent=this;
            tk.Show();
        }

        private void الدليفريToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deliveryreports dv = new deliveryreports();
          dv.MdiParent=this;
            dv.Show();
        }

        private void الصالةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablesreports tb = new tablesreports();
         tb.MdiParent=this;
            tb.Show();
        }

        private void المخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            storereport st=new storereport();
      st.MdiParent = this;
            st.Show();  

        }

        private void الاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void الطلباتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void اضافةموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vendors vd = new vendors();
            vd.MdiParent = this;
            vd.Show();
        }

        private void حسابموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vendordebits vd = new vendordebits();
            vd.MdiParent = this;
            vd.Show();
        }

        private void حساباتالموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vendordebitsreport vd=new vendordebitsreport();
            vd.MdiParent = this;    
            vd.Show();
                
        }
    }
}
