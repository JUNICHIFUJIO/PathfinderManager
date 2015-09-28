using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.d20pfsrd.com/equipment---final/armor

namespace PathfinderManager
{
   #region Enumerators
   /// <summary>
   /// The categories of armor available in Pathfinder. Includes shields.
   /// </summary>
   public enum Enum_Armor_Categories
   {
      Light_Armor,
      Medium_Armor,
      Heavy_Armor,
      Shield
   };

   /// <summary>
   /// The armors officially recognized as Light Armors in Pathfinder. Allows 
   /// use of Evasion feat.
   /// </summary>
   public enum Enum_Light_Armors
   {
      Armored_Kilt,
      Padded,
      Quilted_Cloth,
      Leather,
      Rosewood_Armor,
      Hide_Shirt,
      Leaf_Armor,
      Parade_Armor,
      Studded_Leather,
      Wooden,
      Chain_Shirt
   };

   /// <summary>
   /// The armors officially recognized as Medium Armors in Pathfinder.
   /// </summary>
   public enum Enum_Medium_Armors
   {
      Armored_Coat,
      Hide,
      Scale_Mail,
      Chainmail,
      Breastplate,
      Breastplate_Agile
   };

   /// <summary>
   /// The armors officially recognized as Heavy Armors in Pathfinder.
   /// </summary>
   public enum Enum_Heavy_Armors
   {
      Splint_Mail,
      Banded_Mail,
      Field_Plate,
      Half_Plate,
      Half_Plate_Agile,
      Full_Plate,
      Hellknight_Plate,
      Stoneplate
   };

   /// <summary>
   /// The shields officially recognized in Pathfinder.
   /// </summary>
   public enum Enum_Shields
   {
      Buckler,
      Klar,
      Madu_Leather,
      Madu_Steel,
      Light_Wooden_Shield,
      Light_Wooden_Shield_Quickdraw,
      Light_Steel_Shield,
      Light_Steel_Shield_Quickdraw,
      Heavy_Wooden_Shield,
      Heavy_Steel_Shield,
      Tower_Shield
   };

   /// <summary>
   /// Armor modifications officially listed in the Pathfinder SRD.
   /// </summary>
   public enum Enum_Armor_Modifications
   {
      Armor_Spikes, // +50 gp, +10 lbs.
      Gauntlet_Locked // +8 gp, +5 lbs.
   };

   /// <summary>
   /// Shield modifications officially listed in the Pathfinder SRD.
   /// </summary>
   public enum Enum_Shield_Modifications
   {
      Shield_Boss_Breakaway, // +120 gp, +10 lbs
      Shield_Boss_Hooked, // +80 gp, +10 lbs
      Shield_Boss_Illuminating, // +35 gp, +10 lbs.
      Shield_Boss_Masterwork, // +50 gp, 0 lbs.
      Shield_Boss_Reinforcing, // +30 gp, +10 lbs.
      Shield_Spikes, // +10 gp, +5 lbs
      Throwing // +50 gp, 0 lbs
   };
   #endregion

