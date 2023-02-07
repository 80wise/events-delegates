using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPHNsem2lab1
{
    public class Product
    {
        private string name;
        private string supplier;
        private double price;
        private int quantity;
        private string warehouse;
        
        public string Warehouse => warehouse;
        public Product(string name, string supplier, double price,int quantity, string warehouse)
        {
            this.name = name;
            this.supplier = supplier;
            this.price=price;
            this.quantity = quantity;
            this.warehouse = warehouse;
        }
        public void Output(int i) => Console.WriteLine("║{0,3}║{1,15}║{2,8:f3}║{3,8}║{4,11}║", i, name, price, quantity, supplier);

        public void OnUpArrow()
        {
            price = price * 1.1;
        }
        public void OnDownArrow()
        {
            price = price * 0.9;
        }

        public double Price
        {
            get => price;
            set
            {
                price = value;               

            }
        }
     
        public void ForIncreasing(object ob, EventArgs args)
        { 
    
                Observation observation = ob as Observation;
            if(observation != null)
                price += price * observation.Percent / 100;
        }
        public void ForDecreasing(object ob, EventArgs args)
        {
            Observation observation = ob as Observation;
            if (observation != null)
                price -= price * observation.Percent / 100;
        }
    }
}
