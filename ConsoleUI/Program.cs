using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var manager = new WeddingPlaceManager(new EfWeddingPlaceDal());
            foreach (var item in manager.GetAll().Data)
            {
                Console.WriteLine(item.PlaceName + " "+item.Capacity);
            }
        }

    }
}
