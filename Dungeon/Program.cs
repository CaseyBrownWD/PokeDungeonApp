using DungeonLibrary;
using MonsterLibrary;
using System;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Viridian Forest!\n" +
                "The deep and sprawling forest is said to be a natural maze as many people get lost inside. \n The trees in the forest are so thick that little light gets in.");
            
            string text = @"
                ______     _                                            
                | ___ \   | |                                           
                | |_/ /__ | | _____ _ __ ___   ___  _ __                
                |  __/ _ \| |/ / _ \ '_ ` _ \ / _ \| '_ \               
                | | | (_) |   <  __/ | | | | | (_) | | | |              
                \_|  \___/|_|\_\___|_| |_| |_|\___/|_| |_|              
                                                        
                                                        
                 _____                       _         ___              
                /  __ \                     | |       / _ \             
                | /  \/ ___  _ __  ___  ___ | | ___  / /_\ \_ __  _ __  
                | |    / _ \| '_ \/ __|/ _ \| |/ _ \ |  _  | '_ \| '_ \ 
                | \__/\ (_) | | | \__ \ (_) | |  __/ | | | | |_) | |_) |
                 \____/\___/|_| |_|___/\___/|_|\___| \_| |_/ .__/| .__/ 
                                                           | |   | |    
                                                           |_|   |_|  
  
";
            Console.WriteLine(text);




            int score = 0;

            Pokemon pikachu = new Pokemon(8, 1, "Pikachu", 10, false, PokemonType.Pikachu);

            Console.Write("Hello trainer! What is your name? ");
            string userName = Console.ReadLine();

            #region Specialty Selection

            var specialties = Enum.GetValues(typeof(Specialty));
            int index = 1;
            foreach (var specialty in specialties)
            {
                Console.WriteLine($"{index}) {specialty}");
                index++;
            }
            Console.WriteLine("Please select a specialty from the list above...");

            int userInput = int.Parse(Console.ReadLine()) - 1;
            Specialty userSpecialty = (Specialty)userInput;
            Console.WriteLine(userSpecialty);

            #endregion

            Player player = new Player(userName, 70, 5, 40, 40, userSpecialty, pikachu);

            Console.Clear();
            Console.WriteLine($"Welcome {player.Name}, your journey begins!");

            bool exit = false; 


            do
            {
                if (score < 3)
                {
                   
                    string room = GetRoom();
                    Console.WriteLine(room);

                    WildPoke wildPoke = WildPoke.GetWildPoke();

                    Console.WriteLine("Suddenly a wild " + wildPoke.Name + " appears.");

                    bool reload = false;

                    do
                    {
                        Console.Write("\nPlease choose an action:\n" +
                            "A) Attack\n" +
                            "R) Run away\n" +
                            "P) Player Info\n" +
                            "M) Wild Pokemon Info\n" +
                            "X) Exit\n");
                        string userChoice = Console.ReadKey(true).Key.ToString();
                        Console.Clear();

                        switch (userChoice)
                        {
                            case "A":
                                Console.WriteLine("Attack!");
                                

                                Combat.DoBattle(player, wildPoke);
                                if (wildPoke.Life <= 0)
                                {
                                    
                                    score++;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\nYou beat {wildPoke.Name}!");
                                    Console.Beep(700, 500);
                                    Console.ResetColor();
                                    reload = true; 
                                }
                                if (player.Life <= 0)
                                {
                                    Console.WriteLine("Your pokemon has fainted.\a");
                                    exit = true;
                                }
                                break;
                            case "R":
                                Console.WriteLine("Run away!");
                                

                                Console.WriteLine($"{wildPoke.Name} attacks you as you flee!");
                                Combat.DoAttack(wildPoke, player);
                                reload = true;
                                break;
                            case "P":
                                Console.WriteLine("Player Info");
                                Console.WriteLine(player);
                                Console.WriteLine("Wild Pokemon Defeated: " + score);
                                break;

                            case "M":
                                Console.WriteLine("Wild Pokemon Info");
                                Console.WriteLine(wildPoke);
                                break;

                            case "X":
                            case "E":
                            case "Escape":
                                Console.WriteLine("No one likes a quitter...");
                                
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Please try again...");
                                break;
                        }

                    } while (!exit && !reload);

                }

                else if (score >= 3)
                {
                   
                    Console.WriteLine("You have defeated " + score + " pokemon" + (score == 1 ? "." : "s."));
                    Console.WriteLine("You glance ahead as you push through the tall grass. You finally see the exit. \n You successfully found your way out of Viridian forest.\n Beyond the exit lies Pewter City, the next step in your Pokemon Journey.");
                    Console.WriteLine("\n\nThanks for playing! Press any key to exit...");
                    Console.ReadKey();
                    exit = true;
                }

            } while (!exit);
        
            
            Console.WriteLine("You defeated " + score + " pokemon" + (score == 1 ? "." : "s."));
            Console.WriteLine("\n\nThanks for playing! Press any key to exit...");
            Console.ReadKey();
        }
        
        private static string GetRoom()
        {
            string[] rooms =
            {
                "You continue forward as branches creak overhead. The light breaks through the canopy just enough for you to spot your next battle.",
                "As you advance, a fallen tree covered in green moss blocks the main path. You leave the path and wade through the damp decaying leaves on the forest bed.",
                "After healing up your pokemon, you feel as though the end of the path must be just up ahead. You increase your speed, stomping on fallen twigs and leaves. You might be wrong.",
                "Pushing forward you hear the wind whistling around you. The air tastes earthy and smells of wild herbs. You feel like you've reached close to the center of the forest.",
                "Carrying on you stop to admire some wildflowers growing a surprisingly bright clearing. Although the clearing looks as though it was once man made, nature had reclaimed it.",
                "You gather yourself and press on. You pass by a couple trainers who look eager to battle. You dont make eye contact and head off the path to avoid them."
            };
            return rooms[new Random().Next(rooms.Length)];
        }//end GetRoom
    }//end class
}//end namespace