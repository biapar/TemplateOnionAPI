﻿internal static class ApplicationDbContextHelpers
{
    /// <summary>
    /// Configures the model builder for the application database context.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    public static void DatabaseModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        // Configure Department entity
        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(250);
            // Set properties for the entity
            entity.Property(e => e.Id).ValueGeneratedNever(); // Id is never generated by the database
            entity.Property(e => e.CreatedBy).HasMaxLength(100); // Maximum length of CreatedBy property
            entity.Property(e => e.LastModifiedBy).HasMaxLength(100); // Maximum length of LastModifiedBy property
            entity.Property(e => e.Name).HasMaxLength(250); // Maximum length of Name property
        });

        // Configure Employee entity
        modelBuilder.Entity<Employee>(entity =>
        {
            // Create index for PositionId property
            entity.HasIndex(e => e.PositionId, "IX_Employees_PositionId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.EmployeeNumber).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Prefix).HasMaxLength(100);
            // Set properties for the entity
            entity.Property(e => e.Id).ValueGeneratedNever(); // Id is never generated by the database
            entity.Property(e => e.CreatedBy).HasMaxLength(100); // Maximum length of CreatedBy property
            entity.Property(e => e.Email).HasMaxLength(250); // Maximum length of Email property
            entity.Property(e => e.EmployeeNumber).HasMaxLength(100); // Maximum length of EmployeeNumber property
            entity.Property(e => e.FirstName).HasMaxLength(100); // Maximum length of FirstName property
            entity.Property(e => e.LastModifiedBy).HasMaxLength(100); // Maximum length of LastModifiedBy property
            entity.Property(e => e.LastName).HasMaxLength(100); // Maximum length of LastName property
            entity.Property(e => e.MiddleName).HasMaxLength(100); // Maximum length of MiddleName property
            entity.Property(e => e.Phone).HasMaxLength(100); // Maximum length of Phone property
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)"); // Salary is a decimal with precision 18 and scale 2
            entity.Property(e => e.Prefix).HasMaxLength(100); // Maximum length of Prefix property

            // Configure relationship between Employee and Position entities
            entity.HasOne(d => d.Position).WithMany(p => p.Employees).HasForeignKey(d => d.PositionId);
        });

        // Configure Position entity
        modelBuilder.Entity<Position>(entity =>
        {
            // Create index for DepartmentId property
            entity.HasIndex(e => e.DepartmentId, "IX_Positions_DepartmentId");

            // Create index for SalaryRangeId property
            entity.HasIndex(e => e.SalaryRangeId, "IX_Positions_SalaryRangeId");

            // Set properties for the entity
            entity.Property(e => e.Id).ValueGeneratedNever(); // Id is never generated by the database
            entity.Property(e => e.CreatedBy).HasMaxLength(100); // Maximum length of CreatedBy property
            entity.Property(e => e.LastModifiedBy).HasMaxLength(100); // Maximum length of LastModifiedBy property
            entity.Property(e => e.PositionDescription)
                .IsRequired()
                .HasMaxLength(1000); // Required and maximum length of PositionDescription property
            entity.Property(e => e.PositionNumber)
                .IsRequired()
                .HasMaxLength(100); // Required and maximum length of PositionNumber property
            entity.Property(e => e.PositionTitle)
                .IsRequired()
                .HasMaxLength(250); // Required and maximum length of PositionTitle property

            // Configure relationship between Position and Department entities
            entity.HasOne(d => d.Department).WithMany(p => p.Positions).HasForeignKey(d => d.DepartmentId);

            // Configure relationship between Position and SalaryRange entities
            entity.HasOne(d => d.SalaryRange).WithMany(p => p.Positions).HasForeignKey(d => d.SalaryRangeId);
        });

        // Configure SalaryRange entity
        modelBuilder.Entity<SalaryRange>(entity =>
        {
            // Set properties for the entity
            entity.Property(e => e.Id).ValueGeneratedNever(); // Id is never generated by the database
            entity.Property(e => e.CreatedBy).HasMaxLength(100); // Maximum length of CreatedBy property
            entity.Property(e => e.Name).HasMaxLength(250); // Maximum length of Name property
            entity.Property(e => e.LastModifiedBy).HasMaxLength(100); // Maximum length of LastModifiedBy property
            entity.Property(e => e.MaxSalary).HasColumnType("decimal(18, 2)"); // MaxSalary is a decimal with precision 18 and scale 2
            entity.Property(e => e.MinSalary).HasColumnType("decimal(18, 2)"); // MinSalary is a decimal with precision 18 and scale 2
        });
    }
}