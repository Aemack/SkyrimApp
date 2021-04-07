using CsvHelper;
using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace SkyrimGuide.Services
{
    public class DatabaseSetup
    {
        public static void SetUpData()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                if (DatabaseExists())
                {
                    return;
                }
            }
            bool databaseCreated = CreateDatabase();
            if (databaseCreated)
            {
                bool databasePopulated = PopulateDatabase();
            }
        }

        private static bool PopulateDatabase()
        {
            bool abilitiesComplete = PopulateAbilities();
            bool achievementsComplete = PopulateAchievements();
            bool alchemyComplete = PopulateAlchemy();
            bool booksComplete = PopulateBooks();
            bool collectiblesComplete = PopulateCollectibleItems();
            bool shoutsComplete = PopulateShouts();
            bool enchantsComplete = PopulateEnchants();
            bool followersComplete = PopulateFollowers();
            bool locationsComplete = PopulateLocations();
            bool merchantsComplete = PopulateMerchants();
            bool questsComplete = PopulateQuests();
            bool spellsComplete = PopulateSpells();
            bool gearComplete = PopulateGear();
            return true;

        }

        private static bool PopulateGear()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var gear = new List<UniqueGear>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(UniqueGear)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.UniqueGear.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                gear.Add(new UniqueGear
                                {
                                    Name = csvReader.GetField<string>(0),
                                    Type = csvReader.GetField<string>(1),
                                    Notes = csvReader.GetField<string>(2),
                                    Version = csvReader.GetField<string>(3)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(gear);
                return true;
            }
        }

        private static bool PopulateSpells()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var spells = new List<Spell>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Spell)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.Spells.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                spells.Add(new Spell
                                {
                                    Name = csvReader.GetField<string>(0),
                                    School = csvReader.GetField<string>(1),
                                    Level = csvReader.GetField<string>(2),
                                    Value = csvReader.GetField<string>(3),
                                    Description = csvReader.GetField<string>(4),
                                    Location = csvReader.GetField<string>(5),
                                    ItemID = csvReader.GetField<string>(6)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(spells);
                return true;
            }
        }

        private static bool PopulateQuests()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var quests = new List<Quest>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Quest)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.Quests.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                quests.Add(new Quest
                                {
                                    QuestName = csvReader.GetField<string>(0),
                                    Description = csvReader.GetField<string>(1),
                                    Giver = csvReader.GetField<string>(2),
                                    QuestClass = csvReader.GetField<string>(3),
                                    SubQuestClass = csvReader.GetField<string>(4),
                                    SubSubQuestClass = csvReader.GetField<string>(5)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(quests);
                return true;
            }
        }

        private static bool PopulateMerchants()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var merchants = new List<Merchant>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Merchant)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.Merchants.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                var newMerchant = new Merchant
                                {
                                    Name = csvReader.GetField<string>(0),
                                    PartnerOrReplacement = csvReader.GetField<string>(1),
                                    Region = csvReader.GetField<string>(4),
                                    StoreLocationName = csvReader.GetField<string>(5),
                                    Merchandise = csvReader.GetField<string>(6),
                                    Gold = csvReader.GetField<string>(7),
                                    Investable = csvReader.GetField<string>(8).Contains("Yes"),
                                    MasterTrader = csvReader.GetField<string>(9).Contains("Yes"),
                                    Notes = csvReader.GetField<string>(10)
                                };

                                if (!newMerchant.Investable) newMerchant.Invested = null;
                                merchants.Add(newMerchant);
                            }
                        }
                    }
                }


                conn.InsertAll(merchants);
                return true;
            }
        }

        private static bool PopulateLocations()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var locations = new List<Location>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Location)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.NotedLocations.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                locations.Add(new Location
                                {
                                    LocationName = csvReader.GetField<string>(0),
                                    Coordinates = csvReader.GetField<string>(1),
                                    LocationCategory = csvReader.GetField<string>(2),
                                    Region = csvReader.GetField<string>(3)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(locations);
                return true;
            }
        }

        private static bool PopulateFollowers()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var followers = new List<Follower>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Follower)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.Followers.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                followers.Add(new Follower
                                {
                                    Name = csvReader.GetField<string>(0),
                                    Alive = csvReader.GetField<string>(1).Contains("Y"),
                                    Description = csvReader.GetField<string>(2),
                                    PrimarySkills = csvReader.GetField<string>(3),
                                    PrerequisiteQuest = csvReader.GetField<string>(4),
                                    MaxLevel = csvReader.GetField<string>(5),
                                    Marry = csvReader.GetField<string>(6).Contains("X"),
                                    Blades = csvReader.GetField<string>(7).Contains("X"),
                                    Steward = csvReader.GetField<string>(8).Contains("X"),
                                    Pet = csvReader.GetField<string>(9).Contains("X"),
                                    Trainer = csvReader.GetField<string>(10)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(followers);
                return true;
            }
        }

        private static bool PopulateEnchants()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var enchantingEffects = new List<EnchantingEffect>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(EnchantingEffect)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.EnchantingEffects.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                enchantingEffects.Add(new EnchantingEffect
                                {
                                    EnchantmentName = csvReader.GetField<string>(0),
                                    WorksOnWeapon = csvReader.GetField<string>(1).Contains("X"),
                                    WorksOnHead = csvReader.GetField<string>(2).Contains("X"),
                                    WorksOnNeck = csvReader.GetField<string>(3).Contains("X"),
                                    WorksOnChest = csvReader.GetField<string>(4).Contains("X"),
                                    WorksOnHands = csvReader.GetField<string>(5).Contains("X"),
                                    WorksOnFinger = csvReader.GetField<string>(6).Contains("X"),
                                    WorksOnFeet = csvReader.GetField<string>(7).Contains("X"),
                                    WorksOnShield = csvReader.GetField<string>(8).Contains("X"),
                                    School = csvReader.GetField<string>(9),
                                    BaseMagnitude = csvReader.GetField<string>(10),
                                    BaseCost = csvReader.GetField<string>(11),
                                    Disenchant = csvReader.GetField<string>(12)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(enchantingEffects);
                return true;
            }
        }

        private static bool PopulateShouts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var shouts = new List<DragonShout>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DragonShout)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.DragonShouts.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                shouts.Add(new DragonShout
                                {
                                    WordOfPower = csvReader.GetField<string>(0),
                                    Translation = csvReader.GetField<string>(1),
                                    WordWallLocation = csvReader.GetField<string>(2),
                                    Shout = csvReader.GetField<string>(3),
                                    Version = csvReader.GetField<string>(4)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(shouts);
                return true;
            }
        }

        private static bool PopulateCollectibleItems()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var collectibleItems = new List<CollectibleItem>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(CollectibleItem)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.CollectibleItems.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                collectibleItems.Add(new CollectibleItem
                                {
                                    ItemName = csvReader.GetField<string>(0),
                                    Location = csvReader.GetField<string>(1),
                                    Quest = csvReader.GetField<string>(2),
                                    Type = csvReader.GetField<string>(3)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(collectibleItems);
                return true;
            }
        }

        private static bool PopulateBooks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var books = new List<Book>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Book)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.Books.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                books.Add(new Book
                                {
                                    BookTitle = csvReader.GetField<string>(0),
                                    Author = csvReader.GetField<string>(1),
                                    Description = csvReader.GetField<string>(2),
                                    Value = csvReader.GetField<string>(3),
                                    Type = csvReader.GetField<string>(4)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(books);
                return true;
            }
        }

        private static bool PopulateAlchemy()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var alchemyEffects = new List<AlchemyEffect>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AlchemyEffect)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.AlchemyEffects.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                alchemyEffects.Add(new AlchemyEffect
                                {
                                    ItemName = csvReader.GetField<string>(0),
                                    Effect = csvReader.GetField<string>(1)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(alchemyEffects);
                return true;
            }
        }

        private static bool PopulateAchievements()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var achievements = new List<Achievement>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Achievement)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.Achievements.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                achievements.Add(new Achievement
                                {
                                    Name = csvReader.GetField<string>(0),
                                    Version = csvReader.GetField<string>(1),
                                    Aquired = csvReader.GetField<string>(2),
                                    Quest = csvReader.GetField<string>(3)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(achievements);
                return true;
            }
        }

        private static bool PopulateAbilities()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var abilities = new List<Ability>();
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Ability)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("SkyrimGuide.Data.Abilities.csv");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    if (reader != null)
                    {
                        using (var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            while (csvReader.Read())
                            {
                                abilities.Add(new Ability
                                {
                                    Name = csvReader.GetField<string>(0),
                                    Version = csvReader.GetField<string>(1),
                                    AquiredFrom = csvReader.GetField<string>(2),
                                    Quest = csvReader.GetField<string>(3),
                                    Type = csvReader.GetField<string>(4)
                                });
                            }
                        }
                    }
                }


                conn.InsertAll(abilities);
                return true;
            }
        }

        private static bool CreateDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Ability>();
                conn.CreateTable<Achievement>();
                conn.CreateTable<AlchemyEffect>();
                conn.CreateTable<Book>();
                conn.CreateTable<CollectibleItem>();
                conn.CreateTable<DragonShout>();
                conn.CreateTable<EnchantingEffect>();
                conn.CreateTable<Follower>();
                conn.CreateTable<Location>();
                conn.CreateTable<Merchant>();
                conn.CreateTable<Quest>();
                conn.CreateTable<UniqueGear>();
                conn.CreateTable<Spell>();

                return true;
            }

        }

        public static bool DatabaseExists()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    var data = conn.Table<Ability>().ToList();
                    if (data.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
