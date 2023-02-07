using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPHNsem2lab1
{
    public class Key
    {
        static int n;
        static Action[] ChangePrice;
        public static int N
        {
            set { n = value; ChangePrice = new Action[n]; }
        }
        public static event Action PressedKey
        {
            add
            {
                for (int i = 0; i < n; i++)
                    if (ChangePrice[i] == null) 
                    {
                        ChangePrice[i] = value;
                        break;
                    }
            }
            remove
            {
                for (int i = 0; i < n; i++)
                    if (ChangePrice[i] == value)
                    {
                        ChangePrice[i] = null;
                        break;
                    }
            }
        }
        public void OnPressKey(ConsoleKey k)
        {

            for (int i = 0; i < n; i++)
                if (ChangePrice[i] != null &&
                    "On" + k.ToString() == ChangePrice[i].Method.Name)
                    ChangePrice[i]();
                
        }
    }
}
