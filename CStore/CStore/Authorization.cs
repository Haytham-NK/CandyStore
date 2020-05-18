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
    public struct User
    {
        public string login;
        public string password;
        public string type;
    }
    public partial class Authorization : Form
    {
        public static User users = new User();
        public Authorization()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (boxLogin.Text == "" && boxPassword.Text == "")
            {
                MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                bool key = false;
                foreach (Users user in Program.wftDb.Users)
                {
                    if  (boxLogin.Text == user.Login && boxPassword.Text == user.Password)
                    {
                        key = true;
                        users.login = user.Login;
                        users.password = user.Password;
                        users.type = user.Type;
                    }
                }
                if (!key)
                {
                    MessageBox.Show("Проеверьте данные", "Пользователь не найден", MessageBoxButtons.OK);
                    boxLogin.Text = "";
                    boxPassword.Text = "";
                    
                }
                else
                {
                    MessageBox.Show("Данные введены верно", "Пользователь найден", MessageBoxButtons.OK);
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
            }
        }
    }
}
