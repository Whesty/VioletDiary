
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using FB2Library;

namespace VioletBookDiary.ViewModels
{
	internal class ReadBookViewModel : ViewModelBase
	{
		private readonly string _filePath;
		Stream Stream;
		private FB2File _fb2File;
		private List<string> Chapter
		{
			get
			{
				List<string> chapter = new List<string>();
				foreach (var item in _fb2File.Bodies.ToList())
				{
					chapter.Add(item.Title.ToString());
				}
				return chapter;
			}
			set
			{
				if (Chapter != value)
				{
					Chapter = value;
					OnPropertyChanged("Chapter");
				}
			}
		}
		private string Chapter_selection;
		public async Task ReadFB2FileStreamAsync()
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
				FB2File file = await new FB2Reader().ReadAsync(Stream, loadSettings);
				_fb2File = file;

			}
			catch (Exception ex)
			{
				Debug.WriteLine(string.Format("Error loading file : {0}", ex.Message));
			}
		}

		public ReadBookViewModel(string filePath)
		{
			_filePath = filePath;
			Stream = File.OpenRead(_filePath);

		}

		List<string> Paragraph;
		public void getParagraph(int chapter)
		{
			List<string> paragraph = new List<string>();
			
			if (_fb2File != null)
			{
				var body = _fb2File.Bodies.ToList()[0].Sections.ToList()[chapter];
                Chapter_selection = body.Title.ToString();
                foreach (var i in body.Content.ToList())
				{
					string s = i.ToString();
                    getStyleHelp(s);
                    paragraph.Add(s);
				}
			}
		}
		public string getStyleHelp(string s)
		{
            string style = "";
            Regex regex = new Regex(@"(\w*)<a>(\w*)</a>");
            MatchCollection math = regex.Matches(s);
            //Подсказки добавить
            //Подсказки прикреплять к listItems и писать все существующие в нем подсказки
            style = Regex.Replace(s, @"(\w*)<a>(\w*)</a>", @"$1\[$2\]");
			return style;
		}
	}
}
