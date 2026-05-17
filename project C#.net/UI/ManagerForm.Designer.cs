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
            salesButtonForm.Location = new Point(309, 145);
            salesButtonForm.Margin = new Padding(3, 4, 3, 4);
            salesButtonForm.Name = "salesButtonForm";
            salesButtonForm.Size = new Size(130, 67);
            salesButtonForm.TabIndex = 0;
            salesButtonForm.Text = "מבצעים";
            salesButtonForm.UseVisualStyleBackColor = true;
            salesButtonForm.Click += salesButtonForm_Click;
            // 
            // cusomersButtonForm
            // 
            cusomersButtonForm.Location = new Point(634, 143);
            cusomersButtonForm.Margin = new Padding(3, 4, 3, 4);
            cusomersButtonForm.Name = "cusomersButtonForm";
            cusomersButtonForm.Size = new Size(99, 51);
            cusomersButtonForm.TabIndex = 1;
            cusomersButtonForm.Text = "לקוחות";
            cusomersButtonForm.UseVisualStyleBackColor = true;
            cusomersButtonForm.Click += cusomersButtonForm_Click;
            // 
            // productsbuttonForm
            // 
            productsbuttonForm.Location = new Point(483, 144);
            productsbuttonForm.Margin = new Padding(3, 4, 3, 4);
            productsbuttonForm.Name = "productsbuttonForm";
            productsbuttonForm.Size = new Size(107, 49);
            productsbuttonForm.TabIndex = 1;
            productsbuttonForm.Text = "מוצרים";
            productsbuttonForm.UseVisualStyleBackColor = true;
            productsbuttonForm.Click += productsbuttonForm_Click;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(productsbuttonForm);
            Controls.Add(cusomersButtonForm);
            Controls.Add(salesButtonForm);
            Margin = new Padding(3, 4, 3, 4);
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