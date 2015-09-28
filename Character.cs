using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{

   class Character
   {
      #region Constructors
      public Character()
      {
         skillList = new List<Skill>();
      }
      #endregion

      #region Methods
      static public int StatMod(int stat_level)
      {
         if (stat_level < 10)
         {
            stat_level--;
         }
         return (stat_level - 10) / 2;
      }

      public int GetSwimSpeed(bool successful_check)
      {
         if (successful_check)
         {
            return this.MaxMoveSpeed / 2 / 5 * 5;
         }
         else
         {
            return this.MaxMoveSpeed / 4 / 5 * 5;
         }
      }
      #endregion

      #region Fields
      #region Ability Stats
      private int strength_p;
      private int dexterity_p;
      private int constitution_p;
      private int intelligence_p;
      private int wisdom_p;
      private int charisma_p;
      #endregion

      #region Generic Stats
      private int ac_p;
      private int temp_hp;
      private int hp_p;
      private int max_hp;
      private int initiativeMod;
      private int bab_p;
      private int spell_resist_p;
      private int melee_atk_bonus_p;
      private int ranged_atk_bonus_p;
      private int movespeed_p;
      private int burrowspeed_p;
      private int swimspeed_p;
      private int flightspeed_p;
      private int cmb_p;
      private int cmd_p;
      private Enum_Size_Categories naturalSize;
      private SizeInfo currentSizeInfo;
      private Mount mount;
      #endregion

      #region Saves
      private int fortitude_save_p;
      private int reflex_save_p;
      private int will_save_p;
      #endregion

      #region Magic
      #endregion

      #region Skills
      private List<Skill> skillList;
      private List<Feat> featList;
      // ERROR TESTING fill this out
      private Dictionary<Enum_Affectable_Stats, List<Tuple<string, int>>> specialList;
      #endregion

      #region Items
      private Armor armor_p;
      private List<Armor> shields;
      private Weapon weapon_p;
      private Dictionary<string, Item> item_map_p;
      #endregion

      private bool helpless_p;
      private bool dead;
      private bool bleedingOut;

      #endregion

      #region Properties
      #region Ability Stats
      public int Strength
      {
         get { return strength_p; }
         set
         {
            if (value < 0)
            {
               throw new ArgumentException("Character: Strength cannot be set below 0.");
            }
            else
            {
               strength_p = value;
               if (value == 0)
               {
                  Helpless = true;
               }
            }
         }
      }
      public int Dexterity
      {
         get { return dexterity_p; }
         set
         {
            if (value < 0)
            {
               throw new ArgumentException("Character: Dexterity cannot be below 0.");
            }
            else
            {
               dexterity_p = value;
               if (value == 0)
               {
                  Helpless = true;
               }
            }
         }
      }
      public int Constitution
      {
         get { return constitution_p; }
         set
         {
            if (value < 0)
            {
               throw new ArgumentException("Character: Constitution cannot be below 0.");
            }
            else
            {
               constitution_p = value;
               if (value == 0)
               {
                  Helpless = true;
               }
            }
         }
      }
      public int Intelligence
      {
         get { return intelligence_p; }
         set
         {
            if (value < 0)
            {
               throw new ArgumentException("Character: Intelligence cannot be set below 0.");
            }
            else
            {
               intelligence_p = value;
               if (value == 0)
               {
                  Helpless = true;
               }
            }
         }
      }
      public int Wisdom
      {
         get { return wisdom_p; }
         set
         {
            if (value < 0)
            {
               throw new ArgumentException("Character: Wisdom cannot be set below 0.");
            }
            else
            {
               wisdom_p = value;
               if (value == 0)
               {
                  Helpless = true;
               }
            }
         }
      }
      public int Charisma
      {
         get { return charisma_p; }
         set
         {
            if (value < 0)
            {
               throw new ArgumentException("Character: Charisma cannot be set below 0.");
            }
            else
            {
               charisma_p = value;
               if (value == 0)
               {
                  Helpless = true;
               }
            }
         }
      }

      #endregion

      public bool HasShield
      {

      }

      #region Generic Stats
      public int AC
      {
         get
         {
            // 10 + armor + shield + dex + other
            int ac = 10;
            ac += armor_p.AC;
            if(this.shields != null
               && this.shields.Count > 0)
            {
               foreach (Armor shield in this.shields)
               {
                  ac += shield.AC;
               }
            }
            ac += StatMod(this.dexterity_p);
            // feats
            foreach (Feat feat in this.featList)
            {
               if (feat.StatEffects.ContainsKey(Enum_Affectable_Stats.AC))
               {
                  ac += feat.StatEffects[Enum_Affectable_Stats.AC];
               }
            }
            // miscellaneous special stuff
            if (specialList.ContainsKey(Enum_Affectable_Stats.AC))
            {
               foreach (Tuple<string, int> ac_tuple in specialList[Enum_Affectable_Stats.AC])
               {
                  ac += ac_tuple.Item2;
               }
            }

            return ac;
         }
      }

      public int CurrentHP
      {
         get { return this.hp_p; }
         set
         {
            // account for temp hp
            if (value < 0)
            {
               if (value <= 0 - this.constitution_p)
               {
                  IsDead = true;
               }
               else
               {
                  this.bleedingOut = true;
               }
            }
            if (value > max_hp)
            {
               hp_p = max_hp;
               temp_hp = value - max_hp;
            }
            else
            {
               hp_p = value;
            }
         }
      }

      public bool IsDead
      {
         get { return dead; }
         set
         {
            // ERROR TESTING
            // set up an event trigger here if they died or if they're being revived
            dead = value;
         }
      }

      public bool IsBleedingOut
      {
         get { return this.bleedingOut; }
         set
         {
            // ERROR TESTINg
            // set up an event trigger here if they start bleeding
            this.bleedingOut = value;
         }
      }

      public bool IsDisabled
      {
         get { return !IsDead && !IsBleedingOut && CurrentHP < 0; }
      }

      public int MaxHP
      {
         get { return this.max_hp; }
      }

      public int InitiativeBase
      {
         get { return StatMod(this.dexterity_p) + this.initiativeMod; }
      }
      public int BaseAttackBonus
      {
         get { return this.bab_p; }
      }
      public int SpellResist
      {
         get { return this.spell_resist_p; }
         set
         {
            if (value < 0)
            {
               throw new ArgumentException("Character: Cannot set negative spell resistance.");
            }
            else
            {
               this.spell_resist_p = value;
            }
         }
      }
      public int MeleeAttackBonus
      {
         get
         {
            return this.bab_p + this.strength_p + this.currentSizeInfo.SizeModifier;
         }
      }
      public int RangedAttackBonus
      {
         get
         {
            return this.bab_p + this.dexterity_p + this.currentSizeInfo.SizeModifier + this.RangePenalty;
         }
      }
      public int BaseMoveSpeed
      {
         get { return this.movespeed_p; }
      }
      public int MaxMoveSpeed
      {
         get
         {
            return (this.movespeed_p > this.armor_p.MaxMovespeed) ? this.movespeed_p : this.armor_p.MaxMovespeed;
         }
      }
      public int MountedSpeed
      {
         get
         {
            if (this.mount != null)
            {
               return this.mount.CombatSpeed;
            }
            else
            {
               throw new InvalidOperationException("Character: Character has no mount.");
            }
         }
      }
      public int BurrowSpeed
      {
         get
         {
            if(this.armor_p.ArmorCategory == Enum_Armor_Categories.Medium_Armor
               || this.armor_p.ArmorCategory == Enum_Armor_Categories.Heavy_Armor)
            {
               return 10;
            }
            else
            {
               return 15;
            }
         }
      }
      public int FlightSpeed { }
      public int BaseFlightSpeed { }
      public int CMB { }
      public int CMD { }

      public int CombatManeuverBonus
      {
         get { return CMB; }
         set { CMB = value; }
      }
      public int CombatManeuverDefense
      {
         get { return CMD; }
         set { CMD = value; }
      }

      #endregion

      public bool Helpless
      {
         get { return helpless_p; }
         set { helpless_p = value; }
      }


      #endregion
   }
}
