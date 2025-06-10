using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIASPTemplate.API.DAL.Configuration.DataType;
using WebAPIASPTemplate.API.Domain.Entities;

namespace WebAPIASPTemplate.API.DAL.Configuration
{
    public class TemplateEntityConfig : IEntityTypeConfiguration<TemplateEntity>
    {
        public const string Table_name = "template_entity";

        public void Configure(EntityTypeBuilder<TemplateEntity> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => new { e.Id });
            builder.HasIndex(e => e.Title);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_template_entity_id");

            builder.Property(e => e.Title)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("title");

            builder.Property(e => e.Content)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .IsRequired()
                   .HasColumnName("content");

            builder.Property(e => e.Number)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("number");

            builder.Property(e => e.CreateDate)
                   .HasColumnName("create_date");

            builder.Property(e => e.Status)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("status");

            builder.Property(e => e.IsExist)
                   .HasColumnType(EntityDataTypes.Boolean)
                  .HasColumnName("is_exist");

        }
    }
}
