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
        public string Name { get; set; }
        public List<Information> Information { get; set; }

    }
    public class Information
    {
        public string Location { get; set; }
        public string Sortfile { get; set; }
    }
    //public class InformationStructure
    //{
    //    public List<Information> Information { get; set; }
    //}
}
