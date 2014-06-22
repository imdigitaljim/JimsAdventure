namespace RPG
{
    partial class TitleWindow
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
            this.startGame = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.rpgTitle = new System.Windows.Forms.Label();
            //this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGame.Location = new System.Drawing.Point(12, 12);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(166, 30);
            this.startGame.TabIndex = 14;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.Start_Click);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(12, 48);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(166, 30);
            this.exitButton.TabIndex = 15;
            this.exitButton.Text = "Exit Game";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.Exit_Click);
            // 
            // rpgTitle
            // 
            this.rpgTitle.AutoSize = true;
            this.rpgTitle.BackColor = System.Drawing.Color.Transparent;
            this.rpgTitle.Font = new System.Drawing.Font("Algerian", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpgTitle.ForeColor = System.Drawing.Color.White;
            this.rpgTitle.Location = new System.Drawing.Point(3, 9);
            this.rpgTitle.Name = "rpgTitle";
            this.rpgTitle.Size = new System.Drawing.Size(335, 41);
            this.rpgTitle.TabIndex = 17;
            this.rpgTitle.Text = "Jim\'s Adventure";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.rpgTitle);
            this.panel1.Location = new System.Drawing.Point(99, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 66);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.exitButton);
            this.panel2.Controls.Add(this.startGame);
            this.panel2.Location = new System.Drawing.Point(341, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 88);
            this.panel2.TabIndex = 19;
            // 
            // TitleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::RPG.Properties.Resources.World;
            this.ClientSize = new System.Drawing.Size(544, 415);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Letter Gothic Std", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TitleWindow";
            this.Text = "Jim\'s Adventure";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label rpgTitle;
        //private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