   /// <summary>
   /// Tracks info for a piece of armor.
   /// </summary>
   class Armor : Item, IEquipment
   {
      #region Structs
      /// <summary>
      /// A struct to track all the important/customizable aspects of a piece of armor.
      /// </summary>
      public struct Armor_Values
      {
         /// <summary>
         /// The monetary value of the armor.
         /// </summary>
         //public int MoneyValue;
         /// <summary>
         /// The Armor Class (defensive chance) associated with the armor.
         /// </summary>
         public int AC;
         /// <summary>
         /// The maximum Dexterity Bonus allowed by the armor.
         /// </summary>
         public int MaxDexterityBonus;
         /// <summary>
         /// The absolute value of the penalty associated with STR and DEX skills when this armor is worn.
         /// </summary>
         public int ACCheckPenalty;
         /// <summary>
         /// The chance an arcane spell will fail when this armor is worn. Stored as a decimal between 0 and 1.
         /// </summary>
         public float ArcaneSpellFailureChance;
         /// <summary>
         /// The maximum movement speed allowed when this armor is worn.
         /// </summary>
         public int MaxMovementSpeed;
         /// <summary>
         /// The weight of the armor.
         /// </summary>
         //public int Weight;
         /// <summary>
         /// The maximum durability of the armor.
         /// </summary>
         public int HitPoints;
         /// <summary>
         /// Tracks whether the armor is considered masterwork or not. 
         /// If so, AC Penalty Check is reduced by 1 in calculations.
         /// </summary>
         public bool IsMasterwork;
         /// <summary>
         /// How many rounds it takes for a character to equip armor properly.
         /// </summary>
         public int RoundsToDon;
         /// <summary>
         /// How many rounds it takes for a character to equip the armor improperly.
         /// </summary>
         public int RoundsToHastilyDon;
         /// <summary>
         /// How many rounds it takes for a character to unequip and remove the armor.
         /// </summary>
         public int RoundsToRemove;
         /// <summary>
         /// Category of armor (light/medium/heavy/shield).
         /// </summary>
         public Enum_Armor_Categories ArmorCategory;
         /// <summary>
         /// Is the armor broken? (Half of total durability remaining) 
         /// 1) AC Bonus halved, rounding down
         /// 2) Double AC Penalty on skills (Dex and Str)
         /// </summary>
         public bool IsBroken;
         /// <summary>
         /// Is the armor...CURSED?!
         /// </summary>
         //public bool IsCursed;
         /// <summary>
         /// Is the armor actually a shield?
         /// </summary>
         public bool IsShield;
         /// <summary>
         /// Is the armor actually an armor?
         /// </summary>
         public bool IsArmor;
      }
      #endregion

      #region Constants
      const int _DEFAULT_MONEY_VALUE = 1000;
      const int _DEFAULT_AC = 3;
      const int _DEFAULT_MAX_DEX_BONUS = 3;
      const int _DEFAULT_AC_CHECK_PENALTY = -1;
      const float _DEFAULT_ARCANE_SPELL_FAILURE_CHANCE = (float).2;
      const int _DEFAULT_MAX_MOVESPEED = 20;
      const int _DEFAULT_WEIGHT = 20;
      const int _DEFAULT_HIT_POINTS = 100;
      const bool _DEFAULT_IS_MASTERWORK = false;
      const int _DEFAULT_ROUNDS_TO_DON = 5;
      const int _DEFAULT_ROUNDS_TO_HASTILY_DON = 3;
      const int _DEFAULT_ROUNDS_TO_REMOVE = 5;
      #endregion

      #region Constructors
      /// <summary>
      /// Creates an armor piece with the given name, description, and Armor_Value
      ///  parameters. Any unestablished Armor_Value values will default to a 
      ///  specified value.
      /// </summary>
      /// <param name="name">Name to associate with the armor.</param>
      /// <param name="description">Short description of the armor.</param>
      /// <param name="armor_values">A struct holding many values associated with armor and shields in Pathfinder.</param>
      public Armor(string name, string description, int money_value, bool is_cursed, int weight, Armor_Values armor_values) :
         base(name, 1, description, money_value, is_cursed, weight)
      {
         initialize_armor_values(armor_values);
         armor_modification_list_p = new List<Enum_Armor_Modifications>();
         shield_modification_list_p = new List<Enum_Shield_Modifications>();
      }

      /// <summary>
      /// Create a generic, bad piece of armor labeled "Generic Armor". Not very good.
      /// </summary>
      public Armor() :
         this("Generic Armor", "Some generic armor. Not worth much.", _DEFAULT_MONEY_VALUE, false, _DEFAULT_WEIGHT, new Armor_Values()) { }

