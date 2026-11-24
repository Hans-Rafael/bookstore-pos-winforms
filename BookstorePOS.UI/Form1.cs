using BLL;
using Entities;

namespace BookstorePOS.UI
{
    public partial class FrmInventory : Form
    {
        private readonly BookBLL _bookBll = new BookBLL();
        private readonly CategoryBLL _categoryBll = new CategoryBLL();
        private int _selectedBookId = 0; // 0 = nuevo libro, >0 = editando libro existente

        public FrmInventory()
        {
            InitializeComponent();
        }

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadBooks();
        }

        private void LoadCategories()
        {
            cmbCategories.DataSource = _categoryBll.GetAll();
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "CategoryId";
        }

        private void LoadBooks(string search = "")
        {
            dgvBooks.DataSource = _bookBll.GetAll(search);

            // Oculta columnas internas que el usuario no necesita ver
            string[] hiddenCols = { "BookId", "CategoryId", "IsActive", "CreatedAt" };
            foreach (string col in hiddenCols)
            {
                if (dgvBooks.Columns[col] != null)
                    dgvBooks.Columns[col]!.Visible = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooks(txtSearch.Text.Trim());
        }
        private void btnOpenPOS_Click(object sender, EventArgs e)
        {
            using (var pos = new FrmPOS())
            {
                pos.ShowDialog();
            }
            LoadBooks(txtSearch.Text.Trim());
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Please enter a valid price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var book = new Book
                {
                    BookId = _selectedBookId,
                    ISBN = txtISBN.Text.Trim(),
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    CategoryId = Convert.ToInt32(cmbCategories.SelectedValue),
                    Price = price,
                    Stock = (int)numStock.Value,
                    MinStock = (int)numMinStock.Value
                };

                _bookBll.Save(book);
                MessageBox.Show("Book saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadBooks(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBooks.Rows[e.RowIndex].DataBoundItem is Book book)
            {
                _selectedBookId = book.BookId;
                txtISBN.Text = book.ISBN;
                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                cmbCategories.SelectedValue = book.CategoryId;
                txtPrice.Text = book.Price.ToString("0.00");
                numStock.Value = book.Stock;
                numMinStock.Value = book.MinStock;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedBookId == 0)
            {
                MessageBox.Show("Select a book from the table first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to deactivate this book?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _bookBll.Deactivate(_selectedBookId);
                ClearForm();
                LoadBooks(txtSearch.Text.Trim());
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            _selectedBookId = 0;
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPrice.Clear();
            numStock.Value = 0;
            numMinStock.Value = 5;
            if (cmbCategories.Items.Count > 0) cmbCategories.SelectedIndex = 0;
        }

        private void dgvBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBooks.Rows[e.RowIndex].DataBoundItem is Book book)
            {
                if (book.Stock <= book.MinStock)
                {
                    dgvBooks.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    dgvBooks.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else
                {
                    dgvBooks.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgvBooks.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CategoryBLL categoryBll = new CategoryBLL();
                cmbCategories.DataSource = categoryBll.GetAll();
                cmbCategories.DisplayMember = "Name";
                cmbCategories.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            using (var history = new FrmSalesHistory())
            {
                history.ShowDialog();

            }

        }
    }
}
