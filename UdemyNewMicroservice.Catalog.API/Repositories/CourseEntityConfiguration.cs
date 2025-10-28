using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection.Emit;
using UdemyNewMicroservice.Catalog.API.Feautures.Courses;

namespace UdemyNewMicroservice.Catalog.API.Repositories
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToCollection("courses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).HasElementName("name").HasMaxLength(100);
            builder.Property(x => x.Description).HasElementName("description").HasMaxLength(1000);
            builder.Property(x => x.Created).HasElementName("created");
            builder.Property(x => x.UserId).HasElementName("userId");
            builder.Property(x => x.CategoryId).HasElementName("categoryId");
            builder.Property(x => x.Picture).HasElementName("picture");
            builder.Ignore(x => x.Category);

            builder.OwnsOne(x => x.Feauture, feauture =>
            {
                feauture.HasElementName("feauture");
                feauture.Property(x => x.Duration).HasElementName("duration");
                feauture.Property(x => x.Rating).HasElementName("rating");
                feauture.Property(x => x.EducatorFullName).HasElementName("educatorFullName").HasMaxLength(100);
            });

        }
    }
}
