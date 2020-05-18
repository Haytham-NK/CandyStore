using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CStore
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProductsSet productsSet = new ProductsSet();
            productsSet.Manufacturer = Manufacturer.Text;
            productsSet.Price = Price.Text;
            productsSet.Name = NameProduct.Text;
            productsSet.Amount = Amount.Text;
            Program.wftDb.ProductsSet.Add(productsSet);
            Program.wftDb.SaveChanges();
            ShowProduct();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                ProductsSet productsSet = listViewClient.SelectedItems[0].Tag as ProductsSet;
                productsSet.Manufacturer = Manufacturer.Text;
                productsSet.Price = Price.Text;
                productsSet.Name = NameProduct.Text;
                productsSet.Amount = Amount.Text;
                Program.wftDb.SaveChanges();
                ShowProduct();
            }
        }
        void ShowProduct()
        {
            listViewClient.Items.Clear();
            foreach (ProductsSet productsSet in Program.wftDb.ProductsSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                productsSet.Id.ToString(), productsSet.Manufacturer, productsSet.Price,
                productsSet.Name, productsSet.Amount
                });
                item.Tag = productsSet;
                listViewClient.Items.Add(item);
            }
            listViewClient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewClient.SelectedItems.Count == 1)
                {
                    WorkersSet workersSet = listViewClient.SelectedItems[0].Tag as WorkersSet;
                    Program.wftDb.WorkersSet.Remove(workersSet);
                    Program.wftDb.SaveChanges();
                    ShowProduct();
                }
                Manufacturer.Text = "";
                Price.Text = "";
                NameProduct.Text = "";
                Amount.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
