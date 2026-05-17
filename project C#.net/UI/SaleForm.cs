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
    public partial class SaleForm : Form
    {
        public SaleForm()
        {
            InitializeComponent();
            SalesData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void ShowAllSales(object sender, EventArgs e)
        {

        }
        private void Show_all_sales_Click(object sender, EventArgs e)
        {

        }

        private void Show_all_sales_Click_1(object sender, EventArgs e)
        {

            try
            {
                // 1. יצירת המופע (שימי לב לשם המשתנה bl)
                BlApi.IBI bl = BlApi.Factory.Get();

                // 2. קריאה לנתונים דרך המשתנה bl שיצרנו הרגע
                // אנחנו ניגשים ל-Product שנמצא בתוך ה-bl
                var allSales = bl.sale.ReadAll();

                // 3. הצגה בטבלה
                SalesData.DataSource = null;
                SalesData.DataSource = allSales.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הנתונים: " + ex.Message);
            }
        }

        private void Add_sale_Click(object sender, EventArgs e)
        {
            // יצירת חלון קלט חדש
            Form saleForm = new Form();
            saleForm.Text = "הוספת מבצע חדש";
            saleForm.Size = new Size(350, 500);
            saleForm.StartPosition = FormStartPosition.CenterParent;

            // הגדרת פקדים (Labels ו-Inputs)
            // Label lblProductId = new Label() { Text = "מזהה מוצר:", Left = 10, Top = 20, Width = 100 };
            //NumericUpDown numProductId = new NumericUpDown() { Left = 120, Top = 20, Width = 150 };

            Label lblMinQty = new Label() { Text = "כמות מינימום:", Left = 10, Top = 60, Width = 100 };
            NumericUpDown numMinQty = new NumericUpDown() { Left = 120, Top = 60, Width = 150 };

            Label lblPrice = new Label() { Text = "מחיר מבצע:", Left = 10, Top = 100, Width = 100 };
            TextBox txtPrice = new TextBox() { Left = 120, Top = 100, Width = 150 };

            Label lblEveryone = new Label() { Text = "לכולם?", Left = 10, Top = 140, Width = 100 };
            CheckBox chkEveryone = new CheckBox() { Left = 120, Top = 140 };

            Label lblStart = new Label() { Text = "תאריך התחלה:", Left = 10, Top = 180, Width = 100 };
            DateTimePicker dtpStart = new DateTimePicker() { Left = 120, Top = 180, Width = 180 };

            Label lblEnd = new Label() { Text = "תאריך סיום:", Left = 10, Top = 220, Width = 100 };
            DateTimePicker dtpEnd = new DateTimePicker() { Left = 120, Top = 220, Width = 180 };

            Button btnSave = new Button() { Text = "שמור מבצע", Left = 120, Top = 280, Width = 100, DialogResult = DialogResult.OK };

            // הוספת הפקדים לטופס
            saleForm.Controls.AddRange(new Control[] {
       // lblProductId, numProductId,
        lblMinQty, numMinQty,
        lblPrice, txtPrice,
        lblEveryone, chkEveryone,
        lblStart, dtpStart,
        lblEnd, dtpEnd,
        btnSave
    });

            // הצגת החלון וביצוע הלוגיקה
            if (saleForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // יצירת אובייקט המבצע
                    BO.Sale newSale = new BO.Sale()
                    {
                        // ProductId = (int)numProductId.Value,
                        MinProductSale = (int)numMinQty.Value,
                        SumPriceSale = double.Parse(txtPrice.Text),
                        IfEveryOne = chkEveryone.Checked,
                        StartSale = dtpStart.Value,
                        EndSale = dtpEnd.Value
                    };

                    // קריאה לשכבת ה-BL (יש לוודא שקיימת פונקציה מתאימה ב-API שלך)
                    BlApi.IBI bl = BlApi.Factory.Get();
                    bl.sale.Create(newSale);

                    // רענון התצוגה במידת הצורך
                    // dataGridViewSales.DataSource = bl.sale.ReadAll().ToList();

                    MessageBox.Show("המבצע נוסף בהצלחה!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה בהוספת המבצע: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. נבקש מהמשתמש להקיש ID (כאן אני משתמש בתיבה פשוטה של VB לצורך הדוגמה)
            string input = Microsoft.VisualBasic.Interaction.InputBox("הקש קוד מבצע לחיפוש:", "חיפוש מבצע", "");

            if (int.TryParse(input, out int Id))
            {
                try
                {
                    // 2. קריאה ל-BL כדי לקבל את המוצר הספציפי
                    BlApi.IBI bl = BlApi.Factory.Get();
                    var sale = bl.sale.Read(Id); // בהנחה שיש פונקציית Read שמקבלת ID

                    if (sale != null)
                    {
                        // 3. הצגה בטבלה - ניצור רשימה זמנית שמכילה רק את המוצר הזה
                        SalesData.DataSource = new List<BO.Sale> { sale };
                    }
                    else
                    {
                        MessageBox.Show("מבצע לא נמצא.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה: " + ex.Message);
                }
            }
        }

        private void Delete_sale_Click(object sender, EventArgs e)
        {
            Form inputForm = new Form();
            inputForm.Text = "מחיקת מבצע";
            inputForm.Size = new Size(300, 150);
            inputForm.StartPosition = FormStartPosition.CenterParent;

            Label lblId = new Label() { Text = "הקש קוד מבצע למחיקה:", Left = 10, Top = 20, Width = 200 };

            // תיקון כאן: הוספת Maximum ושינוי ה-Width כדי שיהיה מקום למספרים גדולים
            NumericUpDown numId = new NumericUpDown()
            {
                Left = 10,
                Top = 50,
                Width = 120,
                Maximum = 1000000 // הגדלנו את המקסימום למיליון (או כל מספר שתרצי)
            };

            Button btnConfirm = new Button() { Text = "מחק", Left = 150, Top = 48, Width = 80, DialogResult = DialogResult.OK };

            inputForm.Controls.AddRange(new Control[] { lblId, numId, btnConfirm });

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                int idToDelete = (int)numId.Value;

                var confirmResult = MessageBox.Show($"האם אתה בטוח שברצונך למחוק את מבצע {idToDelete}?",
                                             "אישור מחיקה",
                                             MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        BlApi.IBI bl = BlApi.Factory.Get();
                        bl.sale.Delete(idToDelete);
                        MessageBox.Show("המבצע נמחק בהצלחה!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("שגיאה במחיקה: " + ex.Message);
                    }
                }
            }
        }

        private void SalesData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SalesData.Columns[e.ColumnIndex].Name == "EditSale") // וודאי שזה שם העמודה של הכפתור
            {
                var sale = SalesData.Rows[e.RowIndex].DataBoundItem as BO.Sale;
                if (sale != null)
                {
                    // יצירת חלון קטן וזמני לעריכה
                    Form editForm = new Form();
                    editForm.Text = "עריכת מבצע";
                    editForm.Size = new Size(350, 500);
                    editForm.StartPosition = FormStartPosition.CenterParent;

                    // --- יצירת שדות העריכה ---

                    // קוד מוצר (בדרך כלל לא עורכים ID של מוצר במבצע קיים, אבל אפשר להשאיר כתיבת טקסט)
                    //Label lblProdId = new Label() { Text = "קוד מוצר:", Left = 10, Top = 20, Width = 100 };
                    //NumericUpDown numProdId = new NumericUpDown() { Value = sale.ProductId, Left = 120, Top = 20, Width = 150, Maximum = 1000000 };
                    Label lblProdId = new Label() { Text = "קוד מוצר:", Left = 10, Top = 20, Width = 100 };

                    NumericUpDown numProdId = new NumericUpDown()
                    {
                        Maximum = 1000000,      // קודם כל מגדילים את הגבול המקסימלי
                        Value = sale.ProductId, // ורק אז מציבים את הערך (כדי שלא יחרוג מהגבול)
                        Left = 120,
                        Top = 20,
                        Width = 150
                    };
                    // כמות מינימום
                    Label lblMinQty = new Label() { Text = "כמות מינימום:", Left = 10, Top = 60, Width = 100 };
                    NumericUpDown numMinQty = new NumericUpDown() { Value = sale.MinProductSale ?? 0, Left = 120, Top = 60, Width = 150 };

                    // מחיר מבצע
                    Label lblPrice = new Label() { Text = "מחיר מבצע:", Left = 10, Top = 100, Width = 100 };
                    TextBox txtPrice = new TextBox() { Text = sale.SumPriceSale.ToString(), Left = 120, Top = 100, Width = 150 };

                    // האם לכולם
                    Label lblEveryone = new Label() { Text = "לכולם?", Left = 10, Top = 140, Width = 100 };
                    CheckBox chkEveryone = new CheckBox() { Checked = sale.IfEveryOne, Left = 120, Top = 140 };

                    // תאריך התחלה
                    Label lblStart = new Label() { Text = "תאריך התחלה:", Left = 10, Top = 180, Width = 100 };
                    DateTimePicker dtpStart = new DateTimePicker() { Value = sale.StartSale, Left = 120, Top = 180, Width = 180 };

                    // תאריך סיום
                    Label lblEnd = new Label() { Text = "תאריך סיום:", Left = 10, Top = 220, Width = 100 };
                    DateTimePicker dtpEnd = new DateTimePicker() { Value = sale.EndSale, Left = 120, Top = 220, Width = 180 };

                    // הצגת ה-ID של המבצע (לקריאה בלבד)
                    Label lblId = new Label() { Text = $"קוד מבצע: {sale.Id}", Left = 10, Top = 260, Width = 250, ForeColor = Color.Gray };

                    Button btnSave = new Button() { Text = "שמור שינויים", Left = 120, Top = 310, Width = 100, DialogResult = DialogResult.OK };

                    // הוספת פקדים לטופס
                    editForm.Controls.AddRange(new Control[] {
            lblProdId, numProdId,
            lblMinQty, numMinQty,
            lblPrice, txtPrice,
            lblEveryone, chkEveryone,
            lblStart, dtpStart,
            lblEnd, dtpEnd,
            lblId, btnSave
        });

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // עדכון הנתונים באובייקט המקומי
                            sale.ProductId = (int)numProdId.Value;
                            sale.MinProductSale = (int)numMinQty.Value;
                            sale.SumPriceSale = double.Parse(txtPrice.Text);
                            sale.IfEveryOne = chkEveryone.Checked;
                            sale.StartSale = dtpStart.Value;
                            sale.EndSale = dtpEnd.Value;

                            // קריאה ל-BL לעדכון
                            BlApi.IBI bl = BlApi.Factory.Get();
                            bl.sale.Update(sale);

                            // רענון הטבלה
                            SalesData.Refresh();
                            MessageBox.Show("המבצע עודכן בהצלחה!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("שגיאה בעדכון המבצע: " + ex.Message);
                        }
                    }
                }
            }
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BlApi.IBI bl = BlApi.Factory.Get();
        //    var allSales = bl.sale.ReadAll(); // קבלת כל המבצעים

        //    IEnumerable<BO.Sale> sortedSales;

        //    switch (comboBox1.SelectedItem.ToString())
        //    {
        //        case "מחיר (זול ליקר)":
        //            sortedSales = allSales.OrderBy(s => s.SumPriceSale);
        //            break;
        //        case "מחיר (יקר לזול)":
        //            sortedSales = sortedSales = allSales.OrderByDescending(s => s.SumPriceSale);
        //            break;
        //        case "תאריך התחלה":
        //            sortedSales = allSales.OrderBy(s => s.StartSale);
        //            break;
        //        case "קוד מוצר":
        //            sortedSales = allSales.OrderBy(s => s.ProductId);
        //            break;
        //        default:
        //            sortedSales = allSales;
        //            break;
        //    }

        //    // עדכון הטבלה עם הרשימה הממוינת
        //    SalesData.DataSource = sortedSales.ToList();
        //}
    }
}
