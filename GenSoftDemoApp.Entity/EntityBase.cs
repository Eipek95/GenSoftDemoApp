namespace GenSoftDemoApp.Entity
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
