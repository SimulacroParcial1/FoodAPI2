using Microsoft.EntityFrameworkCore;
using FoodAPI2.Models;

namespace FoodAPI2.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Burger> Burgers { get; set; } = null!;
}