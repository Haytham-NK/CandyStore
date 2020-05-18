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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
            ShowClient();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ClientsSet clientSet = new ClientsSet();
            clientSet.FirstName = FirstName.Text;
            clientSet.MiddleName = MiddleName.Text;
            clientSet.LastName = LastName.Text;
            clientSet.Phone = Phone.Text;
            Program.wftDb.ClientsSet.Add(clientSet);
            Program.wftDb.SaveChanges();
            ShowClient();
        }
        void ShowClient()
        {
            listViewClient.Items.Clear();
            foreach (ClientsSet clientsSet in Program.wftDb.ClientsSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                clientsSet.Id.ToString(), clientsSet.FirstName, clientsSet.MiddleName,
                clientsSet.LastName, clientsSet.Phone
                });
                item.Tag = clientsSet;
                listViewClient.Items.Add(item);
            }
            listViewClient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                ClientsSet clientsSet = listViewClient.SelectedItems[0].Tag as ClientsSet;
                clientsSet.FirstName = FirstName.Text;
                clientsSet.MiddleName = MiddleName.Text;
                clientsSet.LastName = LastName.Text;
                clientsSet.Phone = Phone.Text;
                Program.wftDb.SaveChanges();
                ShowClient();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewClient.SelectedItems.Count == 1)
                {
                    ClientsSet clientsSet = listViewClient.SelectedItems[0].Tag as ClientsSet;
                    Program.wftDb.ClientsSet.Remove(clientsSet);
                    Program.wftDb.SaveChanges();
                    ShowClient();
                }
                //очищаем textBoxt-ы
                FirstName.Text = "";
                MiddleName.Text = "";
                LastName.Text = "";
                Phone.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                ClientsSet clientsSet = listViewClient.SelectedItems[0].Tag as ClientsSet;
                clientsSet.FirstName = FirstName.Text;
                clientsSet.MiddleName = MiddleName.Text;
                clientsSet.LastName = LastName.Text;
                clientsSet.Phone = Phone.Text;
            }
            else
            {
                FirstName.Text = "";
                MiddleName.Text = "";
                LastName.Text = "";
                Phone.Text = "";
            }
        }
    }
}