      /// <summary>
      /// Create a piece of armor that's a replica of another piece of armor.
      /// </summary>
      /// <param name="other">The armor to use as a standard.</param>
      public Armor(Armor other) :
         this(other.Name, other.Description, other.MoneyValue, other.IsCursed, other.Weight,
            new Armor_Values()
            {
               //MoneyValue = other.MoneyValue,
               AC = other.AC,
               MaxDexterityBonus = other.MaxDexBonus,
               ACCheckPenalty = other.ACCheckPenalty,
               ArcaneSpellFailureChance = other.ArcaneSpellFailureChance,
               MaxMovementSpeed = other.MaxMovespeed,
               //Weight = other.Weight,
               HitPoints = other.Durability,
               IsMasterwork = other.IsMasterwork,
               RoundsToDon = other.RoundsToDon,
               RoundsToHastilyDon = other.RoundsToDonHastily,
               RoundsToRemove = other.RoundsToRemove,
               ArmorCategory = other.ArmorCategory,
               IsBroken = other.IsBroken,
               //IsCursed = other.IsCursed,
               IsShield = other.IsShield,
               IsArmor = other.IsArmor
            }
         )
      {
         this.current_hp_p = other.RemainingDurability;
         foreach (Enum_Armor_Modifications mod in other.armor_modification_list_p)
         {
            this.armor_modification_list_p.Add(mod);
         }

         foreach (Enum_Shield_Modifications mod in other.shield_modification_list_p)
         {
            this.shield_modification_list_p.Add(mod);
         }
      }

      /// <summary>
      /// Creates a piece of armor that's a customized version of another piece of 
      /// armor. Any unspecified values in customization_values will default to 
      /// the other armor's related value.
      /// </summary>
      /// <param name="other">Piece of armor used as a base to customize from.</param>
      /// <param name="customization_values">Armor_Values passed in to alter values of the original ("other") piece of armor.</param>
      public Armor(Armor other, Armor_Values customization_values) :
         this(other)
      {
         Customize(customization_values);
      }
      #endregion

      #region Methods
      #region Constructor Helpers
      /// <summary>
      /// Initializes the fields of the Armor object in accordance to the 
      /// Armor_Values struct passed it. Any unspecified values will default 
      /// to a pre-specified value.
      /// </summary>
      /// <param name="values">Custom values to assign to the Armor object's fields.</param>
      private void initialize_armor_values(Armor_Values values)
      {
         //money_value_p = (values.MoneyValue != null) ? values.MoneyValue : _DEFAULT_MONEY_VALUE;
         ac_p = (values.AC != null) ? values.AC : _DEFAULT_AC;
         max_dex_bonus_p = values.MaxDexterityBonus != null ? values.MaxDexterityBonus : _DEFAULT_MAX_DEX_BONUS;
         ac_check_penalty_p = values.ACCheckPenalty != null ? values.ACCheckPenalty : _DEFAULT_AC_CHECK_PENALTY;
         arcane_spell_failure_chance_p = values.ArcaneSpellFailureChance != null ? values.ArcaneSpellFailureChance : _DEFAULT_ARCANE_SPELL_FAILURE_CHANCE;
         max_speed_p = values.MaxMovementSpeed != null ? values.MaxMovementSpeed : _DEFAULT_MAX_MOVESPEED;
         //weight_p = values.Weight != null ? values.Weight : _DEFAULT_WEIGHT;
         hit_points_p = values.HitPoints != null ? values.HitPoints : _DEFAULT_HIT_POINTS;
         current_hp_p = hit_points_p;
         is_masterwork_p = values.IsMasterwork != null ? values.IsMasterwork : _DEFAULT_IS_MASTERWORK;
         rounds_to_don_p = values.RoundsToDon != null ? values.RoundsToDon : _DEFAULT_ROUNDS_TO_DON;
         rounds_to_hastily_don_p = values.RoundsToHastilyDon != null ? values.RoundsToHastilyDon : _DEFAULT_ROUNDS_TO_HASTILY_DON;
         rounds_to_remove_p = values.RoundsToRemove != null ? values.RoundsToRemove : _DEFAULT_ROUNDS_TO_REMOVE;
         armor_category_p = values.ArmorCategory != null ? values.ArmorCategory : Enum_Armor_Categories.Light_Armor;
         is_shield_p = values.IsShield != null ? values.IsShield : false;
         is_armor_p = values.IsArmor != null ? values.IsArmor : true;
         //is_cursed_p = values.IsCursed != null ? values.IsCursed : false;
         is_broken_p = values.IsBroken != null ? values.IsBroken : false;
      }
      #endregion

      #region IEquipment Methods
      /// <summary>
      /// Immediately equips the armor.
      /// </summary>
      public void Equip()
      {
         IsEquipped = true;
      }

      /// <summary>
      /// Immediately removes the armor.
      /// </summary>
      public void Remove()
      {
         IsEquipped = false;
      }

