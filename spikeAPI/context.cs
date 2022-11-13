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

        modelBuilder.Entity<PDF>()
            .Property(p => p.id)
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

    public PDF addPDF(PDF pdf)
    {
        PdfTable.Add(pdf);
        SaveChanges();
        return pdf;
    }

    public PDF GetSinglePdf(int id)
    {
        return PdfTable.FirstOrDefault(pdf => pdf.id == id);
    }

    public Img getSingleImg([FromRoute]int id)
    {
        return ImageTable.FirstOrDefault(img => img.id == id);
    }

    public DbSet<Img> ImageTable { get; set; }
    public DbSet<PDF> PdfTable { get; set; }
}