using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    
    public sealed class Player : Character 
    {
        private Specialty _characterSpecialty;
        
        public Specialty CharacterSpecialty
        {
            get { return _characterSpecialty; }
            set { _characterSpecialty = value; }
        }

        private Pokemon _equippedPokemon;
        
        public Pokemon EquippedPokemon
        {
            get { return _equippedPokemon; }
            set { _equippedPokemon = value; }
        }

        public Player(string name, int hitChance, int block, int maxLife, int life, Specialty characterSpecialty, Pokemon equippedPokemon)
            : base(name, hitChance, block, maxLife, life)
        {
            CharacterSpecialty = characterSpecialty;
            EquippedPokemon = equippedPokemon;
           
            switch (CharacterSpecialty)
            {
                case Specialty.ElectricTrainer:
                    MaxLife += 10;
                    Life += 10;                    
                    break;
                case Specialty.FireTrainer:
                    HitChance += (HitChance / 20); 
                    break;
                case Specialty.WaterTrainer:
                    Block += 3;
                    HitChance += 5;
                    break;
                case Specialty.GrassTrainer:
                    MaxLife += 5;
                    Life += 5;
                    Block += 5;
                    break;
            }
        }

        public override string ToString()
        {
            string description = "";
            switch (CharacterSpecialty)
            {
                case Specialty.ElectricTrainer:
                    description = "Electric Trainer";
                    break;
                case Specialty.FireTrainer:
                    description = "Fire Trainer";
                    break;
                case Specialty.WaterTrainer:
                    description = "Water Trainer";
                    break;
                case Specialty.GrassTrainer:
                    description = "Grass Trainer";
                    break;
                default:
                    break;
            }
            return base.ToString() + $"\nPokemon: {EquippedPokemon.Name}\n" + description;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedPokemon.BonusHitChance;
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedPokemon.MinDamage, EquippedPokemon.MaxDamage + 1);

            return damage;

        }
    }//end class Player
}//end namespace
