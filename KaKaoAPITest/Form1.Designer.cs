
namespace KaKaoAPITest
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.Btn_Login = new System.Windows.Forms.Button();
			this.Btn_Logout = new System.Windows.Forms.Button();
			this.Btn_TempleteMessage = new System.Windows.Forms.Button();
			this.Btn_CustomMessage = new System.Windows.Forms.Button();
			this.Btn_UserData = new System.Windows.Forms.Button();
			this.PB_UserImg = new System.Windows.Forms.PictureBox();
			this.Label_UserName = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.PB_UserImg)).BeginInit();
			this.SuspendLayout();
			// 
			// Btn_Login
			// 
			this.Btn_Login.Location = new System.Drawing.Point(12, 12);
			this.Btn_Login.Name = "Btn_Login";
			this.Btn_Login.Size = new System.Drawing.Size(295, 30);
			this.Btn_Login.TabIndex = 0;
			this.Btn_Login.Text = "로그인";
			this.Btn_Login.UseVisualStyleBackColor = true;
			// 
			// Btn_Logout
			// 
			this.Btn_Logout.Location = new System.Drawing.Point(12, 48);
			this.Btn_Logout.Name = "Btn_Logout";
			this.Btn_Logout.Size = new System.Drawing.Size(295, 30);
			this.Btn_Logout.TabIndex = 1;
			this.Btn_Logout.Text = "로그아웃";
			this.Btn_Logout.UseVisualStyleBackColor = true;
			this.Btn_Logout.Click += new System.EventHandler(this.Btn_Logout_Click);
			// 
			// Btn_TempleteMessage
			// 
			this.Btn_TempleteMessage.Location = new System.Drawing.Point(12, 84);
			this.Btn_TempleteMessage.Name = "Btn_TempleteMessage";
			this.Btn_TempleteMessage.Size = new System.Drawing.Size(295, 30);
			this.Btn_TempleteMessage.TabIndex = 2;
			this.Btn_TempleteMessage.Text = "템플릿 메시지";
			this.Btn_TempleteMessage.UseVisualStyleBackColor = true;
			this.Btn_TempleteMessage.Click += new System.EventHandler(this.Btn_TempleteMessage_Click);
			// 
			// Btn_CustomMessage
			// 
			this.Btn_CustomMessage.Location = new System.Drawing.Point(12, 120);
			this.Btn_CustomMessage.Name = "Btn_CustomMessage";
			this.Btn_CustomMessage.Size = new System.Drawing.Size(295, 30);
			this.Btn_CustomMessage.TabIndex = 3;
			this.Btn_CustomMessage.Text = "커스텀 메시지";
			this.Btn_CustomMessage.UseVisualStyleBackColor = true;
			this.Btn_CustomMessage.Click += new System.EventHandler(this.Btn_CustomMessage_Click);
			// 
			// Btn_UserData
			// 
			this.Btn_UserData.Location = new System.Drawing.Point(12, 156);
			this.Btn_UserData.Name = "Btn_UserData";
			this.Btn_UserData.Size = new System.Drawing.Size(295, 30);
			this.Btn_UserData.TabIndex = 4;
			this.Btn_UserData.Text = "유저 데이터(이름, 프로필사진)";
			this.Btn_UserData.UseVisualStyleBackColor = true;
			this.Btn_UserData.Click += new System.EventHandler(this.Btn_UserData_Click);
			// 
			// PB_UserImg
			// 
			this.PB_UserImg.Location = new System.Drawing.Point(12, 192);
			this.PB_UserImg.Name = "PB_UserImg";
			this.PB_UserImg.Size = new System.Drawing.Size(111, 92);
			this.PB_UserImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PB_UserImg.TabIndex = 5;
			this.PB_UserImg.TabStop = false;
			// 
			// Label_UserName
			// 
			this.Label_UserName.Font = new System.Drawing.Font("굴림", 24F);
			this.Label_UserName.Location = new System.Drawing.Point(129, 192);
			this.Label_UserName.Name = "Label_UserName";
			this.Label_UserName.Size = new System.Drawing.Size(178, 92);
			this.Label_UserName.TabIndex = 6;
			this.Label_UserName.Text = "이름";
			this.Label_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 316);
			this.Controls.Add(this.Label_UserName);
			this.Controls.Add(this.PB_UserImg);
			this.Controls.Add(this.Btn_UserData);
			this.Controls.Add(this.Btn_CustomMessage);
			this.Controls.Add(this.Btn_TempleteMessage);
			this.Controls.Add(this.Btn_Logout);
			this.Controls.Add(this.Btn_Login);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.PB_UserImg)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Btn_Login;
		private System.Windows.Forms.Button Btn_Logout;
		private System.Windows.Forms.Button Btn_TempleteMessage;
		private System.Windows.Forms.Button Btn_CustomMessage;
		private System.Windows.Forms.Button Btn_UserData;
		private System.Windows.Forms.PictureBox PB_UserImg;
		private System.Windows.Forms.Label Label_UserName;
	}
}

