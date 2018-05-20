using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMaster
{
    public abstract class Dice
    {
        protected int max = 6;
        public virtual int Roll()
        {
            if (rand == null)
                rand = new Random();

            int value = rand.Next(1, max + 1);

            if (Die.Record)
                Die.Rolls[value]++;

            return value;
        }
        protected static Random rand;
    }

    public class D6 : Dice
    {
        public D6()
        {
            max = 6;
        }
    }

    public class WeightedD6 : Dice
    {
        public WeightedD6()
        {
            max = 100;
        }

        public override int Roll()
        {
            if (rand == null)
                rand = new Random();

            int value = rand.Next(1, max + 1);

            if (value > 0 && value  <= 18)
            {
                value = 1;   // 18%
            }
            else if (value > 18 && value <= 36)
            {
                value = 2;   // 18%
            } 
            else if (value > 36 && value <= 54)
            {
                value = 3;   // 18%
            }  
            else if (value > 54 && value <= 71)
            {
                value = 4;   // 17%
            } 
            else if (value > 71 && value <= 87)
            {
                value = 5;   // 16%
            }
            else
            {
                value = 6;   // 13%
            }

            if (Die.Record)
                Die.Rolls[value]++;

            return value;
        }
    }

    public class D12 : Dice
    {
        public D12()
        {
            max = 12;
        }
    }

    public static class Die
    {
        public static bool Record { get; set; } = true;

        public static Dictionary<int, int> Rolls = new Dictionary<int, int>()
        {
            {1,0 },
            {2,0 },
            {3,0 },
            {4,0 },
            {5,0 },
            {6,0 },
        };

        public static string Symbol(int value)
        {
            if (value <= 1)
                return "\u2680";
            if (value == 2)
                return "\u2681";
            if (value == 3)
                return "\u2682";
            if (value == 4)
                return "\u2683";
            if (value == 5)
                return "\u2684";
            if (value >= 6)
                return "\u2685";

            return "";
        }
    }
}
