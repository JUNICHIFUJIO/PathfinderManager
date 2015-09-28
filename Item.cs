using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   class Item
   {
      #region Constructors
      public Item(string name, int quantity, string description, int money_value, bool is_cursed, int weight)
      {
         // ERROR TESTING:
         // need failsoft if any items are null;
         this.name_p = name;
         this.Quantity = quantity;
         this.Description = description;
         this.MoneyValue = money_value;
         this.IsCursed = is_cursed;
         this.Weight = weight;
      }
      #endregion

      #region Methods
      // use
      public bool Use(int quantity)
      {
         if (Quantity > 0)
         {
            quantity--;
            return true;
         }
         else
         {
            return false;
         }
      }

      public bool Use()
      {
         return Use(1);
      }

      public void Get(int quantity)
      {
         Quantity += quantity;
      }

      public string Examine()
      {
         return Description;
      }
      #endregion

      #region Fields
      private int quantity_p;
      private string name_p;
      private string description_p;

      private int money_value_p;
      private bool is_cursed_p;
      private int weight_p;
      #endregion

      #region Properties
      public int Quantity
      {
         get { return quantity_p; }
         set
         {
            if (value < 0)
            {
               throw new ArgumentException("Item: Cannot set negative quantity.");
            }
            else
            {
               quantity_p = value;
            }
         }
      }
      public string Name
      {
         get { return name_p; }
      }
      public string Description
      {
         get { return description_p; }
         set
         {
            if(value != null
               && value.Length > 0)
            {
               description_p = value;
            }
            else
            {
               throw new ArgumentException("Item: Item must have a description.");
            }
         }
      }
      public int MoneyValue
      {
         get { return money_value_p; }
         set
         {
            if (value >= 0)
            {
               money_value_p = value;
            }
            else
            {
               throw new ArgumentException("Item: Monetary value cannot be negative.");
            }
         }
      }
      public bool IsCursed
      {
         get { return is_cursed_p; }
         set { is_cursed_p = true; }
      }
      public int Weight
      {
         get { return weight_p; }
         set
         {
            if (value >= 0)
            {
               weight_p = value;
            }
            else
            {
               throw new ArgumentException("Item: Weight cannot be less than 0 lbs.");
            }
         }
      }
      #endregion
   }
}
