namespace UI
{
    partial class ManagerForm
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
            salesButtonForm = new Button();
            cusomersButtonForm = new Button();
            productsbuttonForm = new Button();
            SuspendLayout();
            // 
            // salesButtonForm
            // 
            salesButtonForm.Location = new Point(270, 109);
            salesButtonForm.Name = "salesButtonForm";
            salesButtonForm.Size = new Size(114, 50);
            salesButtonForm.TabIndex = 0;
            salesButtonForm.Text = "מבצעים";
            salesButtonForm.UseVisualStyleBackColor = true;
            // 
            // cusomersButtonForm
            // 
            cusomersButtonForm.Location = new Point(555, 107);
            cusomersButtonForm.Name = "cusomersButtonForm";
            cusomersButtonForm.Size = new Size(87, 38);
            cusomersButtonForm.TabIndex = 1;
            cusomersButtonForm.Text = "לקוחות";
            cusomersButtonForm.UseVisualStyleBackColor = true;
            cusomersButtonForm.Click += cusomersButtonForm_Click;
            // 
            // productsbuttonForm
            // 
            productsbuttonForm.Location = new Point(423, 108);
            productsbuttonForm.Name = "productsbuttonForm";
            productsbuttonForm.Size = new Size(94, 37);
            productsbuttonForm.TabIndex = 1;
            productsbuttonForm.Text = "מוצרים";
            productsbuttonForm.UseVisualStyleBackColor = true;
            productsbuttonForm.Click += productsbuttonForm_Click;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(productsbuttonForm);
            Controls.Add(cusomersButtonForm);
            Controls.Add(salesButtonForm);
            Name = "ManagerForm";
            Text = "ManagerForm";
            ResumeLayout(false);
        }

        #endregion

        private Button salesButtonForm;
        private Button cusomersButtonForm;
        private Button productsbuttonForm;
    }
}