using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   using Critical = Tuple<int, int, int>;
   using Damage = Tuple<int, int>;

   #region Enumerators
   /// <summary>
   /// The basic categories every weapon may fall under. Determines proficiency.
   /// </summary>
   public enum Enum_Weapon_Categories
   {
      Simple,
      Martial,
      Exotic,
      Other
   };

   /// <summary>
   /// The various styles of combat a character can engage with when using a weapon.
   /// </summary>
   public enum Enum_Weapon_Combat_Styles
   {
      Unarmed,
      Two_Handed,
      Two_Weapon,
      One_Handed,
      Sword_And_Shield,
      Ranged,
      Thrown,
      Improvised
   };

   /// <summary>
   /// The three damage styles applicable to a weapon: Piercing, Slashing, and Bludgeoning.
   /// </summary>
   public enum Enum_Weapon_Damage_Types
   {
      Piercing,
      Slashing,
      Bludgeoning
   };

   /// <summary>
   /// Special features that can be applied to weapons to improve certain aspects. 
   /// Innate features as opposed to special aspects specific to weapons.
   /// </summary>
   public enum Enum_Weapon_Special_Features
   {
      Blocking,
      Brace,
      Deadly,
      Disarm,
      Distracting,
      Double,
      Fragile,
      Grapple,
      Monk,
      Nonlethal,
      Performance,
      Reach,
      Strength,
      Sunder,
      Trip,

   };

   #endregion
   

   /// <summary>
   /// Tracks info for a weapon.
   /// </summary>
   class Weapon : Item, IEquipment
   {
      #region Structs
      /// <summary>
      /// A struct to track all the important/customizable aspects of an equippable weapon.
      /// </summary>
      public struct Weapon_Values
      {
         public Damage DamageSmall;
         public Damage DamageMedium;
         public Critical Critical;
         public int RangeIncrement;
         public Enum_Weapon_Damage_Types DamageType;
         public string SpecialEffect;
         public Enum_Size_Categories SizeCategory;

         public bool IsReachWeapon;
         public bool IsDoubleWeapon;
         public bool IsThrownWeapon;
         public bool IsProjectileWeapon;
         public bool IsPerformanceWeapon;
         public bool IsSplashWeapon;
         public bool IsImprovisedWeapon;
         public bool IsBroken;
         public bool IsCursed;

         public bool IsLightWeapon;
         public bool IsOneHandedWeapon;
         public bool IsTwoHandedWeapon;

         public int Durability;
         public bool IsMasterwork;
      }
      #endregion

      #region Constants
      const int _DEFAULT_MONEY_VALUE = 1000; // 10 gp
      readonly Damage _DEFAULT_DAMAGE_SMALL = new Damage(1, 6);
      readonly Damage _DEFAULT_DAMAGE_MEDIUM = new Damage(1, 8);
      readonly Critical _DEFAULT_CRITICAL = new Critical(20, 20, 3);
      const int _DEFAULT_RANGE_INCREMENT = 0;
      const Enum_Weapon_Damage_Types _DEFAULT_WEAPON_DAMAGE_TYPE = Enum_Weapon_Damage_Types.Slashing;
      const string _DEFAULT_SPECIALEFFECT = "N/A";
      const Enum_Size_Categories _DEFAULT_SIZE_CATEGORY = Enum_Size_Categories.Medium;
      const int _DEFAULT_WEIGHT = 10;
      const int _DEFAULT_DURABILITY = 100;
      #endregion

      #region Constructors
      public Weapon(string name, string description, int money_value, bool is_cursed, int weight, Weapon_Values weapon_values) :
         base(name, 1, description, money_value, is_cursed, weight)
      {
         initialize_weapon_values(weapon_values);
         special_features_p = new List<Enum_Weapon_Special_Features>();
      }

      public Weapon() :
         this("Generic Weapon", "Some generic weapon. Not worth much.", _DEFAULT_MONEY_VALUE, false, _DEFAULT_WEIGHT, new Weapon_Values()) { }

      public Weapon(Weapon other) :
         this(other.Name, other.Description, other.MoneyValue, other.IsCursed, other.Weight,
            new Weapon_Values()
            {
               DamageSmall = other.DamageSmall,
               DamageMedium = other.DamageMedium,
               Critical = other.Critical,
               RangeIncrement = other.RangeIncrement,
               DamageType = other.DamageType,
               SpecialEffect = other.SpecialEffect,
               SizeCategory = other.SizeCategory,

               IsReachWeapon = other.IsReachWeapon,
               IsDoubleWeapon = other.IsDoubleWeapon,
               IsThrownWeapon = other.IsThrownWeapon,
               IsProjectileWeapon = other.IsProjectileWeapon,
               IsPerformanceWeapon = other.IsPerformanceWeapon,
               IsSplashWeapon = other.IsSplashWeapon,
               IsImprovisedWeapon = other.IsImprovisedWeapon,
               IsBroken = other.IsBroken,
               IsCursed = other.IsCursed,

               IsLightWeapon = other.IsLightWeapon,
               IsOneHandedWeapon = other.IsOneHandedWeapon,
               IsTwoHandedWeapon = other.IsTwoHandedWeapon,

               Durability = other.Durability,
               IsMasterwork = other.IsMasterwork
            }
         )
      {
         this.current_hp_p = other.RemainingDurability;
         foreach(Enum_Weapon_Special_Features feature in other.SpecialFeatures){
            this.special_features_p.Add(feature);
         }
      }// ERROR TESTING fill with whatever extra is necessary

      public Weapon(Weapon other, Weapon_Values customization_values) :
         this(other)
      {
         Customize(customization_values);
      }

      #endregion

      #region Methods
      #region Constructor Helpers
      private void initialize_weapon_values(Weapon_Values values)
      {
         damage_small_p = values.DamageSmall != null ? values.DamageSmall : _DEFAULT_DAMAGE_SMALL;
         damage_medium_p = values.DamageMedium != null ? values.DamageMedium : _DEFAULT_DAMAGE_MEDIUM;
         critical_p = values.Critical != null ? values.Critical : _DEFAULT_CRITICAL;
         range_increment_p = values.RangeIncrement != null ? values.RangeIncrement : _DEFAULT_RANGE_INCREMENT;
         damage_type_p = values.DamageType != null ? values.DamageType : _DEFAULT_WEAPON_DAMAGE_TYPE;
         special_effect_p = values.SpecialEffect != null ? values.SpecialEffect : _DEFAULT_SPECIALEFFECT;
         size_category_p = values.SizeCategory != null ? values.SizeCategory : _DEFAULT_SIZE_CATEGORY;
         
         is_reach_weapon_p = values.IsReachWeapon != null ? values.IsReachWeapon : false;
         is_double_weapon_p = values.IsDoubleWeapon != null ? values.IsDoubleWeapon : false;
         is_thrown_weapon_p = values.IsThrownWeapon != null ? values.IsThrownWeapon : false;
         is_projectile_weapon_p = values.IsProjectileWeapon != null ? values.IsProjectileWeapon : false;
         is_splash_weapon_p = values.IsSplashWeapon != null ? values.IsSplashWeapon : false;
         is_improvised_weapon_p = values.IsImprovisedWeapon != null ? values.IsImprovisedWeapon : false;
         is_broken_weapon_p = values.IsBroken != null ? values.IsBroken : false;
         is_cursed_weapon_p = values.IsCursed != null ? values.IsCursed : false;

         is_light_weapon_p = values.IsLightWeapon != null ? values.IsLightWeapon : false;
         is_one_handed_weapon_p = values.IsOneHandedWeapon != null ? values.IsOneHandedWeapon : true;
         is_two_handed_weapon_p = values.IsTwoHandedWeapon != null ? values.IsTwoHandedWeapon : false;
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
            if (current_hp_p > hit_points_p)
            {
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

      // ERROR TESTING
      // get special features implemented everywhere

      public void Customize(Weapon_Values values){
         damage_small_p = values.DamageSmall != null ? values.DamageSmall : this.DamageSmall;
         damage_medium_p = values.DamageMedium != null ? values.DamageMedium : this.DamageMedium;
         critical_p = values.Critical != null ? values.Critical : this.Critical;
         range_increment_p = values.RangeIncrement != null ? values.RangeIncrement : this.RangeIncrement;
         damage_type_p = values.DamageType != null ? values.DamageType : this.DamageType;
         special_effect_p = values.SpecialEffect != null ? values.SpecialEffect : this.SpecialEffect;
         size_category_p = values.SizeCategory != null ? values.SizeCategory : this.SizeCategory;
         
         is_reach_weapon_p = values.IsReachWeapon != null ? values.IsReachWeapon : this.IsReachWeapon;
         is_double_weapon_p = values.IsDoubleWeapon != null ? values.IsDoubleWeapon : this.IsDoubleWeapon;
         is_thrown_weapon_p = values.IsThrownWeapon != null ? values.IsThrownWeapon : this.IsThrownWeapon;
         is_projectile_weapon_p = values.IsProjectileWeapon != null ? values.IsProjectileWeapon : this.IsProjectileWeapon;
         is_splash_weapon_p = values.IsSplashWeapon != null ? values.IsSplashWeapon : this.IsSplashWeapon;
         is_improvised_weapon_p = values.IsImprovisedWeapon != null ? values.IsImprovisedWeapon : this.IsImprovisedWeapon;
         is_broken_weapon_p = values.IsBroken != null ? values.IsBroken : this.IsBroken;
         is_cursed_weapon_p = values.IsCursed != null ? values.IsCursed : this.IsCursed;
         
         is_light_weapon_p = values.IsLightWeapon != null ? values.IsLightWeapon : this.IsLightWeapon;
         is_one_handed_weapon_p = values.IsOneHandedWeapon != null ? values.IsOneHandedWeapon : this.IsOneHandedWeapon;
         is_two_handed_weapon_p = values.IsTwoHandedWeapon != null ? values.IsTwoHandedWeapon : this.IsTwoHandedWeapon;
      }

      public void AddSpecialFeature(Enum_Weapon_Special_Features feature){
         if(!special_features_p.Contains(feature)){
            switch(feature){
               case(Enum_Weapon_Special_Features.Blocking):
                  break;
               case(Enum_Weapon_Special_Features.Brace):
                  break;
               case(Enum_Weapon_Special_Features.Deadly):
                  break;
               case(Enum_Weapon_Special_Features.Disarm):
                  break;
               case(Enum_Weapon_Special_Features.Distracting):
                  break;
               case(Enum_Weapon_Special_Features.Double):
                  IsDoubleWeapon = true;
                  break;
               case(Enum_Weapon_Special_Features.Fragile):
                  break;
               case(Enum_Weapon_Special_Features.Grapple):
                  break;
               case(Enum_Weapon_Special_Features.Monk):
                  break;
               case(Enum_Weapon_Special_Features.Nonlethal):
                  break;
               case(Enum_Weapon_Special_Features.Performance):
                  IsPerformanceWeapon = true;
                  break;
               case(Enum_Weapon_Special_Features.Reach):
                  IsReachWeapon = true;
                  break;
               case(Enum_Weapon_Special_Features.Strength):
                  break;
               case(Enum_Weapon_Special_Features.Sunder):
                  break;
               case(Enum_Weapon_Special_Features.Trip):
                  break;
               default:
                  break;
            }
         }
      }

      #endregion

      #region Fields
      private Damage damage_small_p;
      private Damage damage_medium_p;
      private Critical critical_p;
      private int range_increment_p;
      private Enum_Weapon_Damage_Types damage_type_p;
      private string special_effect_p;
      private Enum_Size_Categories size_category_p;

      private bool is_reach_weapon_p;
      private bool is_double_weapon_p;
      private bool is_thrown_weapon_p;
      private bool is_projectile_weapon_p;
      private int specialMaxRange;
      private bool is_performance_weapon_p;
      private bool is_splash_weapon_p;
      private bool is_improvised_weapon_p;
      private bool is_broken_weapon_p;
      private bool is_cursed_weapon_p;

      private bool is_light_weapon_p;
      private bool is_one_handed_weapon_p;
      private bool is_two_handed_weapon_p;

      private bool is_equipped_p;
      private int current_hp_p;
      private int hit_points_p;
      private bool is_masterwork_p;

      private List<Enum_Weapon_Special_Features> special_features_p;
      #endregion

      #region Properties
      public Damage DamageSmall
      {
         get { return damage_small_p; }
         set
         {
            if (value == null)
            {
               damage_small_p = _DEFAULT_DAMAGE_SMALL;
               throw new ArgumentNullException("Weapon: Can't set damage to null value.");
            }
            else if(value.Item1 > 0
               && value.Item2 > 0)
            {
               damage_small_p = value;
            }
            else
            {
               throw new ArgumentException("Weapon: Can't deal zero or negative damage.");
            }
         }
      }
      public Damage DamageMedium
      {
         get { return damage_medium_p; }
         set
         {
            if (value == null)
            {
               damage_medium_p = _DEFAULT_DAMAGE_MEDIUM;
               throw new ArgumentNullException("Weapon: Cannot set weapon damage as null value.");
            }
            else if(value.Item1 > 0
               && value.Item2 > 0)
            {
               damage_medium_p = value;
            }
            else
            {
               throw new ArgumentException("Weapon: Cannot set weapon damage to zero or negative value.");
            }
         }
      }
      public Critical Critical
      {
         get { return critical_p; }
         set
         {
            if (value == null)
            {
               critical_p = _DEFAULT_CRITICAL;
               throw new ArgumentNullException("Weapon: Weapon critical cannot be set to null value. Set to default value.");
            }
            else if(value.Item1 >= 1
               && value.Item2 <= 20
               && value.Item3 > 1)
            {
               critical_p = value;
            }
            else
            {
               throw new ArgumentException("Weapon: Cannot set critical value.");
            }
         }
      }
      public int RangeIncrement
      {
         get { return range_increment_p; }
         set
         {
            if (value >= 0)
            {
               range_increment_p = value;
            }
            else
            {
               range_increment_p = 0;
            }
         }
      }
      public int MaxRange
      {
         // ERROR TESTING
         // need static method for calculating range given horizontal and vertical
         get
         {
            if (this.specialMaxRange != 0)
            {
               return this.specialMaxRange;
            }
            else if (this.IsProjectileWeapon)
            {
               return 10 * this.range_increment_p;
            }
            else if (this.IsThrownWeapon)
            {
               return 5 * this.range_increment_p;
            }
            else if (this.IsReachWeapon)
            {
               return 10;
            }
            else
            {
               return 5;
            }
         }
      }
      public Enum_Weapon_Damage_Types DamageType
      {
         get { return damage_type_p; }
         set
         {
            if (value == null)
            {
               damage_type_p = _DEFAULT_WEAPON_DAMAGE_TYPE;
               throw new ArgumentNullException("Weapon: Damage type cannot be set to null value. Set to default value.");
            }
            else
            {
               damage_type_p = value;
            }
         }
      }
      public string SpecialEffect
      {
         get { return special_effect_p; }
         set
         {
            if(value == null
               || value.Length < 1)
            {
               special_effect_p = "N/A";
               if (value == null)
               {
                  throw new ArgumentNullException("Weapon: Special effect set to default.");
               }
            }
            else
            {
               special_effect_p = value;
            }
         }
      }
      public Enum_Size_Categories SizeCategory
      {
         get { return size_category_p; }
         set
         {
            if (value == null)
            {
               size_category_p = _DEFAULT_SIZE_CATEGORY;
               throw new ArgumentNullException("Weapon: Size category cannot be set to null. Setting to default.");
            }
            else
            {
               size_category_p = value;
            }
         }
      }


      public bool IsReachWeapon
      {
         get { return is_reach_weapon_p; }
         set { is_reach_weapon_p = value; }
      }
      public bool IsDoubleWeapon
      {
         get { return is_double_weapon_p; }
         set { is_double_weapon_p = value; }
      }
      public bool IsThrownWeapon
      {
         get { return is_thrown_weapon_p; }
         set { is_thrown_weapon_p = value; }
      }
      public bool IsProjectileWeapon
      {
         get { return is_projectile_weapon_p; }
         set { is_projectile_weapon_p = value; }
      }
      public bool IsPerformanceWeapon
      {
         get { return is_performance_weapon_p; }
         set { is_performance_weapon_p = value; }
      }
      public bool IsSplashWeapon
      {
         get { return is_splash_weapon_p; }
         set { is_splash_weapon_p = value; }
      }
      public bool IsImprovisedWeapon
      {
         get { return is_improvised_weapon_p; }
         set { is_improvised_weapon_p = value; }
      }
      public bool IsBroken
      {
         get { return is_broken_weapon_p; }
         set { is_broken_weapon_p = value; }
      }
      public bool IsCursed
      {
         get { return is_cursed_weapon_p; }
         set { is_cursed_weapon_p = value; }
      }


      public bool IsLightWeapon
      {
         get { return is_light_weapon_p; }
         set { is_light_weapon_p = value; }
      }
      public bool IsOneHandedWeapon
      {
         get { return is_one_handed_weapon_p; }
         set { is_one_handed_weapon_p = value; }
      }
      public bool IsTwoHandedWeapon
      {
         get { return is_two_handed_weapon_p; }
         set { is_two_handed_weapon_p = value; }
      }

      public bool IsEquipped
      {
         get { return is_equipped_p; }
         set { is_equipped_p = value; }
      }
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
      public bool IsMasterwork
      {
         get { return is_masterwork_p; }
         set { is_masterwork_p = value; }
      }

      public List<Enum_Weapon_Special_Features> SpecialFeatures{
         get { return special_features_p; }
      }
      #endregion
   }
}
