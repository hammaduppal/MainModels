namespace MainModels.DTOModels
{
    public  class NotificationsDTO
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Params { get; set; }

        public int? UserId { get; set; }

        public string GroupName { get; set; }

        public bool IsRead { get; set; }
        public int? NotificationTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class OrderParam
    {
        public Guid? OrderId { get; set; }
        public string CustomerName { get; set; }
        public string OrderNumber { get; set; }

    }
}
