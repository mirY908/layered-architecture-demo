using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void productsbuttonForm_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            this.Hide();
            productForm.FormClosed += Form_FormClosed;
            productForm.Show();
        }


        private void cusomersButtonForm_Click(object sender, EventArgs e)
        {
            CustomerForm cusomersForm = new CustomerForm();
            this.Hide();
            cusomersForm.FormClosed += Form_FormClosed;
            cusomersForm.Show();
        }

        private void salesButtonForm_Click(object sender, EventArgs e)
        {
           SaleForm saleForm = new SaleForm();
            this.Hide();
            saleForm.FormClosed += Form_FormClosed;
            saleForm.Show();
        }
    }
}
