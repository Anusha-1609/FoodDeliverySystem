namespace FoodDelivery.DTOs
{
    public class DeliveryDto
    {
        public int DeliveryID { get; set; }
        public int OrderID { get; set; }
        public int AgentID { get; set; }
        public string? Status { get; set; }
        public DateTime? EstimatedTimeOfArrival { get; set; }
    }

    public class CreateDeliveryDto
    {
        public int OrderID { get; set; }
        public int AgentID { get; set; }
        public string Status { get; set; } = "In Progress";
        public DateTime EstimatedTimeOfArrival { get; set; }
    }
}