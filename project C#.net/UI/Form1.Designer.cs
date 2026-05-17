namespace UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ManagerButton = new Button();
            shopperButton = new Button();
            SuspendLayout();
            // 
            // ManagerButton
            // 
            ManagerButton.Location = new Point(481, 304);
            ManagerButton.Margin = new Padding(3, 4, 3, 4);
            ManagerButton.Name = "ManagerButton";
            ManagerButton.Size = new Size(143, 104);
            ManagerButton.TabIndex = 0;
            ManagerButton.Text = "מנהל";
            ManagerButton.UseVisualStyleBackColor = true;
            ManagerButton.Click += button1_Click;
            // 
            // shopperButton
            // 
            shopperButton.Location = new Point(246, 316);
            shopperButton.Margin = new Padding(3, 4, 3, 4);
            shopperButton.Name = "shopperButton";
            shopperButton.Size = new Size(147, 92);
            shopperButton.TabIndex = 1;
            shopperButton.Text = "קופאי";
            shopperButton.UseVisualStyleBackColor = true;
            shopperButton.Click += shopperButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(shopperButton);
            Controls.Add(ManagerButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button ManagerButton;
        private Button shopperButton;
    }
}