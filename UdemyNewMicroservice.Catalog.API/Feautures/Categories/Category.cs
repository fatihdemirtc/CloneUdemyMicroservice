using UdemyNewMicroservice.Catalog.API.Feautures.Courses;
using UdemyNewMicroservice.Catalog.API.Repositories;

namespace UdemyNewMicroservice.Catalog.API.Feautures.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public List<Course> Course { get; set; }
    }
}
