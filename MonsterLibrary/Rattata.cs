using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    
    public class Rattata : WildPoke
    {
        public bool IsAlert { get; set; }

        public Rattata()
        {
            //we could set default values for a weak version of a Rattata
        }

        public Rattata(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isAlert) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsAlert = isAlert ;
        }//end FQ CTOR

        public override int CalcBlock()
        {
            int result = Block;
            if (IsAlert)
            {
                result += Block / 2;
            }
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + (IsAlert ? "Alert!" : "Not so alert...");
        }



    }//end class
}//end namespace
