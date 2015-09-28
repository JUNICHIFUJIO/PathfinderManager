namespace PathfinderManager
{
   partial class W_Pathfinder_Manager
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.P_Character_Manager = new System.Windows.Forms.Panel();
         this.P_Main = new System.Windows.Forms.TableLayoutPanel();
         this.B_Main_CharacterManager = new System.Windows.Forms.Button();
         this.B_Main_Bestiary = new System.Windows.Forms.Button();
         this.B_Main_Classes = new System.Windows.Forms.Button();
         this.B_Main_Skills = new System.Windows.Forms.Button();
         this.B_Main_Feats = new System.Windows.Forms.Button();
         this.button6 = new System.Windows.Forms.Button();
         this.TLP_Character_Manager = new System.Windows.Forms.TableLayoutPanel();
         this.TLP_Character_Manager_TitleBar = new System.Windows.Forms.TableLayoutPanel();
         this.TLP_Character_Manager_Menus = new System.Windows.Forms.TableLayoutPanel();
         this.TLP_Character_Manager_Menus_Menu = new System.Windows.Forms.TableLayoutPanel();
         this.P_Main.SuspendLayout();
         this.TLP_Character_Manager.SuspendLayout();
         this.TLP_Character_Manager_Menus.SuspendLayout();
         this.SuspendLayout();
         // 
         // P_Character_Manager
         // 
         this.P_Character_Manager.Dock = System.Windows.Forms.DockStyle.Fill;
         this.P_Character_Manager.Location = new System.Drawing.Point(0, 0);
         this.P_Character_Manager.Name = "P_Character_Manager";
         this.P_Character_Manager.Size = new System.Drawing.Size(556, 369);
         this.P_Character_Manager.TabIndex = 1;
         // 
         // P_Main
         // 
         this.P_Main.AutoSize = true;
         this.P_Main.ColumnCount = 2;
         this.P_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.P_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.P_Main.Controls.Add(this.B_Main_CharacterManager, 0, 0);
         this.P_Main.Controls.Add(this.B_Main_Bestiary, 1, 0);
         this.P_Main.Controls.Add(this.B_Main_Classes, 0, 1);
         this.P_Main.Controls.Add(this.B_Main_Skills, 1, 1);
         this.P_Main.Controls.Add(this.B_Main_Feats, 0, 2);
         this.P_Main.Controls.Add(this.button6, 1, 2);
         this.P_Main.Dock = System.Windows.Forms.DockStyle.Fill;
         this.P_Main.Location = new System.Drawing.Point(0, 0);
         this.P_Main.Name = "P_Main";
         this.P_Main.RowCount = 3;
         this.P_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
         this.P_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
         this.P_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
         this.P_Main.Size = new System.Drawing.Size(556, 369);
         this.P_Main.TabIndex = 2;
         // 
         // B_Main_CharacterManager
         // 
         this.B_Main_CharacterManager.AutoSize = true;
         this.B_Main_CharacterManager.Dock = System.Windows.Forms.DockStyle.Fill;
         this.B_Main_CharacterManager.Location = new System.Drawing.Point(21, 21);
         this.B_Main_CharacterManager.Margin = new System.Windows.Forms.Padding(21);
         this.B_Main_CharacterManager.Name = "B_Main_CharacterManager";
         this.B_Main_CharacterManager.Size = new System.Drawing.Size(236, 105);
         this.B_Main_CharacterManager.TabIndex = 0;
         this.B_Main_CharacterManager.Text = "Character Manager";
         this.B_Main_CharacterManager.UseVisualStyleBackColor = true;
         this.B_Main_CharacterManager.Click += new System.EventHandler(this.B_Main_CharacterManager_Click);
         // 
         // B_Main_Bestiary
         // 
         this.B_Main_Bestiary.AutoSize = true;
         this.B_Main_Bestiary.Dock = System.Windows.Forms.DockStyle.Fill;
         this.B_Main_Bestiary.Location = new System.Drawing.Point(299, 21);
         this.B_Main_Bestiary.Margin = new System.Windows.Forms.Padding(21);
         this.B_Main_Bestiary.Name = "B_Main_Bestiary";
         this.B_Main_Bestiary.Size = new System.Drawing.Size(236, 105);
         this.B_Main_Bestiary.TabIndex = 1;
         this.B_Main_Bestiary.Text = "Bestiary";
         this.B_Main_Bestiary.UseVisualStyleBackColor = true;
         // 
         // B_Main_Classes
         // 
         this.B_Main_Classes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.B_Main_Classes.Location = new System.Drawing.Point(20, 167);
         this.B_Main_Classes.Margin = new System.Windows.Forms.Padding(20);
         this.B_Main_Classes.Name = "B_Main_Classes";
         this.B_Main_Classes.Size = new System.Drawing.Size(238, 70);
         this.B_Main_Classes.TabIndex = 2;
         this.B_Main_Classes.Text = "Classes";
         this.B_Main_Classes.UseVisualStyleBackColor = true;
         // 
         // B_Main_Skills
         // 
         this.B_Main_Skills.Dock = System.Windows.Forms.DockStyle.Fill;
         this.B_Main_Skills.Location = new System.Drawing.Point(298, 167);
         this.B_Main_Skills.Margin = new System.Windows.Forms.Padding(20);
         this.B_Main_Skills.Name = "B_Main_Skills";
         this.B_Main_Skills.Size = new System.Drawing.Size(238, 70);
         this.B_Main_Skills.TabIndex = 3;
         this.B_Main_Skills.Text = "Skills";
         this.B_Main_Skills.UseVisualStyleBackColor = true;
         // 
         // B_Main_Feats
         // 
         this.B_Main_Feats.Dock = System.Windows.Forms.DockStyle.Fill;
         this.B_Main_Feats.Location = new System.Drawing.Point(20, 277);
         this.B_Main_Feats.Margin = new System.Windows.Forms.Padding(20);
         this.B_Main_Feats.Name = "B_Main_Feats";
         this.B_Main_Feats.Size = new System.Drawing.Size(238, 72);
         this.B_Main_Feats.TabIndex = 4;
         this.B_Main_Feats.Text = "Feats";
         this.B_Main_Feats.UseVisualStyleBackColor = true;
         // 
         // button6
         // 
         this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button6.Location = new System.Drawing.Point(298, 277);
         this.button6.Margin = new System.Windows.Forms.Padding(20);
         this.button6.Name = "button6";
         this.button6.Size = new System.Drawing.Size(238, 72);
         this.button6.TabIndex = 5;
         this.button6.Text = "Character Generator";
         this.button6.UseVisualStyleBackColor = true;
         // 
         // TLP_Character_Manager
         // 
         this.TLP_Character_Manager.ColumnCount = 1;
         this.TLP_Character_Manager.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.TLP_Character_Manager.Controls.Add(this.TLP_Character_Manager_TitleBar, 0, 0);
         this.TLP_Character_Manager.Controls.Add(this.TLP_Character_Manager_Menus, 0, 1);
         this.TLP_Character_Manager.Dock = System.Windows.Forms.DockStyle.Fill;
         this.TLP_Character_Manager.Location = new System.Drawing.Point(0, 0);
         this.TLP_Character_Manager.Name = "TLP_Character_Manager";
         this.TLP_Character_Manager.RowCount = 2;
         this.TLP_Character_Manager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
         this.TLP_Character_Manager.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
         this.TLP_Character_Manager.Size = new System.Drawing.Size(556, 369);
         this.TLP_Character_Manager.TabIndex = 3;
         // 
         // TLP_Character_Manager_TitleBar
         // 
         this.TLP_Character_Manager_TitleBar.ColumnCount = 2;
         this.TLP_Character_Manager_TitleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
         this.TLP_Character_Manager_TitleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
         this.TLP_Character_Manager_TitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
         this.TLP_Character_Manager_TitleBar.Location = new System.Drawing.Point(3, 3);
         this.TLP_Character_Manager_TitleBar.Name = "TLP_Character_Manager_TitleBar";
         this.TLP_Character_Manager_TitleBar.RowCount = 1;
         this.TLP_Character_Manager_TitleBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.TLP_Character_Manager_TitleBar.Size = new System.Drawing.Size(550, 49);
         this.TLP_Character_Manager_TitleBar.TabIndex = 0;
         this.TLP_Character_Manager_TitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.TLP_Character_Manager_TitleBar_Paint);
         // 
         // TLP_Character_Manager_Menus
         // 
         this.TLP_Character_Manager_Menus.ColumnCount = 2;
         this.TLP_Character_Manager_Menus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
         this.TLP_Character_Manager_Menus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
         this.TLP_Character_Manager_Menus.Controls.Add(this.TLP_Character_Manager_Menus_Menu, 0, 0);
         this.TLP_Character_Manager_Menus.Dock = System.Windows.Forms.DockStyle.Fill;
         this.TLP_Character_Manager_Menus.Location = new System.Drawing.Point(3, 58);
         this.TLP_Character_Manager_Menus.Name = "TLP_Character_Manager_Menus";
         this.TLP_Character_Manager_Menus.RowCount = 1;
         this.TLP_Character_Manager_Menus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.TLP_Character_Manager_Menus.Size = new System.Drawing.Size(550, 308);
         this.TLP_Character_Manager_Menus.TabIndex = 1;
         this.TLP_Character_Manager_Menus.Click += new System.EventHandler(this.TLP_Character_Manager_Menus_Click);
         // 
         // TLP_Character_Manager_Menus_Menu
         // 
         this.TLP_Character_Manager_Menus_Menu.AutoScroll = true;
         this.TLP_Character_Manager_Menus_Menu.BackColor = System.Drawing.Color.White;
         this.TLP_Character_Manager_Menus_Menu.ColumnCount = 1;
         this.TLP_Character_Manager_Menus_Menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.TLP_Character_Manager_Menus_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
         this.TLP_Character_Manager_Menus_Menu.Location = new System.Drawing.Point(15, 15);
         this.TLP_Character_Manager_Menus_Menu.Margin = new System.Windows.Forms.Padding(15);
         this.TLP_Character_Manager_Menus_Menu.Name = "TLP_Character_Manager_Menus_Menu";
         this.TLP_Character_Manager_Menus_Menu.RowCount = 4;
         this.TLP_Character_Manager_Menus_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.TLP_Character_Manager_Menus_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.TLP_Character_Manager_Menus_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.TLP_Character_Manager_Menus_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.TLP_Character_Manager_Menus_Menu.Size = new System.Drawing.Size(327, 278);
         this.TLP_Character_Manager_Menus_Menu.TabIndex = 0;
         // 
         // W_Pathfinder_Manager
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(556, 369);
         this.Controls.Add(this.TLP_Character_Manager);
         this.Controls.Add(this.P_Main);
         this.Controls.Add(this.P_Character_Manager);
         this.Name = "W_Pathfinder_Manager";
         this.Text = "Pathfinder Manager";
         this.P_Main.ResumeLayout(false);
         this.P_Main.PerformLayout();
         this.TLP_Character_Manager.ResumeLayout(false);
         this.TLP_Character_Manager_Menus.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel P_Character_Manager;
      private System.Windows.Forms.TableLayoutPanel P_Main;
      private System.Windows.Forms.Button B_Main_CharacterManager;
      private System.Windows.Forms.Button B_Main_Bestiary;
      private System.Windows.Forms.Button B_Main_Classes;
      private System.Windows.Forms.Button B_Main_Skills;
      private System.Windows.Forms.Button B_Main_Feats;
      private System.Windows.Forms.Button button6;
      private System.Windows.Forms.TableLayoutPanel TLP_Character_Manager;
      private System.Windows.Forms.TableLayoutPanel TLP_Character_Manager_TitleBar;
      private System.Windows.Forms.TableLayoutPanel TLP_Character_Manager_Menus;
      private System.Windows.Forms.TableLayoutPanel TLP_Character_Manager_Menus_Menu;
   }
}

