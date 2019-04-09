using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace primer_kol
{
    public partial class AeroportForm : Form
    {
        public Aeroport Aeroport;

        public AeroportForm()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Aeroport = new Aeroport()
            {
                Name = textBox1.Text,
                City = textBox2.Text,
                ShortCity = textBox3.Text
            };

            DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox1, "Полето е задолжително");

                e.Cancel = true;

                return;
            }

            errorProvider1.SetError(textBox1, "");
        }

        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                errorProvider2.SetError(textBox2, "Полето е задолжително");

                e.Cancel = true;

                return;
            }

            errorProvider2.SetError(textBox2, "");
        }

        private void TextBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Trim().Length != 3)
            {
                errorProvider3.SetError(textBox3, "Полето треба да се содржи од точно 3 карактери");

                e.Cancel = true;

                return;
            }

            errorProvider3.SetError(textBox3, "");
        }
    }
}
