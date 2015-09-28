using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace PathfinderManager
{
   class SelectedCharacterMenuButton : CharacterMenuButton
   {
      #region Constructors
      public SelectedCharacterMenuButton(string character_name, string character_class, int character_level, string nickname, Image thumbnail) :
         base(character_name, character_class, character_level, nickname)
      {
         // handle image
         Thumbnail = thumbnail; // handles null value
         thumbnail_box_p = new PictureBox();
         thumbnail_box_p.Size = thumbnail_p.Size;
         thumbnail_box_p.Image = thumbnail_p;

         date_modified_p = DateTime.Now; // ERROR TESTING placeholder
         this.Paint += new PaintEventHandler(SelectedCharacterMenuButton_Paint);
      }

      public SelectedCharacterMenuButton(string character_name, string character_class, int character_level, string nickname) :
         this(character_name, character_class, character_level, nickname, null) { }

      public SelectedCharacterMenuButton(UnselectedCharacterMenuButton base_button) :
         this(base_button.CharacterName, base_button.CharacterClass, base_button.CharacterLevel, base_button.Nickname, null)
      {
         // set the position correctly

         // load the correct image
      }

      static SelectedCharacterMenuButton()
      {
         // set the static default image
         string directory = "C:\\Users\\Thomas\\Documents\\Visual Studio 2013\\Projects\\C#\\PathfinderManager\\Images\\";
         using (Image file_image = Image.FromFile(directory + "DefaultCharacterThumbnail"))
         {
            std_thumbnail_p = ImageManip.MakeThumbnail(file_image);
         }
      }
      #endregion

      #region Methods
      #region Constructor Helpers
      private void initialize_dock()
      {
         this.Dock = DockStyle.None;
      }

      private void initialize_name()
      {
         this.Name = "B_SelectedCharacterMenuButton";
      }

      private void initialize_size()
      {
         this.MinimumSize = new Size(UnselectedCharacterMenuButton.MIN_WIDTH + UnselectedCharacterMenuButton.PADDING * 2, UnselectedCharacterMenuButton.MIN_HEIGHT + UnselectedCharacterMenuButton.PADDING * 2);
      }

      private void initialize_location()
      {

      }
      #endregion

      #region Painting
      protected override void write_name(string name)
      {
         using (Graphics g = this.CreateGraphics())
         {
            string text = "Name: " + name;
            using (Font name_font = new Font("Arial", 16))
            {
               Size name_rectangle_size = TextRenderer.MeasureText(text, name_font, this.ClientSize);
               Point name_location = new Point(thumbnail_p.Width + 2 * 10, 10);
               TextRenderer.DrawText(g, text, name_font, new Rectangle(name_location, name_rectangle_size), Color.DarkTurquoise);
            }
         }
      }

      protected override void write_class(string new_class)
      {
         using (Graphics g = this.CreateGraphics())
         {
            string text = "Class: " + new_class;
            using (Font class_font = new Font("Arial", 13))
            {
               Size class_rectangle_size = TextRenderer.MeasureText(text, class_font, this.ClientSize);
               Point class_location = new Point(thumbnail_p.Width + 2 * 10, 10 + (class_rectangle_size.Height + 3) + 5);
               TextRenderer.DrawText(g, text, class_font, new Rectangle(class_location, class_rectangle_size), Color.Black);
            }
         }
      }

      protected override void write_level(int level)
      {
         using (Graphics g = this.CreateGraphics())
         {
            string text = "Lvl: " + level.ToString();
            using (Font level_font = new Font("Arial", 13))
            {
               Size level_rectangle_size = TextRenderer.MeasureText(text, level_font, this.ClientSize);
               Point level_location = new Point(FavoriteButton.Location.X, 10 + (level_rectangle_size.Height + 3) + 5);
               TextRenderer.DrawText(g, text, level_font, new Rectangle(level_location, level_rectangle_size), Color.Black);
            }
         }
      }

      protected void write_date_modified(string date_modified)
      {
         using (Graphics g = this.CreateGraphics())
         {
            string text = "Date Modified: " + date_modified;
            using (Font date_font = new Font("Arial", 8))
            {
               Size date_rectangle_size = TextRenderer.MeasureText(text, date_font, this.ClientSize);
               Point date_location = new Point(this.Width - date_rectangle_size.Width - 3, this.Height - date_rectangle_size.Height - 3);
               TextRenderer.DrawText(g, text, date_font, new Rectangle(date_location, date_rectangle_size), Color.Black);
            }
         }
      }
      #endregion

      #region Image Handling
      public void SetImage(Image image)
      {
         if (image == null)
         {
            thumbnail_p = std_thumbnail_p;
         }
         else
         {
            // resize the image
            // save the image as a new occurrence in thumbnail_p
            Thumbnail = ImageManip.MakeThumbnail(image);
            thumbnail_box_p.Size = thumbnail_p.Size;
            thumbnail_box_p.Image = thumbnail_p;
         }
      }
      #endregion

      #region Event Handlers
      public void SelectedCharacterMenuButton_Paint(object sender, PaintEventArgs e)
      {
         //base.OnPaint(e);
         base.CharacterMenuButton_Paint(sender, e);

         // write the picture and date modified
         write_date_modified(date_modified_p.ToString());
      }
      #endregion
      #endregion

      #region Fields
      private PictureBox thumbnail_box_p;
      private Image thumbnail_p;
      static private Image std_thumbnail_p;
      private DateTime date_modified_p;
      #endregion

      #region Properties
      /// <summary>
      /// Get or set the thumbnail to associate with this button. If passed a 
      /// null value, will default to the ThumbnailStandard image.
      /// </summary>
      public Image Thumbnail
      {
         get { return thumbnail_p; }
         set
         {
            if (value == null)
            {
               thumbnail_p = std_thumbnail_p;
            }
            else
            {
               thumbnail_p = value;
            }
         }
      }
      /// <summary>
      /// Gets the Image associated as the default character thumbnail.
      /// </summary>
      public Image ThumbnailStandard
      {
         get { return std_thumbnail_p; }
      }
      #endregion
   }
}
