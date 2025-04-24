namespace MainModels.Util
{
    public class ReturnData<T>
    {
        public int Draw { get; set; }
        public int TotalRecords { get; set; }
        public int RecordFiltered { get; set; }
        public ICollection<T> Data { get; set; }
    }
}
