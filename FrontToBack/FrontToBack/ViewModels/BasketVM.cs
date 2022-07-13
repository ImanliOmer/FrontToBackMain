namespace FrontToBack.ViewModels
{
    public class BasketVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int ProductCount { get; set; }
        public int Sum{ get; set; }

    }
}
