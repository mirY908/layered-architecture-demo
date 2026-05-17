namespace UI
{
    partial class CartWindow
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
            btnAddToCart = new Button();
            btnRemoveProduct = new Button();
            btnUpdateAmount = new Button();
            chkIsFavorite = new CheckBox();
            btnFinishOrder = new Button();
            lblTotalSum = new Label();
            txtAmount = new TextBox();
            dgvCart = new DataGridView();
            cmbProducts = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(669, 53);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(94, 29);
            btnAddToCart.TabIndex = 0;
            btnAddToCart.Text = "הוסף לסל";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // btnRemoveProduct
            // 
            btnRemoveProduct.Location = new Point(625, 115);
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(138, 29);
            btnRemoveProduct.TabIndex = 1;
            btnRemoveProduct.Text = "הסר מוצר נבחר";
            btnRemoveProduct.UseVisualStyleBackColor = true;
            btnRemoveProduct.Click += btnRemoveProduct_Click;
            // 
            // btnUpdateAmount
            // 
            btnUpdateAmount.Location = new Point(669, 169);
            btnUpdateAmount.Name = "btnUpdateAmount";
            btnUpdateAmount.Size = new Size(94, 29);
            btnUpdateAmount.TabIndex = 2;
            btnUpdateAmount.Text = "עדכן כמות";
            btnUpdateAmount.UseVisualStyleBackColor = true;
            btnUpdateAmount.Click += btnUpdateAmount_Click;
            // 
            // chkIsFavorite
            // 
            chkIsFavorite.AutoSize = true;
            chkIsFavorite.Location = new Point(27, 53);
            chkIsFavorite.Name = "chkIsFavorite";
            chkIsFavorite.Size = new Size(105, 24);
            chkIsFavorite.TabIndex = 3;
            chkIsFavorite.Text = "לקוח מועדון";
            chkIsFavorite.UseVisualStyleBackColor = true;
            chkIsFavorite.CheckedChanged += chkIsFavorite_CheckedChanged;
            // 
            // btnFinishOrder
            // 
            btnFinishOrder.Location = new Point(302, 339);
            btnFinishOrder.Name = "btnFinishOrder";
            btnFinishOrder.Size = new Size(239, 66);
            btnFinishOrder.TabIndex = 4;
            btnFinishOrder.Text = "אישור ותשלום הזמנה";
            btnFinishOrder.UseVisualStyleBackColor = true;
            btnFinishOrder.Click += btnFinishOrder_Click;
            // 
            // lblTotalSum
            // 
            lblTotalSum.AutoSize = true;
            lblTotalSum.Location = new Point(62, 362);
            lblTotalSum.Name = "lblTotalSum";
            lblTotalSum.Size = new Size(127, 20);
            lblTotalSum.TabIndex = 5;
            lblTotalSum.Text = "סה\"כ לתשלום: 0 ₪";
            lblTotalSum.Click += lblTotalSum_Click;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(368, 55);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(125, 27);
            txtAmount.TabIndex = 7;
            txtAmount.Text = "כמות";
            // 
            // dgvCart
            // 
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(167, 101);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(425, 210);
            dgvCart.TabIndex = 8;
            dgvCart.CellContentClick += dgvCart_CellContentClick;
            // 
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(514, 51);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(134, 28);
            cmbProducts.TabIndex = 9;
            // 
            // CartWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbProducts);
            Controls.Add(dgvCart);
            Controls.Add(txtAmount);
            Controls.Add(lblTotalSum);
            Controls.Add(btnFinishOrder);
            Controls.Add(chkIsFavorite);
            Controls.Add(btnUpdateAmount);
            Controls.Add(btnRemoveProduct);
            Controls.Add(btnAddToCart);
            Name = "CartWindow";
            Text = "CartWindow";
            Load += CartWindow_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddToCart;
        private Button btnRemoveProduct;
        private Button btnUpdateAmount;
        private CheckBox chkIsFavorite;
        private Button btnFinishOrder;
        private Label lblTotalSum;
        private TextBox txtAmount;
        private DataGridView dgvCart;
        private ComboBox cmbProducts;
    }
}