using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebScreenShooter.Logic
{
	public class WebScreenShootWorker
	{
		public async Task ParseXML(string xmlPath)
		{
			try
			{
				//Document doc = Jsoup.parse(new URL(xmlPath).openStream(), "UTF-8", "", Parser.xmlParser());

				//for (Element e : doc.select("loc"))
				//{
				//	if (e.text().contains(".xml"))
				//	{
				//		parseXML(e.text());
				//		mapHistory.add(e.text());
				//	}
				//	else
				//	{
				//		addURL(e.text());
				//	}
				//}
			}
			catch (IOException e)
			{
				// wrong url for sitemap
				Console.WriteLine(e.StackTrace);
			}
		}

		

		
	}
}
