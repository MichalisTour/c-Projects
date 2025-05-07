using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class Form1 : Form
    {
        public class Product
        {
            public string Name { get; set; }
            public float Price { get; set; }
            public int Quantity { get; set; }
            public float Fpa { get; set; }
            public string Category { get; set; }

            public Product(string name, float price, string category, float fpa)
            {
                Name = name;
                Price = price;
                Quantity = 0;
                Category = category;
                Fpa = fpa;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoadProducts_Click(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>
            {
                new Product("Espresso", 2.0f, "drink", 13),
                new Product("Pizza Margarita", 10.0f, "food", 13),
                new Product("Greek Coffee", 1.5f, "drink", 13),
                new Product("Salad", 7.0f, "food", 13)
            };

            dgvProducts.DataSource = products;
        }
    }
}
