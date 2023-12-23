// See https://aka.ms/new-console-template for more information
using DownloadSorter.Services;
using System.Reflection;

namespace DownloadSorter // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NavigationManager Navman = new NavigationManager();
            SortManagment sortMan = new SortManagment();

            Console.Title = "DownloadSorter";
            Console.WriteLine("Download Sorter" + "[" + "v" + Assembly.GetExecutingAssembly().GetName().Version + "]");
            Thread.Sleep(1000);
            if (!File.Exists("Sorts.json"))
            {
                sortMan.DownloadManager(true);
            }
            Navman.MainNavigation(true);
            Console.ReadLine();
        }
    }
}
//NavigationManager Navman = new NavigationManager();
//SortManagment sortMan = new SortManagment();

//Console.Title = "DownloadSorter";
//Console.WriteLine("Download Sorter" + "[" + "v" + Assembly.GetExecutingAssembly().GetName().Version + "]");
//Thread.Sleep(1000);
//if(!File.Exists("Sorts.json"))
//{
//    sortMan.DownloadManager(true);
//}
//Navman.MainNavigation(true);
//Console.ReadLine();