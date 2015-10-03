using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   public enum Enum_Item_Tags
   {
      Consumable,
      Equippable,
      Two_Handed,
      One_Handed,
      Weapon,
      Ammunition,
      Armor,
      Shield,
      Ring,
      Clothing,
      Magical,
      Wondrous
   };

   class Inventory
   {
      #region Constructors
      public Inventory(List<Item> item_list)
      {
         // transfer all items to the items list
         foreach (Item item in item_list)
         {
            // record the item
            allItems.Add(item);
            // add to all appropriate tag maps
            if (item is IEquipment)
            {
               tagMap.Add(Enum_Item_Tags.Equippable, item);
               IEquipment equipment = (IEquipment)item;

               // if two handed
               // if one handed


            }
         }
         // add them to the appropriate tag maps
      }
      #endregion

      #region Methods
      #endregion

      #region Fields
      private List<Item> allItems;
      private Dictionary<Enum_Item_Tags, List<Item>> tagMap;
      private List<Item> itemList;
      #endregion 

      #region Properties
      #endregion
   }
}
