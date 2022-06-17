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
    internal sealed class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.ToTable("TODO_LIST", "dbo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .HasColumnName("TodoListId");

            builder.Property(x => x.Title)
                .HasMaxLength(200);
        }
    }
}
