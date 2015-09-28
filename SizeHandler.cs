using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   #region Enumerators
   /// <summary>
   /// The size categories for the various creatures of the Pathfinder world.
   /// </summary>
   public enum Enum_Size_Categories
   {
      Fine, // .5 or less ft
      Diminuitive, // .5 to 1 ft
      Tiny, // 1 - 2 ft
      Small, // 2 - 4 ft
      Medium, // 4 - 8 ft
      Large_Tall, // 8 - 16 ft
      Large_Long,
      Huge_Tall, // 16 - 32 ft
      Huge_Long,
      Gargantuan_Tall, // 32 - 64 ft
      Gargantuan_Long,
      Colossal_Tall, // 64 ft
      Colossal_Long
   };
   #endregion

   #region Structs
   public struct SizeInfo
   {
      public Enum_Size_Categories Size;
      public int SizeModifier;
      public int SpecialSizeModifier;
      public int FlyModifier;
      public int StealthModifier;
      public double Space;
      public int NaturalReach;
      public Tuple<float, float> TypicalHeight;
      public Tuple<float, float> TypicalWeight;
   };
   #endregion

   static class SizeHandler
   {
      static public SizeInfo GetSizeInfo(Enum_Size_Categories size){
         SizeInfo info = new SizeInfo() { Size = size };

         switch(size){
            case(Enum_Size_Categories.Fine):
               info.SizeModifier = 8;
               info.SpecialSizeModifier = -8;
               info.FlyModifier = 8;
               info.StealthModifier = 16;
               info.Space = .5;
               info.NaturalReach = 0;
               info.TypicalHeight = new Tuple<float,float>(0, (float).5);
               info.TypicalWeight = new Tuple<float,float>(0, (float).125);
               break;
            case(Enum_Size_Categories.Diminuitive):
               info.SizeModifier = 4;
               info.SpecialSizeModifier = -4;
               info.FlyModifier = 6;
               info.StealthModifier = 12;
               info.Space = 1;
               info.NaturalReach = 0;
               info.TypicalHeight = new Tuple<float,float>((float).5, 1);
               info.TypicalWeight = new Tuple<float, float>((float).125, 1);
               break;
            case(Enum_Size_Categories.Tiny):
               info.SizeModifier = 2;
               info.SpecialSizeModifier = -2;
               info.FlyModifier = 4;
               info.StealthModifier = 8;
               info.Space = 2.5;
               info.NaturalReach = 0;
               info.TypicalHeight = new Tuple<float,float>(1, 2);
               info.TypicalWeight = new Tuple<float,float>(1, 8);
               break;
            case(Enum_Size_Categories.Small):
               info.SizeModifier = 1;
               info.SpecialSizeModifier = -1;
               info.FlyModifier = 2;
               info.StealthModifier = 4;
               info.Space = 5;
               info.NaturalReach = 5;
               info.TypicalHeight = new Tuple<float, float>(2, 4);
               info.TypicalWeight = new Tuple<float,float>(8, 60);
               break;
            case(Enum_Size_Categories.Medium):
               info.SizeModifier = 0;
               info.SpecialSizeModifier = 0;
               info.FlyModifier = 0;
               info.StealthModifier = 0;
               info.Space = 5;
               info.NaturalReach = 5;
               info.TypicalHeight = new Tuple<float, float>(4, 8);
               info.TypicalWeight = new Tuple<float, float>(60, 500);
               break;
            case(Enum_Size_Categories.Large_Tall):
               info.SizeModifier = -1;
               info.SpecialSizeModifier = 1;
               info.FlyModifier = -2;
               info.StealthModifier = -4;
               info.Space = 10;
               info.NaturalReach = 10;
               info.TypicalHeight = new Tuple<float, float>(8, 16);
               info.TypicalWeight = new Tuple<float, float>(500, 4000);
               break;
            case (Enum_Size_Categories.Large_Long):
               info.SizeModifier = -1;
               info.SpecialSizeModifier = 1;
               info.FlyModifier = -2;
               info.StealthModifier = -4;
               info.Space = 10;
               info.NaturalReach = 5;
               info.TypicalHeight = new Tuple<float, float>(8, 16);
               info.TypicalWeight = new Tuple<float, float>(500, 4000);
               break;
            case(Enum_Size_Categories.Huge_Tall):
               info.SizeModifier = -2;
               info.SpecialSizeModifier = 2;
               info.FlyModifier = -4;
               info.StealthModifier = -8;
               info.Space = 15;
               info.NaturalReach = 15;
               info.TypicalHeight = new Tuple<float, float>(16, 32);
               info.TypicalWeight = new Tuple<float, float>(4000, 32000);
               break;
            case (Enum_Size_Categories.Huge_Long):
               info.SizeModifier = -2;
               info.SpecialSizeModifier = 2;
               info.FlyModifier = -4;
               info.StealthModifier = -8;
               info.Space = 15;
               info.NaturalReach = 10;
               info.TypicalHeight = new Tuple<float, float>(16, 32);
               info.TypicalWeight = new Tuple<float, float>(4000, 32000);
               break;
            case(Enum_Size_Categories.Gargantuan_Tall):
               info.SizeModifier = -4;
               info.SpecialSizeModifier = 4;
               info.FlyModifier = -6;
               info.StealthModifier = -12;
               info.Space = 20;
               info.NaturalReach = 20;
               info.TypicalHeight = new Tuple<float, float>(32, 64);
               info.TypicalWeight = new Tuple<float, float>(32000, 250000);
               break;
            case (Enum_Size_Categories.Gargantuan_Long):
               info.SizeModifier = -4;
               info.SpecialSizeModifier = 4;
               info.FlyModifier = -6;
               info.StealthModifier = -12;
               info.Space = 20;
               info.NaturalReach = 15;
               info.TypicalHeight = new Tuple<float, float>(32, 64);
               info.TypicalWeight = new Tuple<float, float>(32000, 250000);
               break;
            case(Enum_Size_Categories.Colossal_Tall):
               info.SizeModifier = -8;
               info.SpecialSizeModifier = 8;
               info.FlyModifier = -6;
               info.StealthModifier = -16;
               info.Space = 30;
               info.NaturalReach = 30;
               info.TypicalHeight = new Tuple<float, float>(64, float.MaxValue);
               info.TypicalWeight = new Tuple<float, float>(250000, float.MaxValue);
               break;
            case (Enum_Size_Categories.Colossal_Long):
               info.SizeModifier = -8;
               info.SpecialSizeModifier = 8;
               info.FlyModifier = -6;
               info.StealthModifier = -16;
               info.Space = 30;
               info.NaturalReach = 20;
               info.TypicalHeight = new Tuple<float, float>(64, float.MaxValue);
               info.TypicalWeight = new Tuple<float, float>(250000, float.MaxValue);
               break;
            default:
               throw new InvalidOperationException("SizeHandler: Invalid size category chosen.");
         }

         return info;
      }
   }
}
