using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   #region Enumerators
   public enum Enum_Affectable_Stats
   {
      Strength,
      Dexterity,
      Constitution,
      Intelligence,
      Charisma,
      Wisdom,
      
      AC,
      Atk,
      Dmg,
      CMB,
      CMD,
      Initiative,
      Spell_Resistance,
      Size,
      Skill,

      Fort_Save,
      Reflex_Save,
      Will_Save,

      Move_Speed,

      Accuracy
   };
   #endregion

   class StatusEffect
   {
      #region Constants
      const string _DEFAULT_DESCRIPTION = "A mysterious status effect.";
      #endregion

      #region Constructors
      public StatusEffect(string name, string description, Dictionary<Enum_Affectable_Stats, int> stat_map)
      {
         this.Name = name;
         this.Description = description;
         this.stat_map = stat_map;
      }

      public StatusEffect(string name) :
         this(name, _DEFAULT_DESCRIPTION, new Dictionary<Enum_Affectable_Stats,int>()) { }
      #endregion

      #region Methods
      #region Publicly Accessible
      public void AddStatEffect(Enum_Affectable_Stats stat, int effect)
      {
         this[stat] = effect;
      }

      public void RemoveStatEffect(Enum_Affectable_Stats stat)
      {
         if (stat_map.ContainsKey(stat))
         {
            stat_map.Remove(stat);
         }
      }

      public List<KeyValuePair<Enum_Affectable_Stats, int>> ToEffectList()
      {
         return stat_map.ToList();
      }
      #endregion
      #endregion

      #region Fields
      private string name;
      private string description;
      private Dictionary<Enum_Affectable_Stats, int> stat_map;
      #endregion

      #region Properties
      public string Name
      {
         get { return this.name; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("StatusEffect: Cannot set status effect's name to null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("StatusEffect: Cannot set status effect's name to a blank value.");
            }
            else
            {
               this.name = value;
            }
         }
      }
      public string Description
      {
         get { return this.description; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("StatusEffect: Cannot set status effect's description to null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("StatusEffect: Cannot set status effect's description to a blank value.");
            }
            else
            {
               this.description = value;
            }
         }
      }
      public int this[Enum_Affectable_Stats Stat]
      {
         get
         {
            if (stat_map.ContainsKey(Stat))
            {
               return stat_map[Stat];
            }
            else
            {
               return 0;
            }
         }
         set
         {
            if (value == 0
               && stat_map.ContainsKey(Stat))
            {
               stat_map.Remove(Stat);
            }
            else if (stat_map.ContainsKey(Stat))
            {
               stat_map[Stat] = value;
            }
            else
            {
               stat_map.Add(Stat, value);
            }
         }
      }
      #endregion
   }
}
