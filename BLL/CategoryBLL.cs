using Dal;
using Entities;

namespace BLL
{
    public class CategoryBLL
    {
        private readonly CategoryDal _categoryDal = new CategoryDal();

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
        public void Insert(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ArgumentException("Category name is required.");

            _categoryDal.Insert(category);
        }
    }
}