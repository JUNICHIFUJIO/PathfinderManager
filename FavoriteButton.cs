using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace PathfinderManager
{
   class FavoriteButton : Button
   {
      #region Constants
      const int _WIDTH = 25;
      const int _HEIGHT = 25;
      #endregion

      #region Constructors
      public FavoriteButton(bool favorited)
      {
         // set the cursor appropriately
         initialize_cursor();
         // set the name and text appropriately
         initialize_name();
         initialize_text();
         // set the size appropriately
         initialize_button_size();
         // set the background to be transparent
         initialize_background();
         // have the border be like a flat one
         initialize_border();
         // set the image
         initialize_image(favorited);
         // set whether the button is active (favorited) or not (unfavorited)
         favorited_p = favorited;

         // make it react to click events
         this.Click += new System.EventHandler(OnClick);
      }

      static FavoriteButton()
      {
         // get the image directory
         // get the files
         string directory = "C:\\Users\\Thomas\\Documents\\Visual Studio 2013\\Projects\\C#\\PathfinderManager\\Images\\";
         string favorite_image_file = "bookmark.png";
         string unfavorite_image_file = "bookmark_star.png";

         using (Image favorite_image = ImageManip.MakeBGTransparent(Image.FromFile(directory + favorite_image_file), Color.White))
         {
            favorited_image_p = new Bitmap(favorite_image, new Size(_WIDTH, _HEIGHT));
         }
         using (Image unfavorite_image = ImageManip.MakeBGTransparent(Image.FromFile(directory + unfavorite_image_file), Color.White))
         {
            unfavorited_image_p = new Bitmap(unfavorite_image, new Size(_WIDTH, _HEIGHT));
         }

         //favorited_image_p = new Bitmap(ImageManip.MakeBGTransparent(Image.FromFile(directory + favorite_image_file), Color.White));
         //unfavorited_image_p = ImageManip.MakeBGTransparent(Image.FromFile(directory + unfavorite_image_file), Color.White);
      }
      #endregion

      #region Methods
      #region Constructor Helpers

      private void initialize_cursor()
      {
         this.Cursor = Cursors.Hand;
      }

      private void initialize_name()
      {
         if (Parent != null)
         {
            this.Name = Parent.Name + "_FavButton";
         }
      }

      private void initialize_text()
      {
         this.Text = "";
      }

      private void initialize_button_size()
      {
         this.Size = new Size(_WIDTH, _HEIGHT);
      }

      private void initialize_background()
      {
         this.BackColor = Color.Transparent;
         this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.Text = "";
         FlatAppearance.MouseOverBackColor = Color.Transparent;
         FlatAppearance.MouseDownBackColor = Color.Transparent;
      }

      private void initialize_border()
      {
         FlatAppearance.BorderSize = 0;
      }

      private void initialize_image(bool favorited)
      {
         if (favorited)
         {
            this.Image = favorited_image_p;
         }
         else
         {
            this.Image = unfavorited_image_p;
         }
      }
      #endregion

      #region Event Handlers
      public void OnClick(Object sender, EventArgs e)
      {
         set_opposite_image();
         favorited_p = !favorited_p;
      }

      public void OnParentChanged(EventArgs e)
      {
         base.OnParentChanged(e);

         this.Name = Parent.Name + "_FavButton";
      }
      #endregion

      #region Miscellaneous Helpers
      /// <summary>
      /// Swaps the image to be representative of the opposite of the button's 
      /// current state. (Favorited -> Unfavorited, vice versa)
      /// </summary>
      private void set_opposite_image()
      {
         if (favorited_p)
         {
            this.Image = unfavorited_image_p;
         }
         else
         {
            this.Image = favorited_image_p;
         }
      }
      #endregion
      #endregion

      #region Fields
      private bool favorited_p;
      static private Image unfavorited_image_p;
      static private Image favorited_image_p;
      #endregion

      #region Properties
      /// <summary>
      /// Gets the Image associated with the unfavorited state of the favorite
      /// button.
      /// </summary>
      public Image UnfavoritedImage
      {
         get { return unfavorited_image_p; }
      }
      /// <summary>
      /// Gets the Image associated with the favorited state of the favorite
      /// button.
      /// </summary>
      public Image FavoritedImage
      {
         get { return favorited_image_p; }
      }
      /// <summary>
      /// Gets if the button is active (favorited).
      /// </summary>
      public bool IsFavorited
      {
         get { return favorited_p; }
      }
      #endregion
   }
}
