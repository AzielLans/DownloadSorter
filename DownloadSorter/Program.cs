// See https://aka.ms/new-console-template for more information
using DownloadSorter.Services;
using System.Reflection;

SortManagemnt createSort = new SortManagemnt();


Console.Title = "DownloadSorter";
Console.WriteLine("Download Sorter" + "[" + "v" + Assembly.GetExecutingAssembly().GetName().Version + "]");
Thread.Sleep(1000);
createSort.list_Sorts();
Console.ReadLine();