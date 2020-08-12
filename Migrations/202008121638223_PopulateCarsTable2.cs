namespace SuperCarStore.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;

    public partial class PopulateCarsTable2 : DbMigration
    {
        public override void Up()
        {

            var path = @"C:\Users\Mauro\OneDrive\repos\SuperCarStore\Content\carList\carList.txt";

            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs, Encoding.UTF8);
            string cars = sr.ReadToEnd();

            List<string> carList = new List<string>();
            List<string> carMakeList = new List<string>();
            List<string> carModelList = new List<string>();



            // ----  Reading and spliting by lines all entries in the txt files  ----------------

            carList = cars.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();


            // ----  Getting the list of all makes in the txt files  ----------------


            carMakeList = carList.Select(s => s.Split(' ')[0]).ToList();


            // Getting the list of all models in the txt files and adding to data Table

            Random store = new Random();

            for (int i = 0; i < carList.Count; i++)
            {
                carModelList.Add(string.Join(" ", carList[i].Split().Skip(1)));

                Sql($"INSERT INTO Cars (Make, Model, StoreId) VALUES ('{carMakeList[i]}','{carModelList[i]}', {store.Next(1, 5)});");
            }


        }

        public override void Down()
        {
        }
    }
}
