using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gai
{
    public partial class Form1 : Form
    {
        public static Regi user { get; set; }

        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }
            Regi usr = db.Regi.Find(loginTextBox.Text);

            if ((usr != null) && (usr.Password == passwordTextBox.Text));
            {
                user = usr;
                if (usr.Dolsh == "Инспектор")
                {
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
