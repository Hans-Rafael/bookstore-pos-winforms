using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using Entities;

namespace BookstorePOS.UI
{
    public partial class FrmSalesHistory : Form
    {
        private readonly SaleBLL _saleBll = new SaleBLL();

        public FrmSalesHistory()
        {
            InitializeComponent();
        }

        private void FrmSalesHistory_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;
            LoadSales();
        }

        private void btnFilter_Click(object sender, EventArgs e) => LoadSales();

        private void LoadSales()
        {
            try
            {
                var sales = _saleBll.GetSalesByDate(dtpFrom.Value, dtpTo.Value);
                dgvSales.DataSource = sales;
                dgvSaleDetails.DataSource = null;

                decimal revenue = sales.Sum(s => s.TotalAmount);
                lblTotalRevenue.Text = $"Total Revenue: ${revenue:0.00}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSales.Rows[e.RowIndex].DataBoundItem is Sale selectedSale)
            {
                dgvSaleDetails.DataSource = _saleBll.GetSaleDetails(selectedSale.SaleId);

                string[] hiddenCols = { "SaleDetailId", "SaleId", "BookId" };
                foreach (string col in hiddenCols)
                {
                    if (dgvSaleDetails.Columns[col] != null)
                        dgvSaleDetails.Columns[col]!.Visible = false;
                }
            }
        }
    }
}