namespace UI
{
    partial class SaleForm
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
            SalesData = new DataGridView();
            colEditSale = new DataGridViewTextBoxColumn();
            ProductId = new DataGridViewTextBoxColumn();
            SumPriceSale = new DataGridViewTextBoxColumn();
            MinProductSale = new DataGridViewTextBoxColumn();
            StartSale = new DataGridViewTextBoxColumn();
            EndSale = new DataGridViewTextBoxColumn();
            IfEveryOne = new DataGridViewTextBoxColumn();
            EditSale = new DataGridViewButtonColumn();
            Show_all_sales = new Button();
            Add_sale = new Button();
            button1 = new Button();
            Delete_sale = new Button();
            ((System.ComponentModel.ISupportInitialize)SalesData).BeginInit();
            SuspendLayout();
            // 
            // SalesData
            // 
            SalesData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SalesData.Columns.AddRange(new DataGridViewColumn[] { colEditSale, ProductId, SumPriceSale, MinProductSale, StartSale, EndSale, IfEveryOne, EditSale });
            SalesData.Location = new Point(11, 152);
            SalesData.Name = "SalesData";
            SalesData.RowHeadersWidth = 51;
            SalesData.Size = new Size(777, 209);
            SalesData.TabIndex = 0;
            SalesData.CellContentClick += SalesData_CellContentClick;
            // 
            // colEditSale
            // 
            colEditSale.DataPropertyName = "Id";
            colEditSale.HeaderText = "קוד מבצע";
            colEditSale.MinimumWidth = 6;
            colEditSale.Name = "colEditSale";
            colEditSale.Width = 125;
            // 
            // ProductId
            // 
            ProductId.DataPropertyName = "ProductId";
            ProductId.HeaderText = "קוד מוצר";
            ProductId.MinimumWidth = 6;
            ProductId.Name = "ProductId";
            ProductId.Width = 125;
            // 
            // SumPriceSale
            // 
            SumPriceSale.DataPropertyName = "SumPriceSale";
            SumPriceSale.HeaderText = "מחיר מבצע";
            SumPriceSale.MinimumWidth = 6;
            SumPriceSale.Name = "SumPriceSale";
            SumPriceSale.Width = 125;
            // 
            // MinProductSale
            // 
            MinProductSale.DataPropertyName = "SumPriceSale";
            MinProductSale.HeaderText = "כמות מינימום לרכישה";
            MinProductSale.MinimumWidth = 6;
            MinProductSale.Name = "MinProductSale";
            MinProductSale.Width = 125;
            // 
            // StartSale
            // 
            StartSale.DataPropertyName = "StartSale";
            StartSale.HeaderText = "תאריך התחלה";
            StartSale.MinimumWidth = 6;
            StartSale.Name = "StartSale";
            StartSale.Width = 125;
            // 
            // EndSale
            // 
            EndSale.DataPropertyName = "EndSale";
            EndSale.HeaderText = "תאריך סיום";
            EndSale.MinimumWidth = 6;
            EndSale.Name = "EndSale";
            EndSale.Width = 125;
            // 
            // IfEveryOne
            // 
            IfEveryOne.DataPropertyName = "IfEveryOne";
            IfEveryOne.HeaderText = "לחברי מועדון";
            IfEveryOne.MinimumWidth = 6;
            IfEveryOne.Name = "IfEveryOne";
            IfEveryOne.Width = 125;
            // 
            // EditSale
            // 
            EditSale.HeaderText = "עריכה";
            EditSale.MinimumWidth = 6;
            EditSale.Name = "EditSale";
            EditSale.Width = 125;
            // 
            // Show_all_sales
            // 
            Show_all_sales.Location = new Point(694, 48);
            Show_all_sales.Name = "Show_all_sales";
            Show_all_sales.Size = new Size(94, 29);
            Show_all_sales.TabIndex = 1;
            Show_all_sales.Text = "הצג הכל";
            Show_all_sales.UseVisualStyleBackColor = true;
            Show_all_sales.Click += Show_all_sales_Click_1;
            // 
            // Add_sale
            // 
            Add_sale.Location = new Point(541, 48);
            Add_sale.Name = "Add_sale";
            Add_sale.Size = new Size(131, 29);
            Add_sale.TabIndex = 2;
            Add_sale.Text = "הוספת מבצע";
            Add_sale.UseVisualStyleBackColor = true;
            Add_sale.Click += Add_sale_Click;
            // 
            // button1
            // 
            button1.Location = new Point(441, 48);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "חיפוש מבצע";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Delete_sale
            // 
            Delete_sale.Location = new Point(338, 52);
            Delete_sale.Name = "Delete_sale";
            Delete_sale.Size = new Size(94, 29);
            Delete_sale.TabIndex = 4;
            Delete_sale.Text = "מחיקה";
            Delete_sale.UseVisualStyleBackColor = true;
            Delete_sale.Click += Delete_sale_Click;
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Delete_sale);
            Controls.Add(button1);
            Controls.Add(Add_sale);
            Controls.Add(Show_all_sales);
            Controls.Add(SalesData);
            Name = "SaleForm";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)SalesData).EndInit();
            ResumeLayout(false);
        }

        private void ShowAllSales_Click_2(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private DataGridView SalesData;
        private Button Show_all_sales;
        private Button Add_sale;
        private Button button1;
        private Button Delete_sale;
        private DataGridViewTextBoxColumn colEditSale;
        private DataGridViewTextBoxColumn ProductId;
        private DataGridViewTextBoxColumn SumPriceSale;
        private DataGridViewTextBoxColumn MinProductSale;
        private DataGridViewTextBoxColumn StartSale;
        private DataGridViewTextBoxColumn EndSale;
        private DataGridViewTextBoxColumn IfEveryOne;
        private DataGridViewButtonColumn EditSale;
    }
}