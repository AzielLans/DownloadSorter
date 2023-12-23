namespace Download_Sorter_UI.Models
{
    public class SortStructure
    {
        public List<InformationList> Information { get; set; }

    }
    public class InformationList
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Sortfile { get; set; }
    }
    public class InformationStructure
    {
        public List<InformationList> Information { get; set; }
    }
    public class RootStructure
    {
        public string DownloadLocation { get; set; }
        public List<InformationList> Information { get; set; }
    }
}
