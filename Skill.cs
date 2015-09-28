using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{

   public enum Enum_Skill_Check_Result_Tiers
   {
      Critical_Success,
      Great_Success,
      Success,
      Failure,
      Great_Failure,
      Critical_Failure
   };

   public enum Enum_Skills
   {
      Acrobatics,
      Appraise,
      Bluff,
      Climb,
      Craft,
      Diplomacy,
      Disable_Device,
      Disguise,
      Escape_Artist,
      Fly,
      Handle_Animal,
      Heal,
      Intimidate,
      Knowledge_Arcana,
      Knowledge_Dungeoneering,
      Knowledge_Engineering,
      Knowledge_Geography,
      Knowledge_History,
      Knowledge_Local,
      Knowledge_Nature,
      Knowledge_Nobility,
      Knowledge_Planes,
      Knowledge_Religion,
      Linguistics,
      Perception,
      Perform,
      Profession,
      Ride,
      Sense_Motive,
      Sleight_of_Hand,
      Spellcraft,
      Stealth,
      Survival,
      Swim,
      Use_Magic_Device,
      Custom
   };

   class Skill
   {
      #region Constants
      const string _DEFAULT_DESCRIPTION = "A mysterious skill.";
      #endregion

      #region Constructors
      public Skill(Enum_Skills skill, string name, string description, bool is_class_skill, int initial_value = 1)
      {
         this.skill = skill;
         if (skill == Enum_Skills.Custom)
         {
            this.name = name;
         }
         else
         {
            this.name = EnumHandler.ToString(skill.ToString());
         }
         this.description = description;
         this.isClassSkill = is_class_skill;
      }
      #endregion

      #region Methods
      public void AddSpecialEffect(int skill_level, string special_effect)
      {
         this.specialEffects.Add(new KeyValuePair<int, string>(skill_level, special_effect));
         // ERROR TESTING
         // Implement OrderBy<> to order the specials by the associated skill level
      }

      #endregion

      #region Fields
      private Enum_Skills skill;
      private string name;
      private string description;
      private bool isClassSkill;
      private List<KeyValuePair<int, string>> specialEffects;
      #endregion

      #region Properties
      public Enum_Skills Skill
      {
         get { return this.skill; }
      }
      public string Name
      {
         get { return this.name; }
         set
         {
            if (this.skill == Enum_Skills.Custom)
            {
               if (value == null)
               {
                  throw new ArgumentNullException("Skill: Cannot set the name of the skill to a null value.");
               }
               else if (value.Length == 0)
               {
                  throw new ArgumentException("Skill: Cannot set the name of the skill to a blank value.");
               }
               else
               {
                  this.name = value;
               }
            }
            else
            {
               throw new InvalidOperationException("Skill: Cannot alter the name of a pre-set skill.");
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
               this.description = _DEFAULT_DESCRIPTION;
               throw new ArgumentNullException("Skill: Cannot set description to null value. Defaulted to default description.");
            }
            else if (value.Length == 0)
            {
               this.description = _DEFAULT_DESCRIPTION;
               throw new ArgumentException("Skill: Cannot set description to blank value. Defaulted to default description.");
            }
            else
            {
               this.description = value;
            }
         }
      }
      public bool IsClassSkill
      {
         get { return isClassSkill; }
         set { isClassSkill = value; }
      }
      public List<KeyValuePair<int, string>> SpecialEffects
      {
         get { return this.specialEffects; }
      }
      #endregion
   }
}
