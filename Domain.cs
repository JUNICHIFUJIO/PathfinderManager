using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   #region Enumerators
   public enum Enum_Domains
   {
      Air,
      Animal,
      Artifice,
      Chaos,
      Charm,
      Community,
      Darkness,
      Death,
      Destruction,
      Earth,
      Evil,
      Fire,
      Glory,
      Good,
      Healing,
      Knowledge,
      Law,
      Liberation,
      Luck,
      Madness,
      Magic,
      Nobility,
      Plant,
      Protection,
      Repose,
      Ruins,
      Rune,
      Scalykind,
      Strength,
      Sun,
      Travel,
      Trickery,
      Vermin,
      Void,
      War,
      Water,
      Weather
   };
   #endregion

   class Domain
   {
      #region Constructors
      public Domain(string name, ICollection<DomainPower> domain_powers)
      {
         this.Name = name;

         foreach (DomainPower power in domain_powers)
         {
            this.domainPowers.Add(power);
         }
      }
      #endregion

      #region Fields
      private string name;
      private List<DomainPower> domainPowers;
      // ERROR TESTING // need to implement spells
      // private List<Spell> domainSpells;
      #endregion

      #region Properties
      public string Name
      {
         get { return this.name; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Domain: Cannot set domain name to null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("Domain: Cannot set domain name to blank value.");
            }
            else
            {
               this.name = value;
            }
         }
      }
      public List<DomainPower> DomainPowers
      {
         get { return this.domainPowers; }
      }
      #endregion
   }

   public class DomainPower
   {
      #region Constructors
      public DomainPower(string name, string description, int dc, Enum_Special_Abilities_Categories special_ability_category)
      {
         this.Name = name;
         this.Description = description;
         this.DC = dc;
         this.AbilityCategory = special_ability_category;
      }
      #endregion

      #region Fields
      private string name;
      private string description;
      private uint dc;
      private Enum_Special_Abilities_Categories abilityCategory;
      #endregion

      #region Properties
      public string Name
      {
         get { return this.name; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("DomainPower: Cannot set domain name to null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("DomainPower: Cannot set domain name to blank value.");
            }
            else
            {
               this.name = value;
            }
         }
      }
      public string Description
      {
         get { return this.description; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("DomainPower: Cannot set domain description to null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("DomainPower: Cannot set domain description to blank value.");
            }
            else
            {
               this.description = value;
            }
         }
      }
      public int DC
      {
         get { return (int)this.dc; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("DomainPower: Cannot set DC to null value.");
            }
            else if (value < 0)
            {
               throw new ArgumentException("DomainPower: Cannot set negative DC.");
            }
            else
            {
               this.dc = (uint)value;
            }
         }
      }
      public Enum_Special_Abilities_Categories AbilityCategory
      {
         get { return this.abilityCategory; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("DomainPower: Cannot set special ability category to null value.");
            }
            else
            {
               this.abilityCategory = value;
            }
         }
      }
      #endregion
   }

   #region Enumerators
   public enum Enum_Subdomains
   {

   };
   #endregion

   public class SubDomain
   {
      #region Constructors
      public SubDomain(string name, Enum_Domains associated_domain, DomainPower replacement_domain_power)
      {
         this.Name = name;
         this.AssociatedDomain = associated_domain;
         this.replacementPower = replacement_domain_power;
      }
      #endregion

      #region Methods
      #endregion

      #region Fields
      private string name;
      private Enum_Domains associatedDomain;
      private DomainPower replacementPower;
      //private List<Spell> replacementSpells;
      // ERROR TESTING
      // private List<Deity> possible_deities;
      #endregion

      #region Properties
      public string Name
      {
         get { return this.name; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("SubDomain: Cannot set name to null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("SubDomain: Cannot set name to blank value.");
            }
            else
            {
               this.name = value;
            }
         }
      }
      public Enum_Domains AssociatedDomain
      {
         get { return this.associatedDomain; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("SubDomain: Cannot set associated domain to null value.");
            }
            else
            {
               this.associatedDomain = value;
            }
         }
      }
      public DomainPower ReplacementPower
      {
         get { return this.replacementPower; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("SubDomain: Cannot set replacement power to null value.");
            }
            else
            {
               this.replacementPower = value;
            }
         }
      }
      #endregion
   }
}