      /// <summary>
      /// Fully restores the durability of this armor.
      /// </summary>
      public void Repair()
      {
         current_hp_p = hit_points_p;
         if (IsBroken)
         {
            IsBroken = false;
         }
      }

      /// <summary>
      /// Restores the durability of this armor by a specified amount. If amount 
      /// repaired is enough to reverse a Broken condition, the Broken condition 
      /// is removed.
      /// </summary>
      /// <param name="durability_repaired"></param>
      /// <exception cref="ArgumentException">durability_repaired must be greater than or equal to 0.</exception>
      public void Repair(int durability_repaired)
      {
         if (durability_repaired < 0)
         {
            throw new ArgumentException("Armor: Invalid usage of armor repair method.");
         }

         current_hp_p += durability_repaired;
         if (current_hp_p * 2 > hit_points_p)
         {
            if(current_hp_p > hit_points_p){
               current_hp_p = hit_points_p;
            }
            IsBroken = false;
         }
      }

      /// <summary>
      /// Sets the broken status for this armor.
      /// </summary>
      /// <exception cref="InvalidOperationException">Armor must have half or less of its total durability remaining.</exception>
      public void Break()
      {
         if (current_hp_p * 2 > hit_points_p)
         {
            throw new InvalidOperationException("Armor: Armor cannot be broken with more than half of its durability remaining.");
         }
         IsBroken = true;
      }

      /// <summary>
      /// Damages the armor's durability by a specified amount. If the damage 
      /// is severe enough to give the armor the Broken condition, the armor 
      /// becomes Broken.
      /// </summary>
      /// <param name="durability_lost">A positive integer defining the amount of durability that will be detracted from the Armor's current durability.</param>
      /// <exception cref="ArgumentException">durability_lost must be a positive integer.</exception>
      public void Damage(int durability_lost)
      {
         if (durability_lost < 0)
         {
            throw new ArgumentException("Armor: Invalid usage of armor damaging method.");
         }

         current_hp_p -= durability_lost;
         if (current_hp_p * 2 < hit_points_p)
         {
            if (current_hp_p < 0)
            {
               current_hp_p = 0;
            }
            Break();
         }
      }
      #endregion

      /// <summary>
      /// Customize this Armor with the given Armor_Values struct values. Any 
      /// null values in the struct will not change this Armor's associated value.
      /// </summary>
      /// <param name="values">The Armor values to use for customizing this piece of armor.</param>
      public void Customize(Armor_Values values)
      {
         //money_value_p = (values.MoneyValue != null) ? values.MoneyValue : money_value_p;
         ac_p = (values.AC != null) ? values.AC : ac_p;
         max_dex_bonus_p = values.MaxDexterityBonus != null ? values.MaxDexterityBonus : max_dex_bonus_p;
         ac_check_penalty_p = values.ACCheckPenalty != null ? values.ACCheckPenalty : ac_check_penalty_p;
         arcane_spell_failure_chance_p = values.ArcaneSpellFailureChance != null ? values.ArcaneSpellFailureChance : arcane_spell_failure_chance_p;
         max_speed_p = values.MaxMovementSpeed != null ? values.MaxMovementSpeed : max_speed_p;
         //weight_p = values.Weight != null ? values.Weight : weight_p;
         hit_points_p = values.HitPoints != null ? values.HitPoints : hit_points_p;
         if(current_hp_p >= hit_points_p){
            current_hp_p = hit_points_p;
         }
         else{
            current_hp_p = (int)((double)current_hp_p / hit_points_p);
         }
         if (current_hp_p * 2 <= hit_points_p)
         {
            Break();
         }
         is_masterwork_p = values.IsMasterwork != null ? values.IsMasterwork : is_masterwork_p;
         rounds_to_don_p = values.RoundsToDon != null ? values.RoundsToDon : rounds_to_don_p;
         rounds_to_hastily_don_p = values.RoundsToHastilyDon != null ? values.RoundsToHastilyDon : rounds_to_hastily_don_p;
         rounds_to_remove_p = values.RoundsToRemove != null ? values.RoundsToRemove : rounds_to_remove_p;
         armor_category_p = values.ArmorCategory != null ? values.ArmorCategory : armor_category_p;
         //is_cursed_p = values.IsCursed != null ? values.IsCursed : is_cursed_p;
         is_broken_p = values.IsBroken != null ? values.IsBroken : is_broken_p;
         is_armor_p = values.IsArmor != null ? values.IsArmor : is_armor_p;
         is_shield_p = values.IsShield != null ? values.IsShield : is_shield_p;
      }

