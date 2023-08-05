using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Linq;
using DownloadSorter.Models;
using System.Data;
using Newtonsoft.Json;
using System.Security.Principal;

namespace DownloadSorter.Services
{
    public class SortManagemnt
    {
        public void list_Sorts()
        {
            if (File.Exists("./Sorts.json"))
            {
                
            }
            Create_Sort();
        }
        public void Create_Sort()
        {
            Console.Clear();
            Console.WriteLine("Creating a New Sort");
            Console.WriteLine(" ");
            Console.WriteLine("Enter The Name of Sort:");
            var NameGiven = Console.ReadLine();
            Console.WriteLine("Enter The Location of Sort:");
            var LocationGiven = Console.ReadLine();
            while (!Directory.Exists(LocationGiven))
            {
                Console.WriteLine("Folder Does Not Exists, Try Again");
                Console.WriteLine("Enter The Location of Sort:");
                LocationGiven = Console.ReadLine();
            }
            Console.WriteLine("Enter The File extension of Sort (eg. .exe)");
            var SortfileGiven = Console.ReadLine();

            //prepare static data
            List<Information> informationlist = new List<Information>()
            {
                new Information() {Location = LocationGiven, Sortfile = SortfileGiven}
            };
            //InformationStructure informationmanagement = new InformationStructure();
            //informationmanagement.Information = informationlist;
            SortStructure sortStructure = new SortStructure
            {
                Name = NameGiven,
                Information = informationlist
            };
            Console.Clear();
            Console.WriteLine("Saving Sort");
            string json = JsonConvert.SerializeObject(sortStructure, Formatting.Indented);
            File.WriteAllText(@"Sorts.json", json);
            Console.WriteLine("Done!");
        }
    }
}
