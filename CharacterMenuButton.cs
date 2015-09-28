using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace PathfinderManager
{
   abstract class CharacterMenuButton : Button
   {
      public delegate void OnClickMy(EventArgs e);
      const int _PADDING = 5;
      const int _MARGIN = 3;

      #region Constructors
      public CharacterMenuButton(string character_name, string character_class, int character_level, string nickname)
      {
         // autosize
         // autoellipsis
         // backcolor
         // backgroundimage
         // backgroundimagelayout
         // bottom
         // BringToFront
         // clientsize
         // dock
         // cursor

         // initialize character info
         name_p = character_name;
         class_p = character_class;
         level_p = character_level;
         nickname_p = nickname;

         // set the cursor appropriately
         initialize_cursor();
         // set the name and text appropriately
         initialize_name();
         initialize_text();
         // set the dock appropriately
         // initialize_dock();
         // set the background to be the right color
         initialize_background();
         // set the border style
         initialize_border();
         // set mouse up/down event handlers
         // create the button for the favorite star
         initialize_favorite_button();

         this.Resize += new System.EventHandler(CharacterMenuButton_Resize);

         this.Padding = new Padding(_PADDING);
         this.Margin = new Padding(_MARGIN);
      }

      public CharacterMenuButton() :
         this(String.Format("Adventurer_{0:000}", 0), "Fighter", 1, "Fresh Meat")
      {
         // reinitialize the name
         //name_p = String.Format("Adventurer_{0:000}", this.Parent.Controls.GetChildIndex(this));
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
         if (name_p == null)
         {
            throw new InvalidOperationException("CharacterMenuButton: Invalid Name state.");
         }
         this.Name = "B_CharacterMenu_" + name_p;
      }

      private void initialize_text()
      {
         this.Text = "";
      }

      private void initialize_dock()
      {
         this.Dock = DockStyle.Fill;
      }

      private void initialize_background()
      {
         // ERROR TESTING
         // Implement it so that this has a faded background image of the character
         this.BackColor = DefaultBackColor;
      }

      private void initialize_border()
      {
         this.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
         this.FlatAppearance.BorderSize = 2;
         this.FlatAppearance.BorderColor = Color.Black;
      }

      
      private void adjust_favorite_button(bool favorited)
      {
         if (favorited != favorite_button.IsFavorited)
         {
            favorite_button.OnClick(this, new EventArgs());
         }
      }
      
      private void initialize_favorite_button()
      {
         favorite_button = new FavoriteButton(false);
         this.Controls.Add(favorite_button);
         reposition_fav_button();
      }

      abstract protected void write_name(string name);
      abstract protected void write_class(string new_class);
      abstract protected void write_level(int level);

      // ERROR TESTING
      // bounding size in ***_rectangle_size shouldn't be client_size, it should be something depending on how much space the item is actually expected to take
      /*
      private void write_name(string name)
      {
         using (Graphics g = this.CreateGraphics())
         {
            string text = "Name: " + name;
            using (Font name_font = new Font("Arial", 13))
            {
               Size name_rectangle_size = TextRenderer.MeasureText(text, name_font, this.ClientSize);
               TextRenderer.DrawText(g, text, name_font, new Rectangle(new Point(0, 0), name_rectangle_size), Color.Black);
            }
         }
      }

      private void write_class(string new_class)
      {
         using (Graphics g = this.CreateGraphics())
         {
            string text = "(Class: " + new_class + ")";
            using (Font class_font = new Font("Arial", 9))
            {
               Size class_rectangle_size = TextRenderer.MeasureText(text, class_font, this.ClientSize);
               TextRenderer.DrawText(g, text, class_font, new Rectangle(new Point(this.Width * 4 / 15, this.Height *3 / 5), class_rectangle_size), Color.DarkGray);
            }
         }
      }

      private void write_level(int level)
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
      */

      #region Event Handlers
      public void CharacterMenuButton_Paint(object sender, PaintEventArgs e)
      {
         write_name(name_p);
         write_class(class_p);
         write_level(level_p);
      }

      public void CharacterMenuButton_Resize(object sender, EventArgs e)
      {
         reposition_fav_button();
      }

      private void reposition_fav_button()
      {
         favorite_button.Location = new Point(this.Width - favorite_button.Width - _PADDING, _PADDING);
         //favorite_button.Location = new Point(this.Width * 9 / 10, this.Height / 10);
      }

      // ERROR TESTING deprecated
      public void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
      
         write_name(name_p);
         write_class(class_p);
         write_level(level_p);
      }


      #endregion


      #region Publicly Accessible
      public void SetName(string name)
      {
         name_p = name;
         write_name(name);
      }

      public void SetClass(string character_class)
      {
         // ERROR TESTING
         // handle multiclassing gracefully
         class_p = character_class;
         write_class(character_class);
         // ERROR TESTING
         // also use the enums listed in Form1
      }

      public void SetLevel(int level)
      {
         if (level < 1
            || level > 25)
         {
            throw new ArgumentException("CharacterMenuButton: Unable to set character Level.");
         }
         level_p = level;
         write_level(level);
      }

      public void SetIsFavorited(bool favorited)
      {
         favorited_p = favorited;
         adjust_favorite_button(favorited);
      }

      public void SetNickname(string nickname)
      {
         nickname_p = nickname;
      }
      #endregion
      #endregion
      #endregion

      #region Fields
      private string name_p;
      private string class_p;
      private int level_p;
      private bool favorited_p;
      private FavoriteButton favorite_button;
      private string nickname_p;
      #endregion

      #region Properties
      public string CharacterName
      {
         get { return name_p; }
         protected set
         {
            if(value != null
               && value.Length > 0)
            {
               SetName(value);
            }
            else
            {
               throw new ArgumentException("CharacterMenuButton: Unable to set character Name.");
            }
         }
      }
      public string CharacterClass
      {
         get { return class_p; }
         protected set
         {
            if(value != null
               && value.Length > 0)
            {
               SetClass(value);
            }
            else
            {
               throw new ArgumentException("CharacterMenuButton: Unable to set character Class.");
            }
         }
      }
      public int CharacterLevel
      {
         get { return level_p; }
         protected set
         {
            if (value > 0)
            {
               SetLevel(value);
            }
            else
            {
               throw new ArgumentException("CharacterMenuButton: Unable to set character Level.");
            }
         }
      }
      public bool IsFavorited
      {
         get { return favorited_p; }
         protected set { favorited_p = value; }
      }
      public string Nickname
      {
         get { return nickname_p; }
         protected set
         {
            if(value != null
               && value.Length > 0)
            {
               nickname_p = value;
            }
            else
            {
               throw new ArgumentException("CharacterMenuButton: Unable to set character nickname.");
            }
         }
      }
      public FavoriteButton FavoriteButton
      {
         get { return favorite_button; }
      }

      public static int PADDING
      {
         get { return _PADDING; }
      }

      #region Base Properties

      #endregion
      #endregion
   }
}