      /// <summary>
      /// Adds an extra to the piece of armor (like spikes).
      /// </summary>
      /// <param name="extra">The extra to add.</param>
      /// <exception cref="InvalidOperationException">The item must be registered as a piece of armor to accept this kind of extra.</exception>
      public void AddArmorExtra(Enum_Armor_Modifications extra)
      {
         if (!IsArmor)
         {
            throw new InvalidOperationException("Armor: Item is not an armor!");
         }
         if (!armor_modification_list_p.Contains(extra))
         {
            switch (extra)
            {
               case (Enum_Armor_Modifications.Armor_Spikes):
                  MoneyValue += 5000; // 50 gp
                  Weight += 10; // 10 lbs
                  break;
               case (Enum_Armor_Modifications.Gauntlet_Locked):
                  MoneyValue += 800; // 8 gp
                  Weight += 5; // 5 lbs
                  break;
               default:
                  throw new ArgumentException("Armor: Invalid Armor modification passed through AddExtra method.");
            }
         }

      }

      /// <summary>
      /// Adds an extra to the shield (like spikes).
      /// </summary>
      /// <param name="extra">The extra to add.</param>
      /// <exception cref="InvalidOperationException">The item must be registered as a shield to accept this kind of extra.</exception>
      public void AddShieldExtra(Enum_Shield_Modifications extra)
      {
         if (!IsShield)
         {
            throw new InvalidOperationException("Armor: The item isn't a shield!");
         }
         if (!shield_modification_list_p.Contains(extra))
         {
            switch (extra)
            {
               case(Enum_Shield_Modifications.Shield_Boss_Breakaway):
                  MoneyValue += 12000; // 120 gp
                  Weight += 10; // 10 lbs
                  break;
               case(Enum_Shield_Modifications.Shield_Boss_Hooked):
                  MoneyValue += 8000; // 80 gp
                  Weight += 10; // 10 lbs
                  break;
               case(Enum_Shield_Modifications.Shield_Boss_Illuminating):
                  MoneyValue += 3500; // 35 gp
                  Weight += 10; // 10 lbs
                  break;
               case(Enum_Shield_Modifications.Shield_Boss_Masterwork):
                  MoneyValue += 5000; // 50 gp
                  Weight += 0; // 0 lbs
                  break;
               case(Enum_Shield_Modifications.Shield_Boss_Reinforcing):
                  MoneyValue += 3000; // 30 gp
                  Weight += 10; // 10 lbs
                  break;
               case(Enum_Shield_Modifications.Shield_Spikes):
                  MoneyValue += 1000; // 10 gp
                  Weight += 5; // 5 lbs
                  break;
               case(Enum_Shield_Modifications.Throwing):
                  MoneyValue += 5000; // 50 gp
                  Weight += 0; // 0 lbs
                  break;
               default:
                  throw new ArgumentException("Armor: Invalid Shield modification passed through AddExtra method.");
            }
         }
      }
      #endregion

      #region Fields
      //private int money_value_p;
      private int ac_p;
      private int max_dex_bonus_p;
      private int ac_check_penalty_p;
      private float arcane_spell_failure_chance_p;
      private int max_speed_p;
      //private int weight_p;
      private int current_hp_p;
      private int hit_points_p;
      private bool is_masterwork_p;
      private int rounds_to_don_p;
      private int rounds_to_hastily_don_p;
      private int rounds_to_remove_p;
      private Enum_Armor_Categories armor_category_p;

      private bool is_equipped_p;
      //private bool is_cursed_p;
      private bool is_broken_p;
      private bool is_shield_p;
      private bool is_armor_p;

      private List<Enum_Armor_Modifications> armor_modification_list_p;
      private List<Enum_Shield_Modifications> shield_modification_list_p;
      #endregion

