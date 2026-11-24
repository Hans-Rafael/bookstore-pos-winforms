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
    }
}