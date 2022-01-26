using System;
using System.Threading.Tasks;
using Models.Request.Product;
using Models.Response.CoreResponse;

namespace Core.Interface
{
    public interface ICategoryService
    {
        Task<CoreResponseModel> InsertCategory(InsertCategory request);
        Task<CoreResponseModel> GetCategories();
        Task<CoreResponseModel> DeleteCategory(long id);

    }
}
