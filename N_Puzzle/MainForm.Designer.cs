
namespace N_Puzzle
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.grbGameView = new System.Windows.Forms.GroupBox();
            this.grbControl = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnStopSolving = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbGridSize = new System.Windows.Forms.TextBox();
            this.btnSetSize = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbSolveType = new System.Windows.Forms.ComboBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.tbShufferItters = new System.Windows.Forms.TextBox();
            this.btnShuffer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.grbControl.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // grbGameView
            // 
            this.grbGameView.Location = new System.Drawing.Point(13, 13);
            this.grbGameView.Name = "grbGameView";
            this.grbGameView.Size = new System.Drawing.Size(425, 425);
            this.grbGameView.TabIndex = 0;
            this.grbGameView.TabStop = false;
            this.grbGameView.Text = "Game View";
            // 
            // grbControl
            // 
            this.grbControl.Controls.Add(this.button3);
            this.grbControl.Controls.Add(this.button2);
            this.grbControl.Controls.Add(this.btnStopSolving);
            this.grbControl.Controls.Add(this.panel1);
            this.grbControl.Controls.Add(this.label4);
            this.grbControl.Controls.Add(this.label3);
            this.grbControl.Controls.Add(this.label2);
            this.grbControl.Controls.Add(this.trackBarSpeed);
            this.grbControl.Location = new System.Drawing.Point(445, 13);
            this.grbControl.Name = "grbControl";
            this.grbControl.Size = new System.Drawing.Size(266, 427);
            this.grbControl.TabIndex = 1;
            this.grbControl.TabStop = false;
            this.grbControl.Text = "Control";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 37);
            this.button2.TabIndex = 16;
            this.button2.Text = "Clean Ram";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStopSolving
            // 
            this.btnStopSolving.Enabled = false;
            this.btnStopSolving.Location = new System.Drawing.Point(144, 227);
            this.btnStopSolving.Name = "btnStopSolving";
            this.btnStopSolving.Size = new System.Drawing.Size(82, 37);
            this.btnStopSolving.TabIndex = 15;
            this.btnStopSolving.Text = "Stop Solving";
            this.btnStopSolving.UseVisualStyleBackColor = true;
            this.btnStopSolving.Click += new System.EventHandler(this.btnStopSolving_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbGridSize);
            this.panel1.Controls.Add(this.btnSetSize);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbSolveType);
            this.panel1.Controls.Add(this.btnSolve);
            this.panel1.Controls.Add(this.tbShufferItters);
            this.panel1.Controls.Add(this.btnShuffer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 205);
            this.panel1.TabIndex = 12;
            // 
            // tbGridSize
            // 
            this.tbGridSize.Location = new System.Drawing.Point(14, 172);
            this.tbGridSize.Name = "tbGridSize";
            this.tbGridSize.Size = new System.Drawing.Size(100, 20);
            this.tbGridSize.TabIndex = 14;
            this.tbGridSize.Text = "3";
            // 
            // btnSetSize
            // 
            this.btnSetSize.Location = new System.Drawing.Point(141, 155);
            this.btnSetSize.Name = "btnSetSize";
            this.btnSetSize.Size = new System.Drawing.Size(82, 37);
            this.btnSetSize.TabIndex = 13;
            this.btnSetSize.Text = "Set";
            this.btnSetSize.UseVisualStyleBackColor = true;
            this.btnSetSize.Click += new System.EventHandler(this.btnSetSize_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Last Shuffle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLastShufferState_Click);
            // 
            // cbSolveType
            // 
            this.cbSolveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSolveType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSolveType.FormattingEnabled = true;
            this.cbSolveType.Location = new System.Drawing.Point(102, 108);
            this.cbSolveType.Name = "cbSolveType";
            this.cbSolveType.Size = new System.Drawing.Size(156, 28);
            this.cbSolveType.TabIndex = 11;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(14, 104);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(82, 37);
            this.btnSolve.TabIndex = 10;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // tbShufferItters
            // 
            this.tbShufferItters.Location = new System.Drawing.Point(102, 22);
            this.tbShufferItters.Name = "tbShufferItters";
            this.tbShufferItters.Size = new System.Drawing.Size(100, 20);
            this.tbShufferItters.TabIndex = 9;
            this.tbShufferItters.Text = "1000";
            // 
            // btnShuffer
            // 
            this.btnShuffer.Location = new System.Drawing.Point(14, 13);
            this.btnShuffer.Name = "btnShuffer";
            this.btnShuffer.Size = new System.Drawing.Size(82, 37);
            this.btnShuffer.TabIndex = 8;
            this.btnShuffer.Text = "Shuffle";
            this.btnShuffer.UseVisualStyleBackColor = true;
            this.btnShuffer.Click += new System.EventHandler(this.btnShuffer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Log: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ram : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Speed";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.LargeChange = 1;
            this.trackBarSpeed.Location = new System.Drawing.Point(17, 295);
            this.trackBarSpeed.Maximum = 4;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarSpeed.Size = new System.Drawing.Size(213, 45);
            this.trackBarSpeed.TabIndex = 8;
            this.trackBarSpeed.Value = 2;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(176, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 37);
            this.button3.TabIndex = 17;
            this.button3.Text = "Test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 460);
            this.Controls.Add(this.grbControl);
            this.Controls.Add(this.grbGameView);
            this.Name = "MainForm";
            this.Text = "N_Puzzle Solver";
            this.grbControl.ResumeLayout(false);
            this.grbControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGameView;
        private System.Windows.Forms.GroupBox grbControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbGridSize;
        private System.Windows.Forms.Button btnSetSize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbSolveType;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.TextBox tbShufferItters;
        private System.Windows.Forms.Button btnShuffer;
        private System.Windows.Forms.Button btnStopSolving;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

