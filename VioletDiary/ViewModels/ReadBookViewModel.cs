using FB2Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VioletDiary.ViewModels
{
    internal class ReadBookViewModel
    {
		private async Task ReadFB2FileStreamAsync(Stream stream)
		{
			// setup
			var readerSettings = new XmlReaderSettings
			{
				DtdProcessing = DtdProcessing.Ignore
			};
			var loadSettings = new FB2Library.XmlLoadSettings(readerSettings);

			try
			{
				// reading
				FB2File file = await new FB2Reader().ReadAsync(stream, loadSettings);
				
			}
			catch (Exception ex)
			{
				Debug.WriteLine(string.Format("Error loading file : {0}", ex.Message));
			}
		}
        
	}

    
}
