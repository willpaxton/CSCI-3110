using System.ComponentModel.DataAnnotations;
namespace CSCI3110WPLab2CRRUD.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public double WeightInPounds { get; set; }
    [DataType(DataType.Date)]
    public DateTime ManufactureDate { get; set; }
    public bool InStock { get; set; }
    public byte[]? ImageData { get; set; }
    public string ImageMIMEType { get; set; } = String.Empty;
}
