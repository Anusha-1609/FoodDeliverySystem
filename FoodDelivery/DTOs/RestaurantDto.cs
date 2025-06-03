namespace FoodDeliver.DTOs
{
    public class RestaurantDto
    {
        public int RestaurantID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ContactEmail { get; set; }
        public string? Phone { get; set; }
    }

    public class CreateRestaurantDto
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
