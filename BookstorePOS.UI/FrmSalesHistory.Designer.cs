namespace BookstorePOS.UI
{
    partial class FrmSalesHistory
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
            dtpFrom = new DateTimePicker();
            btnFilter = new Button();
            lblTotalRevenue = new Label();
            dgvSales = new DataGridView();
            dtpTo = new DateTimePicker();
            lblFrom = new Label();
            lblTo = new Label();
            dgvSaleDetails = new DataGridView();
            lblSales = new Label();
            lblSaleDetail = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaleDetails).BeginInit();
            SuspendLayout();
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(21, 64);
            dtpFrom.Margin = new Padding(5, 6, 5, 6);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(148, 36);
            dtpFrom.TabIndex = 0;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(454, 61);
            btnFilter.Margin = new Padding(5, 6, 5, 6);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(129, 46);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += FrmSalesHistory_Load;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.ForeColor = SystemColors.HotTrack;
            lblTotalRevenue.Location = new Point(78, 135);
            lblTotalRevenue.Margin = new Padding(5, 0, 5, 0);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(218, 30);
            lblTotalRevenue.TabIndex = 2;
            lblTotalRevenue.Text = "Total Revenue: $ 0.00";
            // 
            // dgvSales
            // 
            dgvSales.AllowUserToAddRows = false;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(14, 224);
            dgvSales.MultiSelect = false;
            dgvSales.Name = "dgvSales";
            dgvSales.ReadOnly = true;
            dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.Size = new Size(709, 150);
            dgvSales.TabIndex = 3;
            dgvSales.CellClick += dgvSales_CellClick;
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(213, 64);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(144, 36);
            dtpTo.TabIndex = 4;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(21, 28);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(64, 30);
            lblFrom.TabIndex = 5;
            lblFrom.Text = "From";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(213, 28);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(36, 30);
            lblTo.TabIndex = 6;
            lblTo.Text = "To";
            // 
            // dgvSaleDetails
            // 
            dgvSaleDetails.AllowUserToAddRows = false;
            dgvSaleDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSaleDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSaleDetails.Location = new Point(12, 421);
            dgvSaleDetails.MultiSelect = false;
            dgvSaleDetails.Name = "dgvSaleDetails";
            dgvSaleDetails.ReadOnly = true;
            dgvSaleDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSaleDetails.Size = new Size(711, 150);
            dgvSaleDetails.TabIndex = 7;
            // 
            // lblSales
            // 
            lblSales.AutoSize = true;
            lblSales.Location = new Point(21, 193);
            lblSales.Name = "lblSales";
            lblSales.Size = new Size(62, 30);
            lblSales.TabIndex = 8;
            lblSales.Text = "Sales";
            // 
            // lblSaleDetail
            // 
            lblSaleDetail.AutoSize = true;
            lblSaleDetail.Location = new Point(21, 388);
            lblSaleDetail.Name = "lblSaleDetail";
            lblSaleDetail.Size = new Size(123, 30);
            lblSaleDetail.TabIndex = 9;
            lblSaleDetail.Text = "Sales Detail";
            // 
            // FrmSalesHistory
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 900);
            Controls.Add(lblSaleDetail);
            Controls.Add(lblSales);
            Controls.Add(dgvSaleDetails);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(dtpTo);
            Controls.Add(dgvSales);
            Controls.Add(lblTotalRevenue);
            Controls.Add(btnFilter);
            Controls.Add(dtpFrom);
            Font = new Font("Segoe UI", 16F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmSalesHistory";
            Text = "BookstorePOS - Sales History";
            Load += FrmSalesHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaleDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpFrom;
        private Button btnFilter;
        private Label lblTotalRevenue;
        private DataGridView dgvSales;
        private DateTimePicker dtpTo;
        private Label lblFrom;
        private Label lblTo;
        private DataGridView dgvSaleDetails;
        private Label lblSales;
        private Label lblSaleDetail;
    }
}