using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
  public partial class Form1 : Form
  {
    public float total = 0;

    public Form1()
    {
      InitializeComponent();
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void button4_Click(object sender, EventArgs e)
    {
      var productForm = new ProductForm();

      var result = productForm.ShowDialog();

      if (result == DialogResult.OK)
        listBox1.Items.Add(productForm.Product);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var confirm = MessageBox.Show("Дали сте сигурни дека сакате да ја испразните листата со продукти?", "Испразни ја листата", MessageBoxButtons.YesNo);

      if (confirm == DialogResult.Yes)
      {
        listBox1.Items.Clear();
        textBox1.Text = textBox2.Text = textBox3.Text = "";
      }
    }

    private void button6_Click(object sender, EventArgs e)
    {
      var confirm = MessageBox.Show("Дали сте сигурни дека сакате да ја испразните кошничката?", "Испразни ја кошничката", MessageBoxButtons.YesNo);

      if (confirm == DialogResult.Yes)
      {
        listBox2.Items.Clear();
        textBox4.Text = "0.00";
      }
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      var index = listBox1.SelectedIndex;

      if (index >= 0)
      {
        var selected = (Product) listBox1.Items[listBox1.SelectedIndex];

        textBox1.Text = selected.Name;
        textBox2.Text = selected.Category;
        textBox3.Text = String.Format("{0:0.00}", selected.Price);
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      var index = listBox1.SelectedIndex;

      if (index >= 0)
      {
        var selected = (Product) listBox1.Items[index];

        Product product = new Product
        {
          Name = $"{selected.Name} {numericUpDown1.Value} x {selected.Price}",
          Category = selected.Category,
          Price = selected.Price * (float) numericUpDown1.Value
        };

        listBox2.Items.Add(product);

        total += product.Price;

        textBox4.Text = String.Format("{0:0.00}", total);
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      var index = listBox2.SelectedIndex;

      if (index >= 0)
      {
        var selected = (Product) listBox2.Items[index];
        listBox2.Items.Remove(selected);

        total -= selected.Price;

        textBox4.Text = String.Format("{0:0.00}", total);
      }
    }

    private void button5_Click(object sender, EventArgs e)
    {
      var index = listBox1.SelectedIndex;

      if (index >= 0)
      {
        var selected = listBox1.Items[index];
        listBox1.Items.Remove(selected);

        textBox1.Text = textBox2.Text = textBox3.Text = "";
      }
    }
  }
}
