namespace FoodDelivery.DTOs
{
    public class MenuItemDto
    {
        public int ItemID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantID { get; set; }
    }

    public class CreateMenuItemDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int RestaurantID { get; set; }
    }
}