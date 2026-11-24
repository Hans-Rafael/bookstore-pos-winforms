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
    public partial class FrmPOS : Form
    {
        private readonly BookBLL _bookBll = new BookBLL();
        private readonly SaleBLL _saleBll = new SaleBLL();
        private readonly List<SaleDetail> _cart = new List<SaleDetail>();

        public FrmPOS()
        {
            InitializeComponent();
        }

        private void FrmPOS_Load(object sender, EventArgs e)
        {
            txtSearchBook.PlaceholderText = "Search book by Title, Author, or ISBN...";
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Debit Card", "Credit Card", "Transfer" });
            cmbPaymentMethod.SelectedIndex = 0;
            LoadCatalog();
        }

        private void LoadCatalog(string search = "")
        {
            dgvCatalog.DataSource = _bookBll.GetAll(search);
            string[] hiddenCols = { "BookId", "CategoryId", "MinStock", "IsActive", "CreatedAt" };
            foreach (string col in hiddenCols)
            {
                if (dgvCatalog.Columns[col] != null)
                    dgvCatalog.Columns[col]!.Visible = false;
            }
        }

        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            LoadCatalog(txtSearchBook.Text.Trim());
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvCatalog.CurrentRow?.DataBoundItem is not Book selectedBook)
            {
                MessageBox.Show("Select a book from the catalog.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int qty = (int)numQuantity.Value;
            var existingItem = _cart.FirstOrDefault(d => d.BookId == selectedBook.BookId);
            int totalRequested = qty + (existingItem?.Quantity ?? 0);

            if (totalRequested > selectedBook.Stock)
            {
                MessageBox.Show($"Insufficient stock. Available: {selectedBook.Stock}", "Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existingItem != null)
            {
                existingItem.Quantity += qty;
            }
            else
            {
                _cart.Add(new SaleDetail
                {
                    BookId = selectedBook.BookId,
                    BookTitle = selectedBook.Title,
                    Quantity = qty,
                    UnitPrice = selectedBook.Price
                });
            }

            numQuantity.Value = 1;
            RefreshCart();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow?.DataBoundItem is SaleDetail selectedItem)
            {
                _cart.Remove(selectedItem);
                RefreshCart();
            }
        }

        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;

            string[] hiddenCols = { "SaleDetailId", "SaleId", "BookId" };
            foreach (string col in hiddenCols)
            {
                if (dgvCart.Columns[col] != null)
                    dgvCart.Columns[col]!.Visible = false;
            }

            decimal total = _cart.Sum(d => d.Subtotal);
            lblTotal.Text = $"Total: ${total:0.00}";
        }

        
        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            try
            {
                var sale = new Sale
                {
                    PaymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash",
                    Details = new List<SaleDetail>(_cart)
                };

                int saleId = _saleBll.RegisterSale(sale);
                MessageBox.Show($"Sale #{saleId} completed successfully!", "Sale Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _cart.Clear();
                RefreshCart();
                LoadCatalog(txtSearchBook.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
