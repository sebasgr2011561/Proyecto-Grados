using Application.Commons.Bases;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories();
        Task<BaseResponse<CategoryResponseDto>> GetCategoryById(int categoryId);
        Task<BaseResponse<bool>> CreateCategory(CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> UpdateCategory(int idCategory, CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> DeleteCategory(int idCategory);
    }
}
