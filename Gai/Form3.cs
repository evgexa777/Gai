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
    public partial class Form3 : Form
    {
        Model1 db = new Model1();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            driversBindingSource.DataSource = db.Drivers.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
                {
                    driversBindingSource.DataSource = null;
                    driversBindingSource.DataSource = db.Drivers.ToList();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Drivers drv = (Drivers)driversBindingSource.Current;

            Form4 frm = new Form4();
            frm.drv = drv;

            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                driversBindingSource.DataSource = db.Drivers.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Drivers drv = (Drivers)driversBindingSource.Current;
            DialogResult dr = MessageBox.Show("Удалить водителя" + drv.ID + "?", "Удаление водителя", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Drivers.Remove(drv);
                try
                {
                    db.SaveChanges();
                    driversBindingSource.DataSource = db.Drivers.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.InnerException.Message);
                }
            }
        }
    }
}
