using UdemyNewMicroservice.Catalog.API.Feautures.Categories;
using UdemyNewMicroservice.Catalog.API.Repositories;

namespace UdemyNewMicroservice.Catalog.API.Feautures.Courses
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public string? Picture { get; set; }
        public DateTime Created { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public Feauture Feauture { get; set; } = default!;
    }
}
