
namespace MainModels.DTOModels
{
    public partial class BuildingVM
    {
        public Guid BuildingId { get; set; }

        public string BuildingName { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public Guid? BranchId { get; set; }

        public virtual BranchVM Branch { get; set; }

        public virtual ICollection<FloorVM> Floors { get; set; } = new List<FloorVM>();
    }
    public partial class FloorVM
    {
        public Guid FloorId { get; set; }

        public string FloorName { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public Guid? BuildingId { get; set; }

        public virtual BuildingVM Building { get; set; }

        public virtual ICollection<ServingTableVM> ServingTables { get; set; } = new List<ServingTableVM>();
    }
    public partial class ServingTableVM
    {
        public Guid ServingTableId { get; set; }

        public string TableName { get; set; }
        public string FloorName { get; set; }
        public string BuildingName { get; set; }
        public int? TableNumber { get; set; }

        public int? SittingCapacity { get; set; }

        public Guid? FloorId { get; set; }

        public virtual FloorVM Floor { get; set; }
    }
}
