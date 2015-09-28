using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace PathfinderManager
{
   class UnselectedCharacterMenuButton : CharacterMenuButton
   {
      #region Constants
      const int _MIN_WIDTH = 300;
      const int _MIN_HEIGHT = 55;
      #endregion

      #region Constructors
      public UnselectedCharacterMenuButton(string character_name, string character_class, int character_level, string nickname) :
         base(character_name, character_class, character_level, nickname)
      {

         initialize_name();
         initialize_dock();
         initialize_size();

         this.Paint += new PaintEventHandler(base.CharacterMenuButton_Paint);
      }

      public UnselectedCharacterMenuButton() :
         base() { }
      #endregion

      #region Methods
      #region Constructor Helpers
      private void initialize_name()
      {
         if (CharacterName == null)
         {
            throw new InvalidOperationException("UnselectedCharacterMenuButton: Invalid Name state.");
         }
         this.Name = "B_UnselectedCharacterMenu_" + CharacterName;
      }

      private void initialize_dock()
      {
         this.Dock = DockStyle.Fill;
      }

      private void initialize_size()
      {
         this.MinimumSize = new Size(_MIN_WIDTH, _MIN_HEIGHT);
         //this.MaximumSize = new Size(300, 55);
         // ERROR TESTING need to be able to grow controls/drawings as the button resizes
      }
      #endregion

      #region Painting
      protected override void write_name(string name)
      {
         using (Graphics g = this.CreateGraphics())
         {
            // Display "Name:"
            using (Font field_font = new Font("Arial", 20, FontStyle.Bold))
            {
               Size field_space = TextRenderer.MeasureText("Name:", field_font, this.ClientSize);
               
               Point field_loc = new Point(this.Padding.Left, this.Padding.Top);
               TextRenderer.DrawText(g, "Name:", field_font, new Rectangle(field_loc, field_space), Color.DarkMagenta, TextFormatFlags.Bottom);

               // Display the name
               using (Font name_font = new Font("Arial", 13))
               {
                  Size name_rectangle_size = TextRenderer.MeasureText(name, name_font, this.ClientSize);
                  Size name_space = new Size(this.Width - this.Padding.Horizontal - field_space.Width - FavoriteButton.Width, name_rectangle_size.Height);

                  Point name_loc = new Point(this.Padding.Left + field_space.Width, this.Padding.Top + calculate_height_difference_for_font_baseline_match(field_font, g, name_font, g));
                  TextRenderer.DrawText(g, name, name_font, new Rectangle(name_loc, name_space), Color.Black, TextFormatFlags.EndEllipsis);
               }
            }
         }
      }

      /// <summary>
      /// Returns the height difference you need to add to the other font's Y location to make its baseline align with the standard font's baseline.
      /// </summary>
      /// <param name="standard">The font whose baseline you want to align with.</param>
      /// <param name="std_g">The graphics object for the standard font.</param>
      /// <param name="other">The font whose baseline you want to align to standard's baseline.</param>
      /// <param name="other_g">The graphics object for the other font.</param>
      /// <returns>The height difference you need to add to the other font's Y location to make its baseline align with the standard font's baseline.</returns>
      static public int calculate_height_difference_for_font_baseline_match(Font standard, Graphics std_g, Font other, Graphics other_g)
      {
         float std_ascent = standard.FontFamily.GetCellAscent(standard.Style);
         float std_linespace = standard.FontFamily.GetLineSpacing(standard.Style);
         float std_baseline = standard.GetHeight(std_g) * std_ascent / std_linespace;

         float other_ascent = other.FontFamily.GetCellAscent(other.Style);
         float other_linespace = other.FontFamily.GetLineSpacing(other.Style);
         float other_baseline = other.GetHeight(other_g) * other_ascent / other_linespace;

         return (int)(std_baseline - other_baseline);
      }

      protected override void write_class(string new_class)
      {
         using (Graphics g = this.CreateGraphics())
         {
            string text = "(Class: " + new_class + ")";
            using (Font class_font = new Font("Arial", 9))
            {
               Size class_rectangle_size = TextRenderer.MeasureText(text, class_font, this.ClientSize);
               TextRenderer.DrawText(g, text, class_font, new Rectangle(new Point(this.Width * 4 / 15, this.Height * 3 / 5), class_rectangle_size), Color.DarkGray);
            }
         }
      }

      protected override void write_level(int level)
      {
         using (Graphics g = this.CreateGraphics())
         {
            string text = "(Lvl: " + level.ToString() + ")";
            using (Font level_font = new Font("Arial", 9))
            {
               Size level_rectangle_size = TextRenderer.MeasureText(text, level_font, this.ClientSize);
               TextRenderer.DrawText(g, text, level_font, new Rectangle(new Point(this.Width * 10 / 13, this.Height * 3 / 5), level_rectangle_size), Color.DarkGreen);
            }
         }
      }
      #endregion

      #region Event Handlers
      #endregion
      #endregion

      #region Fields
      #endregion

      #region Properties
      public static int MIN_WIDTH
      {
         get { return _MIN_WIDTH; }
      }
      public static int MIN_HEIGHT
      {
         get { return _MIN_HEIGHT; }
      }
      #endregion
   }
}
