namespace TumblrSplider
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
            this.Cur_Url_Text = new System.Windows.Forms.TextBox();
            this.Start_Button = new System.Windows.Forms.Button();
            this.User_List = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.follower_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photo_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.video_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.IsDownloadPhoto = new System.Windows.Forms.CheckBox();
            this.IsDownloadVideo = new System.Windows.Forms.CheckBox();
            this.StartTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Proxy_Text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.User_List)).BeginInit();
            this.SuspendLayout();
            // 
            // Cur_Url_Text
            // 
            this.Cur_Url_Text.Location = new System.Drawing.Point(645, 16);
            this.Cur_Url_Text.Name = "Cur_Url_Text";
            this.Cur_Url_Text.Size = new System.Drawing.Size(128, 21);
            this.Cur_Url_Text.TabIndex = 3;
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(759, 147);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(66, 20);
            this.Start_Button.TabIndex = 4;
            this.Start_Button.Text = "开始";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // User_List
            // 
            this.User_List.AllowUserToAddRows = false;
            this.User_List.AllowUserToDeleteRows = false;
            this.User_List.BackgroundColor = System.Drawing.SystemColors.Control;
            this.User_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.User_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.user_name,
            this.follower_number,
            this.photo_number,
            this.video_number,
            this.status});
            this.User_List.Dock = System.Windows.Forms.DockStyle.Left;
            this.User_List.GridColor = System.Drawing.SystemColors.Control;
            this.User_List.Location = new System.Drawing.Point(0, 0);
            this.User_List.MultiSelect = false;
            this.User_List.Name = "User_List";
            this.User_List.ReadOnly = true;
            this.User_List.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.User_List.RowHeadersVisible = false;
            this.User_List.RowTemplate.Height = 23;
            this.User_List.Size = new System.Drawing.Size(565, 399);
            this.User_List.TabIndex = 5;
            // 
            // index
            // 
            this.index.FillWeight = 80F;
            this.index.HeaderText = "序号";
            this.index.Name = "index";
            this.index.ReadOnly = true;
            this.index.Width = 60;
            // 
            // user_name
            // 
            this.user_name.HeaderText = "昵称";
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            // 
            // follower_number
            // 
            this.follower_number.HeaderText = "粉丝数";
            this.follower_number.Name = "follower_number";
            this.follower_number.ReadOnly = true;
            // 
            // photo_number
            // 
            this.photo_number.HeaderText = "图片数";
            this.photo_number.Name = "photo_number";
            this.photo_number.ReadOnly = true;
            // 
            // video_number
            // 
            this.video_number.HeaderText = "视频数";
            this.video_number.Name = "video_number";
            this.video_number.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "初始昵称";
            // 
            // IsDownloadPhoto
            // 
            this.IsDownloadPhoto.AutoSize = true;
            this.IsDownloadPhoto.Location = new System.Drawing.Point(645, 84);
            this.IsDownloadPhoto.Name = "IsDownloadPhoto";
            this.IsDownloadPhoto.Size = new System.Drawing.Size(72, 16);
            this.IsDownloadPhoto.TabIndex = 9;
            this.IsDownloadPhoto.Text = "下载图片";
            this.IsDownloadPhoto.UseVisualStyleBackColor = true;
            // 
            // IsDownloadVideo
            // 
            this.IsDownloadVideo.AutoSize = true;
            this.IsDownloadVideo.Location = new System.Drawing.Point(645, 119);
            this.IsDownloadVideo.Name = "IsDownloadVideo";
            this.IsDownloadVideo.Size = new System.Drawing.Size(72, 16);
            this.IsDownloadVideo.TabIndex = 10;
            this.IsDownloadVideo.Text = "下载视频";
            this.IsDownloadVideo.UseVisualStyleBackColor = true;
            // 
            // StartTime
            // 
            this.StartTime.Location = new System.Drawing.Point(580, 187);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(193, 21);
            this.StartTime.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(578, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "代理IP";
            // 
            // Prox_Text
            // 
            this.Proxy_Text.Location = new System.Drawing.Point(645, 47);
            this.Proxy_Text.Name = "Proxy_Text";
            this.Proxy_Text.Size = new System.Drawing.Size(128, 21);
            this.Proxy_Text.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 399);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Proxy_Text);
            this.Controls.Add(this.StartTime);
            this.Controls.Add(this.IsDownloadVideo);
            this.Controls.Add(this.IsDownloadPhoto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.User_List);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.Cur_Url_Text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "爬虫一号";
            ((System.ComponentModel.ISupportInitialize)(this.User_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Cur_Url_Text;
        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.DataGridView User_List;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn follower_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn photo_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn video_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox IsDownloadPhoto;
        private System.Windows.Forms.CheckBox IsDownloadVideo;
        private System.Windows.Forms.TextBox StartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Proxy_Text;
    }
}

