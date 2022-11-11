using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace spikeAPI;

public class context : DbContext
{
    public context(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Img>()
            .Property(i => i.id)
            .ValueGeneratedOnAdd();
    }

    public void remakeDb()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public Img addImage(Img img)
    {
        ImageTable.Add(img);
        SaveChanges();
        return img;
    }

    public Img getSingleImg([FromRoute]int id)
    {
        return ImageTable.FirstOrDefault(img => img.id == id);
    }

    public DbSet<Img> ImageTable { get; set; }
}