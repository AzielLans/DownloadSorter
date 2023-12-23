using Microsoft.VisualStudio.TestTools.UnitTesting;
using DownloadSorter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadSorter.Models;
using Newtonsoft.Json;

namespace DownloadSorter.Services.Tests
{
    [TestClass()]
    public class SortManagmentTests
    {
        [TestMethod()]
        public void Sort_FileTest()
        {
            SortManagment sortManagment = new SortManagment();
            try
            {
                sortManagment.Sort_File();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            //Console.WriteLine("FAILED");

        }

        [TestMethod()]
        public void ListSortsTest()
        {
            SortManagment sortManagment = new SortManagment();
            try
            {
                sortManagment.ListSorts(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

        }
    }
}