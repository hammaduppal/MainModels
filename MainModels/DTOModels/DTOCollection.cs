

namespace MainModels.DTOModels
{
    public class CollectionMasterVM
    {
        public Guid CollectionId { get; set; }

        public string CollectionName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<CollectionDetailVM> CollectionDetails { get; set; }


    }
    public class CollectionDetailVM
    {
        public Guid CollectionDetailId { get; set; }

        public Guid CollectionId { get; set; }

        public Guid ProductId { get; set; }

        public Guid? VariantId { get; set; }

        public int? SortOrder { get; set; }

        public virtual CollectionMasterVM Collection { get; set; }

        public virtual ProductVM Product { get; set; }

        public virtual ProductVariantVM Variant { get; set; }
    }

    public class AddCollectionVM
    {
        public List<Guid> VariantIds { get; set; }
        public string CollectionName { get; set; }
        public string DateRange { get; set; }
        public string CollectionDescription { get; set; }

    }

}