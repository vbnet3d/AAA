using AAMaster;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAMaster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            AttackerIPCs();
        }

        private int GetInfantryMod(ComboBox cmb)
        {
            if (cmb.SelectedItem == null) { return 0; }

            if (cmb == cmbAttacker)
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rainf.Value;
                    case "Germany":
                        return (int)gainf.Value;
                    case "UK":
                        return (int)bainf.Value;
                    case "Japan":
                        return (int)jainf.Value;
                    case "USA":
                        return (int)aainf.Value;
                }

            }
            else
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rdinf.Value;
                    case "Germany":
                        return (int)gdinf.Value;
                    case "UK":
                        return (int)bdinf.Value;
                    case "Japan":
                        return (int)jdinf.Value;
                    case "USA":
                        return (int)adinf.Value;
                }
            }

            return 0;
        }

        private int GetTankMod(ComboBox cmb)
        {
            if (cmb.SelectedItem == null) { return 0; }

            if (cmb == cmbAttacker)
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)ratnk.Value;
                    case "Germany":
                        return (int)gatnk.Value;
                    case "UK":
                        return (int)batnk.Value;
                    case "Japan":
                        return (int)jatnk.Value;
                    case "USA":
                        return (int)aatnk.Value;
                }

            }
            else
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rdtnk.Value;
                    case "Germany":
                        return (int)gdtnk.Value;
                    case "UK":
                        return (int)bdtnk.Value;
                    case "Japan":
                        return (int)jdtnk.Value;
                    case "USA":
                        return (int)adtnk.Value;
                }
            }

            return 0;
        }

        private int GetFighterMod(ComboBox cmb)
        {
            if (cmb.SelectedItem == null) { return 0; }

            if (cmb == cmbAttacker)
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rafig.Value;
                    case "Germany":
                        return (int)gafig.Value;
                    case "UK":
                        return (int)bafig.Value;
                    case "Japan":
                        return (int)jafig.Value;
                    case "USA":
                        return (int)aafig.Value;
                }

            }
            else
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rdfig.Value;
                    case "Germany":
                        return (int)gdfig.Value;
                    case "UK":
                        return (int)bdfig.Value;
                    case "Japan":
                        return (int)jdfig.Value;
                    case "USA":
                        return (int)adfig.Value;
                }
            }

            return 0;
        }

        private int GetBomberMod(ComboBox cmb)
        {
            if (cmb.SelectedItem == null) { return 0; }

            if (cmb == cmbAttacker)
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rabom.Value;
                    case "Germany":
                        return (int)gabom.Value;
                    case "UK":
                        return (int)babom.Value;
                    case "Japan":
                        return (int)jabom.Value;
                    case "USA":
                        return (int)aabom.Value;
                }

            }
            else
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rdbom.Value;
                    case "Germany":
                        return (int)gdbom.Value;
                    case "UK":
                        return (int)bdbom.Value;
                    case "Japan":
                        return (int)jdbom.Value;
                    case "USA":
                        return (int)adbom.Value;
                }
            }

            return 0;
        }

        private int GetSubMod(ComboBox cmb)
        {
            if (cmb.SelectedItem == null) { return 0; }

            if (cmb == cmbAttacker)
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rasub.Value;
                    case "Germany":
                        return (int)gasub.Value;
                    case "UK":
                        return (int)basub.Value;
                    case "Japan":
                        return (int)jasub.Value;
                    case "USA":
                        return (int)aasub.Value;
                }

            }
            else
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rdsub.Value;
                    case "Germany":
                        return (int)gdsub.Value;
                    case "UK":
                        return (int)bdsub.Value;
                    case "Japan":
                        return (int)jdsub.Value;
                    case "USA":
                        return (int)adsub.Value;
                }
            }

            return 0;
        }

        private int GetDestroyerMod(ComboBox cmb)
        {
            if (cmb.SelectedItem == null) { return 0; }

            if (cmb == cmbAttacker)
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rades.Value;
                    case "Germany":
                        return (int)gades.Value;
                    case "UK":
                        return (int)bades.Value;
                    case "Japan":
                        return (int)jades.Value;
                    case "USA":
                        return (int)aades.Value;
                }

            }
            else
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rddes.Value;
                    case "Germany":
                        return (int)gddes.Value;
                    case "UK":
                        return (int)bddes.Value;
                    case "Japan":
                        return (int)jddes.Value;
                    case "USA":
                        return (int)addes.Value;
                }
            }

            return 0;
        }

        private int GetBattleshipMod(ComboBox cmb)
        {
            if (cmb.SelectedItem == null) { return 0; }

            if (cmb == cmbAttacker)
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rabat.Value;
                    case "Germany":
                        return (int)gabat.Value;
                    case "UK":
                        return (int)babat.Value;
                    case "Japan":
                        return (int)jabat.Value;
                    case "USA":
                        return (int)aabat.Value;
                }

            }
            else
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rdbat.Value;
                    case "Germany":
                        return (int)gdbat.Value;
                    case "UK":
                        return (int)bdbat.Value;
                    case "Japan":
                        return (int)jdbat.Value;
                    case "USA":
                        return (int)adbat.Value;
                }
            }

            return 0;
        }

        private int GetCarrierMod(ComboBox cmb)
        {
            if (cmb.SelectedItem == null) { return 0; }

            if (cmb == cmbAttacker)
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)racar.Value;
                    case "Germany":
                        return (int)gacar.Value;
                    case "UK":
                        return (int)bacar.Value;
                    case "Japan":
                        return (int)jacar.Value;
                    case "USA":
                        return (int)aacar.Value;
                }

            }
            else
            {
                switch (cmb.SelectedItem.ToString())
                {
                    case "Russia":
                        return (int)rdcar.Value;
                    case "Germany":
                        return (int)gdcar.Value;
                    case "UK":
                        return (int)bdcar.Value;
                    case "Japan":
                        return (int)jdcar.Value;
                    case "USA":
                        return (int)adcar.Value;
                }
            }

            return 0;
        }

        private void HeavyBomber(List<Unit> group, ComboBox cmb)
        {
            if (cmb.SelectedItem == null) { return; }

            switch (cmb.SelectedItem.ToString())
            {
                case "Russia":
                    if (chkRusHvyBomber.Checked)
                    {
                        foreach (Unit b in group.Where(x => x.Name == "Bomber"))
                        {
                            b.Rolls = 2;
                        }
                    }
                    return;
                case "Germany":
                    if (chkGerHvhBomber.Checked)
                    {
                        foreach (Unit b in group.Where(x => x.Name == "Bomber"))
                        {
                            b.Rolls = 2;
                        }
                    }
                    return;
                case "UK":
                    if (chkUKHvyBomber.Checked)
                    {
                        foreach (Unit b in group.Where(x => x.Name == "Bomber"))
                        {
                            b.Rolls = 2;
                        }
                    }
                    return;
                case "Japan":
                    if (chkRusHvyBomber.Checked)
                    {
                        foreach (Unit b in group.Where(x => x.Name == "Bomber"))
                        {
                            b.Rolls = 2;
                        }
                    }
                    return;
                case "USA":
                    if (chkUSHvyBomber.Checked)
                    {
                        foreach (Unit b in group.Where(x => x.Name == "Bomber"))
                        {
                            b.Rolls = 2;
                        }
                    }
                    return;
            }

        }

        private List<Unit> GetAttacker()
        {
            int AttackerInfantryMod = GetInfantryMod(cmbAttacker);
            int AttackerTankMod = GetTankMod(cmbAttacker);
            int AttackerFighterMod = GetFighterMod(cmbAttacker);
            int AttackerBomberMod = GetBomberMod(cmbAttacker);
            int AttackerSubMod = GetSubMod(cmbAttacker);
            int AttackerDestroyerMod = GetDestroyerMod(cmbAttacker);
            int AttackerBattleshipMod = GetBattleshipMod(cmbAttacker);
            int AttackerCarrierMod = GetCarrierMod(cmbAttacker);


            List<Unit> Attacker = new List<Unit>();

            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Infantry, ainf.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Tank, atnk.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Fighter, afig.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Bomber, abom.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Submarine, asub.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Destroyer, ades.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Battleship, abat.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Carrier, acar.Value));

            foreach (Unit u in Attacker)
            {
                switch (u.Name)
                {
                    case "Infantry":
                        u.Attack += AttackerInfantryMod;
                        break;
                    case "Tank":
                        u.Attack += AttackerTankMod;
                        break;
                    case "Fighter":
                        u.Attack += AttackerFighterMod;
                        break;
                    case "Bomber":
                        u.Attack += AttackerBomberMod;
                        break;
                    case "Submarine":
                        u.Attack += AttackerSubMod;
                        break;
                    case "Destroyer":
                        u.Attack += AttackerDestroyerMod;
                        break;
                    case "Battleship":
                        u.Attack += AttackerBattleshipMod;
                        break;
                    case "Carrier":
                        u.Attack += AttackerCarrierMod;
                        break;
                }
            }

            HeavyBomber(Attacker, cmbAttacker);

            if (cmbAttacker.SelectedItem.ToString() == "Germany")
            {
                // SS Panzerkorps
                if (chkPZ.Checked && Attacker.Any(x => x.Name == "Tank"))
                {
                    Attacker.Where(x => x.Name == "Tank").First().Attack += 1;
                }

                // Wolfpack National Advantage
                // When Germany attacks with 2 or more subs 
                // All the subs receive +1 attack.
                if (Attacker.Count(x => x.Name == "Submarine") >= 2)
                {
                    foreach (Unit sub in Attacker.Where(x => x.Name == "Submarine"))
                    {
                        sub.Attack++;
                    }
                }

                
            }

            return Attacker;
        }

        private List<Unit> GetDefender()
        {
            int DefenderInfantryMod = GetInfantryMod(cmbDefender);
            int DefenderTankMod = GetTankMod(cmbDefender);
            int DefenderFighterMod = GetFighterMod(cmbDefender);
            int DefenderBomberMod = GetBomberMod(cmbDefender);
            int DefenderSubMod = GetSubMod(cmbDefender);
            int DefenderDestroyerMod = GetDestroyerMod(cmbDefender);
            int DefenderBattleshipMod = GetBattleshipMod(cmbDefender);
            int DefenderCarrierMod = GetCarrierMod(cmbDefender);

            List<Unit> Defender = new List<Unit>();

            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Infantry, dinf.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Tank, dtnk.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Fighter, dfig.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Bomber, dbom.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Submarine, dsub.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Destroyer, ddes.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Battleship, dbat.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Carrier, dcar.Value));

            foreach (Unit u in Defender)
            {
                switch (u.Name)
                {
                    case "Infantry":
                        u.Defend += DefenderInfantryMod;
                        break;
                    case "Tank":
                        u.Defend += DefenderTankMod;
                        break;
                    case "Fighter":
                        u.Defend += DefenderFighterMod;
                        break;
                    case "Bomber":
                        u.Defend += DefenderBomberMod;
                        break;
                    case "Submarine":
                        u.Defend += DefenderSubMod;
                        break;
                    case "Destroyer":
                        u.Defend += DefenderDestroyerMod;
                        break;
                    case "Battleship":
                        u.Defend += DefenderBattleshipMod;
                        break;
                    case "Carrier":
                        u.Defend += DefenderCarrierMod;
                        break;
                }
            }


            HeavyBomber(Defender, cmbDefender);


            if (cmbDefender.SelectedItem != null && cmbDefender.SelectedItem.ToString() == "Germany")
            {
                // SS Panzerkorps
                if (chkPZ.Checked && Defender.Any(x => x.Name == "Tank"))
                {
                    Defender.Where(x => x.Name == "Tank").First().Defend += 2;
                } 
            }

            return Defender;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblRounds.Text = "";

            if (cmbAttacker.SelectedIndex < 0)
            {
                MessageBox.Show("Set the attacking power.");
                return;
            }

            if (cmbDefender.SelectedIndex < 0)
            {
                MessageBox.Show("Set the defending power.");
                return;
            }

            var Attacker = GetAttacker();
            var Defender = GetDefender();

            int attackCommitted = Attacker.Count;
            int defendCommitted = Defender.Count;

            // Dive bombers national advantage 
            // Unaccompanied ground units v.s. fighters
            if (cmbAttacker.SelectedItem.ToString() == "Germany" && Defender.Only("Tank", "Infantry"))
            {
                foreach (Unit f in Attacker.Where(x => x.Name == "Fighter"))
                {
                    f.Attack += 1;
                }
            }


            int def = 0;
            int off = 0;
            if (chkFullBattle.Checked)
            {
                BattleResult b = BattleCalculator.FullBattle(Attacker.ToArray(), Defender.ToArray(), GetMethod());

                def = b.AttackHits;
                off = b.DefendHits;
                lblRounds.Text = b.Rounds + " round(s) of battle.";
            }
            else
            {
                def = Calculate(Attacker.ToArray(), true);
                off = Calculate(Defender.ToArray(), false);
            }

            lblDefCasualties.Text = def.ToString();
            lblCasualties.Text = off.ToString();
            if (def < off)
            {
                Stat s = new Stat();
                s.Power = cmbAttacker.SelectedItem.ToString();
                s.Win = false;
                s.Offense = true;
                s.Margin = -(off - def);
                s.Hits = def;

                Stat s2 = new Stat();
                s2.Power = cmbDefender.SelectedItem.ToString();
                s2.Win = true;
                s2.Offense = false;
                s2.Margin = -(def - off);
                s2.Hits = off;

                BattleStats.Stats.Add(s);
                BattleStats.Stats.Add(s2);
            }
            else
            {
                Stat s = new Stat();
                s.Power = cmbDefender.SelectedItem.ToString();
                s.Win = false;
                s.Offense = false;
                s.Margin = (off - def);
                s.Hits = off;

                Stat s2 = new Stat();
                s2.Power = cmbAttacker.SelectedItem.ToString();
                s2.Win = def > off;
                s2.Offense = true;
                s2.Margin = (def - off);
                s2.Hits = def;

                BattleStats.Stats.Add(s);
                BattleStats.Stats.Add(s2);
            }

            fade2.Enabled = true;
            UpdateStats();
            UpdateDiceStats();
        }

        private void UpdateStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (object o in cmbAttacker.Items)
            {
                string p = o.ToString();

                sb.AppendLine(p);
                sb.AppendLine("===============");
                if (BattleStats.Stats.Any(x => x.Power == p))
                {
                    sb.AppendLine("Wins   : " + BattleStats.Stats.Count(x => x.Power == p && x.Win).ToString().PadLeft(5));
                    sb.AppendLine("Loss   : " + BattleStats.Stats.Count(x => x.Power == p && !x.Win && x.Margin != 0).ToString().PadLeft(5));
                    sb.AppendLine("Draw   : " + BattleStats.Stats.Count(x => x.Power == p && !x.Win && x.Margin == 0).ToString().PadLeft(5));
                    sb.AppendLine("Margin : " + Math.Round(BattleStats.Stats.Where(x => x.Power == p).Average(x => x.Margin), 2).ToString().PadLeft(5));
                    sb.AppendLine("Force  : " + BattleStats.Stats.Where(x => x.Power == p).Sum(x => x.Margin).ToString().PadLeft(5));
                    sb.AppendLine("Attack : " + BattleStats.Stats.Where(x => x.Power == p && x.Offense).Count().ToString().PadLeft(5));
                    sb.AppendLine("Defend : " + BattleStats.Stats.Where(x => x.Power == p && !x.Offense).Count().ToString().PadLeft(5));
                    sb.AppendLine("Hits   : " + BattleStats.Stats.Where(x => x.Power == p).Sum(x => x.Hits).ToString().PadLeft(5));
                    sb.AppendLine("Battles: " + BattleStats.Stats.Count.ToString().PadLeft(5));
                }
                else
                {
                    sb.AppendLine("No data.");
                }
                sb.AppendLine("===============");
            }

            lblStats.Text = sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Unit[] subs = UnitDefinitions.Multiple(UnitDefinitions.Submarine, sneakSubs.Value);

            lblSneakHits.Text = Calculate(subs, true).ToString();

            fade2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Unit[] subs = UnitDefinitions.Multiple(UnitDefinitions.Submarine, sneakSubs.Value);

            lblSneakHits.Text = Calculate(subs, false).ToString();

            fade2.Enabled = true;
        }

        private int count = 255;
        private void fade_Tick(object sender, EventArgs e)
        {
            if (count < 255)
            {
                tabPage1.BackColor = Color.FromArgb(255, count, count);
                tabPage4.BackColor = Color.FromArgb(255, count, count);
                count += 100;
            }
            else
            {
                fade.Enabled = false;
                count = 255;
                tabPage1.BackColor = Color.FromArgb(255, count, count);
                tabPage4.BackColor = Color.FromArgb(255, count, count);
            }
        }

        private void fade2_Tick(object sender, EventArgs e)
        {
            if (count > 0)
            {
                tabPage1.BackColor = Color.FromArgb(255, count, count);
                tabPage4.BackColor = Color.FromArgb(255, count, count);
                count -= 100;
            }
            else
            {
                count = 0;
                fade2.Enabled = false;
                fade.Enabled = true;
            }
        }

        private void UpdateDiceStats()
        {
            DiceLabel.Text = "Dice Stats\n====================";
            int total = Die.Rolls.Sum(x => x.Value);

            foreach (KeyValuePair<int, int> stat in Die.Rolls)
            {
                DiceLabel.Text += "\n" + Die.Symbol(stat.Key) + " - " + stat.Value.ToString() + " | " + ((double)stat.Value / total).ToString("0.0%");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = Die.Symbol(BattleCalculator.RollDie());
            UpdateDiceStats();
            fade2.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            flowDice.Controls.Clear();
            for (int i = 0; i < numDice.Value; i++)
            {
                Label l = new Label();
                l.Font = new Font("Arial", 48);
                int value = BattleCalculator.RollDie();

                if (cmbOp.SelectedIndex == 0)
                {
                    if (value <= numTarget.Value)
                    {
                        l.ForeColor = Color.Red;
                    }
                }
                else
                {
                    if (value >= numTarget.Value)
                    {
                        l.ForeColor = Color.Red;
                    }
                }

                l.Text = Die.Symbol(value);
                l.Width = 48;
                l.Height = 64;
                flowDice.Controls.Add(l);
            }
            UpdateDiceStats();
        }

        private void cmbDefender_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DefenderInfantryMod = GetInfantryMod(cmbDefender);
            int DefenderTankMod = GetTankMod(cmbDefender);
            int DefenderFighterMod = GetFighterMod(cmbDefender);
            int DefenderBomberMod = GetBomberMod(cmbDefender);
            int DefenderSubMod = GetSubMod(cmbDefender);
            int DefenderDestroyerMod = GetDestroyerMod(cmbDefender);
            int DefenderBattleshipMod = GetBattleshipMod(cmbDefender);
            int DefenderCarrierMod = GetCarrierMod(cmbDefender);

            if (DefenderInfantryMod > 0)
            {
                dinfmod.Text = "+" + DefenderInfantryMod.ToString();
                dinfmod.ForeColor = Color.Green;
            }
            else
            {
                dinfmod.Text = "";
            }

            DefenderIPCs();
        }

        private void cmbAttacker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AttackerInfantryMod = GetInfantryMod(cmbAttacker);
            int AttackerTankMod = GetTankMod(cmbAttacker);
            int AttackerFighterMod = GetFighterMod(cmbAttacker);
            int AttackerBomberMod = GetBomberMod(cmbAttacker);
            int AttackerSubMod = GetSubMod(cmbAttacker);
            int AttackerDestroyerMod = GetDestroyerMod(cmbAttacker);
            int AttackerBattleshipMod = GetBattleshipMod(cmbAttacker);
            int AttackerCarrierMod = GetCarrierMod(cmbAttacker);


            if (AttackerInfantryMod > 0)
            {
                ainfmod.Text = "+" + AttackerInfantryMod.ToString();
                ainfmod.ForeColor = Color.Green;
            }
            else
            {
                ainfmod.Text = "";
            }

            AttackerIPCs();
        }

        private int Calculate(Unit[] units, bool attacking)
        {
            return GetMethod()(units, attacking);
        }

        private Func<Unit[], bool, int> GetMethod()
        {
            if (rdoLowLuck.Checked)
            {
                return BattleCalculator.LowLuckHits;
            }
            if (rdoNoLuck.Checked)
            {
                return BattleCalculator.NonLuckHits;
            }
            if (radBloodbath.Checked)
            {
                return BattleCalculator.Bloodbath;
            }
            return BattleCalculator.Hits;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbAttacker.SelectedIndex = 0;
            cmbDefender.SelectedIndex = 1;
            cmbFocus.SelectedIndex = 0;
            cmbOp.SelectedIndex = 0;
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            int AttackerInfantryMod = GetInfantryMod(cmbAttacker);
            int AttackerTankMod = GetTankMod(cmbAttacker);
            int AttackerFighterMod = GetFighterMod(cmbAttacker);
            int AttackerBomberMod = GetBomberMod(cmbAttacker);
            int AttackerSubMod = GetSubMod(cmbAttacker);
            int AttackerDestroyerMod = GetDestroyerMod(cmbAttacker);
            int AttackerBattleshipMod = GetBattleshipMod(cmbAttacker);
            int AttackerCarrierMod = GetCarrierMod(cmbAttacker);


            List<Unit> Attacker = new List<Unit>();

            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Infantry, ainf.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Tank, atnk.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Fighter, afig.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Bomber, abom.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Submarine, asub.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Destroyer, ades.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Battleship, abat.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Carrier, acar.Value));

            foreach (Unit u in Attacker)
            {
                switch (u.Name)
                {
                    case "Infantry":
                        u.Attack += AttackerInfantryMod;
                        break;
                    case "Tank":
                        u.Attack += AttackerTankMod;
                        break;
                    case "Fighter":
                        u.Attack += AttackerFighterMod;
                        break;
                    case "Bomber":
                        u.Attack += AttackerBomberMod;
                        break;
                    case "Submarine":
                        u.Attack += AttackerSubMod;
                        break;
                    case "Destroyer":
                        u.Attack += AttackerDestroyerMod;
                        break;
                    case "Battleship":
                        u.Attack += AttackerBattleshipMod;
                        break;
                    case "Carrier":
                        u.Attack += AttackerCarrierMod;
                        break;
                }
            }


            int DefenderInfantryMod = GetInfantryMod(cmbDefender);
            int DefenderTankMod = GetTankMod(cmbDefender);
            int DefenderFighterMod = GetFighterMod(cmbDefender);
            int DefenderBomberMod = GetBomberMod(cmbDefender);
            int DefenderSubMod = GetSubMod(cmbDefender);
            int DefenderDestroyerMod = GetDestroyerMod(cmbDefender);
            int DefenderBattleshipMod = GetBattleshipMod(cmbDefender);
            int DefenderCarrierMod = GetCarrierMod(cmbDefender);

            List<Unit> Defender = new List<Unit>();

            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Infantry, dinf.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Tank, dtnk.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Fighter, dfig.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Bomber, dbom.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Submarine, dsub.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Destroyer, ddes.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Battleship, dbat.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Carrier, dcar.Value));

            foreach (Unit u in Defender)
            {
                switch (u.Name)
                {
                    case "Infantry":
                        u.Defend += DefenderInfantryMod;
                        break;
                    case "Tank":
                        u.Defend += DefenderTankMod;
                        break;
                    case "Fighter":
                        u.Defend += DefenderFighterMod;
                        break;
                    case "Bomber":
                        u.Defend += DefenderBomberMod;
                        break;
                    case "Submarine":
                        u.Defend += DefenderSubMod;
                        break;
                    case "Destroyer":
                        u.Defend += DefenderDestroyerMod;
                        break;
                    case "Battleship":
                        u.Defend += DefenderBattleshipMod;
                        break;
                    case "Carrier":
                        u.Defend += DefenderCarrierMod;
                        break;
                }
            }

            HeavyBomber(Attacker, cmbAttacker);
            HeavyBomber(Defender, cmbDefender);

            if (cmbAttacker.SelectedItem.ToString() == "Germany")
            {
                // SS Panzerkorps
                if (chkPZ.Checked && Attacker.Any(x => x.Name == "Tank"))
                {
                    Attacker.Where(x => x.Name == "Tank").First().Attack += 1;
                }

                // Wolfpack National Advantage
                // When Germany attacks with 2 or more subs 
                // All the subs receive +1 attack.
                if (Attacker.Count(x => x.Name == "Submarine") >= 2)
                {
                    foreach (Unit sub in Attacker.Where(x => x.Name == "Submarine"))
                    {
                        sub.Attack++;
                    }
                }

                // Dive bombers national advantage 
                // Unaccompanied ground units v.s. fighters
                if (Defender.Only("Tank", "Infantry"))
                {
                    foreach (Unit f in Attacker.Where(x => x.Name == "Fighter"))
                    {
                        f.Attack += 1;
                    }
                }
            }
            if (cmbDefender.SelectedItem.ToString() == "Germany")
            {
                // SS Panzerkorps
                if (chkPZ.Checked && Defender.Any(x => x.Name == "Tank"))
                {
                    Defender.Where(x => x.Name == "Tank").First().Defend += 2;
                }


            }

            int attack_power = Attacker.Sum(x => x.NetAttack);
            int defend_power = Defender.Sum(x => x.NetDefend);

            double attack_avg = (double)attack_power / 6;
            double defend_avg = (double)defend_power / 6;

            double attack_ratio = Attacker.Count / defend_avg;
            double defend_ratio = Defender.Count / attack_avg;

            int attack_survive = (int)Math.Max(Math.Floor(Attacker.Count - (defend_ratio * defend_avg)), 0);
            int defend_survive = (int)Math.Max(Math.Floor(Defender.Count - (attack_ratio * attack_avg)), 0);

            double attack_prob = Math.Round((attack_ratio / (attack_ratio + defend_ratio)) * 100);
            double defend_prob = Math.Round((defend_ratio / (attack_ratio + defend_ratio)) * 100);

            string outcome;
            if (attack_prob > defend_prob)
            {
                outcome = "Attacker Wins";
            }
            else if (defend_prob > attack_prob)
            {
                outcome = "Defender Wins";
            }
            else
            {
                outcome = "Draw";
            }

            string message = $@"
