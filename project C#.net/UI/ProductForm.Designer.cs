namespace UI
{
    partial class ProductForm
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
            dataGridView1 = new DataGridView();
            txtSearch = new Label();
            dataGridView2 = new DataGridView();
            cbCategories = new ComboBox();
            colProductName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colID = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            colDelete = new DataGridViewButtonColumn();
            btnShowAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 14);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(884, 574);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.AutoSize = true;
            txtSearch.Location = new Point(643, 99);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(86, 20);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "חיפוש מוצר:";
            txtSearch.Click += label1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { colProductName, colPrice, colID, colStock, Column1, colDelete });
            dataGridView2.Location = new Point(51, 132);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(787, 243);
            dataGridView2.TabIndex = 2;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // cbCategories
            // 
            cbCategories.FormattingEnabled = true;
            cbCategories.Location = new Point(51, 82);
            cbCategories.Name = "cbCategories";
            cbCategories.Size = new Size(151, 28);
            cbCategories.TabIndex = 3;
            cbCategories.Tag = "cbCategories";
            cbCategories.Text = "מיין לפי:";
            cbCategories.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // colProductName
            // 
            colProductName.HeaderText = "שם מוצר:";
            colProductName.MinimumWidth = 6;
            colProductName.Name = "colProductName";
            colProductName.Width = 125;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "מחיר מוצר";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.Width = 125;
            // 
            // colID
            // 
            colID.HeaderText = "קוד מוצר";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.Width = 125;
            // 
            // colStock
            // 
            colStock.HeaderText = "מלאי";
            colStock.MinimumWidth = 6;
            colStock.Name = "colStock";
            colStock.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "עריכה";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "מחיקה";
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.Resizable = DataGridViewTriState.True;
            colDelete.SortMode = DataGridViewColumnSortMode.Automatic;
            colDelete.Text = "מחיקה";
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Width = 125;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(744, 90);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(94, 29);
            btnShowAll.TabIndex = 4;
            btnShowAll.Text = "צפייה בכל המוצרים";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += button1_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnShowAll);
            Controls.Add(cbCategories);
            Controls.Add(dataGridView2);
            Controls.Add(txtSearch);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductForm";
            Text = "ProductForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label txtSearch;
        private DataGridView dataGridView2;
        protected internal ComboBox cbCategories;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewButtonColumn colDelete;
        private Button btnShowAll;
    }
}