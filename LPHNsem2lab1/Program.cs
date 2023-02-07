using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LPHNsem2lab1
{
    public class Program
    {
        
        public static string path = @"D:\ФАИС\ИП-21\ЯПВУ\labsLPHN\LPHNsem2lab1\LPHNsem2lab1\TextFile1.txt";
        public static void ReadFromFile(out Product[] products)
        {
            try
            {

                StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
                string line = sr.ReadLine();
                int count = 0;

                while (line != null)
                {
                    line = sr.ReadLine();
                    count++;
                }

                sr.Close();
                products = new Product[count];

                sr = new StreamReader(path, System.Text.Encoding.Default);
                string[] data;
                int j = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    data = line.Split(';');
                    products[j] = new Product(data[0], data[1], Convert.ToDouble(data[2]),
                        Convert.ToInt32(data[3]), data[4]);

                    j++;
                }
            }
            catch (Exception sample)
            {
                throw new Exception(sample.Message);
            }
        }

        //output information about every product in a warehouse
        public static void Output(Product[] products)
        {
            int number = 1;
            Console.WriteLine(products[0].Warehouse);
            Console.WriteLine("╔═══╦═══════════════╦════════╦════════╦═══════════╗");
            Console.WriteLine("║ n ║    product    ║ price  ║quantity║ supplier  ║");
            Console.WriteLine("╠═══╬═══════════════╬════════╬════════╬═══════════╣");
            products[0].Output(number);

            for (int i = 1; i < products.Length; i++)
            {
                if (products[i].Warehouse != products[i - 1].Warehouse)
                {
                    number = 0;
                    Console.WriteLine("╚═══╩═══════════════╩════════╩════════╩═══════════╝");
                    Console.WriteLine(products[i].Warehouse);
                    Console.WriteLine("╔═══╦═══════════════╦════════╦════════╦═══════════╗");
                    Console.WriteLine("║ n ║    product    ║ price  ║quantity║ supplier  ║");
                    Console.WriteLine("╠═══╬═══════════════╬════════╬════════╬═══════════╣");
                }
                number++;
                products[i].Output(number);
            }
            Console.WriteLine("╚═══╩═══════════════╩════════╩════════╩═══════════╝");
        }
        
        static void Main(string[] args)
        {
            Product[] products;
            ReadFromFile(out products);
            Output(products);

           // Observation observation=new Observation(products);

            Key.N = 11;
            Key k = new Key();


            foreach(Product prd in products)
            {
                Key.PressedKey += prd.OnUpArrow;
                Key.PressedKey += prd.OnDownArrow;
            }
            Key.PressedKey += OnEscape;
            
            while (isWork)
            { 
                k.OnPressKey(Console.ReadKey(true).Key);
                if(isWork)
                   Output(products);
            }

        }
        static bool isWork = true;
        static void OnEscape()
        {
            isWork = false;
        }
    }
}