Probable Outcome: {outcome}
Attacker probability {attack_prob}%
Attacker survivors:  {attack_survive}
Defender probability {defend_prob}%
Defender survivors:  {defend_survive} 
";

            MessageBox.Show(message);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox3.Controls)
            {
                NumericUpDown n = c as NumericUpDown;
                if (n != null)
                {
                    n.Value = 0;
                }
            }
            foreach (Control c in groupBox4.Controls)
            {
                NumericUpDown n = c as NumericUpDown;
                if (n != null)
                {
                    n.Value = 0;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (cmbAttacker.SelectedIndex < 0)
            {
                MessageBox.Show("Set the attacking power.");
                return;
            }

            if (cmbDefender.SelectedIndex < 0)
            {
                MessageBox.Show("Set the defending power.");
                return;
            }

            int AttackerInfantryMod = GetInfantryMod(cmbAttacker);
            int AttackerTankMod = GetTankMod(cmbAttacker);
            int AttackerFighterMod = GetFighterMod(cmbAttacker);
            int AttackerBomberMod = GetBomberMod(cmbAttacker);
            int AttackerSubMod = GetSubMod(cmbAttacker);
            int AttackerDestroyerMod = GetDestroyerMod(cmbAttacker);
            int AttackerBattleshipMod = GetBattleshipMod(cmbAttacker);
            int AttackerCarrierMod = GetCarrierMod(cmbAttacker);


            List<Unit> Attacker = new List<Unit>();

            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Infantry, ainf.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Tank, atnk.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Fighter, afig.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Bomber, abom.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Submarine, asub.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Destroyer, ades.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Battleship, abat.Value));
            Attacker.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Carrier, acar.Value));

            foreach (Unit u in Attacker)
            {
                switch (u.Name)
                {
                    case "Infantry":
                        u.Attack += AttackerInfantryMod;
                        break;
                    case "Tank":
                        u.Attack += AttackerTankMod;
                        break;
                    case "Fighter":
                        u.Attack += AttackerFighterMod;
                        break;
                    case "Bomber":
                        u.Attack += AttackerBomberMod;
                        break;
                    case "Submarine":
                        u.Attack += AttackerSubMod;
                        break;
                    case "Destroyer":
                        u.Attack += AttackerDestroyerMod;
                        break;
                    case "Battleship":
                        u.Attack += AttackerBattleshipMod;
                        break;
                    case "Carrier":
                        u.Attack += AttackerCarrierMod;
                        break;
                }
            }


            int DefenderInfantryMod = GetInfantryMod(cmbDefender);
            int DefenderTankMod = GetTankMod(cmbDefender);
            int DefenderFighterMod = GetFighterMod(cmbDefender);
            int DefenderBomberMod = GetBomberMod(cmbDefender);
            int DefenderSubMod = GetSubMod(cmbDefender);
            int DefenderDestroyerMod = GetDestroyerMod(cmbDefender);
            int DefenderBattleshipMod = GetBattleshipMod(cmbDefender);
            int DefenderCarrierMod = GetCarrierMod(cmbDefender);

            List<Unit> Defender = new List<Unit>();

            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Infantry, dinf.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Tank, dtnk.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Fighter, dfig.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Bomber, dbom.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Submarine, dsub.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Destroyer, ddes.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Battleship, dbat.Value));
            Defender.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Carrier, dcar.Value));

            foreach (Unit u in Defender)
            {
                switch (u.Name)
                {
                    case "Infantry":
                        u.Defend += DefenderInfantryMod;
                        break;
                    case "Tank":
                        u.Defend += DefenderTankMod;
                        break;
                    case "Fighter":
                        u.Defend += DefenderFighterMod;
                        break;
                    case "Bomber":
                        u.Defend += DefenderBomberMod;
                        break;
                    case "Submarine":
                        u.Defend += DefenderSubMod;
                        break;
                    case "Destroyer":
                        u.Defend += DefenderDestroyerMod;
                        break;
                    case "Battleship":
                        u.Defend += DefenderBattleshipMod;
                        break;
                    case "Carrier":
                        u.Defend += DefenderCarrierMod;
                        break;
                }
            }

            HeavyBomber(Attacker, cmbAttacker);
            HeavyBomber(Defender, cmbDefender);

            if (cmbAttacker.SelectedItem.ToString() == "Germany")
            {
                // SS Panzerkorps
                if (chkPZ.Checked && Attacker.Any(x => x.Name == "Tank"))
                {
                    Attacker.Where(x => x.Name == "Tank").First().Attack += 1;
                }

                // Wolfpack National Advantage
                // When Germany attacks with 2 or more subs 
                // All the subs receive +1 attack.
                if (Attacker.Count(x => x.Name == "Submarine") >= 2)
                {
                    foreach (Unit sub in Attacker.Where(x => x.Name == "Submarine"))
                    {
                        sub.Attack++;
                    }
                }

                // Dive bombers national advantage 
                // Unaccompanied ground units v.s. fighters
                if (Defender.Only("Tank", "Infantry"))
                {
                    foreach (Unit f in Attacker.Where(x => x.Name == "Fighter"))
                    {
                        f.Attack += 1;
                    }
                }
            }
            if (cmbDefender.SelectedItem.ToString() == "Germany")
            {
                // SS Panzerkorps
                if (chkPZ.Checked && Defender.Any(x => x.Name == "Tank"))
                {
                    Defender.Where(x => x.Name == "Tank").First().Defend += 2;
                }


            }

            List<BattleResult> Battles = new List<BattleResult>();

            Die.Record = false;
            for (int i = 0; i < 1000; i++)
            {
                Battles.Add(BattleCalculator.FullBattle(Attacker.ToArray(), Defender.ToArray(), GetMethod()));
            }
            Die.Record = true;

            var def_avg = Math.Ceiling(Battles.Average(x => x.DefendHits));
            var atk_avg = Math.Ceiling(Battles.Average(x => x.AttackHits));
            var rounds = Math.Ceiling(Battles.Average(x => x.Rounds));

            MessageBox.Show($"Avg. Atk. Hits: {atk_avg}\nAvg. Def. Hits: {def_avg}\nAvg. # rounds: {rounds}\n");

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

            UpdateOptions();
        }

        private void UpdateOptions()
        {
            int ipcs = (int)numericUpDown6.Value;
            if (ipcs < UnitDefinitions.Infantry.Cost)
            {
                lblPurchase.Text = "You have insufficient IPCs for any unit purchase.";
                return;
            }

            List<Unit> Units = new List<Unit>() { UnitDefinitions.Infantry, UnitDefinitions.Tank, UnitDefinitions.Fighter, UnitDefinitions.Bomber, UnitDefinitions.Carrier, UnitDefinitions.Battleship, UnitDefinitions.Destroyer, UnitDefinitions.Submarine };

            List<Option> Options = GenerateAllPossibleOptions(ipcs);

            if (cmbFocus.SelectedIndex >= 3 && cmbFocus.SelectedIndex <= 5)
            {
                if (cmbFocus.SelectedIndex == 5)
                {
                    // Carrier Focus
                    Options = Options.Where(x =>
                                            x.Units.Only("Destroyer", "Battleship", "Carrier", "Submarine", "Fighter")).ToList();
                }
                else
                {
                    // Naval Focus
                    Options = Options.Where(x =>
                                            x.Units.Only("Destroyer", "Battleship", "Carrier", "Submarine")).ToList();
                }                      

                if (Options.Count == 0 || ipcs < Options.Min(x => x.Cost))
                {
                    lblPurchase.Text = "You have insufficient IPCs for any Naval unit purchase.";
                    return;
                }
            }



            Option best = Options.MaxBy(x => Score(x.Hits, x.Attack, x.Defend, x.Mobility));

            lblPurchase.Text = "Cost: " + best.Cost
                + "\n" + "Hit pts: " + best.Hits
                + "\n" + "Attack: " + best.Attack + " @ " + Math.Round((double)best.Cost / best.Attack, 0).ToString() + " IPC/Atk"
                + "\n" + "Defend: " + best.Defend + " @ " + Math.Round((double)best.Cost / best.Defend, 0).ToString() + " IPC/Def"
                + "\n" + "Mobility: " + best.Mobility
                + "\n";

            foreach (Unit u in Units)
            {
                if (best.Units.Any(x => x.Name == u.Name))
                {
                    lblPurchase.Text += best.Units.Count(x => x.Name == u.Name) + " " + u.Name + " ";
                }
            }


        }

        private List<Option> GenerateAllPossibleOptions(int IPCs)
        {
            List<Option> Options = new List<Option>();
            List<Unit> Units = new List<Unit>() { UnitDefinitions.Infantry, UnitDefinitions.Tank, UnitDefinitions.Fighter, UnitDefinitions.Bomber, UnitDefinitions.Carrier, UnitDefinitions.Battleship, UnitDefinitions.Destroyer, UnitDefinitions.Submarine };
            for (int inf = 0; inf <= IPCs / UnitDefinitions.Infantry.Cost; inf++)
            {
                for (int tank = 0; tank <= IPCs / UnitDefinitions.Tank.Cost; tank++)
                {
                    for (int fighter = 0; fighter <= IPCs / UnitDefinitions.Fighter.Cost; fighter++)
                    {
                        for (int bomber = 0; bomber <= IPCs / UnitDefinitions.Bomber.Cost; bomber++)
                        {
                            for (int sub = 0; sub <= IPCs / UnitDefinitions.Submarine.Cost; sub++)
                            {
                                for (int des = 0; des <= IPCs / UnitDefinitions.Destroyer.Cost; des++)
                                {
                                    for (int car = 0; car <= IPCs / UnitDefinitions.Carrier.Cost; car++)
                                    {
                                        for (int bat = 0; bat <= IPCs / UnitDefinitions.Battleship.Cost; bat++)
                                        {
                                            Option o = new Option();

                                            o.Units.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Infantry, inf));
                                            o.Units.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Tank, tank));
                                            o.Units.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Fighter, fighter));
                                            o.Units.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Bomber, bomber));
                                            o.Units.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Submarine, sub));
                                            o.Units.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Destroyer, des));
                                            o.Units.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Carrier, car));
                                            o.Units.AddRange(UnitDefinitions.Multiple(UnitDefinitions.Battleship, bat));

                                            Options.Add(o);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Options.Where(x => x.Cost <= IPCs && x.Cost >= 3).OrderBy(x => x.Cost).ToList();
        }

        private double Score(int count, int attack, int defend, int movement)
        {
            bool AttackFocus = cmbFocus.SelectedIndex == 0;
            bool DefendFocus = cmbFocus.SelectedIndex == 1;
            bool MobilityFocus = cmbFocus.SelectedIndex == 2;
            bool NavalFocus = cmbFocus.SelectedIndex == 3;
            bool NavalFocusDefend = cmbFocus.SelectedIndex == 4;
            bool NavalFocusCarrier = cmbFocus.SelectedIndex == 5;

            if (AttackFocus)
            {
                return count * 0.5 + attack * 2.0 + defend * 0.75 + movement * 1.5;
            }

            if (DefendFocus)
            {
                return count * 0.5 + attack * 0.75 + defend * 2.0 + movement * 1.0;
            }

            if (MobilityFocus)
            {
                return count * 0.5 + attack * 1.0 + defend * 0.75 + movement * 3.0;
            }

            if (NavalFocus)
            {
                return count * 0.5 + attack * 2.0 + defend * 1.5;
            }

            if (NavalFocusDefend)
            {
                return count * 0.5 + attack * 1.5 + defend * 2.0;
            }

            if (NavalFocusCarrier) // bias towards fighters/defense
            {
                return count * 0.5 + attack * 1.0 + defend * 1.5 + movement * 2.0;
            }

            return count * 0.5 + attack * 1.0 + defend * 1.0 + movement * 1.5;
        }

        private void cmbFocus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOptions();
        }

        private void numericUpDown6_Validated(object sender, EventArgs e)
        {
            UpdateOptions();
        }

        private void ainf_ValueChanged(object sender, EventArgs e)
        {
            AttackerIPCs();
        }

        private void AttackerIPCs()
        {
            var Attacker = GetAttacker();
            var Defender = GetDefender(); 

            // Dive bombers national advantage 
            // Unaccompanied ground units v.s. fighters
            if (cmbAttacker.SelectedItem.ToString() == "Germany" && Defender.Only("Tank", "Infantry"))
            {
                foreach (Unit f in Attacker.Where(x => x.Name == "Fighter"))
                {
                    f.Attack += 1;
                }
            }

            lblAttackerIPC.Text = Attacker.Sum(x => x.Cost).ToString();
            lblAttackPower.Text = Attacker.Sum(x => x.Attack * x.Rolls).ToString();
        }

        private void DefenderIPCs()
        {                      
            var Defender = GetDefender();

            lblDefenderIPCs.Text = Defender.Sum(x => x.Cost).ToString();
            lblDefendPower.Text = Defender.Sum(x => x.Defend * x.Rolls).ToString();
        }

        private void atnk_ValueChanged(object sender, EventArgs e)
        {
            AttackerIPCs();
        }

        private void afig_ValueChanged(object sender, EventArgs e)
        {
            AttackerIPCs();
        }

        private void abom_ValueChanged(object sender, EventArgs e)
        {
            AttackerIPCs();
        }

        private void asub_ValueChanged(object sender, EventArgs e)
        {
            AttackerIPCs();
        }

        private void ades_ValueChanged(object sender, EventArgs e)
        {
            AttackerIPCs();
        }

        private void acar_ValueChanged(object sender, EventArgs e)
        {
            AttackerIPCs();
        }

        private void dinf_ValueChanged(object sender, EventArgs e)
        {
            DefenderIPCs();
        }

        private void dtnk_ValueChanged(object sender, EventArgs e)
        {
            DefenderIPCs();
        }

        private void dfig_ValueChanged(object sender, EventArgs e)
        {
            DefenderIPCs();
        }

        private void dbom_ValueChanged(object sender, EventArgs e)
        {
            DefenderIPCs();
        }

        private void dsub_ValueChanged(object sender, EventArgs e)
        {
            DefenderIPCs();
        }

        private void ddes_ValueChanged(object sender, EventArgs e)
        {
            DefenderIPCs();
        }

        private void dbat_ValueChanged(object sender, EventArgs e)
        {
            DefenderIPCs();
        }

        private void dcar_ValueChanged(object sender, EventArgs e)
        {
            DefenderIPCs();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lblRounds.Text = "";

            if (cmbAttacker.SelectedIndex < 0)
            {
                MessageBox.Show("Set the attacking power.");
                return;
            }

            if (cmbDefender.SelectedIndex < 0)
            {
                MessageBox.Show("Set the defending power.");
                return;
            }

            var Attacker = GetAttacker();
            var Defender = GetDefender();

            // Dive bombers national advantage 
            // Unaccompanied ground units v.s. fighters
            if (cmbAttacker.SelectedItem.ToString() == "Germany" && Defender.Only("Tank", "Infantry"))
            {
                foreach (Unit f in Attacker.Where(x => x.Name == "Fighter"))
                {
                    f.Attack += 1;
                }
            }

            BattleResult r;

            if (chkFullBattle.Checked)
            {
                r = BattleCalculator.RPSFullBattle(Attacker.ToArray(), Defender.ToArray());
                lblRounds.Text = r.Rounds + " round(s) of battle.";
            }
            else
            {
                r = BattleCalculator.RPSBattleRound(Attacker.ToArray(), Defender.ToArray());
            }             

            int def = r.AttackHits;
            int off = r.DefendHits;

            lblDefCasualties.Text = def.ToString();
            lblCasualties.Text = off.ToString();

            if (def < off)
            {
                Stat s = new Stat();
                s.Power = cmbAttacker.SelectedItem.ToString();
                s.Win = false;
                s.Offense = true;
                s.Margin = -(off - def);
                s.Hits = def;

                Stat s2 = new Stat();
                s2.Power = cmbDefender.SelectedItem.ToString();
                s2.Win = true;
                s2.Offense = false;
                s2.Margin = -(def - off);
                s2.Hits = off;

                BattleStats.Stats.Add(s);
                BattleStats.Stats.Add(s2);
            }
            else
            {
                Stat s = new Stat();
                s.Power = cmbDefender.SelectedItem.ToString();
                s.Win = false;
                s.Offense = false;
                s.Margin = (off - def);
                s.Hits = off;

                Stat s2 = new Stat();
                s2.Power = cmbAttacker.SelectedItem.ToString();
                s2.Win = def > off;
                s2.Offense = true;
                s2.Margin = (def - off);
                s2.Hits = def;

                BattleStats.Stats.Add(s);
                BattleStats.Stats.Add(s2);
            }

            fade2.Enabled = true;
            UpdateStats();
            UpdateDiceStats();
        }
    }

    public class Option
    {
        public int Cost
        {
            get
            {
                return Units.Sum(x => x.Cost);
            }
        }

        public int Mobility
        {
            get
            {
                return Units.Max(x => x.Movement);
            }
        }

        public int Hits
        {
            get
            {
                return Units.Sum(x => x.Hits);
            }
        }

        public int Attack
        {
            get
            {
                return Units.Sum(x => x.Attack);
            }
        }

        public int Defend
        {
            get
            {
                return Units.Sum(x => x.Defend);
            }
        }

        public Option(params Unit[] units)
        {
            Units.AddRange(units);
        }

        public List<Unit> Units { get; set; } = new List<Unit>();
    }

    public class Result
    {
        public int AttackerLeft { get; set; }
        public int DefenderLeft { get; set; }
    }

}
