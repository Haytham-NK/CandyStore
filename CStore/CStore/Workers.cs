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
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
            ShowWorker();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            WorkersSet workersSet = new WorkersSet();
            workersSet.FirstName = boxFirstName.Text;
            workersSet.MiddleName = boxMiddleName.Text;
            workersSet.LastName = boxLastName.Text;
            workersSet.Phone = boxPhone.Text;
            workersSet.Address = boxAddress.Text;
            workersSet.Position = boxPosition.Text;
            Program.wftDb.WorkersSet.Add(workersSet);
            Program.wftDb.SaveChanges();
            ShowWorker();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
           if (listViewClient.SelectedItems.Count == 1)
            {
                WorkersSet workersSet = listViewClient.SelectedItems[0].Tag as WorkersSet;
                workersSet.FirstName = boxFirstName.Text;
                workersSet.MiddleName = boxMiddleName.Text;
                workersSet.LastName = boxLastName.Text;
                workersSet.Phone = boxPhone.Text;
                workersSet.Address = boxAddress.Text;
                workersSet.Position = boxPosition.Text;
                Program.wftDb.SaveChanges();
                ShowWorker();
            }
        }
        void ShowWorker()
        {
            listViewClient.Items.Clear();
            foreach (WorkersSet workersSet in Program.wftDb.WorkersSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                workersSet.Id.ToString(), workersSet.FirstName, workersSet.MiddleName,
                workersSet.LastName, workersSet.Phone
                });
                item.Tag = workersSet;
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
                    ShowWorker();
                }
                //очищаем textBoxt-ы
                boxFirstName.Text = "";
                boxMiddleName.Text = "";
                boxLastName.Text = "";
                boxPhone.Text = "";
                boxAddress.Text = "";
                boxPosition.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
