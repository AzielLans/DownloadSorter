using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSorter.Services
{
    public class NavigationManager
    {

        public SortManagment sortMan = new SortManagment();
        public void MainNavigation(bool is_main_menu)
        {
            Console.WriteLine("Options:");
            Console.WriteLine(" ");
            Console.WriteLine("Create a new sort - 1");
            Console.WriteLine("Edit a sort - 2");
            Console.WriteLine("Show all sorts - 3");
            Console.WriteLine("AutoStart Sorter - 4");
            if(is_main_menu == true)
            {
                Console.WriteLine("Change Default Download Loction - 5");
            }
            Console.WriteLine("Exit - 0");
            Console.Write("Enter the value: ");
            var GetOption = Console.ReadLine();

            while ((GetOption != "5") == (GetOption != "4") == (GetOption != "3") == (GetOption != "2") == (GetOption != "1") == (GetOption != "0"))
            {
                Console.WriteLine("Invalid Output");
                Console.WriteLine(" ");
                Console.Write("Enter the value:");
                GetOption = Console.ReadLine();
            };

            if (GetOption == "0")
            {
                Environment.Exit(0);
            }
            if (GetOption == "1")
            {
                sortMan.Create_Sort();
                return;
            }
            if (GetOption == "2")
            {
                sortMan.Edit_Sort();
            }
            if (GetOption == "3")
            {
                Console.Clear();
                sortMan.list_Sorts(false);
                return;
            }
            if (GetOption == "4")
            {

            }
            if (GetOption == "5") 
            {
                sortMan.DownloadManager(true);
            }

        }
        public void ReturnExitMenuNavigation()
        {
            Console.WriteLine("Options:");
            Console.WriteLine(" ");
            Console.WriteLine("Return - R"); 
            Console.WriteLine("Exit - 0");
            Console.Write("Enter the value: ");
            var GetOption = Console.ReadLine();
            while ((GetOption != "R") == (GetOption != "0"))
            {
                Console.WriteLine("Invalid Output");
                Console.WriteLine(" ");
                Console.Write("Enter the value:");
                GetOption = Console.ReadLine();
            }
            if (GetOption == "0")
            {
                Environment.Exit(0);
            }
            if (GetOption == "R")
            {
                Console.Clear ();
                Console.WriteLine("Returning to the Main Menu ......");
                Console.Clear();
                Console.Title = "DownloadSorter";
                Console.WriteLine("Download Sorter" + "[" + "v" + Assembly.GetExecutingAssembly().GetName().Version + "]");
                Thread.Sleep(1000);
                MainNavigation(true);
            }
        }
    }
}
