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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;

            var selected = (Aeroport) listBox1.Items[listBox1.SelectedIndex];

            listBox2.Items.Clear();

            foreach (var destination in selected.Destinations)
                listBox2.Items.Add(destination);

            textBox1.Text = textBox2.Text = "";

            if (selected.Destinations.Count == 0)
                return;

            var max = selected.Destinations.Max(x => x.Price);

            textBox1.Text = selected.Destinations.Where(x => x.Price == max).First().ToString();
            textBox2.Text = selected.Destinations.Average(x => x.Length).ToString("0.0");
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AeroportForm aform = new AeroportForm();

            aform.ShowDialog();

            if (aform.DialogResult == DialogResult.OK)
                listBox1.Items.Add(aform.Aeroport);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                return;

            DestinationForm dform = new DestinationForm();

            dform.ShowDialog();

            if (dform.DialogResult == DialogResult.OK)
            {
                var current = (Aeroport)listBox1.Items[listBox1.SelectedIndex];

                current.Destinations.Add(dform.Destination);

                listBox1.SetSelected(listBox1.SelectedIndex, true);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var result = MessageBox.Show("Дали сте сигурни дека сакате да го избришете селектираната ставка?", "Избриши ставка", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    return;

                listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                listBox2.Items.Clear();
                textBox1.Text = textBox2.Text = "";
            }
        }
    }
}
