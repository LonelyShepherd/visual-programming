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
  public partial class ProductForm : Form
  {
    public Product Product { get; set; }

    public ProductForm()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Form1 f = Parent as Form1;

      float.TryParse(textBox3.Text, out float price);

      Product = new Product();

      Product.Name = textBox1.Text;
      Product.Category = textBox2.Text;
      Product.Price = price;

      DialogResult = DialogResult.OK;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
      if (textBox1.Text.Trim().Length == 0)
      {
        e.Cancel = true;
        errorProvider1.SetError(textBox1, "Внесете име!");
      }
      else
      {
        errorProvider1.SetError(textBox1, null);
      }
    }

    private void textBox2_Validating(object sender, CancelEventArgs e)
    {
      if (textBox2.Text.Trim().Length == 0)
      {
        e.Cancel = true;
        errorProvider2.SetError(textBox2, "Внесете категорија!");
      }
      else
      {
        errorProvider2.SetError(textBox2, null);
      }
    }

    private void textBox3_Validating(object sender, CancelEventArgs e)
    {
      if (textBox3.Text.Trim().Length == 0)
      {
        e.Cancel = true;
        errorProvider3.SetError(textBox3, "Внесете цена!");
      }
      else
      {
        errorProvider3.SetError(textBox3, null);
      }
    }
  }
}
