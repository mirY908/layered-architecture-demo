using Microsoft.VisualBasic;
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
    public partial class CartWindow : Form
    {
        // הגדרת משתנה עבור שכבת הלוגיקה
        BlApi.IBI bl = BlApi.Factory.Get();

        // יצירת אובייקט הזמנה חדש שילווה אותנו בחלון זה
        BO.Order currentOrder = new BO.Order
        {
            ProductList = new List<BO.ProductInOrder>(),
            TotalPrice = 0,
            IsFavoriteCustomer = false
        };
        public CartWindow()
        {
            InitializeComponent();

            var allProducts = bl.product.ReadAll();
            cmbProducts.DataSource = allProducts.ToList();
            cmbProducts.DisplayMember = "ProductName"; // מה שהמשתמש יראה
            cmbProducts.ValueMember = "Id";

        }

        private void lblTotalSum_Click(object sender, EventArgs e)
        {

        }

        private void CartWindow_Load(object sender, EventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                // שליפת ה-ID שנבחר מהרשימה הנפתחת
                int pId = (int)cmbProducts.SelectedValue;

                if (!int.TryParse(txtAmount.Text, out int amount))
                {
                    MessageBox.Show("נא להזין כמות תקינה");
                    return;
                }

                // שאר הקוד נשאר אותו דבר בדיוק!
                bl.order.AddProductToOrder(currentOrder, pId, amount);

                dgvCart.DataSource = null;
                dgvCart.DataSource = currentOrder.ProductList;
                lblTotalSum.Text = $"סה\"כ לתשלום: {currentOrder.TotalPrice} ₪";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                // שליפת האובייקט מהשורה שנבחרה
                var selectedProduct = (BO.ProductInOrder)dgvCart.SelectedRows[0].DataBoundItem;

                // הסרה מהרשימה הפנימית של ההזמנה
                currentOrder.ProductList.Remove(selectedProduct);

                // עדכון המחיר הכולל בעזרת הפונקציה הקיימת ב-BL
                bl.order.CalcTotalPrice(currentOrder);

                // ריענון התצוגה
                RefreshUI();
            }
            else
            {
                MessageBox.Show("נא לבחור שורה להסרה מהטבלה");
            }
        }
        private void RefreshUI()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = currentOrder.ProductList;
            lblTotalSum.Text = $"סה\"כ לתשלום: {currentOrder.TotalPrice} ₪";
        }

        private void btnFinishOrder_Click(object sender, EventArgs e)
        {
            // 1. בדיקה אם העגלה בכלל לא ריקה
            if (currentOrder.ProductList.Count == 0)
            {
                MessageBox.Show("העגלה ריקה! נא להוסיף מוצרים לפני התשלום.");
                return;
            }

            try
            {
                // 2. קריאה לפונקציית הלוגיקה שסוגרת את ההזמנה ומעדכנת מלאי
                bl.order.DoOrder(currentOrder);

                // 3. הודעת הצלחה למשתמש
                MessageBox.Show("ההזמנה בוצעה בהצלחה! המלאי עודכן.", "סיום הזמנה");

                // 4. איפוס העגלה לקראת הלקוח הבא
                currentOrder = new BO.Order
                {
                    ProductList = new List<BO.ProductInOrder>(),
                    TotalPrice = 0
                };

                RefreshUI(); // ניקוי הטבלה והסכום במסך
            }
            catch (Exception ex)
            {
                // אם למשל נגמר המלאי בזמן שחיכינו, ה-BL יזרוק שגיאה וזה יקפוץ כאן
                MessageBox.Show(ex.Message, "שגיאה בביצוע ההזמנה");
            }
        }

        private void btnUpdateAmount_Click(object sender, EventArgs e)
        {



            //if (dgvCart.SelectedRows.Count > 0)
            //{
            //    if (int.TryParse(txtAmount.Text, out int newAmount) && newAmount > 0)
            //    {
            //        // שליפת האובייקט מהשורה שנבחרה
            //        var selectedProduct = (BO.ProductInOrder)dgvCart.SelectedRows[0].DataBoundItem;

            //        // עדכון הכמות
            //        selectedProduct.amount = newAmount;

            //        // חישוב מחדש של מבצעים ומחיר למוצר הספציפי
            //        bl.order.SearchSaleForProduct(selectedProduct, currentOrder.IsFavoriteCustomer);
            //        bl.order.CalcTotalPriceForProduct(selectedProduct);

            //        // עדכון המחיר הכולל של כל ההזמנה
            //        bl.order.CalcTotalPrice(currentOrder);

            //        // הפעולה החשובה ביותר - ריענון התצוגה!
            //        RefreshUI();

            //        MessageBox.Show("הכמות עודכנה בהצלחה");
            //    }
            //    else
            //    {
            //        MessageBox.Show("נא להזין מספר תקין בתיבת הכמות");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("נא לבחור שורה מהטבלה");
            //}


            if (dgvCart.SelectedRows.Count > 0)
            {
                // 1. קפיצת תיבת קלט ששואלת את המשתמש לכמות
                string input = Interaction.InputBox("נא להזין את הכמות החדשה:", "עדכון כמות", "");

                // 2. בדיקה אם המשתמש הקיש ביטול או השאיר ריק
                if (string.IsNullOrWhiteSpace(input)) return;

                if (int.TryParse(input, out int newAmount) && newAmount > 0)
                {
                    var selectedProduct = (BO.ProductInOrder)dgvCart.SelectedRows[0].DataBoundItem;

                    // 3. עדכון הנתונים
                    selectedProduct.amount = newAmount;
                    bl.order.SearchSaleForProduct(selectedProduct, currentOrder.IsFavoriteCustomer);
                    bl.order.CalcTotalPriceForProduct(selectedProduct);
                    bl.order.CalcTotalPrice(currentOrder);

                    // 4. ריענון המסך
                    RefreshUI();
                }
                else
                {
                    MessageBox.Show("נא להזין מספר תקין.");
                }
            }
            else
            {
                MessageBox.Show("נא לבחור מוצר מהטבלה.");
            }

        }

        private void chkIsFavorite_CheckedChanged(object sender, EventArgs e)
        {
            // 1. עדכון המצב באובייקט ההזמנה
            currentOrder.IsFavoriteCustomer = chkIsFavorite.Checked;

            // 2. מעבר על כל המוצרים שכבר בעגלה וחישוב מחדש של מבצעים
            foreach (var item in currentOrder.ProductList)
            {
                bl.order.SearchSaleForProduct(item, currentOrder.IsFavoriteCustomer);
                bl.order.CalcTotalPriceForProduct(item);
            }

            // 3. עדכון מחיר סופי וריענון מסך
            bl.order.CalcTotalPrice(currentOrder);
            RefreshUI();
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
