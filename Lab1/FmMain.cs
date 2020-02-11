using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        Workshop shop;
        private int index = 1;
        List<string> types;

        private void FmMain_Load(object sender, EventArgs e)
        {
            shop = new Workshop();
            int i = 1;
            types = new List<string>();
            foreach(Baugette b in shop.GetBaugetteList())
            {
                comboBox1.Items.Add("type" + i.ToString());
                types.Add("type" + i.ToString());
                i++;
            }
            comboBox1.Text = "type1";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            shop.AddOrder(index, (int)numericUpDown1.Value);
            txtOrders.Text += types[index] + "\n";
            txtOrders.Text += (int)numericUpDown1.Value + "\n\n";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> mater;
            if ((mater = shop.GetMaterials()) != null)
            {
                label3.Visible = true;
                label3.Text = "Матеріалів\n не вистачає";
                label3.ForeColor = Color.DarkRed;

                txtMaterials.Visible = true;
                foreach (KeyValuePair<string, int> pair in mater)
                {
                    if (pair.Value != 0)
                    {
                        txtMaterials.Text += pair.Key + "\n";
                        txtMaterials.Text += pair.Value + "\n\n";
                    }
                }
            }
            else
            {
                label3.Visible = true;
                label3.Text = "Матеріалів\n вистачає";
                label3.ForeColor = Color.DarkGreen;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            index = types.IndexOf(selectedState);
        }
    }
}
