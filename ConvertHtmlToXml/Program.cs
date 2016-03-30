using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Xsl;

namespace ConvertHtmlToXml
{
	class Program
	{
		static string xsltName = "test.xsl";
		static string htmlName = "test.html";
		static string xmlName = "test.xml";

		static void Main(string[] args)
		{
			ParseWebPage("http://www.tmxnews.co.uk/news/motocross-news-s3/A-Highland-challenge-Lampkin-v-Fujinami-i190", "tmxnews.xsl");
			//ParseWebPage("http://www.dirtbikerider.com/news/motocross-news-s1/Report-Lyng-2016-Maxxis-ACU-British-Motocross-Championship-i12603", "dirtbikerider.xsl");
			//CheckParseHtmlAsXml();
			//CheckParseXml();
			//CheckParseHtml();
		}

		static void CheckParseHtmlHAP()
		{
			HtmlWeb hw = new HtmlWeb();

			// create an XML file
			var xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.ConformanceLevel = ConformanceLevel.Fragment;
			xmlWriterSettings.Encoding = System.Text.Encoding.UTF8;

			XmlTextWriter writer = new XmlTextWriter("rss.xml", System.Text.Encoding.UTF8);

			// get an Internet resource and write it as an XML file, after an XSLT transormation
			// if www.asp.net ever change its HTML format, just changes the XSL file. No need for recompilation.
			hw.LoadHtmlAsXml("http://rumbledev.blob.core.windows.net/test/test.html", xsltName, null, writer);

			// cleanup
			writer.Flush();
			writer.Close();
		}

		static void CheckParseHtml()
		{
			XslCompiledTransform xslt = new XslCompiledTransform();
			xslt.Load(xsltName);

			StringWriter textWriter = new StringWriter();
			XmlTextWriter writer = new XmlTextWriter(textWriter);

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(File.ReadAllText(htmlName));
			xslt.Transform(doc, null, writer);
			Console.WriteLine(textWriter.ToString());
			Console.ReadKey();
		}

		static void CheckParseXml()
		{
			XslCompiledTransform xslt = new XslCompiledTransform();
			xslt.Load(xsltName);

			StringWriter textWriter = new StringWriter();
			XmlTextWriter writer = new XmlTextWriter(textWriter);

			//XmlTextReader reader = new XmlTextReader(xmlName);
			XmlDocument doc = new XmlDocument();
			doc.Load(xmlName);
			var nav = doc.CreateNavigator();

			xslt.Transform(nav, null, writer);
			Console.WriteLine(textWriter.ToString());
			Console.ReadKey();
		}

		static void CheckParseHtmlAsXml()
		{
			CheckParseHtmlAsXml(File.ReadAllText(htmlName), xsltName);
		}

		static void ParseWebPage(string url, string xslFileName)
		{
			var wc = new WebClient();
			CheckParseHtmlAsXml(wc.DownloadString(url), xslFileName);
		}

		static void CheckParseHtmlAsXml(string inputHtml, string xslFileName)
		{
			HtmlDocument hdoc = new HtmlDocument();
			hdoc.LoadHtml(inputHtml);
			hdoc.OptionOutputAsXml = true;

			var xml = GetString(hdoc);

			XslCompiledTransform xslt = new XslCompiledTransform();
			xslt.Load(xslFileName);

			StringWriter textWriter = new StringWriter();
			XmlTextWriter writer = new XmlTextWriter(textWriter);
			writer.Formatting = Formatting.Indented;
			writer.Indentation = 4;

			//XmlTextReader reader = new XmlTextReader(xmlName);
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);
			var nav = doc.CreateNavigator();

			xslt.Transform(nav, null, writer);
			Console.WriteLine(textWriter.ToString());
			Console.WriteLine("\r\n==================================================");
			Console.ReadKey();
		}

		static string GetString(HtmlDocument doc)
		{
			using (StringWriter textWriter = new StringWriter())
			{
				doc.Save(textWriter);
				return textWriter.ToString();
			}
		}
	}
}
