namespace MainModels.DTOModels
{
    public class DCSExcel
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Guid SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
    public class UOMSUBUomExcel
    {
        public Guid UOMId { get; set; }
        public string UOMName { get; set; }

        public Guid SubUOMId { get; set; }
        public string SubUOMName { get; set; }
    }
    public class ColorExcel
    {
        public Guid ColorId { get; set; }
        public string ColorName { get; set; }
    }
    public partial class SizeExcel
    {
        public Guid SizeId { get; set; }
        public string SizeName { get; set; }
    }
    public partial class MaterialExcel
    {
        public Guid MaterialId { get; set; }
        public string MaterialName { get; set; }
    }
}
