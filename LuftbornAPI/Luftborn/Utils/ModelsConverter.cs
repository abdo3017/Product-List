using Luftborn.InfraStructure.Entity;
using Luftborn.Presentation.ViewModels;

namespace Luftborn.Utils
{
    public static class ModelsConverter
    {
        public static Products ToEntity(this ProductModel product)
        {
            return new Products
            {
                Id = product.Id,
                Name = product.Name,
                AvailableAmount = product.AvailableAmount,
                Cost = product.Cost
            };
        }

        public static ProductModel ToDTO(this Products product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                AvailableAmount = product.AvailableAmount,
                Cost = product.Cost,
            };
        }


    }
}
