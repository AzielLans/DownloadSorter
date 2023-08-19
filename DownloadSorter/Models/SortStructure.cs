using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSorter.Models
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
