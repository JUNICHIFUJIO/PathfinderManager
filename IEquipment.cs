using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   interface IEquipment
   {
      #region Methods
      void Equip();
      void Remove();
      void Repair();
      void Repair(int durability_repaired);
      void Break();
      void Damage(int durability_lost);
      #endregion

      #region Properties
      bool IsEquipped { get; set; }
      //public bool IsCursed { get; set; }
      bool IsBroken { get; set; }
      #endregion
   }
}
