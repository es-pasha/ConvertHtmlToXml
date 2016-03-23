using HtmlAgilityPack;
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace ConvertHtmlToXml
{
	class Program
	{
		static string xsltName = "test.xsl";
		static string htmlName = "test.html";

		static void Main(string[] args)
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

		static void InnerMethod()
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
	}
}
