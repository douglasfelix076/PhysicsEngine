namespace Physics
{
    partial class Form1
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
            this.ButtonCreateCircle = new System.Windows.Forms.Button();
            this.TextBoxSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearAllButton = new System.Windows.Forms.Button();
            this.ButtonCreateBox = new System.Windows.Forms.Button();
            this.Canvas = new BufferedPanel();
            this.BodyCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCreateCircle
            // 
            this.ButtonCreateCircle.Location = new System.Drawing.Point(15, 35);
            this.ButtonCreateCircle.Name = "ButtonCreateCircle";
            this.ButtonCreateCircle.Size = new System.Drawing.Size(96, 23);
            this.ButtonCreateCircle.TabIndex = 0;
            this.ButtonCreateCircle.Text = "Criar circulo";
            this.ButtonCreateCircle.UseVisualStyleBackColor = true;
            this.ButtonCreateCircle.Click += new System.EventHandler(this.ButtonCreateCircle_Click);
            // 
            // TextBoxSize
            // 
            this.TextBoxSize.Location = new System.Drawing.Point(63, 9);
            this.TextBoxSize.Name = "TextBoxSize";
            this.TextBoxSize.Size = new System.Drawing.Size(48, 20);
            this.TextBoxSize.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Diametro";
            // 
            // ClearAllButton
            // 
            this.ClearAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearAllButton.Location = new System.Drawing.Point(12, 513);
            this.ClearAllButton.Name = "ClearAllButton";
            this.ClearAllButton.Size = new System.Drawing.Size(96, 23);
            this.ClearAllButton.TabIndex = 4;
            this.ClearAllButton.Text = "Apagar tudo";
            this.ClearAllButton.UseVisualStyleBackColor = true;
            this.ClearAllButton.Click += new System.EventHandler(this.ButtonClearAll_Click);
            // 
            // ButtonCreateBox
            // 
            this.ButtonCreateBox.Enabled = false;
            this.ButtonCreateBox.Location = new System.Drawing.Point(15, 64);
            this.ButtonCreateBox.Name = "ButtonCreateBox";
            this.ButtonCreateBox.Size = new System.Drawing.Size(96, 23);
            this.ButtonCreateBox.TabIndex = 5;
            this.ButtonCreateBox.Text = "Criar caixa";
            this.ButtonCreateBox.UseVisualStyleBackColor = true;
            this.ButtonCreateBox.Click += new System.EventHandler(this.ButtonCreateBox_Click);
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.Location = new System.Drawing.Point(117, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(512, 524);
            this.Canvas.TabIndex = 1;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // BodyCount
            // 
            this.BodyCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BodyCount.AutoSize = true;
            this.BodyCount.Location = new System.Drawing.Point(15, 497);
            this.BodyCount.Name = "BodyCount";
            this.BodyCount.Size = new System.Drawing.Size(74, 13);
            this.BodyCount.TabIndex = 6;
            this.BodyCount.Text = "Nº Objetos:  X";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 548);
            this.Controls.Add(this.BodyCount);
            this.Controls.Add(this.ButtonCreateCircle);
            this.Controls.Add(this.ClearAllButton);
            this.Controls.Add(this.ButtonCreateBox);
            this.Controls.Add(this.TextBoxSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Canvas);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCreateCircle;
        private BufferedPanel Canvas;
        private System.Windows.Forms.TextBox TextBoxSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearAllButton;
        private System.Windows.Forms.Button ButtonCreateBox;
        private System.Windows.Forms.Label BodyCount;
    }
}

