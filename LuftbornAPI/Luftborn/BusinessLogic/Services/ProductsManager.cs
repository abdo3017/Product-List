using Luftborn.InfraStructure.DataServices;
using Luftborn.Presentation.ViewModels;
using Luftborn.Utils;

namespace Luftborn.BusinessLogic.Services
{
    public class ProductsManager : IProductsManager
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsManager(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductModel> AddAsync(ProductModel product)
        {
            var addedProduct = await _productsRepository.AddAsync(product.ToEntity());
            return addedProduct.ToDTO();
        }

        public async Task<ProductModel> DeleteAsync(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            var deletedProduct = await _productsRepository.DeleteAsync(product);
            return deletedProduct.ToDTO();
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var products = _productsRepository.GetAll()
                .Select(s => s.ToDTO())
                .ToList();

            return products;
        }

        public async Task<ProductModel?> GetByIdAsync(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);
            return product.ToDTO();
        }

        public async Task SaveChangesAsync()
        {
            await _productsRepository.SaveChangesAsync();
        }

        public async Task<ProductModel> UpdateAsync(ProductModel product)
        {
            var updatedProduct = await _productsRepository.UpdateAsync(product.ToEntity());
            return updatedProduct.ToDTO();
        }
        public async Task<bool> IsExistAsync(int id)
        {
            return await _productsRepository.IsExistAsync(s => s.Id == id);
        }
        public async Task<ProductModel?> FindOneAsync(int id)
        {
            var product = await _productsRepository.FindOneAsync(s => s.Id == id);
            return product.ToDTO();
        }
    }
}
