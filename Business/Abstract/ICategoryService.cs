using Core.Utilities.Results.Abstract;
using Entities.DTOs.CategoryDTOs;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult AddCategory(CategoryCreateDTO categoryCreateDTO);
        IResult UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);
        IResult DeleteCategory(int categoryId);
        IResult CategoryChangeStatus(int categoryId);
        IDataResult<List<CategoryAdminListDTO>> CategoryAdminCategories();
        IDataResult<List<CategoryHomeNavbarDTO>> GetNavbarCategories();
        IDataResult<List<CategoryFeaturedDTO>> GetFeaturedCategories();
    }
}
