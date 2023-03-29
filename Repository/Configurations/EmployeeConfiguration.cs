using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.LastName).HasMaxLength(50);

            builder.Property(e => e.Phone).HasMaxLength(15);
            builder.Property(e => e.Address).HasMaxLength(200);

        }
    }
}
