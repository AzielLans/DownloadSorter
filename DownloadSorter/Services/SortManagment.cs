using DownloadSorter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DownloadSorter.Services
{
    public class SortManagment
    {
        public static NavigationManager Navman = new NavigationManager();
        public void ListSorts(bool isEdit_Sorts)
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
            while (NameGiven == "SKIP_CHANGE")
            {
                Console.WriteLine("It is a reserved NAME, Try Again");
                Console.WriteLine("Enter The Name of Sort:");
                NameGiven = Console.ReadLine();
            }
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
        public List<string> SortNameList = new List<string>();
        public List<string> SortLocationList = new List<string>();
        public List<string> SortfileList = new List<string>();
        public List<string> Global = new List<string>();
        public void Edit_Sort()
        {
            Console.Clear();
            Console.WriteLine("Edit Sorts");
            Console.WriteLine(" ");
            ListSorts(true);
            var information = GetInformation("Sorts.json");
            foreach (var informarionset in information.Information)
            {
                SortNameList.Add(informarionset.Name);
                SortLocationList.Add(informarionset.Location);
                SortfileList.Add(informarionset.Sortfile);
                Global.Add(informarionset.Name);
                Global.Add(informarionset.Location);
                Global.Add(informarionset.Sortfile);
            }
            //Get the Name Given. If the given not equal to informarionset.Name while loop is active
            //Console.WriteLine("Enter The Name of Sort that you want to skip. Enter 'SKIP_CHANGE' to skip the change");
            //Console.WriteLine(string.Join(" + ", SortNameList));
            //var GetNameGiven = Console.ReadLine();
            //var ChangeNameGiven = " ";
            //var ChangeLocationGiven = " ";
            //var ChangeSortfileGiven = " ";
            //ErrorCommon(true, false, false, GetNameGiven);
            //if (GetNameGiven != "SKIP_CHANGE")
            //{
            //    Console.WriteLine("Change the Name of Sort: " + GetNameGiven + " to what value");
            //    ChangeNameGiven = Console.ReadLine();
            //}
            //Console.WriteLine("Enter The Destination of the file after being Sorted: Enter 'SKIP_CHANGE' to skip the change");
            //Console.WriteLine(string.Join(" + ", SortLocationList));
            //var LocationGiven = Console.ReadLine();
            //ErrorCommon(false, true, false, LocationGiven);
            //if (LocationGiven != "SKIP_CHANGE")
            //{
            //    Console.WriteLine("Change the Destination of the file after being Sorted: " + LocationGiven + " to what Directory");
            //    LocationGiven = Console.ReadLine();
            //    while (!Directory.Exists(ChangeLocationGiven))
            //    {
            //        Console.WriteLine("Folder Does Not Exists, Try Again");
            //        Console.WriteLine("Enter The Destination of the file after being Sorted: Enter 'SKIP_CHANGE' to skip the change");
            //        ChangeLocationGiven = Console.ReadLine();
            //    }
            //}
            //Console.WriteLine("Enter The File extension of Sort (eg. .exe) Enter 'SKIP_CHANGE' to skip the change");
            //var SortfileGiven = Console.ReadLine();
            //ErrorCommon(false, false, true, SortfileGiven);
            //if (SortfileGiven != "SKIP_CHANGE")
            //{
            //    Console.WriteLine("Change The File extension of Sort: " + SortfileGiven + " to what File extension");
            //    ChangeSortfileGiven = Console.ReadLine();
            //}
            //UpdateListService(GetNameGiven, ChangeNameGiven, "Name");
            //UpdateListService(LocationGiven, ChangeLocationGiven, "Location");
            UpdateListService(".exe", ".docx", "Sortfile");
            Navman.ReturnExitMenuNavigation();
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

        public string ErrorCommon(bool isfindNameGiven, bool isfindLocationGiven, bool isfindFolderGiven, string findvalueGiven)
        {
            if (isfindNameGiven)
            {
                while ((!SortNameList.Contains(findvalueGiven)) == (findvalueGiven != "SKIP_CHANGE"))
                {
                    Console.WriteLine("Input Incorrect, Try Again");
                    Console.WriteLine("Enter The Name of Sort:");
                    Console.WriteLine(" ^ Enter 'SKIP_CHANGE' to skip the change");
                    findvalueGiven = Console.ReadLine();
                }
            }
            if (isfindLocationGiven)
            {
                while ((!SortLocationList.Contains(findvalueGiven)) == (findvalueGiven != "SKIP_CHANGE"))
                {
                    Console.WriteLine("Input Incorrect, Try Again");
                    Console.WriteLine("Enter The Destination of the file after being Sorted:");
                    Console.WriteLine(" ^ Enter 'SKIP_CHANGE' to skip the change");
                    findvalueGiven = Console.ReadLine();
                }
            }
            if (isfindFolderGiven)
            {
                while ((!SortfileList.Contains(findvalueGiven)) == (findvalueGiven != "SKIP_CHANGE"))
                {
                    Console.WriteLine("Input Incorrect, Try Again");
                    Console.WriteLine("Enter The File extension of Sort (eg. .exe)");
                    Console.WriteLine(" ^ Enter 'SKIP_CHANGE' to skip the change");
                    findvalueGiven = Console.ReadLine();
                }
            }

            return findvalueGiven;

        }

        public void UpdateListService(string GetValueGiven, string GetValueSet, string GetValueInfo)
        {
            try
            {
                if (GetValueGiven != "SKIP_CHANGE")
                {
                    string json = File.ReadAllText("Sorts.json");
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);
                    //int GetValueLocation = Global.FindIndex(a => a.Equals(GetValueGiven));
                    jsonObj["Information"][1][GetValueInfo] = GetValueSet;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText("sorts.json", output);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString() + " " + GetValueInfo + Global.FindIndex(a => a.Equals(GetValueGiven)));
            }

        }

        public void Sort_File()
        {
            var information = GetInformation("Sorts.json");
            string Downloadlocation;
            Console.WriteLine("============================");
            try
            {
                foreach (var informarionset in information.Information)
                {
                    SortLocationList.Add(informarionset.Location);
                    SortfileList.Add(informarionset.Sortfile);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " " + e.Source);
            }
            using (StreamReader r = new StreamReader(@"Sorts.json"))
            {
                string json = r.ReadToEnd();
                RootStructure structure = JsonConvert.DeserializeObject<RootStructure>(json);
                Downloadlocation = structure.DownloadLocation;

            }
            Console.WriteLine(string.Join(" + ", Downloadlocation));
            Console.WriteLine(string.Join(" + ", SortLocationList));
            Console.WriteLine(string.Join(" + ", SortfileList));
            foreach (var sortfileextention in SortfileList)
            {
                string mkdirfoldername = Downloadlocation + "/" + sortfileextention.Replace(".", " ");
                if (!Directory.Exists(mkdirfoldername))
                {
                    Directory.CreateDirectory(mkdirfoldername);
                }
            }
            List<string> fileNames = new List<string>();
            foreach (String file in Directory.GetFiles(Downloadlocation, "*"))
            {
                fileNames.Add(file);
            }
            var ordered = fileNames.OrderBy(p => Path.GetExtension(p));
            Console.WriteLine(string.Join(" + ", ordered));
            while (ordered.Contains)
            {

            }
        }
    }
}
