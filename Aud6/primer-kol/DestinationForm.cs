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
    public partial class DestinationForm : Form
    {
        public Destination Destination;

        public DestinationForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Destination = new Destination()
            {
                Name = textBox1.Text,
                Length = (int) numericUpDown1.Value,
                Price = (float) numericUpDown2.Value
            };

            DialogResult = DialogResult.OK;
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
    }
}
