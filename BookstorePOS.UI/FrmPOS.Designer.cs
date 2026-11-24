namespace BookstorePOS.UI
{
    partial class FrmPOS
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
            lblNumQuntity = new Label();
            lblCart = new Label();
            splitContainer1 = new SplitContainer();
            numQuantity = new NumericUpDown();
            dgvCatalog = new DataGridView();
            label4 = new Label();
            txtSearchBook = new TextBox();
            btnAddToCart = new Button();
            lblCatalog = new Label();
            dgvCart = new DataGridView();
            btnRemoveItem = new Button();
            cmbPaymentMethod = new ComboBox();
            lblTotal = new Label();
            btnCompleteSale = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lblNumQuntity
            // 
            lblNumQuntity.AutoSize = true;
            lblNumQuntity.Location = new Point(22, 270);
            lblNumQuntity.Name = "lblNumQuntity";
            lblNumQuntity.Size = new Size(53, 15);
            lblNumQuntity.TabIndex = 1;
            lblNumQuntity.Text = "Quantity";
            // 
            // lblCart
            // 
            lblCart.AutoSize = true;
            lblCart.Location = new Point(40, 26);
            lblCart.Name = "lblCart";
            lblCart.Size = new Size(29, 15);
            lblCart.TabIndex = 1;
            lblCart.Text = "Cart";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.Info;
            splitContainer1.Panel1.Controls.Add(lblCatalog);
            splitContainer1.Panel1.Controls.Add(btnAddToCart);
            splitContainer1.Panel1.Controls.Add(numQuantity);
            splitContainer1.Panel1.Controls.Add(dgvCatalog);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(txtSearchBook);
            splitContainer1.Panel1.Controls.Add(lblNumQuntity);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.GradientInactiveCaption;
            splitContainer1.Panel2.Controls.Add(cmbPaymentMethod);
            splitContainer1.Panel2.Controls.Add(dgvCart);
            splitContainer1.Panel2.Controls.Add(btnCompleteSale);
            splitContainer1.Panel2.Controls.Add(btnRemoveItem);
            splitContainer1.Panel2.Controls.Add(lblTotal);
            splitContainer1.Panel2.Controls.Add(lblCart);
            splitContainer1.Size = new Size(800, 394);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 2;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(12, 288);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(173, 23);
            numQuantity.TabIndex = 4;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dgvCatalog
            // 
            dgvCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCatalog.Location = new Point(12, 101);
            dgvCatalog.Name = "dgvCatalog";
            dgvCatalog.Size = new Size(240, 150);
            dgvCatalog.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 26);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 1;
            label4.Text = "label1";
            // 
            // txtSearchBook
            // 
            txtSearchBook.Location = new Point(12, 44);
            txtSearchBook.Name = "txtSearchBook";
            txtSearchBook.Size = new Size(173, 23);
            txtSearchBook.TabIndex = 2;
            txtSearchBook.TextChanged += this.txtSearchBook_TextChanged;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.OliveDrab;
            btnAddToCart.ForeColor = SystemColors.ButtonHighlight;
            btnAddToCart.Location = new Point(50, 342);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(135, 35);
            btnAddToCart.TabIndex = 5;
            btnAddToCart.Text = "AddToCart";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += this.btnAddToCart_Click;
            // 
            // lblCatalog
            // 
            lblCatalog.AutoSize = true;
            lblCatalog.Location = new Point(22, 83);
            lblCatalog.Name = "lblCatalog";
            lblCatalog.Size = new Size(48, 15);
            lblCatalog.TabIndex = 6;
            lblCatalog.Text = "Catalog";
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(24, 44);
            dgvCart.Name = "dgvCart";
            dgvCart.Size = new Size(240, 150);
            dgvCart.TabIndex = 2;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.BackColor = Color.Chocolate;
            btnRemoveItem.ForeColor = SystemColors.ButtonHighlight;
            btnRemoveItem.Location = new Point(297, 44);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(135, 35);
            btnRemoveItem.TabIndex = 5;
            btnRemoveItem.Text = "RemoveItem";
            btnRemoveItem.UseVisualStyleBackColor = false;
            btnRemoveItem.Click += this.btnRemoveItem_Click;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(143, 270);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(121, 23);
            cmbPaymentMethod.TabIndex = 6;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(65, 222);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(65, 15);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: $0.00";
            // 
            // btnCompleteSale
            // 
            btnCompleteSale.BackColor = Color.Teal;
            btnCompleteSale.ForeColor = SystemColors.ButtonHighlight;
            btnCompleteSale.Location = new Point(297, 260);
            btnCompleteSale.Name = "btnCompleteSale";
            btnCompleteSale.Size = new Size(135, 35);
            btnCompleteSale.TabIndex = 5;
            btnCompleteSale.Text = "CompleteSale";
            btnCompleteSale.UseVisualStyleBackColor = false;
            btnCompleteSale.Click += this.btnCompleteSale_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(31, 423);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(690, 150);
            dataGridView.TabIndex = 7;
            // 
            // FrmPOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 624);
            Controls.Add(dataGridView);
            Controls.Add(splitContainer1);
            Name = "FrmPOS";
            Text = "Form2";
            Load += this.FrmPOS_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalog).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNumQuntity;
        private Label lblCart;
        private SplitContainer splitContainer1;
        private NumericUpDown numQuantity;
        private DataGridView dgvCatalog;
        private Label label4;
        private TextBox txtSearchBook;
        private Label lblCatalog;
        private Button btnAddToCart;
        private DataGridView dgvCart;
        private Button button1;
        private ComboBox cmbPaymentMethod;
        private Button btnRemoveItem;
        private Label lblTotal;
        private DataGridView dataGridView;
        private Button btnCompleteSale;
    }
}