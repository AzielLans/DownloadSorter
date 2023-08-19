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
using System.Collections.Immutable;
using Newtonsoft.Json.Linq;
using System.IO;

namespace DownloadSorter.Services
{
    public class SortManagment
    {
        public static NavigationManager Navman = new NavigationManager();
        public void list_Sorts(bool isEdit_Sorts)
        {
            if (!File.Exists("./Sorts.json"))
            {
                Create_Sort();
                return;
            }
            if (isEdit_Sorts == false)
            {
                Console.WriteLine("List of Sorts");
                Console.WriteLine(" ");
            }
            var information = GetInformation("Sorts.json");
            Console.WriteLine("============================");
            try
            {
                foreach (var informarionset in information.Information)
                {
                    Console.Write("Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(informarionset.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Destination of the file after being Sorted: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(informarionset.Location);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("File extension of Sort: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(informarionset.Sortfile);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("============================");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " " + e.Source);
            }
            Console.WriteLine("============================");
            if (isEdit_Sorts == false)
            {
                Console.WriteLine("");
                Navman.ReturnExitMenuNavigation();
            }
        }
        public void Create_Sort()
        {
            Console.Clear();
            Console.WriteLine("Creating a New Sort");
            Console.WriteLine(" ");
            Console.WriteLine("Enter The Name of Sort:");
            var NameGiven = Console.ReadLine();
            Console.WriteLine("Enter The Destination of the file after being Sorted:");
            var LocationGiven = Console.ReadLine();
            while (!Directory.Exists(LocationGiven))
            {
                Console.WriteLine("Folder Does Not Exists, Try Again");
                Console.WriteLine("Enter The Destination of the file after being Sorted:");
                LocationGiven = Console.ReadLine();
            }
            Console.WriteLine("Enter The File extension of Sort (eg. .exe)");
            var SortfileGiven = Console.ReadLine();
            var information = GetInformation("Sorts.json");
            JObject root = (JObject)JsonConvert.DeserializeObject(File.ReadAllText("Sorts.json"));
            JArray packages = (JArray)root["Information"];
            JObject newItem = new JObject();
            newItem["Name"] = NameGiven;
            newItem["Location"] = LocationGiven;
            newItem["Sortfile"] = SortfileGiven;
            packages.Add(newItem);
            string json = JsonConvert.SerializeObject(root, Formatting.Indented);
            File.WriteAllText(@"Sorts.json", json);
            Console.WriteLine("Saved!");
            Console.WriteLine("");
            Navman.ReturnExitMenuNavigation();
        }
        public void Edit_Sort()
        {
            Console.Clear();
            Console.WriteLine("Edit Sorts");
            Console.WriteLine(" ");
            list_Sorts(true);

        }
        public void DownloadManager(bool SortManagerisnew)
        {
            if (SortManagerisnew == true)
            {
                Console.Clear();
                Console.WriteLine("Seting the location of the Download Folder");
                Console.WriteLine(" ");
                Console.WriteLine("Enter the download loction e.g C:/Documents/Downloads");
                var GetDownloadLocation = Console.ReadLine();
                while (!Directory.Exists(GetDownloadLocation))
                {
                    Console.WriteLine("Folder Does Not Exists, Try Again");
                    Console.WriteLine("Enter the download loction e.g C:/Documents/Downloads");
                    GetDownloadLocation = Console.ReadLine();
                }
                List<InformationList> informationlist = new List<InformationList>() { };
                RootStructure rootStructure = new RootStructure
                {
                    DownloadLocation = GetDownloadLocation,
                    Information = informationlist
                };
                string json = JsonConvert.SerializeObject(rootStructure, Formatting.Indented);
                File.WriteAllText(@"Sorts.json", json);
                Console.WriteLine("");
                Navman.ReturnExitMenuNavigation();
            }
        }
        public InformationStructure GetInformation(string fileName)
        {
            string json;
            using (var reader = File.OpenText(fileName))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<InformationStructure>(json);
        }



    }
}
