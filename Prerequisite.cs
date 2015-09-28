using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   public enum Enum_Prerequisite_Types
   {
      Feat,
      Skill,
      Race,
      Age,
      Level,
      Stat,
      Stance
   };

   class Prerequisite
   {
      #region Constructors
      public Prerequisite(Enum_Prerequisite_Types prerequisite_type, string name, bool dynamic)
      {
         this.prerequisiteType = prerequisite_type;
         this.name = name;
         this.dynamic = dynamic;
      }
      #endregion

      #region Methods
      public bool IsMet(Character character)
      {
         // ERROR TESTING // complete
         bool result = false;

         switch (this.prerequisiteType)
         {
            case(Enum_Prerequisite_Types.Age):
               break;
            case(Enum_Prerequisite_Types.Feat):
               break;
            case(Enum_Prerequisite_Types.Level):
               break;
            case(Enum_Prerequisite_Types.Race):
               break;
            case(Enum_Prerequisite_Types.Skill):
               break;
            case(Enum_Prerequisite_Types.Stance):
               break;
            case(Enum_Prerequisite_Types.Stat):
               break;
            default:
               throw new InvalidOperationException("Prerequisite: Invalid prerequisite type encountered.");
         }

         return result;
      }
      #endregion

      #region Fields
      private Enum_Prerequisite_Types prerequisiteType;
      private string name;
      private bool dynamic;
      #endregion

      #region Properties
      public Enum_Prerequisite_Types PrerequisiteType
      {
         get { return this.prerequisiteType; }
      }
      public string Name
      {
         get { return this.name; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Prerequisite: Cannot set name to a null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("Prerequisite: Cannot set name to a blank value.");
            }
            else
            {
               this.name = value;
            }
         }
      }
      public bool IsDynamic
      {
         get { return this.dynamic; }
      }
      #endregion
   }
}
