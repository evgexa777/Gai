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
    public partial class Form4 : Form
    {
        public Drivers drv { get; set; } = null;
        public Model1 db { get; set; }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (drv == null)
            {
                driversBindingSource.AddNew();
            }
            else
            {
                driversBindingSource.Add(drv);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (iDTextBox.Text == "" || nameTextBox.Text == "" || lastNameTextBox.Text == "" || firstNameTextBox.Text == "" || passportTextBox.Text == "" || addresTextBox.Text == "" ||
                adressLifeTextBox.Text == "" || companyTextBox.Text == "" || jobNameTextBox.Text == "" || phoneTextBox.Text == "" || emailTextBox.Text == "" || photoTextBox.Text == "" || descripTextBox.Text == "")
            {
                MessageBox.Show("Заполните пустые поля!");
            }
            else if (drv == null)
            {
                drv = (Drivers)driversBindingSource.Current;
                db.Drivers.Add(drv);
            }
            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
