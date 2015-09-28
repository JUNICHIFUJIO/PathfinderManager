using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   #region Enumerators
   public enum Enum_Feat_Types
   {
      General,
      Combat,
      Combat_Critical,
      Metamagic,
      Damnation,
      Faction,
      Grit,
      Panache,
      Meditation,
      Item_Creation,
      Mythic,
      Story,
      Achievement,
      Animal_Familiar,
      Monster
   };

   public enum Enum_Feat_Subtypes
   {
      Teamwork,
      Performance,
      Racial,
      // Grit,
      Style,
      Targeting
   }

   #endregion
   class Feat
   {
      #region Constructors
      /// <summary>
      /// Makes dynamic copies of the subtypes and prerequisites lists passed in.
      /// </summary>
      /// <param name="feat_type"></param>
      /// <param name="feat_subtypes"></param>
      /// <param name="prerequisites"></param>
      /// <param name="benefit"></param>
      /// <param name="special"></param>
      public Feat(Enum_Feat_Types feat_type,
         List<Enum_Feat_Subtypes> feat_subtypes,
         List<Prerequisite> prerequisites,
         string benefit,
         Dictionary<Enum_Affectable_Stats, int> stat_effects,
         string special)
      {
         this.featType = feat_type;
         this.featSubTypes = new List<Enum_Feat_Subtypes>();
         if(feat_subtypes != null){
            foreach (Enum_Feat_Subtypes subtype in feat_subtypes)
            {
               this.featSubTypes.Add(subtype);
            }
         }
         this.prerequisites = new List<Prerequisite>();
         if(prerequisites != null){
            foreach (Prerequisite prereq in prerequisites)
            {
               this.prerequisites.Add(prereq);
            }
         }
         this.Benefit = benefit;
         this.statEffects = new Dictionary<Enum_Affectable_Stats, int>();
         foreach (Enum_Affectable_Stats stat in stat_effects.Keys)
         {
            this.statEffects.Add(stat, stat_effects[stat]);
         }
         this.Special = special;
      }

      /// <summary>
      /// Use for generic combat feats
      /// </summary>
      public Feat(List<Prerequisite> prerequisites, string benefit, Dictionary<Enum_Affectable_Stats, int> stat_effects, string special) :
         this(Enum_Feat_Types.Combat, null, prerequisites, benefit, stat_effects, special) { }
      #endregion

      #region Methods
      public void AddPrerequisite(Prerequisite prereq)
      {
         this.prerequisites.Add(prereq);
      }

      public void AddStatEffect(Enum_Affectable_Stats stat, int effect)
      {
         this.statEffects.Add(stat, effect);
      }
      #endregion

      #region Fields
      private Enum_Feat_Types featType;
      private List<Enum_Feat_Subtypes> featSubTypes;
      private List<Prerequisite> prerequisites;
      private string benefit;
      private Dictionary<Enum_Affectable_Stats, int> statEffects;
      private string special;
      #endregion

      #region Properties
      public Enum_Feat_Types FeatType
      {
         get { return this.featType; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Feat: Feat type cannot be set to null value.");
            }
            else
            {
               this.featType = value;
            }
         }
      }
      public List<Enum_Feat_Subtypes> FeatSubTypes
      {
         get { return this.featSubTypes; }
      }
      public List<Prerequisite> Prerequisites
      {
         get
         {
            return this.prerequisites;
         }
      }
      public string Benefit
      {
         get { return this.benefit; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Feat: Feat benefit cannot be set to null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("Feat: Feat benefit cannot be set to blank value.");
            }
            else
            {
               this.benefit = value;
            }
         }
      }
      public Dictionary<Enum_Affectable_Stats, int> StatEffects
      {
         get { return this.statEffects; }
      }
      public string Special
      {
         get { return this.special; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Feat: Feat special field cannot be set to null value.");
            }
            else
            {
               this.special = value;
            }
         }
      }
      #endregion
   }
}
