namespace MainModels.DTOModels
{
    public class PagesViewModel
    {
        public IEnumerable<BusinessEntityTypeVM> BusinessEntities { get; set; }
        public BusinessVM Busineses { get; set; }
        public List<BusinessVM> Busineseses { get; set; }

        public IEnumerable<OrganizationVM> Organizations { get; set; }

        public IEnumerable<BusinessCategoryVM> BusinessCategories { get; set; }
    }
    public class SystemSettings
    {
        public string ContentAPIUrl { get; set; }
    }
    public class APIImageContentRequest
    {
        public string Base64String { get; set; }
        public string Website { get; set; }
        public string Folder { get; set; }
        public string Type { get; set; }
    }
    public class APIImageContentResponse
    {
        public string ImageUrl { get; set; }
        public string StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }

}
