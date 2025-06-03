namespace FoodDelivery.DTOs
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public string? Status { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class CreateOrderDto
    {
        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public string Status { get; set; } = "Pending";
        public decimal TotalAmount { get; set; }
    }
}