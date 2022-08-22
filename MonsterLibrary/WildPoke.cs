using DungeonLibrary;

namespace MonsterLibrary
{
    public class WildPoke : Character
    {
        //Has Caterpie as the wild pokemon encounter
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        private int _minDamage;

        public int MinDamage
        {
            get { return _minDamage; }
           
            set
            {
                if (value > MaxDamage || value < 1)
                {
                    _minDamage = 1;
                }
                

                else
                {
                    _minDamage = value;
                }
                
            }
        }

        public WildPoke(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, hitChance, block, maxLife, life)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
            
        }
        
        public WildPoke()
        {
            Name = "Wild Caterpie";
            MaxLife = 25;
            Life = 25;
            HitChance = 30;
            Block = 8;
             
            MaxDamage = 10; 
            MinDamage = 2;
            Description = @"A caterpie jumps out of a near by bush...                                                                                                                                       
            ";

        } 

         
        public override string ToString()
        {
            return $@"
********* WildPoke *********
{Name}
Life: {Life} of {MaxLife}
Damage: {MinDamage} to {MaxDamage}
Block: {Block}
Description:
{Description}
";
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

        public static WildPoke GetWildPoke()
        {
            WildPoke caterpie = new WildPoke();
            WildPoke spearow = new WildPoke("Spearow", 30, 30, 70, 8, 8, 1, "An angry Spearow swoops down from the sky.");
            WildPoke weedle = new WildPoke("Weedle", 17, 25, 50, 10, 4, 1, "A Weedle falls from a near by tree.");
            WildPoke pidgey = new WildPoke("Pidgey", 10, 20, 65, 20, 15, 1, "A Pidgey perches on a branch beside you.");
            WildPoke rattata = new WildPoke("Wild Rattata", 25, 25, 50, 20, 8, 2, "a Rattata jumps from a bush near by.");

            List<WildPoke> wildPokes = new List<WildPoke>()
            {
                caterpie, spearow, weedle, pidgey, rattata
            };
            

            return wildPokes[new Random().Next(wildPokes.Count)];

        }//end GetWildPoke()
    }//end class
}//end namespace