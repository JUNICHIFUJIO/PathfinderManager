using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   #region Enumerators
   public enum Enum_Races
   {
      // Standard Races
      Dwarf,
      Elf,
      Gnome,
      Half_Elf,
      Halfling,
      Half_Orc,
      Human,

      // Featured Paizo Races
      Aasimar,
      Catfolk,
      Dhampir,
      Drow,
      Fetchling,
      Goblin,
      Hobgoblin,
      Ifrit,
      Kobold,
      Orc,
      Oread,
      Ratfolk,
      Sylph,
      Tengu,
      Tiefling,
      Undine,

      // Uncommon Paizo Races
      Changeling,
      Duergar,
      Gillman,
      Grippli,
      Kitsune,
      Merfolk,
      Nagaji,
      Samsaran,
      Strix,
      Suli,
      Svirfneblin,
      Vanara,
      Vishkanya,
      Wayang,

      // Other Paizo Races
      Android,
      Ghoran,
      Monkey_Goblin,
      Lashunta,
      Wyvaran,

      // Customizable Race
      Custom
   };

   public enum Enum_Creature_Subtypes
   {
      Adlet,
      Aeon,
      Agathion,
      Air,
      Angel,
      Aquatic,
      Archon,
      Asura,
      Augmented,
      Azata,
      Behemoth,
      Catfolk,
      Chaotic,
      Clockwork,
      Cold,
      Colossus,
      Daemon,
      Dark_Folk,
      Demodand,
      Demon,
      Devil,
      Div,
      Dwarf,
      Earth,
      Elemental,
      Elf,
      Evil,
      Extraplanar,
      Fire,
      Giant,
      Gnome,
      Goblinoid,
      Godspawn,
      Good,
      Great_Old_One,
      Halfling,
      Herald,
      Human,
      Incorporeal,
      Inevitable,
      Kaiju,
      Kami,
      Kasatha,
      Kitsune,
      Kyton,
      Lawful,
      Leshy,
      Mythic,
      Native,
      Nightshade,
      Oni,
      Orc,
      Protean,
      Psychopomp,
      Qlippoth,
      Rakshasa,
      Ratfolk,
      Reptilian,
      Robot,
      Samsaran,
      Sasquatch,
      Shapechanger,
      Swarm,
      Troop,
      Udaeus,
      Unbreathing,
      Vanara,
      Vishkanya,
      Water
   };

   public enum Enum_Creature_Types
   {
      Aberration,
      Animal,
      Construct,
      Dragon,
      Fey,
      Humanoid,
      Magical_Beast,
      Monstrous_Humanoid,
      Ooze,
      Outsider,
      Plant,
      Undead,
      Vermin
   };

   public enum Enum_Languages
   {
      Aboleth,
      Abyssal,
      Aklo,
      Aquan,
      Auran,
      Boggard,
      Celestial,
      Common,
      Cyclops,
      Dark_Folk,
      Draconic,
      Drow_Sign_Language,
      Druidic,
      Dwarven,
      Dziriak,
      Elven,
      Giant,
      Gnoll,
      Gnome,
      Goblin,
      Grippli,
      Halfling,
      Ignan,
      Infernal,
      Necril,
      Orc,
      Protean,
      Sphinx,
      Sylvan,
      Tengu,
      Terran,
      Treant,
      Undercommon,
      Vegepygmy
   };

   public enum Enum_Special_Abilities
   {
      Blindsight,
      Blindsense,
      Channel_Resistance,
      Charm_and_Compulsion,
      Damage_Reduction,
      Darkvision,
      Death_Attacks,
      Energy_Drain_and_Negative_Levels,
      Energy_Immunity_and_Vulnerability,
      Energy_Resistance,
      Ethereal,
      Fear,
      Invisibility,
      Low_Light_Vision,
      Paralysis,
      Scent,
      Spell_Resistance
   };

   public enum Enum_Senses
   {
      Darkvision,
      Superior_Darkvision,
      Light_Sensitivity,
      Low_Light_Vision,
   };

   public enum Enum_Defensive_Racial_Traits
   {
      AC_Bonus,
      Saving_Throw_Bonus,
      CMD_Bonus,
      CMB_Bonus,
      Status_Effect_Immunities,
      Elemental_Immunity,
      Defensive_Training,
      Illusion_Resistance,
      Fearless,
      Lucky,
      Level_Drain_Resistance,
      Spell_Resistance,
      Energy_Resistance,
      Extra_Armor,
      Legless,
      Hard_To_Kill, // my own creation
      Suspicious,
      Altered_Movespeed,

   };

   public enum Enum_Offensive_Racial_Traits
   {
      Attack_Bonus,
      Weapon_Familiarity,
      Hatred,
      Ferocity,
      Poison_Familiarity,
      Swarming,
      Natural_Weapon
   };
   #endregion

   class Race
   {
      #region Constructors
      // non-custom race
      public Race(Enum_Races race,
         Enum_Size_Categories creature_size, 
         Enum_Creature_Types creature_type, 
         List<Enum_Creature_Subtypes> creature_subtypes, 
         int base_movespeed,
         List<Enum_Languages> starting_languages, 
         List<Enum_Special_Abilities> special_abilities, 
         List<Enum_Senses> innate_senses, 
         List<Enum_Defensive_Racial_Traits> defensive_traits, 
         List<Enum_Offensive_Racial_Traits> offensive_traits)
      {
         // racial identifier
         this.race = race;
         // name
         if (this.race == Enum_Races.Custom)
         {
            this.name = "Custom Race";
         }
         else
         {
            this.name = EnumHandler.ToString(race.ToString());
         }
         // size class
         this.size = creature_size;
         // creature type
         this.creatureType = creature_type;
         // creature subtypes
         this.creatureSubTypes = new List<Enum_Creature_Subtypes>();
         foreach (Enum_Creature_Subtypes subtype in creature_subtypes)
         {
            this.creatureSubTypes.Add(subtype);
         }
         // move speed
         this.baseMoveSpeed = base_movespeed;
         // starting languages
         this.startingLanguages = new List<Enum_Languages>();
         foreach (Enum_Languages language in starting_languages)
         {
            this.startingLanguages.Add(language);
         }
         // special abilities
         this.specialAbilities = new List<Enum_Special_Abilities>();
         foreach (Enum_Special_Abilities ability in special_abilities)
         {
            this.specialAbilities.Add(ability);
         }
         // senses
         this.senses = new List<Enum_Senses>();
         foreach (Enum_Senses sense in innate_senses)
         {
            this.senses.Add(sense);
         }
         // defensive traits
         this.defensiveTraits = new List<Enum_Defensive_Racial_Traits>();
         foreach (Enum_Defensive_Racial_Traits trait in defensive_traits)
         {
            this.defensiveTraits.Add(trait);
         }
         // offensive traits
         this.offensiveTraits = new List<Enum_Offensive_Racial_Traits>();
         foreach (Enum_Offensive_Racial_Traits trait in offensive_traits)
         {
            this.offensiveTraits.Add(trait);
         }
      }

      /// <summary>
      /// Create a custom race.
      /// </summary>
      /// <param name="custom_race_name"></param>
      /// <param name="creature_size"></param>
      /// <param name="creature_type"></param>
      /// <param name="creature_subtypes"></param>
      /// <param name="base_movespeed"></param>
      /// <param name="starting_languages"></param>
      /// <param name="special_abilities"></param>
      /// <param name="innate_senses"></param>
      /// <param name="defensive_traits"></param>
      /// <param name="offensive_traits"></param>
      public Race(string custom_race_name,
         Enum_Size_Categories creature_size,
         Enum_Creature_Types creature_type,
         List<Enum_Creature_Subtypes> creature_subtypes,
         int base_movespeed,
         List<Enum_Languages> starting_languages,
         List<Enum_Special_Abilities> special_abilities,
         List<Enum_Senses> innate_senses,
         List<Enum_Defensive_Racial_Traits> defensive_traits,
         List<Enum_Offensive_Racial_Traits> offensive_traits) :
         this(Enum_Races.Custom, creature_size, creature_type, creature_subtypes, base_movespeed, starting_languages, special_abilities, innate_senses, defensive_traits, offensive_traits)
      {
         this.name = custom_race_name;
      }
      #endregion

      #region Methods
      public void AddCreatureSubType(Enum_Creature_Subtypes subtype)
      {
         if (!this.creatureSubTypes.Contains(subtype))
         {
            this.creatureSubTypes.Add(subtype);
         }
      }
      
      public void AddStartingLanguage(Enum_Languages language)
      {
         if (!this.startingLanguages.Contains(language))
         {
            this.startingLanguages.Add(language);
         }
      }

      public void AddSpecialAbility(Enum_Special_Abilities ability)
      {
         if (!this.specialAbilities.Contains(ability))
         {
            this.specialAbilities.Add(ability);
         }
      }

      public void AddSense(Enum_Senses sense){
         if(!this.senses.Contains(sense)){
            this.senses.Add(sense);
         }
      }

      public void AddDefensiveTrait(Enum_Defensive_Racial_Traits trait){
         if(!this.defensiveTraits.Contains(trait)){
            this.defensiveTraits.Add(trait);
         }
      }

      public void AddOffensiveTrait(Enum_Offensive_Racial_Traits trait){
         if(!this.offensiveTraits.Contains(trait)){
            this.offensiveTraits.Add(trait);
         }
      }
      #endregion

      #region Fields
      private Enum_Races race;
      private string name;
      private Enum_Size_Categories size;
      private Enum_Creature_Types creatureType;
      private List<Enum_Creature_Subtypes> creatureSubTypes;
      private int baseMoveSpeed;
      private List<Enum_Languages> startingLanguages;
      List<Enum_Special_Abilities> specialAbilities;
      List<Enum_Senses> senses;
      List<Enum_Defensive_Racial_Traits> defensiveTraits;
      List<Enum_Offensive_Racial_Traits> offensiveTraits;

      // racial feats
      #endregion

      #region Properties
      public Enum_Races Race
      {
         get { return this.race; }
      }
      public string RaceName
      {
         get { return this.name; }
         set
         {
            if (this.race == Enum_Races.Custom)
            {
               if (value == null)
               {
                  throw new ArgumentNullException("Race: Cannot set race name to a null value.");
               }
               else if (value.Length < 1)
               {
                  throw new ArgumentException("Race: Cannot set race name to a blank value.");
               }
               else
               {
                  this.name = value;
               }
            }
            else
            {
               throw new InvalidOperationException("Race: Cannot alter the race's name of a preset race.");
            }
         }
      }
      public Enum_Size_Categories Size
      {
         get { return this.size; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Race: Racial size cannot be set to a null value.");
            }
            else
            {
               this.size = value;
            }
         }
      }
      public Enum_Creature_Types CreatureType
      {
         get { return this.creatureType; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Race: Cannot set creature type to null value.");
            }
            else
            {
               this.creatureType = value;
            }
         }
      }
      public List<Enum_Creature_Subtypes> CreatureSubTypes
      {
         get { return this.creatureSubTypes; }
      }
      public int BaseMoveSpeed
      {
         get { return this.baseMoveSpeed; }
         set { this.baseMoveSpeed = value; }
      }
      public List<Enum_Languages> StartingLanguages
      {
         get { return this.startingLanguages; }
      }
      public List<Enum_Special_Abilities> SpecialAbilities
      {
         get { return this.specialAbilities; }
      }
      public List<Enum_Senses> Senses
      {
         get { return this.senses; }
      }
      public List<Enum_Defensive_Racial_Traits> DefensiveTraits
      {
         get { return this.defensiveTraits; }
      }
      public List<Enum_Offensive_Racial_Traits> OffensiveTraits
      {
         get { return this.offensiveTraits; }
      }
      #endregion
   }
}
