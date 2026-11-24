using BLL;

namespace BookstorePOS.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
