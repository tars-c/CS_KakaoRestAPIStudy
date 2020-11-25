using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace KaKaoAPITest.Scripts
{
	class KakaoManager
	{
		/// <summary>
		/// 유저 토큰 얻기
		/// </summary>
		/// <param name="browser">브라우저</param>
		/// <returns>성공 여부 true, false</returns>
		public static bool InitUserToken(WebBrowser browser)
		{
			string redirectURI = browser.Url.ToString();
			if (redirectURI.IndexOf("access_denied") != -1)
				return false;

			int tokenIdx = redirectURI.IndexOf("code=");
			if (tokenIdx == -1)
				return false;

			string userToken = redirectURI.Substring(tokenIdx+("code=").Length);
			Console.WriteLine($"redirectURI: [{redirectURI}]");
			Console.WriteLine("userToken: " + userToken);
			KakaoData.UserToken = userToken;
			return true;
		}

		public static bool GetToken()
		{
			var client = new RestClient(KakaoAPIEndPoint.KakaoHostOAuthUrl);

			var req = new RestRequest(KakaoAPIEndPoint.KakaoOAuthUrl, Method.POST);
			req.AddParameter("grant_type", "authorization_code");
			req.AddParameter("client_id", KakaoAPIEndPoint.RestAPIKey);
			req.AddParameter("redirect_uri", KakaoAPIEndPoint.KakaoRedirectUrl);
			req.AddParameter("code", KakaoData.UserToken);


			var restResponse = client.Execute(req);
			var json = JObject.Parse(restResponse.Content);
			KakaoData.accessToken = json["access_token"].ToString();
			//Console.WriteLine($"json: {json.ToString()}");
			return true;
		}

		public static int KakaoLogout()
		{
			RestRequest req = new RestRequest(KakaoAPIEndPoint.KakaoUnlinkUrl, Method.POST);
			req.AddHeader("Authorization", $"Bearer {KakaoData.accessToken}");

			RestClient client = new RestClient(KakaoAPIEndPoint.KakaoHostApiUrl);
			var response = client.Execute(req);
			var json = JObject.Parse(response.Content);
			Console.WriteLine(json.ToString());
			return json["id"].ToObject<Int32>();
		}

		public static void GetUserData()
		{
			RestRequest req = new RestRequest(KakaoAPIEndPoint.KakaoUserDataUrl, Method.POST);
			req.AddHeader("Authorization", $"Bearer {KakaoData.accessToken}");

			RestClient client = new RestClient(KakaoAPIEndPoint.KakaoHostApiUrl);
			var response = client.Execute(req);
			var json = JObject.Parse(response.Content);

			if (json["properties"]["profile_image"] != null)
			{
				string imageUrl = json["properties"]["profile_image"].ToString();
				KakaoData.UserImg = GetWebImage(imageUrl);
			}
			KakaoData.UserNickName = json["properties"]["nickname"].ToString();
		}

		public static Bitmap GetWebImage(string url)
		{
			Bitmap bitmap = null;
			try
			{
				WebClient cl = new WebClient();
				Stream stream = cl.OpenRead(url);
				bitmap = Bitmap.FromStream(stream) as Bitmap;

				stream.Close();
				cl.Dispose();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return bitmap;
		}

		public static void SendTempleteMessage()
		{
			RestClient restClient = new RestClient(KakaoAPIEndPoint.KakaoHostApiUrl);
			RestRequest req = new RestRequest(KakaoAPIEndPoint.KakaoTemplateMessageUrl, Method.POST);
			req.AddHeader("Authorization", $"bearer {KakaoData.accessToken}");
			req.AddParameter("template_id", KakaoAPIEndPoint.MessageTempleteKey);

			var response = restClient.Execute(req);
			var json = JObject.Parse(response.Content);
			Console.WriteLine(json.ToString());
		}
		public static void SendCustomMessage()
		{
			RestClient restClient = new RestClient(KakaoAPIEndPoint.KakaoHostApiUrl);
			RestRequest req = new RestRequest(KakaoAPIEndPoint.KakaoDefaultMessageUrl, Method.POST);
			req.AddHeader("Authorization", $"bearer {KakaoData.accessToken}");

			JObject obj = new JObject();
			obj.Add("object_type", "text");
			obj.Add("text", "ㅋㅋㅋㅋㅋㅋ 테스트앱 ");

			JObject linkJson = new JObject();
			// 버튼을 이용하여 사이트를 사용하기 위해서는
			// 웹 플랫폼에 사이트를 등록해야한다.
			// 모바일 링크도 추가로 등록해야하며, 모바일은 등록하지 않을 경우 PC링크로 대체된다.
			linkJson.Add("web_url", "https://google.com");
			linkJson.Add("mobile_web_url", "https://m.naver.com");
			obj.Add("link", linkJson);

			req.AddParameter("template_object", obj);

			var response = restClient.Execute(req);
			var json = JObject.Parse(response.Content);
			Console.WriteLine(json.ToString());
		}
	}
}
