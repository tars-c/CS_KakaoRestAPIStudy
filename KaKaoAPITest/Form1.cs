using KaKaoAPITest.Scripts;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaKaoAPITest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			Btn_Login.Click += Btn_Login_Click;
		}
		private void Btn_Login_Click(object sender, EventArgs e)
		{
			KakaoLoginPage page = new KakaoLoginPage();
			page.ShowDialog();
		}

		private void Btn_UserData_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(KakaoData.accessToken))
				return;

			KakaoManager.GetUserData();
			PB_UserImg.Image = KakaoData.UserImg;
			Label_UserName.Text = KakaoData.UserNickName;
		}

		private void Btn_TempleteMessage_Click(object sender, EventArgs e)
		{
			KakaoManager.SendTempleteMessage();
		}

		private void Btn_Logout_Click(object sender, EventArgs e)
		{
            if (string.IsNullOrEmpty(KakaoData.accessToken))
                return;
			KakaoManager.KakaoLogout();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
           WebBrowserVersionSetting();
        }

        private void WebBrowserVersionSetting()
        {
            RegistryKey registryKey = null; // 레지스트리 변경에 사용 될 변수

            int browserver = 0;
            int ie_emulation = 0;
            var targetApplication = Process.GetCurrentProcess().ProcessName + ".exe"; // 현재 프로그램 이름

            // 사용자 IE 버전 확인
            using (WebBrowser wb = new WebBrowser())
            {
                browserver = wb.Version.Major;
                if (browserver >= 11)
                    ie_emulation = 11001;
                else if (browserver == 10)
                    ie_emulation = 10001;
                else if (browserver == 9)
                    ie_emulation = 9999;
                else if (browserver == 8)
                    ie_emulation = 8888;
                else
                    ie_emulation = 7000;
            }

            try
            {
                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);

                // IE가 없으면 실행 불가능
                if (registryKey == null)
                {
                    MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                    Application.Exit();
                    return;
                }

                string FindAppkey = Convert.ToString(registryKey.GetValue(targetApplication));
                //Console.WriteLine(FindAppkey + "target: " +targetApplication);
                // 이미 키가 있다면 종료
                if (FindAppkey == ie_emulation.ToString())
                {
                    registryKey.Close();
                    return;
                }

                // 키가 없으므로 키 셋팅
                registryKey.SetValue(targetApplication, ie_emulation, RegistryValueKind.DWord);

                // 다시 키를 받아와서
                FindAppkey = Convert.ToString(registryKey.GetValue(targetApplication));

                // 현재 브라우저 버전이랑 동일 한지 판단
                if (FindAppkey == ie_emulation.ToString())
                {
                    Console.WriteLine("EXIT!");
                    return;
                }
                else
                {
                    MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                    Application.Exit();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                Application.Exit();
                return;
            }
            finally
            {
                // 키 메모리 해제
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }

		private void Btn_CustomMessage_Click(object sender, EventArgs e)
		{
            KakaoManager.SendCustomMessage();

        }
	}
}
