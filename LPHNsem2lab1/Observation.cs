using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPHNsem2lab1
{  
    public class Observation
    {
        private static int percent = 10;
        private Action<object, EventArgs> IncreasePrice;
        public event Action<object, EventArgs> DecreasePrice;
        public int Percent => percent;
        public Observation(Product[] products)
        {
            foreach (Product product in products)
            {
                RegistrationForIncrease(product.ForIncreasing);
                DecreasePrice += product.ForDecreasing;
            }               
        }
        public void RegistrationForIncrease(Action<object, EventArgs> IncreaseMe) { IncreasePrice += IncreaseMe; }
        
    }
}
