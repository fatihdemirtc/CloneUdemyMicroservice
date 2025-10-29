using UdemyNewMicroservice.Catalog.API.Feautures.Categories.Create;
using UdemyNewMicroservice.Catalog.API.Feautures.Categories.GetAll;
using UdemyNewMicroservice.Catalog.API.Feautures.Categories.GetById;

namespace UdemyNewMicroservice.Catalog.API.Feautures.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpoitExt(this WebApplication application)
        {
            application.MapGroup("api/categories")
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint()
                .GetByIdCategoryGroupItemEndpoint();
        }
    }
}
