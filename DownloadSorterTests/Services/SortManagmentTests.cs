﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

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