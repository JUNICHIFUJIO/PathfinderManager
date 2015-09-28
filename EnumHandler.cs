using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   static class EnumHandler
   {
      static EnumHandler() { }

      /// <summary>
      /// Erases all underlines.
      /// </summary>
      /// <param name="enum_string"></param>
      /// <returns></returns>
      static public string ToString(string enum_string)
      {
         return enum_string.Replace('_', ' ');
      }
   }
}
