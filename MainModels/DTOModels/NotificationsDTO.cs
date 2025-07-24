namespace MainModels.DTOModels
{
    public partial class NotificationsDTO
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Params { get; set; }

        public string UserId { get; set; }

        public string GroupName { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
