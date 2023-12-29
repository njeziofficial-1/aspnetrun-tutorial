namespace Catalog.Api.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> products)
    {
        if (!products.Find(p => true).Any())
            products.InsertMany(GetPreConfiguredProducts());
    }

    private static IEnumerable<Product> GetPreConfiguredProducts()
    => new List<Product>()
    {
        new() {
            Id = "602d2149e773f2a3990b47f1",
            Name = "Iphone 10",
            Category = "Mobile Phones",
            Summary = "This is a flagship bearing phone for the year and it was very freaking good.",
            Description = "The phone is patent to rival latest Samsung of its time. ",
            ImageFile = "product-1.jpg",
            Price = 277.99
        },
        new() {
            Id = "602d2149e773f2a3990b47f2",
            Name = "Iphone 11",
            Category = "Mobile Phones",
            Summary = "This is a flagship bearing phone for the year and it was very freaking good.",
            Description = "The phone is patent to rival latest Samsung of its time. ",
            ImageFile = "product-2.jpg",
            Price = 377.99
        },
        new() {
            Id = "602d2149e773f2a3990b47f3",
            Name = "Iphone 12",
            Category = "Mobile Phones",
            Summary = "This is a flagship bearing phone for the year and it was very freaking good.",
            Description = "The phone is patent to rival latest Samsung of its time. ",
            ImageFile = "product-3.jpg",
            Price = 477.99
        },
        new() {
            Id = "602d2149e773f2a3990b47f4",
            Name = "Iphone 13",
            Category = "Mobile Phones",
            Summary = "This is a flagship bearing phone for the year and it was very freaking good.",
            Description = "The phone is patent to rival latest Samsung of its time. ",
            ImageFile = "product-4.jpg",
            Price = 577.99
        },
        new() {
            Id = "602d2149e773f2a3990b47f5",
            Name = "Iphone 14",
            Category = "Mobile Phones",
            Summary = "This is a flagship bearing phone for the year and it was very freaking good.",
            Description = "The phone is patent to rival latest Samsung of its time. ",
            ImageFile = "product-5.jpg",
            Price = 877.99
        },
        new() {
            Id = "602d2149e773f2a3990b47f6",
            Name = "Highlander",
            Category = "Cars and Automobile",
            Summary = "This is a flagship bearing car for the year and it was very freaking good.",
            Description = "The car is patent to rival latest cars of its time. ",
            ImageFile = "product-6.jpg",
            Price = 7277.99
        },
        new() {
            Id = "602d2149e773f2a3990b47f7",
            Name = "Acura",
            Category = "Cars and Automobile",
            Summary = "This is a flagship bearing car for the year and it was very freaking good.",
            Description = "The car is patent to rival latest car of its time. ",
            ImageFile = "product-7.jpg",
            Price = 8377.99
        },
        new() {
            Id = "602d2149e773f2a3990b47f8",
            Name = "Mercedes Benz",
            Category = "Cars and Automobile",
            Summary = "This is a flagship bearing car for the year and it was very freaking good.",
            Description = "The car is patent to rival latest car of its time. ",
            ImageFile = "product-8.jpg",
            Price = 7477.99
        },
        new() {
            Id = "602d2149e773f2a3990b47f9",
            Name = "Jeep",
            Category = "Cars and Automobile",
            Summary = "This is a flagship bearing car for the year and it was very freaking good.",
            Description = "The car is patent to rival latest car of its time. ",
            ImageFile = "product-9.jpg",
            Price = 6577.99
        },
        new() {
            Id = "602d2149e773f2a3990b47g1",
            Name = "Maybach",
            Category = "Cars and Automobile",
            Summary = "This is a flagship bearing car for the year and it was very freaking good.",
            Description = "The car is patent to rival latest car of its time. ",
            ImageFile = "product-10.jpg",
            Price = 9877.99
        }
    };
}
