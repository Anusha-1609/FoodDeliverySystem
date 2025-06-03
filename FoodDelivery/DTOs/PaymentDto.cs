namespace FoodDelivery.DTOs
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
    }

    public class CreatePaymentDto
    {
        public int OrderID { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Successful";
    }
}