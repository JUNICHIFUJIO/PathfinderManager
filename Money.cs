using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   class Money
   {
      #region Constants
      const int _copper_per_silver = 10;
      const int _copper_per_gold = 100;
      const int _copper_per_platinum = 1000;
      const int _per_tier = 10;
      #endregion

      #region Constructors
      public Money(int pp = 0, int gp = 0, int sp = 0, int cp = 0)
      {
         Add(pp, gp, sp, cp);
      }
      #endregion

      #region Methods
      public void Add(int pp = 0, int gp = 0, int sp = 0, int cp = 0)
      {
         copper_p += pp * _copper_per_platinum;
         copper_p += gp * _copper_per_gold;
         copper_p += sp * _copper_per_silver;
         copper_p += cp;
      }

      /// <summary>
      /// Returns true if the money was removed.
      /// </summary>
      /// <param name="pp"></param>
      /// <param name="gp"></param>
      /// <param name="sp"></param>
      /// <param name="cp"></param>
      /// <returns></returns>
      public bool Remove(int pp = 0, int gp = 0, int sp = 0, int cp = 0)
      {
         if (CanAfford(pp, gp, sp, cp))
         {
            copper_p -= pp * _copper_per_platinum;
            copper_p -= gp * _copper_per_gold;
            copper_p -= sp * _copper_per_silver;
            copper_p -= cp;

            return true;
         }
         else
         {
            return false;
         }
      }

      public bool CanAfford(int pp = 0, int gp = 0, int sp = 0, int cp = 0)
      {
         int total =
            pp * _copper_per_platinum
            + gp * _copper_per_gold 
            + sp * _copper_per_silver 
            + cp;

         if (total <= copper_p)
         {
            return true;
         }
         else
         {
            return false;
         }
      }

      public void Reset()
      {
         copper_p = 0;
      }

      new public string ToString()
      {
         return String.Format("{0}pp, {1}gp, {2}sp, {3}cp", Platinum, Gold, Silver, Copper);
      }
      #endregion

      #region Fields
      private int copper_p;
      #endregion

      #region Properties
      public int Copper
      {
         get { return copper_p % _per_tier; }
      }
      public int Silver
      {
         get { return copper_p / _copper_per_silver % _per_tier; }
      }
      public int Gold
      {
         get { return copper_p / _copper_per_gold % _per_tier; }
      }
      public int Platinum
      {
         get { return copper_p / _copper_per_platinum; }
      }
      public bool IsBroke
      {
         get { return this.copper_p == 0; }
      }
      #endregion
   }
}
