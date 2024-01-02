using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace POS_MEDKB
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            new ToolTip().SetToolTip(pictureBox1, "Cookie");
            new ToolTip().SetToolTip(pictureBox2, "Cake");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addItems("Cookie", 100);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            addItems("Cake", 500);
        }
        public void addItems(string item, int price)
        {
            bool itemFound = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Debug.WriteLine("Executed");
                if (row.Cells["Item"].Value.ToString() == item)
                {
                    Console.WriteLine("Item exist");
                    int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    row.Cells["Quantity"].Value = quantity + 1;
                    int newPrice = int.Parse(row.Cells["Price"].Value.ToString());
                    row.Cells["Price"].Value = newPrice + price;
                    itemFound = true;
                    break;
                }
            }

            if (!itemFound)
            {
                Debug.WriteLine("Item doesnt exist");
                dataGridView1.Rows.Add(1, item, price);
            }
        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited cell is in the Quantity column
            if (e.ColumnIndex == dataGridView1.Columns["Quantity"].Index && e.RowIndex >= 0)
            {
                Debug.WriteLine("Value Changed");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
