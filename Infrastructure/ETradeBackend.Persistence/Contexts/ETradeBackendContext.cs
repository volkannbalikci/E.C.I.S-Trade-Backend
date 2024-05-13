using ETradeBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence.Contexts;

public class ETradeBackendContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Advert> Advers { get; set; }
    public DbSet<AdvertPhotoPath> AdvertPhotoPaths { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<CorporateUser> CorporateUsers { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<IndividualUser> IndividualUsers { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<CorporateAdvert> CorporateAdverts { get; set; }
    public DbSet<IndividualAdvert> IndividualAdverts { get; set; }
    public DbSet<SwapAdvert> SwapAdverts { get; set; }
    public DbSet<SwapForCategoryAdvert> SwapForCategoryAdverts { get; set; }
    public DbSet<SwapForProductAdvert> SwapForProductAdverts { get; set; }
    public DbSet<CorporateAdvertOrder> CorporateAdvertOrders { get; set; }
    public DbSet<CorporateAdvertOrderItem> CorporateAdvertOrderItems { get; set; }
    
    public ETradeBackendContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.SetRelationshipsOnDeleteBehaviors(DeleteBehavior.Restrict, modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void SetRelationshipsOnDeleteBehaviors(DeleteBehavior deleteBehavior, ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = deleteBehavior;
        }
    }
}
