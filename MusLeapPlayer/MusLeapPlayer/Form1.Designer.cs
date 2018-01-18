namespace MusLeapPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LeapMotion = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Song = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LoadFiles = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // LeapMotion
            // 
            this.LeapMotion.BackColor = System.Drawing.Color.SaddleBrown;
            this.LeapMotion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LeapMotion.BackgroundImage")));
            this.LeapMotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LeapMotion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeapMotion.Font = new System.Drawing.Font("Magneto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeapMotion.Location = new System.Drawing.Point(0, 368);
            this.LeapMotion.Name = "LeapMotion";
            this.LeapMotion.Size = new System.Drawing.Size(193, 85);
            this.LeapMotion.TabIndex = 0;
            this.LeapMotion.Text = "LeapMotion";
            this.LeapMotion.UseVisualStyleBackColor = false;
            this.LeapMotion.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listView1.BackgroundImage")));
            this.listView1.BackgroundImageTiled = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Song,
            this.Path});
            this.listView1.Font = new System.Drawing.Font("Magneto", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.Location = new System.Drawing.Point(0, 68);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(193, 300);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // Song
            // 
            this.Song.Text = "Title";
            this.Song.Width = 101;
            // 
            // Path
            // 
            this.Path.Text = "Path";
            this.Path.Width = 101;
            // 
            // LoadFiles
            // 
            this.LoadFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoadFiles.BackgroundImage")));
            this.LoadFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoadFiles.Font = new System.Drawing.Font("Magneto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadFiles.Location = new System.Drawing.Point(0, 2);
            this.LoadFiles.Name = "LoadFiles";
            this.LoadFiles.Size = new System.Drawing.Size(194, 70);
            this.LoadFiles.TabIndex = 2;
            this.LoadFiles.Text = "Load Files";
            this.LoadFiles.UseVisualStyleBackColor = true;
            this.LoadFiles.Click += new System.EventHandler(this.LoadFiles_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(200, 2);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(855, 450);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 448);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.LoadFiles);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.LeapMotion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LeapMotion;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button LoadFiles;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ColumnHeader Path;
        private System.Windows.Forms.ColumnHeader Song;
    }
}

