namespace PikPokTest {
    partial class PikPokTest {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.Load = new System.Windows.Forms.Button();
            this.MovementTimer = new System.Windows.Forms.Timer(this.components);
            this.Animate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.frameRateControl = new System.Windows.Forms.NumericUpDown();
            this.animationComboBox = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateControl)).BeginInit();
            this.SuspendLayout();
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(12, 27);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(75, 23);
            this.Load.TabIndex = 0;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // MovementTimer
            // 
            this.MovementTimer.Enabled = true;
            this.MovementTimer.Tick += new System.EventHandler(this.MovementTimer_Tick);
            // 
            // Animate
            // 
            this.Animate.Location = new System.Drawing.Point(94, 27);
            this.Animate.Name = "Animate";
            this.Animate.Size = new System.Drawing.Size(75, 23);
            this.Animate.TabIndex = 1;
            this.Animate.Text = "Animate";
            this.Animate.UseVisualStyleBackColor = true;
            this.Animate.Click += new System.EventHandler(this.Animate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Framerate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Animation";
            // 
            // frameRateControl
            // 
            this.frameRateControl.Location = new System.Drawing.Point(192, 29);
            this.frameRateControl.Maximum = new decimal(new int[] {
            144,
            0,
            0,
            0});
            this.frameRateControl.Name = "frameRateControl";
            this.frameRateControl.Size = new System.Drawing.Size(120, 20);
            this.frameRateControl.TabIndex = 7;
            this.frameRateControl.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.frameRateControl.ValueChanged += new System.EventHandler(this.frameRateControl_ValueChanged);
            // 
            // animationComboBox
            // 
            this.animationComboBox.FormattingEnabled = true;
            this.animationComboBox.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical",
            "Box",
            "Circular"});
            this.animationComboBox.Location = new System.Drawing.Point(333, 28);
            this.animationComboBox.Name = "animationComboBox";
            this.animationComboBox.Size = new System.Drawing.Size(121, 21);
            this.animationComboBox.TabIndex = 8;
            this.animationComboBox.SelectedIndexChanged += new System.EventHandler(this.animationComboBox_SelectedIndexChanged);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(464, 26);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(75, 23);
            this.colorButton.TabIndex = 9;
            this.colorButton.Text = "Colour";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // PikPokTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 438);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.animationComboBox);
            this.Controls.Add(this.frameRateControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Animate);
            this.Controls.Add(this.Load);
            this.Name = "PikPokTest";
            this.Text = "PikPokTest";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PikPokTest_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.frameRateControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Timer MovementTimer;
        private System.Windows.Forms.Button Animate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown frameRateControl;
        private System.Windows.Forms.ComboBox animationComboBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button colorButton;
    }
}

