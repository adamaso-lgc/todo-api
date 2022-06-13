using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Infra.Database.Configurations
{
    internal sealed class TodoConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TODO", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .HasColumnName("TodoId");

            builder.Property(c => c.Done)
            .HasColumnType("bit");

        }
    }
}
