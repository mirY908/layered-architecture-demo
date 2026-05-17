namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerForm managerForm = new ManagerForm();
            this.Hide();
            managerForm.FormClosed += ManagerForm_FormClosed;
            managerForm.Show();
        }

        private void ManagerForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void shopperButton_Click(object sender, EventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            this.Hide();
            cartWindow.FormClosed += ManagerForm_FormClosed;
            cartWindow.Show();
        }
    }
}