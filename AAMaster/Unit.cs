using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMaster
{
    public static class BattleStats
    {
        public static List<Stat> Stats = new List<Stat>();
    }

    public class Stat
    {
        public string Power { get; set; }
        public bool Win { get; set; }

        public bool Offense { get; set; }
        public int Margin { get; set; }

        public Dictionary<int, int> Rolls = new Dictionary<int, int>()
        {
            {1,0 },
            {2,0 },
            {3,0 },
            {4,0 },
            {5,0 },
            {6,0 },
        };

        public int Hits { get; set; }

        public int Misses { get; set; }

        public double HitPercent
        {
            get
            {
                return (double)Hits / (Hits + Misses);
            }
        }

        public int IPCLoss { get; set; }
    }

    public static class Type
    {
        /// <summary>
        /// Surface ships
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool Naval(string name)
        {
            if (name == "Battleship" || name == "Destroyer" || name == "Carrier")
            {
                return true;
            }
            return false;
        }

        public static bool Sub(string name)
        {
            if (name == "Submarine")
            {
                return true;
            }
            return false;
        }

        public static bool Land(string name)
        {
            if (name == "Tank" || name == "Infantry")
            {
                return true;
            }
            return false;
        }

        public static bool Air(string name)
        {
            if (name == "Bomber" || name == "Fighter")
            {
                return true;
            }
            return false;
        }
    }

    public static class Extensions
    {
        public static bool Only(this IEnumerable<Unit> list, params string[] unitnames)
        {
            if (list.Any(x => !unitnames.Contains(x.Name)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class BattleResult
    {
        public int AttackHits { get; set; }
        public int DefendHits { get; set; }

        public int Rounds { get; set; }

        public List<int> AttackRolls = new List<int>();
        public List<int> DefendRolls = new List<int>();
    }

    public static class BattleCalculator
    {
        private static Random rand;
        public static int RollDie(bool weighted = false)
        {
            Dice d;

            if (weighted)
                d = new WeightedD6();
            else
                d = new D6();

            int value = d.Roll();

            if (Die.Record)
                Die.Rolls[value]++;

            return value;
        }

        private static void RemoveUnitType(Unit[] units, string name)
        {
            var remain = units.Where(x => x.Name != name);
            
            units = remain.ToArray();
        }

        public static bool UseWeightedDice = false;

        public static BattleResult FullBattle(Unit[] attacker, Unit[] defender, Func<Unit[], bool, int> calculation, bool border)
        {
            var b = new BattleResult();
            
            while (attacker.Length > 0 && defender.Length > 0 && UnitsThatCanFight(attacker, defender) && b.Rounds < 20)
            {
                // Battleships and Destroyers only give supporting bombardment on the first round.
                if (b.Rounds >= 1)
                {
                    if (attacker.Any(x => x.Name == "Battleship" || x.Name == "Destroyer") && attacker.Any(x => x.Name == "Infantry" || x.Name == "Tank"))
                    {
                        RemoveUnitType(attacker, "Battleship");
                        RemoveUnitType(attacker, "Destroyer");
                    }
                }

                int sub_attack;
                int air_attack;
                int naval_attack;
                int land_attack;

                int sub_defend;
                int air_defend;
                int naval_defend;
                int land_defend;

                sub_attack = calculation(attacker.Where(x => x.Name == "Submarine").ToArray(), true);
                sub_defend = calculation(defender.Where(x => x.Name == "Submarine").ToArray(), border);

                b.AttackHits += sub_attack;
                b.DefendHits += sub_defend;

                if (!defender.Any(x => x.Name == "Destroyer"))
                {
                    defender = RemoveUnits(defender, sub_attack, true, false, true, false);
                    sub_attack = 0;                      
                }
                
                if (!attacker.Any(x => x.Name == "Destroyer"))
                {
                    attacker = RemoveUnits(attacker, sub_defend, true, false, true, false);
                    sub_attack = 0;
                }

                air_attack = calculation(attacker.Where(x => x.Name == "Bomber" || x.Name == "Fighter").ToArray(), true);
                naval_attack = calculation(attacker.Where(x => x.Name == "Destroyer" || x.Name == "Battleship" || x.Name == "Carrier").ToArray(), true);
                land_attack = calculation(attacker.Where(x => x.Name == "Infantry" || x.Name == "Tank").ToArray(), true);

                b.AttackHits += air_attack;
                b.AttackHits += naval_attack;
                b.AttackHits += land_attack;

                air_defend = calculation(defender.Where(x => Type.Air(x.Name)).ToArray(), border);
                naval_defend = calculation(defender.Where(x => Type.Naval(x.Name)).ToArray(), border);
                land_defend = calculation(defender.Where(x => Type.Land(x.Name)).ToArray(), border);

                b.DefendHits += air_defend;
                b.DefendHits += naval_defend;
                b.DefendHits += land_defend;

                defender = RemoveUnits(defender, sub_attack, true, false, false, false);
                defender = RemoveUnits(defender, air_attack, false, true, false, false);
                defender = RemoveUnits(defender, naval_attack, false, false, false, false);
                defender = RemoveUnits(defender, land_attack, false, false, false, true);

                attacker = RemoveUnits(attacker, sub_defend, true, false, false, false);
                attacker = RemoveUnits(attacker, air_defend, false, true, false, false);
                attacker = RemoveUnits(attacker, naval_defend, false, false, false, false);
                attacker = RemoveUnits(attacker, land_defend, false, false, false, true);

                b.Rounds++;                
            }

            return b;
        }

        private static bool UnitsThatCanFight(Unit[] attacker, Unit[] defender)
        {
            if (attacker.Count(x => Type.Sub(x.Name)) == attacker.Length && defender.Count(x => Type.Naval(x.Name) || Type.Sub(x.Name)) == 0)
            {
                return false;
            }

            if (defender.Count(x => Type.Sub(x.Name)) == defender.Length && attacker.Count(x => Type.Naval(x.Name) || Type.Sub(x.Name)) == 0)
            {
                return false;
            }

            return true;
        }

        private static Unit[] RemoveUnits(Unit[] units, int count, bool sub, bool aircraft, bool sneak, bool land)
        {
            List<Unit> remain = new List<Unit>();
            remain.AddRange(units.OrderBy(x => x.Cost));
            for (int i = 0; i < count; i++)
            {
                for (int c = 0; c < remain.Count; c++)
                {
                    Unit u = remain[c];
                    if (sub)
                    {
                        if (!Type.Air(u.Name) && !Type.Land(u.Name) && !(!sneak && u.Name != "Submarine"))
                        {
                            if (u.Hits < 2)
                            {
                                remain.RemoveAt(c);
                            }
                            else
                            {
                                remain[c].Hits--;
                            }
                            
                            break;
                        }
                    }
                    else
                    {
                        if (aircraft)
                        {
                            if (u.Name != "Submarine")
                            {
                                if (u.Hits < 2)
                                {
                                    remain.RemoveAt(c);
                                }
                                else
                                {
                                    remain[c].Hits--;
                                }
                                break;
                            }
                        }
                        if (land)
                        {
                            if (!Type.Sub(u.Name) && !Type.Naval(u.Name))
                            {
                                if (u.Hits < 2)
                                {
                                    remain.RemoveAt(c);
                                }
                                else
                                {
                                    remain[c].Hits--;
                                }
                                break;
                            }
                        }
                        else
                        {
                            if (u.Hits < 2)
                            {
                                remain.RemoveAt(c);
                            }
                            else
                            {
                                remain[c].Hits--;
                            }
                            break;
                        }
                    }
                }
            }
            return remain.ToArray();
        }

        /// <summary>
        /// Get the average number of hits as a pure probability. Use for a perfectly predictable set of outcomes.
        /// </summary>
        /// <param name="units"></param>
        /// <param name="attacking"></param>
        /// <returns></returns>
        public static int NonLuckHits(Unit[] units, bool attacking)
        {
            int result;
            if (attacking)
            {
                var p = (double)units.Sum(x => x.Attack) / 6;
                result = (int)Math.Round(p);
            }
            else
            {
                var p = (double)units.Sum(x => x.Defend) / 6;
                result = (int)Math.Round(p);
            }            

            return result;
        }

        /// <summary>
        /// Ignore unit types - everything hits every time.
        /// </summary>
        /// <param name="units"></param>
        /// <param name="attacking"></param>
        /// <returns></returns>
        public static int Bloodbath(Unit[] units, bool attacking)
        {
            return units.Length;
        }

        /// <summary>
        /// Use probability with a slight variability. Use for a reasonably predictable set of outcomes.
        /// </summary>
        /// <param name="units"></param>
        /// <param name="attacking"></param>
        /// <returns></returns>
        public static int LowLuckHits(Unit[] units, bool attacking)
        {
            if (rand == null)
                rand = new Random();

            int result;
            double p;
            if (attacking)
            {
                p = (double)units.Sum(x => x.Attack) / 6;
            }
            else
            {
                p = (double)units.Sum(x => x.Defend) / 6;
            }

            if (rand.Next(0,2) < 1)
            {
                result = (int)Math.Ceiling(p);
            }
            else
            {
                result = (int)Math.Floor(p);
            }

            return result;
        }

        /// <summary>
        /// Calculate hits in the manner of dice rolls. Any outcome between zero and number of units is possible.
        /// </summary>
        /// <param name="units"></param>
        /// <param name="attacking"></param>
        /// <returns></returns>
        public static int Hits(Unit[] units, bool attacking)
        {
            int hits = 0;
            if (attacking)
            {
                foreach (Unit u in units)
                {
                    for (int i = 0; i < u.Rolls; i++)
                    {
                        if (RollDie(UseWeightedDice) <= u.Attack)
                        {
                            hits++;
                        }
                    }
                }   
            }
            else
            {
                foreach (Unit u in units)
                {
                    for (int i = 0; i < u.Rolls; i++)
                    {
                        if (RollDie(UseWeightedDice) <= u.Defend)
                        {
                            hits++;
                        }
                    }                    
                }
            }
            return hits;
        }

        public static BattleResult RPSFullBattle(Unit[] attacker, Unit[] defender)
        {
            var b = new BattleResult(); 

            while (attacker.Length > 0 && defender.Length > 0 && UnitsThatCanFight(attacker, defender) && b.Rounds < 20)
            {
                // Battleships and Destroyers only give supporting bombardment on the first round.
                if (b.Rounds >= 1)
                {
                    if (attacker.Any(x => x.Name == "Battleship" || x.Name == "Destroyer") && attacker.Any(x => x.Name == "Infantry" || x.Name == "Tank"))
                    {
                        RemoveUnitType(attacker, "Battleship");
                        RemoveUnitType(attacker, "Destroyer");
                    }
                }

                BattleResult r = RPSBattleRound(attacker, defender);                

                defender = RemoveUnits(defender, r.AttackHits, false, false, false, false);                
                attacker = RemoveUnits(attacker, r.DefendHits, false, false, false, false);

                b.AttackHits += r.AttackHits;
                b.DefendHits += r.DefendHits;
                b.Rounds++;
            }

            return b;
        }
        
        public static BattleResult RPSBattleRound(Unit[] Attacker, Unit[] Defender)
        {
            if (rand == null)
                rand = new Random();

            BattleResult r = new BattleResult();

            Attacker = Attacker.Select(x => x).OrderBy(x => rand.Next()).ToArray();
            Defender = Defender.Select(x => x).OrderBy(x => rand.Next()).ToArray();

            for (int i = 0; i < Attacker.Length; i++)
            {
                if (Defender.Length > i)
                {
                    if (RPSAttack(Attacker[i], Defender[i]))
                    {
                        r.AttackHits++;
                    }
                    else
                    {
                        r.DefendHits++;
                    }
                }
                else
                {
                    break;
                }
            }
            return r;  
        }
        
        private static bool RPSAttack(Unit Attacker, Unit Defender)
        {
            int atk = Attacker.Attack * Attacker.Hits;
            int def = Defender.Defend * Defender.Hits;

            while (atk > 0 && def > 0)
            {
                int r = RPS.Check(RPS.Get(), RPS.Get());

                if (r > 0)
                    Die.Rolls[r]++;
                else
                    Die.Rolls[6]++;

                if (r == 1)
                    def--;
                else if (r == 2)
                    atk--;
            }

            return atk > def;
        }   
    }

    public enum RockPaperScissors
    {
        Rock, Paper, Scissors
    }

    public static class RPS
    {
        static Random rand = new Random(5432198);
        public static RockPaperScissors Get()
        {
            return (RockPaperScissors)(rand.Next(0, 300) / 100);
        }

        /// <summary>
        /// Check to see who won. Returns 0 for draw, 1 for first, 2 for second.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static int Check(RockPaperScissors first, RockPaperScissors second)
        {                        
            if (first == second)
            {
                return 0; 
            } 
            
            if (first == RockPaperScissors.Rock)
            {
                if (second == RockPaperScissors.Paper)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }

            if (first == RockPaperScissors.Paper)
            {
                if (second == RockPaperScissors.Scissors)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }

            if (first == RockPaperScissors.Scissors)
            {
                if (second == RockPaperScissors.Rock)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }

            return 0;
        }
    }       

    public static class UnitDefinitions
    {
        public static Unit[] Multiple(Unit u, decimal Qty)
        {
            List<Unit> l = new List<Unit>();
            for (int i = 0; i < Qty; i++)
            {
                l.Add(new Unit(u.Name, u.Attack, u.Defend, u.Cost, u.Hits, u.Rolls, u.Movement));
            }
            return l.ToArray();
        }

        public static Unit Infantry
        {
            get
            {
                return new Unit("Infantry", 1, 2, 3, 1, 1, 1);
            }
        }

        public static Unit Tank
        {
            get
            {
                return new Unit("Tank", 3, 3, 6, 1, 1, 2);
            }
        }

        public static Unit Fighter
        {
            get
            {
                return new Unit("Fighter", 3, 4, 10, 1, 1, 4);
            }
        }

        public static Unit Bomber
        {
            get
            {
                return new Unit("Bomber", 4, 1, 12, 1, 1, 6);
            }
        }

        public static Unit Submarine
        {
            get
            {
                return new Unit("Submarine", 2, 1, 6, 1, 1, 2);
            }
        }

        public static Unit Destroyer
        {
            get
            {
                return new Unit("Destroyer", 2, 2, 8, 1, 1, 2);
            }
        }

        public static Unit Battleship
        {
            get
            {
                return new Unit("Battleship", 4, 4, 16, 2, 1, 2);
            }
        }

        public static Unit Carrier
        {
            get
            {
                return new Unit("Carrier", 1, 2, 12, 1, 1, 2);
            }
        }
    }

    public class Unit
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defend { get; set; }

        public int NetAttack { get { return Attack * Rolls; } }
        public int NetDefend { get { return Defend * Rolls; } }

        public int Hits { get; set; }

        public int Cost { get; set; }

        public int Rolls { get; set; }

        public int Movement { get; set; } = 1;

        public Unit(string name, int atk, int def, int cost, int hits, int rolls, int movement)
        {
            Name = name;
            Attack = atk;
            Defend = def;
            Cost = cost;
            Hits = hits;
            Rolls = rolls;
            Movement = movement;
        }
    }
}
