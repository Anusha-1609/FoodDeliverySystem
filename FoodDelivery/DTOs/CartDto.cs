namespace FoodDelivery.DTOs
{
    public class CartDto
    {
        public int CartID { get; set; }
        public int CustomerID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateCartDto
    {
        public int CustomerID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }
}