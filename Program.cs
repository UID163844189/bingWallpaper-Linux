using System;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Http;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string wallpaperPath = "/home/spark/.local/share/backgrounds/todaybing.jpg"; // PLEASE MODIFY HERE!!!
todayBingInfo todayBing = getTodayBing();
downloadImage(todayBing.url);


todayBingInfo getTodayBing()
{
	string todaybing = HttpGet("https://cn.bing.com/HPImageArchive.aspx?format=js&idx=%d&n=1&mkt=zh-CN");

	string url = todaybing.Substring(todaybing.IndexOf("\"urlbase\":\"") + 11);
	//Console.WriteLine(url);
	url = url.Substring(0, url.IndexOf('"'));
	//url += "_1920x1080.jpg";
	url = "https://www.bing.com" + url + "_1920x1080.jpg";
	Console.WriteLine(url);

	string copyright = todaybing.Substring(todaybing.IndexOf("\"copyright\":\"") + 13);
	//Console.WriteLine(copyright);
	copyright = copyright.Substring(0, copyright.IndexOf('"'));
	Console.WriteLine(copyright);

	string copyrightlink = todaybing.Substring(todaybing.IndexOf("\"copyrightlink\":\"") + 17);
	copyrightlink = copyrightlink.Substring(0, copyrightlink.IndexOf('"'));
	Console.WriteLine(copyrightlink);

	todayBingInfo info = new();
	info.url = url;
	info.copyright = copyright;
	info.copyrightlink = copyrightlink;
	return info;
}

static string HttpGet(string url)
{
	string result = "";
	try
	{
		HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
		wbRequest.Proxy = null;
		wbRequest.Method = "GET";
		HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
		using (Stream responseStream = wbResponse.GetResponseStream())
		{
			using (StreamReader sReader = new StreamReader(responseStream))
			{
				result = sReader.ReadToEnd();
			}
		}
	}
	catch (Exception e)
	{
		result = e.Message;     //输出捕获到的异常，用OUT关键字输出
	}
	return result;
}
void downloadImage(string Url){
	using (WebClient client = new WebClient())
	{
		client.DownloadFile(new Uri(Url), wallpaperPath);
	}
}


class todayBingInfo
{
	public string url { get; set; }
	public string copyright { get; set; }
	public string copyrightlink { get; set; }
}
