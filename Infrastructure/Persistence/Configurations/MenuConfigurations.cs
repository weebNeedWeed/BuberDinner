using Domain.Host.ValueObjects;
using Domain.Menu;
using Domain.Menu.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, rib =>
        {
            rib.ToTable("MenuReviewIds");

            rib.WithOwner().HasForeignKey("MenuId");

            rib.Property(m => m.Value)
                .ValueGeneratedNever()
                .HasColumnName("ReviewId");

            rib.HasKey("Id");
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))
            !.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");

            dib.WithOwner().HasForeignKey("MenuId");

            dib.HasKey("Id");

            dib.Property(m => m.Value)
                .ValueGeneratedNever()
                .HasColumnName("DinnerId");
        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))
            !.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.HasKey("Id", "MenuId");

            sb.WithOwner().HasForeignKey("MenuId");

            sb.Property(m => m.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value)
                );

            sb.Property(m => m.Name)
                .HasMaxLength(100);

            sb.Property(m => m.Description)
                .HasMaxLength(100);

            sb.OwnsMany(m => m.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey("Id", "MenuSectionId", "MenuId");

                ib.Property(m => m.Id)
                    .HasColumnName("MenuItemId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value)
                    );

                ib.Property(m => m.Name)
                    .HasMaxLength(100);

                ib.Property(m => m.Description)
                    .HasMaxLength(100);
            });

            sb.Navigation(m => m.Items).Metadata.SetField("_items");
            sb.Navigation(m => m.Items).Metadata
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        });
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value)
            );

        builder.Property(m => m.Name)
            .HasMaxLength(100);

        builder.Property(m => m.Description)
            .HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);

        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}