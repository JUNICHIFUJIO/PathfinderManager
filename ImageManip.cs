using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace PathfinderManager
{
   static class ImageManip
   {
      const int _THUMBNAIL_WIDTH = 40;
      const int _THUMBNAIL_HEIGHT = 40;

      /// <summary>
      /// Iterates through all of the pixels (n-time) of an image to convert all 
      /// specified background pixels to the system's Transparent color.
      /// </summary>
      /// <param name="image">The image to create a transformed copy of.</param>
      /// <param name="background_color">The color recognized as having the ARGB 
      ///   value of the background.</param>
      /// <returns>A transformed copy of the passed in image. (Can wrap this 
      ///   function call safely in a using declaration.)</returns>
      static public Image MakeBGTransparent(Image image, Color background_color)
      {
         if (image == null)
         {
            throw new ArgumentNullException("ImageManip: Invalid image passed to ImageManip.");
         }

         Bitmap result = new Bitmap(image);

         for (int x = 0; x < result.Width; x++)
         {
            for (int y = 0; y < result.Height; y++)
            {
               if (result.GetPixel(x, y).ToArgb() == background_color.ToArgb())
               {
                  result.SetPixel(x, y, Color.Transparent);
               }
            }
         }

         return result;
      }

      /// <summary>
      /// Iterates through all of the pixels (n-time) of an image to convert all 
      /// pixels of the specified original color to a replacement color.
      /// </summary>
      /// <param name="image">The image to create a transformed copy of.</param>
      /// <param name="replacement_color">The color to replace the original color with.</param>
      /// <param name="original_color">The color to swap out with the replacement color.</param>
      static public Image ReplaceColor(Image image, Color replacement_color, Color original_color)
      {
         if (image == null)
         {
            throw new ArgumentNullException("ImageManip: Invalid image passed to ImageManip.");
         }

         Bitmap result = new Bitmap(image);

         for (int x = 0; x < result.Width; x++)
         {
            for (int y = 0; y < result.Height; y++)
            {
               if (result.GetPixel(x, y).ToArgb() == original_color.ToArgb())
               {
                  result.SetPixel(x, y, replacement_color);
               }
            }
         }

         return result;
      }

      static public Image MakeThumbnail(Image image)
      {
         return new Bitmap(image, new Size(_THUMBNAIL_WIDTH, _THUMBNAIL_HEIGHT));
      }
   }
}