      #region Properties
      #region Armor-specific Properties
      /// <summary>
      /// The monetary value of the armor.
      /// </summary>
      //public int MoneyValue
      //{
      //   get { return MoneyValue; }
      //}
      /// <summary>
      /// The Armor Class (defensive chance) associated with the armor.
      /// </summary>
      public int AC
      {
         get { return ac_p; }
      }
      /// <summary>
      /// The maximum Dexterity Bonus allowed by the armor.
      /// </summary>
      public int MaxDexBonus
      {
         get { return max_dex_bonus_p; }
      }
      /// <summary>
      /// The absolute value of the penalty associated with STR and DEX skills when this armor is worn.
      /// </summary>
      public int ACCheckPenalty
      {
         get { return ac_check_penalty_p; }
      }
      /// <summary>
      /// The chance an arcane spell will fail when this armor is worn. Stored as a decimal between 0 and 1.
      /// </summary>
      public float ArcaneSpellFailureChance
      {
         get { return arcane_spell_failure_chance_p; }
      }
      /// <summary>
      /// The maximum movement speed allowed when this armor is worn.
      /// </summary>
      public int MaxMovespeed
      {
         get { return max_speed_p; }
      }
      /// <summary>
      /// The weight of the armor.
      /// </summary>
      //public int Weight
      //{
      //   get { return weight_p; }
      //}
      /// <summary>
      /// The remaining durability of the armor.
      /// </summary>
      public int RemainingDurability
      {
         get { return current_hp_p; }
      }
      /// <summary>
      /// The maximum durability of the armor.
      /// </summary>
      public int Durability
      {
         get { return hit_points_p; }
      }
      /// <summary>
      /// Tracks whether the armor is considered masterwork or not. 
      /// If so, AC Penalty Check is reduced by 1 in calculations.
      /// </summary>
      public bool IsMasterwork
      {
         get { return is_masterwork_p; }
      }
      /// <summary>
      /// How many rounds it takes for a character to equip armor properly.
      /// </summary>
      public int RoundsToDon
      {
         get { return rounds_to_don_p; }
      }
      /// <summary>
      /// How many rounds it takes for a character to equip the armor improperly.
      /// </summary>
      public int RoundsToDonHastily
      {
         get { return rounds_to_hastily_don_p; }
      }
      /// <summary>
      /// How many rounds it takes for a character to unequip and remove the armor.
      /// </summary>
      public int RoundsToRemove
      {
         get { return rounds_to_remove_p; }
      }
      /// <summary>
      /// Category of armor (light/medium/heavy/shield).
      /// </summary>
      public Enum_Armor_Categories ArmorCategory
      {
         get { return armor_category_p; }
         set { armor_category_p = value; }
      }
      /// <summary>
      /// Is the armor actually a shield?
      /// </summary>
      public bool IsShield
      {
         get { return is_shield_p; }
      }
      /// <summary>
      /// Is the armor actually an armor?
      /// </summary>
      public bool IsArmor
      {
         get { return is_armor_p; }
      }
      #endregion

      #region IEquipment Properties
      /// <summary>
      /// Is the armor equipped?
      /// </summary>
      public bool IsEquipped
      {
         get { return is_equipped_p; }
         set { is_equipped_p = value; }
      }
      /// <summary>
      /// Is the armor...CURSED?!
      /// </summary>
      //public bool IsCursed
      //{
      //   get { return is_cursed_p; }
      //   set { is_cursed_p = value; }
      //}
      /// <summary>
      /// Is the armor broken? (Half of total durability remaining) 
      /// 1) AC Bonus halved, rounding down
      /// 2) Double AC Penalty on skills (Dex and Str)
      /// </summary>
      public bool IsBroken
      {
         get { return is_broken_p; }
         set { is_broken_p = value; }
      }
      #endregion

      #region Armor/Shield Modifications
      /// <summary>
      /// List of all current armor modifications applied to the armor.
      /// </summary>
      public List<Enum_Armor_Modifications> ArmorMods
      {
         get { return armor_modification_list_p; }
      }
      /// <summary>
      /// List of all current shield modifications applied to the shield.
      /// </summary>
      public List<Enum_Shield_Modifications> ShieldMods
      {
         get { return shield_modification_list_p; }
      }
      #endregion
      #endregion
   }
}
