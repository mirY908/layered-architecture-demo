using BlApi;
using Dal;
using DalApi;
using Do;
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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. יצירת המופע (שימי לב לשם המשתנה bl)
                BlApi.IBI bl = BlApi.Factory.Get();

                // 2. קריאה לנתונים דרך המשתנה bl שיצרנו הרגע
                // אנחנו ניגשים ל-Product שנמצא בתוך ה-bl
                var allProducts = bl.product.ReadAll();

                // 3. הצגה בטבלה
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = allProducts.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הנתונים: " + ex.Message);
            }
        }
    }
}
