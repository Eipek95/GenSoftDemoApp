using Bogus;

namespace GenSoftDemoApp.UI.Models
{
    public class ProductDetailCommentViewModel
    {
        public string FullName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }

        private static readonly Faker faker = new Faker(); 
        private static readonly Random rnd = new Random();

        public ProductDetailCommentViewModel()
        {
            FullName = faker.Name.FullName();
            Comment = faker.Lorem.Sentence();
            Rating = rnd.Next(1, 6);
        }

        public static List<ProductDetailCommentViewModel> GenerateRandomComments()
        {
            int numberOfComments = rnd.Next(1, 11); 
            return Enumerable.Range(0, numberOfComments)
                             .Select(_ => new ProductDetailCommentViewModel()) 
                             .ToList();
        }
    }

}
