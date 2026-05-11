using Microsoft.EntityFrameworkCore;

namespace WebApplicationCore.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    
}