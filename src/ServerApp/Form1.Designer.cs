namespace ServerApp
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
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.roomsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.saveChatButton = new System.Windows.Forms.Button();
            this.restoreChatButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 13);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(13, 43);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rooms";
            // 
            // roomsListBox
            // 
            this.roomsListBox.FormattingEnabled = true;
            this.roomsListBox.Location = new System.Drawing.Point(15, 109);
            this.roomsListBox.Name = "roomsListBox";
            this.roomsListBox.Size = new System.Drawing.Size(155, 290);
            this.roomsListBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chat";
            // 
            // chatRichTextBox
            // 
            this.chatRichTextBox.Location = new System.Drawing.Point(190, 30);
            this.chatRichTextBox.Name = "chatRichTextBox";
            this.chatRichTextBox.Size = new System.Drawing.Size(579, 369);
            this.chatRichTextBox.TabIndex = 5;
            this.chatRichTextBox.Text = "";
            // 
            // saveChatButton
            // 
            this.saveChatButton.Location = new System.Drawing.Point(95, 13);
            this.saveChatButton.Name = "saveChatButton";
            this.saveChatButton.Size = new System.Drawing.Size(75, 23);
            this.saveChatButton.TabIndex = 8;
            this.saveChatButton.Text = "Save";
            this.saveChatButton.UseVisualStyleBackColor = true;
            this.saveChatButton.Click += new System.EventHandler(this.saveChatButton_Click);
            // 
            // restoreChatButton
            // 
            this.restoreChatButton.Location = new System.Drawing.Point(95, 42);
            this.restoreChatButton.Name = "restoreChatButton";
            this.restoreChatButton.Size = new System.Drawing.Size(75, 23);
            this.restoreChatButton.TabIndex = 9;
            this.restoreChatButton.Text = "Restore";
            this.restoreChatButton.UseVisualStyleBackColor = true;
            this.restoreChatButton.Click += new System.EventHandler(this.restoreChatButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 414);
            this.Controls.Add(this.restoreChatButton);
            this.Controls.Add(this.saveChatButton);
            this.Controls.Add(this.chatRichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.roomsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox roomsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox chatRichTextBox;
        private System.Windows.Forms.Button saveChatButton;
        private System.Windows.Forms.Button restoreChatButton;
        private System.Windows.Forms.Timer timer1;
    }
}

