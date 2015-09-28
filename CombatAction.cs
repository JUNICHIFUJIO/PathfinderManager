using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   class CombatAction : Action
   {
      public CombatAction(Enum_Action_Types action_type, string name, Enum_Combat_Actions combat_action_type) :
         base(action_type, name)
      {
         this.combatActionType = combat_action_type;
      }

      public CombatAction(CombatAction other, string new_name) :
         this(other.ActionType, new_name, other.CombatActionType) { }

      private Enum_Combat_Actions combatActionType;

      public Enum_Combat_Actions CombatActionType
      {
         get { return this.combatActionType; }
      }
   }
}
