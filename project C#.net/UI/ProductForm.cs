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
            // 1. נבקש מהמשתמש להקיש ID (כאן אני משתמש בתיבה פשוטה של VB לצורך הדוגמה)
            string input = Microsoft.VisualBasic.Interaction.InputBox("הקש קוד מוצר לחיפוש:", "חיפוש מוצר", "");

            if (int.TryParse(input, out int productId))
            {
                try
                {
                    // 2. קריאה ל-BL כדי לקבל את המוצר הספציפי
                    BlApi.IBI bl = BlApi.Factory.Get();
                    var product = bl.product.Read(productId); // בהנחה שיש פונקציית Read שמקבלת ID

                    if (product != null)
                    {
                        // 3. הצגה בטבלה - ניצור רשימה זמנית שמכילה רק את המוצר הזה
                        dataGridView2.DataSource = new List<BO.Product> { product };
                    }
                    else
                    {
                        MessageBox.Show("מוצר לא נמצא.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה: " + ex.Message);
                }
            }
        }

        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // 1. בדיקה לפי השם המדויק מה-Designer: colDelete
        //    if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "colDelete")
        //    {
        //        try
        //        {
        //            // 2. חילוץ האובייקט של השורה הנוכחית (זו הדרך הכי בטוחה)
        //            var product = dataGridView2.Rows[e.RowIndex].DataBoundItem as BO.Product;

        //            if (product != null)
        //            {
        //                // 3. הצגת חלון אישור
        //                var result = MessageBox.Show($"האם אתה בטוח שברצונך למחוק את {product.ProductName}?",
        //                                           "אישור מחיקה",
        //                                           MessageBoxButtons.YesNo,
        //                                           MessageBoxIcon.Question);

        //                if (result == DialogResult.Yes)
        //                {
        //                    // 4. מחיקה ב-BL
        //                    BlApi.IBI bl = BlApi.Factory.Get();
        //                    bl.product.Delete(product.Id);

        //                    // 5. רענון הרשימה בטבלה
        //                    dataGridView2.DataSource = bl.product.ReadAll().ToList();

        //                    MessageBox.Show("המוצר נמחק בהצלחה!");
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("שגיאה במחיקה: " + ex.Message);
        //        }
        //    }
        //}



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // --- כפתור עריכה ---
            if (dataGridView2.Columns[e.ColumnIndex].Name == "colEdit")
            {
                var product = dataGridView2.Rows[e.RowIndex].DataBoundItem as BO.Product;
                if (product != null)
                {
                    // יצירת חלון קטן וזמני לעריכה
                    Form editForm = new Form();
                    editForm.Text = "עריכת מוצר";
                    editForm.Size = new Size(300, 400);
                    editForm.StartPosition = FormStartPosition.CenterParent;

                    // יצירת שדות (לדוגמה: שם ומחיר)
                    Label lblName = new Label() { Text = "שם מוצר:", Left = 10, Top = 20 };
                    TextBox txtName = new TextBox() { Text = product.ProductName, Left = 100, Top = 20, Width = 150 };

                    Label lblPrice = new Label() { Text = "מחיר:", Left = 10, Top = 60 };
                    TextBox txtPrice = new TextBox() { Text = product.Price.ToString(), Left = 100, Top = 60, Width = 150 };

                    Label lblId = new Label() { Text = $"קוד מוצר (לקריאה בלבד): {product.Id}", Left = 10, Top = 100, Width = 250 };

                    Button btnSave = new Button() { Text = "שמור שינויים", Left = 100, Top = 150, DialogResult = DialogResult.OK };

                    editForm.Controls.AddRange(new Control[] { lblName, txtName, lblPrice, txtPrice, lblId, btnSave });

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // עדכון הנתונים באובייקט
                            product.ProductName = txtName.Text;
                            product.Price = double.Parse(txtPrice.Text);

                            // קריאה ל-BL לעדכון
                            BlApi.IBI bl = BlApi.Factory.Get();
                            bl.product.Update(product);

                            // רענון הטבלה
                            dataGridView2.Refresh();
                            MessageBox.Show("המוצר עודכן בהצלחה!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("שגיאה בעדכון: " + ex.Message);
                        }
                    }
                }
            }

            // --- כפתור מחיקה ---
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "colDelete")
            {
                if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "colDelete")
                {
                    try
                    {
                        // 2. חילוץ האובייקט של השורה הנוכחית (זו הדרך הכי בטוחה)
                        var product = dataGridView2.Rows[e.RowIndex].DataBoundItem as BO.Product;

                        if (product != null)
                        {
                            // 3. הצגת חלון אישור
                            var result = MessageBox.Show($"האם אתה בטוח שברצונך למחוק את {product.ProductName}?",
                                                       "אישור מחיקה",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                // 4. מחיקה ב-BL
                                BlApi.IBI bl = BlApi.Factory.Get();
                                bl.product.Delete(product.Id);

                                // 5. רענון הרשימה בטבלה
                                dataGridView2.DataSource = bl.product.ReadAll().ToList();

                                MessageBox.Show("המוצר נמחק בהצלחה!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("שגיאה במחיקה: " + ex.Message);
                    }
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo == null || combo.SelectedItem == null) return;

            try
            {
                string selectedHebrew = combo.SelectedItem.ToString();
                string categoryInEnglish = "";

                // המרה של הבחירה בעברית לערך המקורי שקיים ב-DB (באנגלית)
                switch (selectedHebrew)
                {
                    case "פיצה": categoryInEnglish = "Piza"; break;
                    case "סלט": categoryInEnglish = "Salad"; break;
                    case "פסטה": categoryInEnglish = "Pasta"; break;
                    case "הום פרייז": categoryInEnglish = "HomeFrize"; break;
                    case "משקאות": categoryInEnglish = "Beverage"; break;
                    default: categoryInEnglish = selectedHebrew; break;
                }

                BlApi.IBI bl = BlApi.Factory.Get();
                var allProducts = bl.product.ReadAll();

                // עכשיו הסינון מתבצע לפי השם האנגלי שה-DB מכיר
                var filteredList = allProducts
                    .Where(p => p.category != null && p.category.ToString() == categoryInEnglish)
                    .ToList();

                dataGridView2.DataSource = null;
                if (filteredList.Any())
                {
                    dataGridView2.DataSource = filteredList;
                }
                else
                {
                    // הודעה ידידותית למשתמש בעברית
                    MessageBox.Show($"לא נמצאו מוצרים בקטגוריה: {selectedHebrew}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה: " + ex.Message);
            }
        }
        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // במקום להשתמש בשם comboBox1, נשתמש ב-sender ששלח את האירוע
        //    ComboBox combo = sender as ComboBox;

        //    // בדיקה שההמרה הצליחה ושיש פריט נבחר
        //    if (combo == null || combo.SelectedItem == null) return;

        //    try
        //    {
        //        string selectedValue = combo.SelectedItem.ToString();

        //        BlApi.IBI bl = BlApi.Factory.Get();
        //        var allProducts = bl.product.ReadAll();

        //        // סינון
        //        var filteredList = allProducts
        //            .Where(p => p.category != null && p.category.ToString() == selectedValue)
        //            .ToList();

        //        // עדכון הטבלה
        //        dataGridView2.DataSource = null;
        //        if (filteredList.Any())
        //        {
        //            dataGridView2.DataSource = filteredList;
        //        }
        //        else
        //        {
        //            MessageBox.Show($"לא נמצאו מוצרים בקטגוריה: {selectedValue}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("שגיאה: " + ex.Message);
        //    }
        //}


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        BlApi.IBI bl = BlApi.Factory.Get();
        //        var allProducts = bl.product.ReadAll();

        //        // בדיקה: האם הרשימה בכלל מכילה נתונים?
        //        if (allProducts == null || !allProducts.Any())
        //        {
        //            MessageBox.Show("הרשימה שהתקבלה מה-BL ריקה.");
        //            return;
        //        }

        //        // ניקוי והגדרת יצירה אוטומטית
        //        dataGridView2.DataSource = null;
        //        dataGridView2.AutoGenerateColumns = true; // זה יכריח את הטבלה להציג את כל ה-Properties
        //        dataGridView2.DataSource = allProducts.ToList();

        //        // רענון התצוגה
        //        dataGridView2.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("שגיאה בטעינת הנתונים: " + ex.Message);
        //    }
        //}
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

        //private void btnAddProduct_Click(object sender, EventArgs e)
        //{
        //    // יצירת חלון קלט חדש וריק
        //    Form addForm = new Form();
        //    addForm.Text = "הוספת מוצר חדש";
        //    addForm.Size = new Size(300, 450);
        //    addForm.StartPosition = FormStartPosition.CenterParent;

        //    // שדות להזנת נתונים
        //    Label lblName = new Label() { Text = "שם מוצר:", Left = 10, Top = 20 };
        //    TextBox txtName = new TextBox() { Left = 100, Top = 20, Width = 150 };

        //    Label lblPrice = new Label() { Text = "מחיר:", Left = 10, Top = 60 };
        //    TextBox txtPrice = new TextBox() { Left = 100, Top = 60, Width = 150 };

        //    Label lblCategory = new Label() { Text = "קטגוריה:", Left = 10, Top = 100 };
        //    ComboBox cmbCategory = new ComboBox() { Left = 100, Top = 100, Width = 150 };
        //    cmbCategory.DataSource = Enum.GetValues(typeof(BO.Category));

        //    Button btnSave = new Button() { Text = "הוסף מוצר", Left = 100, Top = 160, DialogResult = DialogResult.OK };

        //    addForm.Controls.AddRange(new Control[] { lblName, txtName, lblPrice, txtPrice, lblCategory, cmbCategory, btnSave });

        //    if (addForm.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            // יצירת אובייקט מוצר חדש
        //            BO.Product newProduct = new BO.Product()
        //            {
        //                ProductName = txtName.Text,
        //                Price = double.Parse(txtPrice.Text),
        //                category = (BO.Category)cmbCategory.SelectedItem
        //            };

        //            // קריאה ל-BL להוספה
        //            BlApi.IBI bl = BlApi.Factory.Get();
        //            bl.product.Create(newProduct);

        //            // רענון הטבלה כדי לראות את המוצר החדש
        //            dataGridView2.DataSource = bl.product.ReadAll().ToList();

        //            MessageBox.Show("המוצר נוסף בהצלחה!");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("שגיאה בהוספת מוצר: " + ex.Message);
        //        }
        //    }
        //}



        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // יצירת חלון קלט חדש
            Form addForm = new Form();
            addForm.Text = "הוספת מוצר חדש";
            addForm.Size = new Size(320, 300); // הקטנתי את הגובה כי היה הרבה רווח ריק
            addForm.StartPosition = FormStartPosition.CenterParent;

            // --- הוספת הגדרות ליישור לימין ---
            addForm.RightToLeft = RightToLeft.Yes;
            addForm.RightToLeftLayout = true;

            // שדות להזנת נתונים - שימי לב ששיניתי מעט את ה-Left כדי שלא ייצמדו לקצה
            Label lblName = new Label() { Text = "שם מוצר:", Left = 20, Top = 20, AutoSize = true };
            TextBox txtName = new TextBox() { Left = 100, Top = 20, Width = 150 };

            Label lblPrice = new Label() { Text = "מחיר:", Left = 20, Top = 60, AutoSize = true };
            TextBox txtPrice = new TextBox() { Left = 100, Top = 60, Width = 150 };

            Label lblCategory = new Label() { Text = "קטגוריה:", Left = 20, Top = 100, AutoSize = true };
            ComboBox cmbCategory = new ComboBox() { Left = 100, Top = 100, Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCategory.DataSource = Enum.GetValues(typeof(BO.Category));

            // כפתור הוספה - מרכזתי אותו לפי רוחב הטופס
            Button btnSave = new Button()
            {
                Text = "הוסף מוצר",
                Left = 100,
                Top = 160,
                Width = 100,
                Height = 30,
                DialogResult = DialogResult.OK
            };

            addForm.Controls.AddRange(new Control[] { lblName, txtName, lblPrice, txtPrice, lblCategory, cmbCategory, btnSave });

            // הגדרת כפתור ברירת מחדל (לחיצה על Enter תפעיל אותו)
            addForm.AcceptButton = btnSave;

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                    {
                        throw new Exception("חובה למלא שם ומחיר");
                    }

                    BO.Product newProduct = new BO.Product()
                    {
                        ProductName = txtName.Text,
                        Price = double.Parse(txtPrice.Text),
                        category = (BO.Category)cmbCategory.SelectedItem
                    };

                    BlApi.IBI bl = BlApi.Factory.Get();
                    bl.product.Create(newProduct);

                    dataGridView2.DataSource = bl.product.ReadAll().ToList();
                    MessageBox.Show("המוצר נוסף בהצלחה!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה: " + ex.Message);
                }
            }
        }
    }
}

