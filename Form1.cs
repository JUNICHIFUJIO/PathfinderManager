using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathfinderManager
{

   #region Character Class Enumerators
   public enum Enum_CharacterClasses { Barbarian, Bard, Cleric, Druid, Fighter, Monk, Paladin, Ranger, Rogue, Sorcerer, Wizard};
   public enum Enum_BaseCharacterClasses { Alchemist, Cavalier, Gunslinger, Inquisitor, Magus, Oracle, Summoner, Witch};
   public enum Enum_AlternateCharacterClasses { Antipaladin, Ninja, Samurai};
   public enum Enum_HybridCharacterClasses { Arcanist, Bloodrager, Brawler, Hunter, Investigator, Shaman, Skald, Slayer, Swashbuckler, Warpriest};
   public enum Enum_UnchainedCharacterClasses { Unchained_Barbarian, Unchained_Monk, Unchained_Rogue, Unchained_Summoner};
   public enum Enum_OccultCharacterClasses { Kineticist, Medium, Mesmerist, Occultist, Psychic, Spiritualist };
   public enum Enum_PrestigeCharacterClasses { Arcane_Archer, Arcane_Trickster, Assassin, Dragon_Disciple, Duelist, Eldritch_Knight, Loremaster, Mystic_Theurge, Pathfinder, Chronicler, Shadowdancer,
      // Other Paizo prestige classes
         Agent_of_the_Grave, Arcane_Savant, Battle_Herald, Bloodmage, Brightness_Seeker, Brother_of_the_Seal, Celestial_Knight, Champion_of_the_Enlightened, Chevalier, Coastal_Pirate, Collegiate_Arcanist, Crimson_Assassin, Cyphermage, Daivrat, Dark_Delver, Darkfire_Adept, Deep_Sea_Pirate, Demoniac, Diabolist, Dissident_of_Dawn, Divine_Assessor, Divine_Scion, Envoy_of_Balance, Evangelist, False_Priest, Field_Agent, Furious_Guardian, Genie_Binder, Golden_Legionnaire, Grand_Marshal, Gray_Warden, Green_Faith_Acolyte, Group_Leader, Guild_Agent, Guild_Poisoner, Halfling_Opportunist, Harrower, Hell_Knight_Commander, Hell_Knight_Enforcer, Holy_Vindicator, Horizon_Walker, Inheritors_Crusader, Justiciar, Lantern_Bearer, Liberator, Lion_Blade, Living_Monolith, Low_Templar, Mage_of_the_Third_Eye, Mammoth_Rider, Master_Chymist, Master_of_Storms, Master_Spy, Natural_Alchemist, Nature_Warden, Noble_Scion, Pain_Taster, Pit_Fighter, Planes_Walker, Purity_Legion_Enforcer, Rage_Prophet, Sanctified_Prophet, Sleepless_Detective, Souleater, Soul_Warden, Spherewalker, Stalwart_Defender, Steel_Falcon, Student_of_War, Sun_Seeker, Swordlord, Tattooed_Mystic, Technomancer, Umbral_Agent, Veiled_Illusionist, Winter_Witch
      };
   public enum Enum_NPCCharacterClasses { Adept, Aristocrat, Commoner, Expert, Warrior, Courtesan};
   public enum Enum_3rdPartyCharacterClasses { Apprentice, Gladiator, Hedge_Witch, Schooled_Bard, Voyageur, // 4 Winds Fantasy Gaming
         // Adamant Entertainment
         Artificer, Knight, Priest, Shaman, Spellblade, Swashbuckler, Warlock, Warlord,
         // Ascension Games, LLC
         Nightblade,
         // Dreamscarred Press
         Aegis, Cryptic, Dread, Marksman, Psion, Psychic_Warrior, Soulknife, Stalker, Tactician, Vitalist, The_Vizier, Warder, Wilder, //Warlord,
         // Drop Dead Studios
         The_Artisan,
         // Flaming Crab Games
         //Priest,
         // Forest Guardian Press
         Direlock,
         // Interjection Games
         Tinker,
         // Kobold Press/Open Design
         Battle_Scion, Elven_Archer, Savant, Spell_less_Ranger, Theurge, White_Necromancer, // Shaman,
         // Louis Porter Jr. Design
         Machinesmith,
         // Radiance House
         Occultist,
         // Rite Publishing
         Luckbringer, Taskshaper, Jotun_Paragon_Class,
         // Rogue Genius Games
         Adept_Godling, Archon, Armiger, Clever_Godling, Death_Mage, Dragonrider, Eldritch_Godling, Magister, Mighty_Godling, Shadow_Assassin, Time_Thief, Vanguard, War_Master, Witch_Hunter, // Shaman, 
         // Sean K. Reynolds Games
         Hellenic_Sorceress,
         // Total Party Kill Games
         Malefactor,
         // Tripod Machine
         Beastmaster, Bounty_Hunter, Corbie, Corsair, Hunter, Martial_Artist, Scholar, Scout, Spy, // Gladiator, Knight, 
         // Wordcasting Entertainment
         Pugilist
      };
   public enum Enum_3rdPartyPrestigeCharacterClasses { 
         // 4 Winds Fantasy Gaming
         Armor_Bonded, Blood_Caster, Butcher, Child_of_Bast, Crypt_Stalker, Daredevil, Ioun_Angel, Jinx, Pikeman, Tin_Man,
         // Alluria Publishing
         Abolisher, Archeovitus, Battletwin, Deathseeker, Demolisher, Entrepreneur, Golden_Muse, Grim_Reaper, Lightseeker, Pharaoh, Reverent_of_Spring, Savage, Slime_Lord, Warrior_Philosopher, Zubbit,
         // Bastion Press
         Bloodtracker, Dinosaur_Cultist, Gutter_Stalker, Sea_Reaver,
         // Louis Porter Jr. Design
         Transmechanical_Ascendant,
         // Dreamscarred Press
         Awakened_Blade, Battle_Templar, Bladecaster, Dragon_Fury, Mage_Hunter, Umbral_Blade,
         // Paizo Fans United
         Dawa_Defender, Dervish_of_Dawn, Gunslinger, Lord_of_the_Dead, Shadow_Scout,
         // Rite Publishing
         Bone_Breaker_Racial_Paragon_Class, Bugyo, Machi_Yakko, Mosa,
         // Prestige Classes - 3rd Party - Rogue Genius Games
         Godling, Dauntless_Shield, Unseen_Hand, Warding_Eye,
         // Sean K Reynolds Games
         Serpent_Archer,
         // Zombie Sky Press
         Fire_Scion
      };
   #endregion
   public partial class W_Pathfinder_Manager : Form
   {
      #region Constants
      private const int _CLIENT_WIDTH = 550;
      private const int _CLIENT_HEIGHT = 400;
      #endregion

      public W_Pathfinder_Manager()
      {
         InitializeComponent();

         initialize_screen();

         TLP_Character_Manager_Menus_Menu.Margin = new Padding(20);
         TLP_Character_Manager_Menus_Menu.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

         // adjust the cells of 

         TLP_Character_Manager_Menus_Menu.Controls.Add(new UnselectedCharacterMenuButton("Dick 'n Balls", "Barbarian", 15, "Thomas"));
         TLP_Character_Manager_Menus_Menu.Controls.Add(new UnselectedCharacterMenuButton("Character2", "Magus", 10, "Thomas"));

         foreach (Control menu_button in TLP_Character_Manager_Menus_Menu.Controls)
         {
            menu_button.Margin = new Padding(3);
         }

         TLP_Character_Manager_Menus_Menu.MinimumSize = new Size(TLP_Character_Manager_Menus_Menu.Controls[0].Width, TLP_Character_Manager_Menus_Menu.Controls[0].Height * 4);
         this.MinimumSize = new Size(550, 400);
         TLP_Character_Manager_Menus.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
      }

      #region Initialization
      private void initialize_screen()
      {
         this.ClientSize = new Size(_CLIENT_WIDTH, _CLIENT_HEIGHT);
         this.MinimumSize = new Size(_CLIENT_WIDTH, _CLIENT_HEIGHT);

         CenterToScreen();
         SetStyle(ControlStyles.ResizeRedraw, true);
      }

      private void initialize_character_manager_screen()
      {
      }

      private void initialize_character_manager_menu()
      {
         TLP_Character_Manager_Menus_Menu.Margin = new Padding(20);
         TLP_Character_Manager_Menus_Menu.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
         // add the characters to the menu
         add_characters_to_character_menu();
      }

      private void add_characters_to_character_menu()
      {

      }
      #endregion

      private void B_Main_CharacterManager_Click(object sender, EventArgs e)
      {
         TLP_Character_Manager.BringToFront();
      }

      private void graphictest()
      {
         using (Graphics g = TLP_Character_Manager_TitleBar.CreateGraphics())
         {
            g.DrawString("Character Manager", new Font("Arial", 13), new SolidBrush(Color.Red), 1, 1);
         }
      }

      private void TLP_Character_Manager_TitleBar_Paint(object sender, PaintEventArgs e)
      {
         graphictest();
      }

      private void TLP_Character_Manager_Menus_Click(object sender, EventArgs e)
      {

      }

      private void draw_line(Object sender, PaintEventArgs e)
      {
         using (Graphics g = TLP_Character_Manager_Menus.CreateGraphics())
         {
            int x = (int)(TLP_Character_Manager_Menus.ColumnStyles[0].Width * .01 * TLP_Character_Manager_Menus.Width);
            int y1 = (int)(0);
            int y2 = (int)(TLP_Character_Manager_Menus.Height + y1);

            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), new Rectangle(x, y1, 10, y2));

            //g.Drawline(new Pen(new SolidBrush(Color.Black)), new Point(x, y1), new Point(x, y2));
         }
      }
   }
}
