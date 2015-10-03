using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderManager
{
   #region Event Delegates
   public delegate void GoodnessAlignmentChangedHandler(object sender, GoodnessChangedEventArgs e);
   public delegate void LawfulnessAlignmentChangedHandler(object sender, LawfulnessChangedEventArgs e);
   #endregion

   #region Enumerators
   public enum Enum_Goodness_Alignments
   {
      Good,
      Neutral,
      Evil
   };

   public enum Enum_Lawfulness_Alignments
   {
      Lawful,
      Neutral,
      Chaotic
   };
   #endregion

   class Alignment
   {
      #region Events
      public event GoodnessAlignmentChangedHandler GoodnessAlignmentChanged;
      public event LawfulnessAlignmentChangedHandler LawfulnessAlignmentChanged;

      protected virtual void OnGoodnessAlignmentChanged(GoodnessChangedEventArgs e)
      {
         if (GoodnessAlignmentChanged != null)
         {
            GoodnessAlignmentChanged(this, e);
         }
      }

      protected virtual void OnLawfulnessAlignmentChanged(LawfulnessChangedEventArgs e)
      {
         if (LawfulnessAlignmentChanged != null)
         {
            LawfulnessAlignmentChanged(this, e);
         }
      }
      #endregion

      #region Constructors
      public Alignment(Enum_Goodness_Alignments goodness, Enum_Lawfulness_Alignments lawfulness)
      {
         this.goodness = goodness;
         this.lawfulness = lawfulness;
      }

      public Alignment() :
         this(Enum_Goodness_Alignments.Neutral, Enum_Lawfulness_Alignments.Neutral) { }
      #endregion

      #region Methods
      new public string ToString()
      {
         if(this.goodness == Enum_Goodness_Alignments.Neutral
            && this.lawfulness == Enum_Lawfulness_Alignments.Neutral)
         {
            return "True Neutral";
         }

         StringBuilder builder = new StringBuilder();
         builder.Append(this.lawfulness.ToString());
         builder.Append(' ');
         builder.Append(this.goodness.ToString());

         return builder.ToString();
      }
      #endregion

      #region Fields
      private Enum_Goodness_Alignments goodness;
      private Enum_Lawfulness_Alignments lawfulness;
      #endregion

      #region Properties
      public Enum_Goodness_Alignments Goodness
      {
         get { return this.goodness; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Alignment: Cannot set goodness to null value.");
            }
            else
            {
               if (value != this.goodness)
               {
                  Enum_Goodness_Alignments old_alignment = this.goodness;
                  this.goodness = value;
                  OnGoodnessAlignmentChanged(new GoodnessChangedEventArgs(this.goodness, old_alignment));
               }
            }
         }
      }
      public Enum_Lawfulness_Alignments Lawfulness
      {
         get { return this.lawfulness; }
         set
         {
            if (value == null)
            {
               throw new ArgumentNullException("Alignment: Cannot set lawfulness to null value.");
            }
            else
            {
               Enum_Lawfulness_Alignments old_alignment = this.lawfulness;
               this.lawfulness = value;
               OnLawfulnessAlignmentChanged(new LawfulnessChangedEventArgs(this.lawfulness, old_alignment));
            }
         }
      }
      #endregion
   }

   public class GoodnessChangedEventArgs : EventArgs
   {
      #region Constructors
      public GoodnessChangedEventArgs(Enum_Goodness_Alignments new_alignment, Enum_Goodness_Alignments old_alignment)
      {
         this.newAlignment = new_alignment;
         this.oldAlignment = old_alignment;
      }
      #endregion

      #region Fields
      private Enum_Goodness_Alignments newAlignment;
      private Enum_Goodness_Alignments oldAlignment;
      #endregion

      #region Properties
      public Enum_Goodness_Alignments NewAlignment
      {
         get { return this.newAlignment; }
      }
      public Enum_Goodness_Alignments OldAlignment
      {
         get { return this.oldAlignment; }
      }
      #endregion
   }

   public class LawfulnessChangedEventArgs : EventArgs
   {
      #region Constructors
      public LawfulnessChangedEventArgs(Enum_Lawfulness_Alignments new_alignment, Enum_Lawfulness_Alignments old_alignment)
      {
         this.newAlignment = new_alignment;
         this.oldAlignment = old_alignment;
      }
      #endregion

      #region Fields
      private Enum_Lawfulness_Alignments newAlignment;
      private Enum_Lawfulness_Alignments oldAlignment;
      #endregion

      #region Properties
      public Enum_Lawfulness_Alignments NewAlignment
      {
         get { return this.newAlignment; }
      }
      public Enum_Lawfulness_Alignments OldAlignment
      {
         get { return this.oldAlignment; }
      }
      #endregion
   }
}
