namespace UI
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddCustomerButton = new Button();
            CustomerUpdateButton = new Button();
            DeleteCustomerButton = new Button();
            ShowAllCustomersButton = new Button();
            ShowCustomerButton = new Button();
            rbRegularCustomer = new RadioButton();
            rbClubMember = new RadioButton();
            groupBoxRegular_club = new GroupBox();
            panelAdd = new Panel();
            checkBoxJoiningTheClub = new CheckBox();
            ToAddCustomerButton = new Button();
            textBoxAddress = new TextBox();
            textBoxPhone = new TextBox();
            textBox_ID = new TextBox();
            textBoxName = new TextBox();
            labelPhone = new Label();
            label_ID = new Label();
            labelAddress = new Label();
            labelName = new Label();
            panelAdd.SuspendLayout();
            SuspendLayout();
            // 
            // AddCustomerButton
            // 
            AddCustomerButton.Location = new Point(625, 56);
            AddCustomerButton.Name = "AddCustomerButton";
            AddCustomerButton.Size = new Size(104, 34);
            AddCustomerButton.TabIndex = 0;
            AddCustomerButton.Text = "הוספה";
            AddCustomerButton.UseVisualStyleBackColor = true;
            AddCustomerButton.Click += AddCustomerButton_Click;
            // 
            // CustomerUpdateButton
            // 
            CustomerUpdateButton.Location = new Point(625, 96);
            CustomerUpdateButton.Name = "CustomerUpdateButton";
            CustomerUpdateButton.Size = new Size(104, 34);
            CustomerUpdateButton.TabIndex = 1;
            CustomerUpdateButton.Text = "עדכון";
            CustomerUpdateButton.UseVisualStyleBackColor = true;
            //CustomerUpdateButton.Click += CustomerUpdateButton_Click;
            // 
            // DeleteCustomerButton
            // 
            DeleteCustomerButton.Location = new Point(625, 136);
            DeleteCustomerButton.Name = "DeleteCustomerButton";
            DeleteCustomerButton.Size = new Size(104, 34);
            DeleteCustomerButton.TabIndex = 2;
            DeleteCustomerButton.Text = "מחיקה";
            DeleteCustomerButton.UseVisualStyleBackColor = true;
            //DeleteCustomerButton.Click += DeleteCustomerButton_Click;
            // 
            // ShowAllCustomersButton
            // 
            ShowAllCustomersButton.Location = new Point(625, 176);
            ShowAllCustomersButton.Name = "ShowAllCustomersButton";
            ShowAllCustomersButton.Size = new Size(104, 34);
            ShowAllCustomersButton.TabIndex = 3;
            ShowAllCustomersButton.Text = "הצג הכל";
            ShowAllCustomersButton.UseVisualStyleBackColor = true;
            //ShowAllCustomersButton.Click += ShowAllCustomersButton_Click;
            // 
            // ShowCustomerButton
            // 
            ShowCustomerButton.Location = new Point(625, 216);
            ShowCustomerButton.Name = "ShowCustomerButton";
            ShowCustomerButton.Size = new Size(104, 34);
            ShowCustomerButton.TabIndex = 4;
            ShowCustomerButton.Text = "הצג בודד";
            ShowCustomerButton.UseVisualStyleBackColor = true;
            //ShowCustomerButton.Click += ShowCustomerButton_Click;
            // 
            // rbRegularCustomer
            // 
            rbRegularCustomer.AutoSize = true;
            rbRegularCustomer.Location = new Point(615, 307);
            rbRegularCustomer.Name = "rbRegularCustomer";
            rbRegularCustomer.RightToLeft = RightToLeft.Yes;
            rbRegularCustomer.Size = new Size(114, 29);
            rbRegularCustomer.TabIndex = 5;
            rbRegularCustomer.TabStop = true;
            rbRegularCustomer.Text = "לקוח רגיל";
            rbRegularCustomer.UseVisualStyleBackColor = true;
            //rbRegularCustomer.CheckedChanged += rbRegularCustomer_CheckedChanged;
            // 
            // rbClubMember
            // 
            rbClubMember.AutoSize = true;
            rbClubMember.Location = new Point(601, 342);
            rbClubMember.Name = "rbClubMember";
            rbClubMember.RightToLeft = RightToLeft.Yes;
            rbClubMember.Size = new Size(128, 29);
            rbClubMember.TabIndex = 6;
            rbClubMember.TabStop = true;
            rbClubMember.Text = "לקוח מועדון";
            rbClubMember.UseVisualStyleBackColor = true;
            //rbClubMember.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // groupBoxRegular_club
            // 
            groupBoxRegular_club.Location = new Point(575, 270);
            groupBoxRegular_club.Name = "groupBoxRegular_club";
            groupBoxRegular_club.Size = new Size(176, 31);
            groupBoxRegular_club.TabIndex = 7;
            groupBoxRegular_club.TabStop = false;
            groupBoxRegular_club.Text = "סנן לפי חברי מועדון";
            // 
            // panelAdd
            // 
            panelAdd.Controls.Add(checkBoxJoiningTheClub);
            panelAdd.Controls.Add(ToAddCustomerButton);
            panelAdd.Controls.Add(textBoxAddress);
            panelAdd.Controls.Add(textBoxPhone);
            panelAdd.Controls.Add(textBox_ID);
            panelAdd.Controls.Add(textBoxName);
            panelAdd.Controls.Add(labelPhone);
            panelAdd.Controls.Add(label_ID);
            panelAdd.Controls.Add(labelAddress);
            panelAdd.Controls.Add(labelName);
            panelAdd.Location = new Point(69, 56);
            panelAdd.Name = "panelAdd";
            panelAdd.Size = new Size(405, 332);
            panelAdd.TabIndex = 8;
            panelAdd.Visible = false;
            //panelAdd.Paint += panelAdd_Paint;
            // 
            // checkBoxJoiningTheClub
            // 
            checkBoxJoiningTheClub.AutoSize = true;
            checkBoxJoiningTheClub.Location = new Point(159, 201);
            checkBoxJoiningTheClub.Name = "checkBoxJoiningTheClub";
            checkBoxJoiningTheClub.RightToLeft = RightToLeft.Yes;
            checkBoxJoiningTheClub.Size = new Size(85, 29);
            checkBoxJoiningTheClub.TabIndex = 9;
            checkBoxJoiningTheClub.Text = "מועדון";
            checkBoxJoiningTheClub.UseVisualStyleBackColor = true;
            //checkBoxJoiningTheClub.CheckedChanged += checkBoxJoiningTheClub_CheckedChanged;
            // 
            // ToAddCustomerButton
            // 
            ToAddCustomerButton.Location = new Point(159, 251);
            ToAddCustomerButton.Name = "ToAddCustomerButton";
            ToAddCustomerButton.Size = new Size(112, 34);
            ToAddCustomerButton.TabIndex = 8;
            ToAddCustomerButton.Text = "להוספה";
            ToAddCustomerButton.UseVisualStyleBackColor = true;
            ToAddCustomerButton.Click += ToAddCustomerButton_Click;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(83, 76);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(150, 31);
            textBoxAddress.TabIndex = 7;
            //textBoxAddress.TextChanged += textBoxAddress_TextChanged;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(83, 150);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(150, 31);
            textBoxPhone.TabIndex = 6;
            //textBoxPhone.TextChanged += textBoxPhone_TextChanged;
            // 
            // textBox_ID
            // 
            textBox_ID.Location = new Point(83, 113);
            textBox_ID.Name = "textBox_ID";
            textBox_ID.Size = new Size(150, 31);
            textBox_ID.TabIndex = 5;
            //textBox_ID.TextChanged += textBox_ID_TextChanged;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(83, 39);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(150, 31);
            textBoxName.TabIndex = 4;
            //textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // labelPhone
            // 
            labelPhone.AllowDrop = true;
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(248, 156);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(55, 25);
            labelPhone.TabIndex = 3;
            labelPhone.Text = "טלפון";
            //labelPhone.Click += labelPhone_Click;
            // 
            // label_ID
            // 
            label_ID.AllowDrop = true;
            label_ID.AutoSize = true;
            label_ID.Location = new Point(248, 119);
            label_ID.Name = "label_ID";
            label_ID.Size = new Size(98, 25);
            label_ID.TabIndex = 2;
            label_ID.Text = "מספר זהות";
            //label_ID.Click += label_ID_Click;
            // 
            // labelAddress
            // 
            labelAddress.AllowDrop = true;
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(248, 82);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(63, 25);
            labelAddress.TabIndex = 1;
            labelAddress.Text = "כתובת";
            //labelAddress.Click += labelAddress_Click;
            // 
            // labelName
            // 
            labelName.AllowDrop = true;
            labelName.AutoSize = true;
            labelName.Location = new Point(248, 45);
            labelName.Name = "labelName";
            labelName.Size = new Size(38, 25);
            labelName.TabIndex = 0;
            labelName.Text = "שם";
            //labelName.Click += labelName_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelAdd);
            Controls.Add(groupBoxRegular_club);
            Controls.Add(rbClubMember);
            Controls.Add(rbRegularCustomer);
            Controls.Add(ShowCustomerButton);
            Controls.Add(ShowAllCustomersButton);
            Controls.Add(DeleteCustomerButton);
            Controls.Add(CustomerUpdateButton);
            Controls.Add(AddCustomerButton);
            Name = "CustomerForm";
            Text = "CustomerForm";
            panelAdd.ResumeLayout(false);
            panelAdd.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddCustomerButton;
        private Button CustomerUpdateButton;
        private Button DeleteCustomerButton;
        private Button ShowAllCustomersButton;
        private Button ShowCustomerButton;
        private RadioButton rbRegularCustomer;
        private RadioButton rbClubMember;
        private GroupBox groupBoxRegular_club;
        private Panel panelAdd;
        private Label labelName;
        private Label labelAddress;
        private Label label_ID;
        private Label labelPhone;
        private TextBox textBoxAddress;
        private TextBox textBoxPhone;
        private TextBox textBox_ID;
        private TextBox textBoxName;
        private Button ToAddCustomerButton;
        private CheckBox checkBoxJoiningTheClub;
    }
}