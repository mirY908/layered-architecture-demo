//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//namespace UI
//{
//    public partial class CustomerForm : Form
//    {
//        public CustomerForm()
//        {
//            InitializeComponent();
//        }

//        private void AddCustomerButton_Click(object sender, EventArgs e)
//        {
//            panelAdd.Visible = true;
//            textBoxName.Clear();
//            textBox_ID.Clear();
//            textBoxAddress.Clear();
//            textBoxPhone.Clear();
//            checkBoxJoiningTheClub.Checked = false;
//        }

//        private void CustomerUpdateButton_Click(object sender, EventArgs e)
//        {

//        }

//        private void DeleteCustomerButton_Click(object sender, EventArgs e)
//        {

//        }

//        private void ShowAllCustomersButton_Click(object sender, EventArgs e)
//        {

//        }

//        private void ShowCustomerButton_Click(object sender, EventArgs e)
//        {

//        }

//        private void rbRegularCustomer_CheckedChanged(object sender, EventArgs e)
//        {

//        }

//        private void radioButton1_CheckedChanged(object sender, EventArgs e)
//        {

//        }

//        private void panelAdd_Paint(object sender, PaintEventArgs e)
//        {

//        }

//        private void labelName_Click(object sender, EventArgs e)
//        {

//        }

//        private void labelAddress_Click(object sender, EventArgs e)
//        {

//        }

//        private void label_ID_Click(object sender, EventArgs e)
//        {

//        }

//        private void labelPhone_Click(object sender, EventArgs e)
//        {

//        }

//        private void textBoxName_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void textBoxAddress_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void textBox_ID_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void textBoxPhone_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void checkBoxJoiningTheClub_CheckedChanged(object sender, EventArgs e)
//        {

//        }

//        private void ToAddCustomerButton_Click(object sender, EventArgs e)
//        {
//            // 1. כאן את יכולה להוסיף את הלוגיקה לשמירת הנתונים
//            // למשל: שליחת הנתונים למחלקה שמנהלת את הלקוחות

//            // בדיקה שהשדות לא ריקים
//            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
//                string.IsNullOrWhiteSpace(textBox_ID.Text) ||
//                string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
//                string.IsNullOrWhiteSpace(textBoxPhone.Text))
//            {
//                MessageBox.Show("נא למלא את כל שדות החובה (שם, כתובת, תעודת זהות וטלפון).");
//                return; // עוצר את הפונקציה כאן ולא ממשיך להוספה
//            }

//            // בדיקה שהשם מכיל רק אותיות (ורווחים)
//            if (!textBoxName.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
//            {
//                MessageBox.Show("נא להזין בשם אותיות בלבד.");
//                return;
//            }

//            // בדיקה שהכתובת מכילה רק אותיות, מספרים או רווחים
//            if(!textBoxAddress.Text.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)) || !textBoxAddress.Text.Any(char.IsLetter))
//            {
//                    MessageBox.Show("הכתובת חייבת להכיל אותיות .");
//                    return;
//            }

//            // בדיקה שמספר הזהות והטלפון מכילים רק מספרים
//            if (!textBox_ID.Text.All(char.IsDigit))
//            {
//                MessageBox.Show("במספר זהות יש להזין מספרים בלבד.");
//                return;
//            }

//            if (!textBoxPhone.Text.All(char.IsDigit))
//            {
//                MessageBox.Show("טלפון יש להזין מספרים בלבד.");
//                return;
//            }




//            MessageBox.Show("הלקוח נוסף בהצלחה!");
//            panelAdd.Visible = false;
//        }


//    }
//}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi; // הכרחי כדי שהקוד יזהה את Factory ו-IBl
using BO;

namespace UI
{
    public partial class CustomerForm : Form
    {
        // הגדרת החיבור לשכבת הלוגיקה - זה מה שמאפשר שמירה ל-XML
        readonly IBI s_Bl = Factory.Get();

        public CustomerForm()
        {
            InitializeComponent();
        }

        // כפתור שפותח את פאנל ההוספה ומנקה שדות
        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            panelAdd.Visible = true;
            textBoxName.Clear();
            textBox_ID.Clear();
            textBoxAddress.Clear();
            textBoxPhone.Clear();
            checkBoxJoiningTheClub.Checked = false;
        }

        // כפתור השמירה הסופי שנמצא בתוך הפאנל
        private void ToAddCustomerButton_Click(object sender, EventArgs e)
        {
            // --- בדיקות תקינות נתונים ---

            // 1. בדיקה ששדות חובה אינם ריקים
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBox_ID.Text) ||
                string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("נא למלא את כל שדות החובה.");
                return;
            }

            // 2. בדיקה שהשם מכיל רק אותיות ורווחים
            if (!textBoxName.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("נא להזין בשם אותיות בלבד.");
                return;
            }

            // 3. בדיקה שהכתובת תקינה (אותיות ומספרים, ללא תווים מוזרים, וחייבת להכיל אותיות)
            if (!textBoxAddress.Text.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)) || !textBoxAddress.Text.Any(char.IsLetter))
            {
                MessageBox.Show("הכתובת חייבת להכיל אותיות (ניתן לשלב מספרים), ללא סימנים מיוחדים.");
                return;
            }

            // 4. בדיקה שתעודת זהות וטלפון מכילים ספרות בלבד
            if (!textBox_ID.Text.All(char.IsDigit) || !textBoxPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("במספר זהות וטלפון יש להזין מספרים בלבד.");
                return;
            }

            // --- שלב השמירה ל-XML ---
           
                try
                {
                    // יצירת אובייקט לקוח עם השמות המדויקים מהמחלקה שלך
                    BO.Customer newCustomer = new BO.Customer
                    {
                        ClientId = int.Parse(textBox_ID.Text), // השם אצלך הוא ClientId
                        ClientName = textBoxName.Text,         // השם אצלך הוא ClientName
                        Adress = textBoxAddress.Text,          // שימי לב: אצלך כתוב Adress עם s אחת!
                        phone = textBoxPhone.Text,              // אצלך זה phone באות קטנה
                        IsClubMember = checkBoxJoiningTheClub.Checked
                    };


                    // קריאה לשכבת ה-BL שתבצע את השמירה בפועל לקובץ ה-XML
                    s_Bl.customer.Create(newCustomer);

                MessageBox.Show("הלקוח נוסף בהצלחה!");
                    panelAdd.Visible = false;
                }
                catch (Exception ex)
                {
                    // כאן נתפוס שגיאות כמו "לקוח כבר קיים" שחוזרות מה-BL
                    MessageBox.Show("שגיאה: " + ex.Message);
                }
          
        }

    }
}

