using System.Linq.Expressions;
using Luftborn.InfraStructure.DataServices;
using Luftborn.InfraStructure.Entity;
using Luftborn.Presentation.ViewModels;

namespace Luftborn.BusinessLogic.Services
{
    public interface IProductsManager
    {
        Task<ProductModel> AddAsync(ProductModel product);
        IEnumerable<ProductModel> GetAll();
        Task<ProductModel?> GetByIdAsync(int id);
        Task<ProductModel> UpdateAsync(ProductModel product);
        Task<ProductModel> DeleteAsync(int id);
        Task<bool> IsExistAsync(int id);
        Task<ProductModel?> FindOneAsync(int id);
        Task SaveChangesAsync();

    }
}
