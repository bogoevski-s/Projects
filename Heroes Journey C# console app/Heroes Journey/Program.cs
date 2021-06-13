using System;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Heroes_Journey
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Users> allUsers = new List<Users>
            {
                new Users("Slave_Bo", "slave@yahoo.com", "123"),
                new Users("userTest","test@gmail.com", "test123")
            };
            List<Race> allRaces = new List<Race>
            {
                new Race("Dwarf", 100, 6, 2),
                new Race("Elf", 60, 4, 6),
                new Race("Human", 80, 5, 4)
            };
            List<CharacterClass> allClasses = new List<CharacterClass>
            {
                new CharacterClass("Warrior", 20, -1),
                new CharacterClass("Rogue", -20, 1),
                new CharacterClass("Mage", 20, -1)
            };

            Login(allUsers);

            while (true)
            {
                Character newCharacterGame = CharaterCreate(allRaces, allClasses);
                Game(newCharacterGame);

                while (true)
                {
                    Console.WriteLine("1.Start new game\n2.Exit");
                    string userInputAfterAGame = Console.ReadLine();
                    bool inputAfterGameParsed = int.TryParse(userInputAfterAGame, out int afterGameChoise);
                    if (!inputAfterGameParsed || afterGameChoise < 1 || afterGameChoise > 3)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input!!!\nPlease select 1 or 2");
                        Console.ResetColor();
                        continue;
                    }
                    else if(afterGameChoise == 1)
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        return;
                    }
                }

            }
        }
        static void Login(List<Users> users)
        {
            while (true)
            {
                Console.WriteLine("Enter you email and password\n");
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("password: ");
                string pass = Console.ReadLine();
                Console.Clear();

                if (email.Length == 0 || pass.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fields must not be empty\n");
                    Console.ResetColor();
                    continue;
                }
                else if (!email.Contains("@") || !email.Contains(".com"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($@"Wrong email input you're missing @ or "".com"" ");
                    Console.ResetColor();
                    continue;
                }

                Users loginUser = users.FirstOrDefault(x => x.Email == email);

                if (loginUser != null)
                {
                    if (loginUser.CheckPassword(pass))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Welcome {loginUser.UserName}\n");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong password!!!\n");
                        Console.ResetColor();
                        continue;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User email not found\n");
                    Console.ResetColor();
                    continue;
                }

            }

        }
        
        static Character CharaterCreate(List<Race> allRaces, List<CharacterClass> allClasses)
        {
            Race seectedRace = null;

            CharacterClass seectedClass = null;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Wellcome to Heroes Journey\n");
                Console.ResetColor();
                Console.Write("Choose a name :");
                string inputNameCharacter = Console.ReadLine();
                Console.Clear();
                if (inputNameCharacter.Length <= 1 || inputNameCharacter.Length > 20)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nName must be longer than 1 character and less then 20 characters\n");
                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine("Please choose race to play with:\n");
                Console.WriteLine($"1.Dwarf");
                Console.WriteLine($"2.Elf");
                Console.WriteLine($"3.Human");
                string raceSelection = Console.ReadLine();
                Console.Clear();
                bool raceSelectionParsed = int.TryParse(raceSelection, out int raceSelectionNum);
                if (!raceSelectionParsed || raceSelectionNum < 1 || raceSelectionNum > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nWrong input!!\nPlease select numberic value from 1 - 3\n");
                    Console.ResetColor();
                    continue;
                }
                if (raceSelectionNum == 1)
                {
                    seectedRace = allRaces.FirstOrDefault(x => x.Name == "Dwarf");
                }
                else if (raceSelectionNum == 2)
                {
                    seectedRace = allRaces.FirstOrDefault(x => x.Name == "Elf");
                }
                else if (raceSelectionNum == 3)
                {
                    seectedRace = allRaces.FirstOrDefault(x => x.Name == "Human");
                }

                Console.WriteLine("Please choose class to play with:\n");
                Console.WriteLine($"1.Warrior");
                Console.WriteLine($"2.Rogue");
                Console.WriteLine($"3.Mage");
                string classSelection = Console.ReadLine();
                Console.Clear();
                bool classSelectionParsed = int.TryParse(classSelection, out int classSelectionNum);
                if (!classSelectionParsed || classSelectionNum < 1 || classSelectionNum > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nWrong input!!\nPlease select numberic value from 1 - 3\n");
                    Console.ResetColor();
                    continue;
                }

                if(classSelectionNum == 1)
                {
                    seectedClass = allClasses.FirstOrDefault(x => x.Name == "Warrior");
                }
                else if (classSelectionNum == 2)
                {
                    seectedClass = allClasses.FirstOrDefault(x => x.Name == "Rogue");
                }
                else if (classSelectionNum == 3)
                {
                    seectedClass = allClasses.FirstOrDefault(x => x.Name == "Mage");
                }

                Character newCharacter = new Character(inputNameCharacter, seectedRace, seectedClass);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfuly created character\n");
                Console.ForegroundColor = ConsoleColor.Blue; 
                Console.WriteLine($"{newCharacter.CharacterInfo()}\n");
                Console.WriteLine(newCharacter.Stats());
                Console.ResetColor();
                Console.WriteLine("Press any key to continue");
                string anyKeyToContiniue = Console.ReadLine();
                Console.Clear();
                return newCharacter;
            } 
        }

        static void Game(Character player)
        {
            int banditsDamage = -20;
            int guardsDamage = -30;
            int landSharkDamage = -50;
            int ratDamage = -10;
            int rockDamage = -30;
            while (true)
            {
                Console.WriteLine("Bandits attack you out of nowhere. They seem very dangerous..");
                Console.WriteLine($"\nHealth: {player.Health}");
                Console.WriteLine("\n1.Fight\n2.Run");
                string event1Selection = Console.ReadLine();
                Console.Clear();
                bool event1Parsed = int.TryParse(event1Selection, out int event1NumberSelect);
                if (!event1Parsed || event1NumberSelect < 1 || event1NumberSelect > 2)
                {
                    Console.WriteLine("\nWrong input!! Plese select 1 or 2\n");
                    continue;
                }
                FightOrRunSelect(event1NumberSelect, banditsDamage, player);
                if (player.Health <= 0) break;


                Console.WriteLine("You bump in to one of the guards of the nearby village. They attack you without warning...");
                Console.WriteLine($"\nHealth {player.Health}");
                Console.WriteLine("\n1.Fight\n2.Run");
                string event2Selection = Console.ReadLine();
                Console.Clear();
                bool event2Parsed = int.TryParse(event2Selection, out int event2NumberSelection);
                if (!event2Parsed || event2NumberSelection < 1 || event2NumberSelection > 2)
                {
                    Console.WriteLine("\nWrong input!! Plese select 1 or 2");
                    continue;
                }
                FightOrRunSelect(event2NumberSelection, guardsDamage, player);
                if (player.Health <= 0) break;


                Console.WriteLine("A Land Shark appears. It starts chasing you down to eat you...");
                Console.WriteLine($"\nHealth {player.Health}");
                Console.WriteLine("\n1.Fight\n2.Run");
                string event3Selection = Console.ReadLine();
                Console.Clear();
                bool event3Parsed = int.TryParse(event3Selection, out int event3NumberSelection);
                if (!event3Parsed || event3NumberSelection < 1 || event3NumberSelection > 2)
                {
                    Console.WriteLine("\nWrong input!! Plese select 1 or 2");
                    continue;
                }
                FightOrRunSelect(event3NumberSelection, landSharkDamage, player);
                if (player.Health <= 0) break;


                Console.WriteLine("You accidentally step on a rat. His friends are not happy. They attack..");
                Console.WriteLine($"\nHealth {player.Health}");
                Console.WriteLine("\n1.Fight\n2.Run");
                string event4Selection = Console.ReadLine();
                Console.Clear();
                bool event4Parsed = int.TryParse(event4Selection, out int event4NumberSelection);
                if (!event4Parsed || event4NumberSelection < 1 || event4NumberSelection > 2)
                {
                    Console.WriteLine("\nWrong input!! Plese select 1 or 2");
                    continue;
                }
                FightOrRunSelect(event4NumberSelection, ratDamage, player);
                if (player.Health <= 0) break;


                Console.WriteLine("You find a huge rock. It comes alive somehow and tries to smash you...");
                Console.WriteLine($"\nHealth {player.Health}");
                Console.WriteLine("\n1.Fight\n2.Run");
                string event5Selection = Console.ReadLine();
                Console.Clear();
                bool event5Parsed = int.TryParse(event5Selection, out int event5NumberSelection);
                if (!event5Parsed || event5NumberSelection < 1 || event5NumberSelection > 2)
                {
                    Console.WriteLine("\nWrong input!! Plese select 1 or 2");
                    continue;
                }
                FightOrRunSelect(event5NumberSelection, rockDamage, player);
                if (player.Health <= 0) break;

                Console.Clear();
                if (player.Health > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("YOU WON ! ! !\n");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("YOU LOSE ! ! !\n");
                    Console.ResetColor();
                    break;
                }
            }
        }

        static void FightOrRunSelect(int runOrFight, int eventNum, Character player)
        {
            if (runOrFight == 1)
            {
                Random rnd = new Random();
                int randNumber = rnd.Next(1, 10);
                if (randNumber > player.Race.Strength && player.Health > 0)
                {
                    player.Health += eventNum;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lost the fight");
                    Console.ResetColor();
                }
                else if (player.Health <= 0)
                {
                    player.Health = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lost\nGame over");
                    Console.ResetColor();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You win the fight");
                    Console.ResetColor();
                }
            }
            else if (runOrFight == 2)
            {
                Random rnd = new Random();
                int randNumber = rnd.Next(1, 10);
                if (randNumber > player.Agility && player.Health > 0)
                {
                    player.Health += eventNum;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("They catch you");
                    Console.ResetColor();
                }
                else if (player.Health <= 0)
                {
                    player.Health = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lost\nGame over");
                    Console.ResetColor();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You run away");
                    Console.ResetColor();
                }
            }
        }
    }
}
