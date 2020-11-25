using KaKaoAPITest.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaKaoAPITest
{
	public partial class KakaoLoginPage : Form
	{
		KakaoManager kakaoManager = new KakaoManager();
		public KakaoLoginPage()
		{
			InitializeComponent();
			webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
			webBrowser.Navigate(KakaoAPIEndPoint.KakaoLogInUrl);
		}

		private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (KakaoManager.InitUserToken(webBrowser)) // 유저 토큰을 성공적으로 받은 경우
			{
				// 폼 닫기
				Console.WriteLine("액세스 토큰 얻기 시도");
				KakaoManager.GetToken();
				//this.Close();
			}
		}

		private void KakaoLoginPage_Load(object sender, EventArgs e)
		{
			Console.WriteLine(webBrowser.Version.ToString());
		}
	}
}
