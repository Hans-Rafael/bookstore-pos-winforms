namespace BookstorePOS.UI
{
    partial class FrmInventory
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
            cmbCategories = new ComboBox();
            txtSearch = new TextBox();
            txtISBN = new TextBox();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtPrice = new TextBox();
            numStock = new NumericUpDown();
            numMinStock = new NumericUpDown();
            btnSave = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            dgvBooks = new DataGridView();
            splitter1 = new Splitter();
            lblISBN = new Label();
            lblTitle = new Label();
            lblAuthor = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            btnOpenPOS = new Button();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // cmbCategories
            // 
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(12, 194);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(135, 23);
            cmbCategories.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.CharacterCasing = CharacterCasing.Lower;
            txtSearch.Location = new Point(172, 32);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search (Title, Author, ISBN)...";
            txtSearch.Size = new Size(390, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(12, 32);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(135, 23);
            txtISBN.TabIndex = 2;
            
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 86);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(135, 23);
            txtTitle.TabIndex = 3;
            
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(12, 141);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(135, 23);
            txtAuthor.TabIndex = 4;
            
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(12, 251);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(135, 23);
            txtPrice.TabIndex = 5;
            
            // 
            // numStock
            // 
            numStock.Location = new Point(12, 304);
            numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(135, 23);
            numStock.TabIndex = 6;
            
            // 
            // numMinStock
            // 
            numMinStock.Location = new Point(12, 361);
            numMinStock.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numMinStock.Name = "numMinStock";
            numMinStock.Size = new Size(135, 23);
            numMinStock.TabIndex = 7;
            numMinStock.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Highlight;
            btnSave.ForeColor = SystemColors.ButtonHighlight;
            btnSave.Location = new Point(12, 400);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 35);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ControlDark;
            btnClear.ForeColor = SystemColors.ButtonHighlight;
            btnClear.Location = new Point(12, 441);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(135, 35);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(12, 484);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 35);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Deactivate";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(172, 106);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(616, 388);
            dgvBooks.TabIndex = 9;
            dgvBooks.CellClick += dgvBooks_CellClick;
            dgvBooks.CellFormatting += dgvBooks_CellFormatting;
            // 
            // splitter1
            // 
            splitter1.BorderStyle = BorderStyle.FixedSingle;
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(156, 531);
            splitter1.TabIndex = 10;
            splitter1.TabStop = false;
            splitter1.SplitterMoved += splitter1_SplitterMoved;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(15, 14);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(32, 15);
            lblISBN.TabIndex = 11;
            lblISBN.Text = "ISBN";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(15, 68);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(29, 15);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Title";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(15, 123);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(44, 15);
            lblAuthor.TabIndex = 11;
            lblAuthor.Text = "Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 233);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 11;
            label3.Text = "Price ($)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 343);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 11;
            label4.Text = "Min Stock";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 176);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 12;
            label1.Text = "Category";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 286);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 13;
            label2.Text = "Stock";
            // 
            // btnOpenPOS
            // 
            btnOpenPOS.BackColor = SystemColors.Highlight;
            btnOpenPOS.ForeColor = SystemColors.ButtonHighlight;
            btnOpenPOS.Location = new Point(623, 32);
            btnOpenPOS.Name = "btnOpenPOS";
            btnOpenPOS.Size = new Size(135, 35);
            btnOpenPOS.TabIndex = 8;
            btnOpenPOS.Text = "OpenPOS";
            btnOpenPOS.UseVisualStyleBackColor = false;
            btnOpenPOS.Click += btnOpenPOS_Click;
            // 
            // FrmInventory
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 531);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Controls.Add(lblISBN);
            Controls.Add(dgvBooks);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnOpenPOS);
            Controls.Add(btnSave);
            Controls.Add(numMinStock);
            Controls.Add(numStock);
            Controls.Add(txtPrice);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(txtISBN);
            Controls.Add(txtSearch);
            Controls.Add(cmbCategories);
            Controls.Add(splitter1);
            Name = "FrmInventory";
            Text = "FrmInventory.cs";
            Load += FrmInventory_Load;
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategories;
        private TextBox txtSearch;
        private TextBox txtISBN;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtPrice;
        private NumericUpDown numStock;
        private NumericUpDown numMinStock;
        private Button btnSave;
        private Button btnClear;
        private Button btnDelete;
        private DataGridView dgvBooks;
        private Splitter splitter1;
        private Label lblISBN;
        private Label lblTitle;
        private Label lblAuthor;
        private Label label3;
        private Label label4;
        private Label label1;
        private Label label2;
        private Button btnOpenPOS;
    }
}
