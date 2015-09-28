using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   public enum Enum_Action_Types
   {
      Standard,
      Move,
      Full_Round,
      Swift,
      Immediate,
      Free
   };

   public enum Enum_Combat_Actions
   {
      // Standard actions
      Attack_Melee,
      Attack_Ranged,
      Attack_Unarmed,
      Activate_Magic_Item,
      Aid_Another,
      Cast_Spell,
      Channel_Energy,
      Concentrate_to_Maintain_Active_Spell,
      Dismiss_Spell,
      Draw_Hidden_Weapon,
      Drink_Potion,
      Apply_Oil,
      Escape_Grapple,
      Feint,
      Light_Torch_Quickly,
      Lower_Spell_Resistance,
      Read_Scroll,
      Ready_Other_Action,
      Stabilize_Heal,
      Total_Defense,
      Use_EX_Ability,
      Use_Some_Standard_Action,
      Use_SL_Ability,
      Use_SU_Ability,

      // Move actions
      Move,
      Control_Frightened_Mount,
      Direct_Active_Spell,
      Redirect_Active_Spell,
      Draw_Weapon,
      Load_Light_Crossbow,
      Open_Door,
      Close_Door,
      Mount_Steed,
      Dismount_Steed,
      Pick_Up_Item,
      Sheathe_Weapon,
      Stand_Up_From_Prone,
      Ready_Shield,
      Drop_Shield,
      Retrieve_Stored_Item,

      // Full Round actions
      Full_Attack,
      Charge,
      Coup_de_Grace,
      Escape_Net,
      Extinguish_Flames,
      Light_Torch,
      Load_Heavy_Crossbow,
      Lock_In_Gauntlet,
      Unlock_From_Gauntlet,
      Prepare_to_Throw_Splash_Weapon,
      Run,
      Use_Some_Standard_Skill,
      Use_Touch_Spell,
      Withdraw,

      // Free Actions
      Cease_Spell_Concentration,
      Drop_Item,
      Drop_to_Floor,
      Prepare_Spell_Components,
      Speak,

      // Swift Actions
      Cast_Quickened_Spell,

      // Immediate Actions
      Cast_Feather_Fall,

      // No Action
      Delay,
      Five_Foot_Step,

      // Varied Action Type
      Combat_Maneuver,
      Use_Feat
   }

   class Action
   {
      public Action(Enum_Action_Types action_type, string action_name)
      {
         this.actionType = action_type;
         this.name = action_name;
      }

      public Action(Action other, string new_action_name)
      {
         this.name = new_action_name;
      }

      private Enum_Action_Types actionType;
      private string name;

      public Enum_Action_Types ActionType
      {
         get { return this.actionType; }
      }
      public string Name
      {
         get { return this.name; }
      }
   }
}
