using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElmasryCsharp
{
    internal class validation
    {
        public static int i;
        public static void txtclear(Form frm, GroupBox grp)
        {
            foreach (Control item in frm.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control txt in grp.Controls)
                    {
                        if (txt is TextBox)
                        {
                            txt.Text = "";
                        }
                        if (txt is ComboBox)
                        {
                            txt.Text = "";
                        }
                        if (txt is MaskedTextBox)
                        {
                            txt.Text = "";
                        }
                    }
                }
            }
        }
        public static void suretxt(Form frm, GroupBox grp)
        {

            foreach (Control item in frm.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control txt in grp.Controls)
                    {
                        if (txt is TextBox)
                        {
                            if (txt.Text == "")
                            {

                                MessageBox.Show("Enter Correct Data", "Error");
                                i = -1;
                                return;
                            }

                        }
                        if (txt is ComboBox)
                        {
                            if (txt.Text == "")
                            {
                                MessageBox.Show("Enter Correct Data", "Error");
                                i = -1;
                                return;

                            }
                        }
                        if (txt is MaskedTextBox)
                        {
                            if (txt.Text == "")
                            {
                                MessageBox.Show("Enter Correct Data", "Error");
                                i = -1;
                                return;
                            }
                        }
                        i = 0;



                    }
                }
            }
        }
    }
}
