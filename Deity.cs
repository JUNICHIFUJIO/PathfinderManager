using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   #region Enumerators
   public enum Enum_Deities
   {
      Aleria,
      Chiuta,
      Eshsalqua,
      Ferrakus,
      Fenris_Kul,
      Gerana,
      Ithreia,
      Kamus,
      Linium,
      Lyvalia,
      Mal,
      Myketa,
      Nemyth_Vaar,
      Neria,
      Nise,
      Paletius,
      Rajuk_Amon_Gore,
      Rolterra,
      Saren,
      Shade,
      Shankhil,
      Tulis,
      Toma_Thule,
      Ul_ul,
      Veiloaria,
      Vortain,
      Yolana
   };
   #endregion

   class Deity
   {
      #region Constructors
      /// <summary>
      /// Create a custom deity.
      /// </summary>
      /// <param name="deity_name"></param>
      /// <param name="alignment"></param>
      /// <param name="domains"></param>
      /// <param name="subdomains"></param>
      /// <param name="favored_weapon"></param>
      /// <param name="favored_animal"></param>
      public Deity(
         string deity_name,
         Alignment alignment,
         ICollection<Domain> domains,
         ICollection<SubDomain> subdomains,
         Weapon favored_weapon,
         string favored_animal
         ){
         this.name = deity_name;
         this.alignment = alignment;
         
         foreach(Domain domain in domains){
            this.domains.Add(domain);
         }
         foreach(SubDomain subdomain in subdomains){
            this.subdomains.Add(subdomain);
         }
         this.favoredWeapon = favored_weapon;
         this.favoredAnimal = favored_animal;
      }

      /// <summary>
      /// Create a deity based off of the official Paizo deities.
      /// </summary>
      /// <param name="deity"></param>
      /// <param name="alignment"></param>
      /// <param name="domains"></param>
      /// <param name="subdomains"></param>
      /// <param name="favored_weapon"></param>
      /// <param name="favored_animal"></param>
      public Deity(Enum_Deities deity, Alignment alignment, ICollection<Domain> domains, ICollection<SubDomain> subdomains, Weapon favored_weapon, string favored_animal) :
         this(deity.ToString(), alignment, domains, subdomains, favored_weapon, favored_animal) { }
      #endregion

      #region Methods
      #endregion

      #region Fields
      private string name;
      private Alignment alignment;
      private List<Domain> domains;
      private List<SubDomain> subdomains;
      private Weapon favoredWeapon;
      private string favoredAnimal;
      #endregion

      #region Properties
      public string Name
      {
         get { return this.name; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Deity: Cannot set name to null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("Deity: Cannot set name to blank value.");
            }
            else
            {
               this.name = value;
            }
         }
      }
      public Alignment Alignment
      {
         get { return this.alignment; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Deity: Cannot set alignment to null value.");
            }
            else
            {
               // trigger goodness alignment change event if appropriate
               if (value.Goodness != this.alignment.Goodness)
               {
                  this.alignment.Goodness = value.Goodness;
               }
               // trigger lawfulness alignment change event if appropriate
               if (value.Lawfulness != this.alignment.Lawfulness)
               {
                  this.alignment.Lawfulness = value.Lawfulness;
               }
               // replace the alignment object
               this.alignment = value;
               // ERROR TESTING
               // dispose of the old alignment object
            }
         }
      }
      public List<Domain> Domains
      {
         get
         {
            return this.domains;
         }
      }
      public List<SubDomain> Subdomains
      {
         get { return this.subdomains; }
      }
      public Weapon FavoredWeapon
      {
         get { return this.favoredWeapon; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Deity: Cannot set deity favored weapon to null value.");
            }
            else
            {
               this.favoredWeapon = value;
               // ERROR TESTING
            }
         }
      }
      public string FavoredAnimal
      {
         get { return this.favoredAnimal; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Deity: Cannot set favored animal to null value.");
            }
            else if (value.Length < 1)
            {
               throw new ArgumentException("Deity: Cannot set favored animal to blank value.");
            }
            else
            {
               this.favoredAnimal = value;
            }
         }
      }
      #endregion
   }
}
