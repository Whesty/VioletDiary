
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
using System.Windows.Input;
using VioletBookDiary.Commands;
using VioletBookDiary.Views;
using System.Windows.Controls;

namespace VioletBookDiary.ViewModels
{
    internal class ReadBookViewModel : ViewModelBase
    {
        private readonly string _filePath;
        Stream Stream;
        private FB2File _fb2File;
        private List<string> chapter;
        public List<string> Chapter
        {
            get
            {
                return chapter;
            }
            set
            {
                if (chapter != value)
                {
                    chapter = value;
                    OnPropertyChanged("Chapter");
                }
            }
        }
        private int Chapter_selection = 0;
        private string chapter_selectionTitel;
        public string Chapter_selectionTitel
        {
            get
            {
                return chapter_selectionTitel;
            }
            set
            {
                if (chapter_selectionTitel != value)
                {
                    chapter_selectionTitel = value;
                    OnPropertyChanged("Chapter_selectionTitel");
                }
            }
        }

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
                Chapter = new List<string>();
                foreach (var item in _fb2File.Bodies[0].Sections.ToList())
                {
                    Chapter.Add(item.Title.ToString());
                }
                getParagraph(Chapter_selection);

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
        private List<string> paragraph;
        public List<string> Paragraph { get { return paragraph; } set 
            {
                if (paragraph != value)
                {
                    paragraph = value;
                    OnPropertyChanged("Paragraph");
                }
            } }
        public void getParagraph(int chapter)
        {
            Paragraph = new List<string>();

            if (_fb2File != null)
            {
                var body = _fb2File.Bodies.ToList()[0].Sections.ToList()[chapter];
                chapter_selectionTitel = body.Title.ToString();
                int i;
                List<string> par = new List<string>();
                for (i=0;  i < body.Content.LongCount(); i++)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = _fb2File.Bodies.ToList()[0].Sections.ToList()[chapter].Content.ToList()[i].ToXML().ToString();
                    string s = textBlock.Text;
                    //getStyleHelp(s);
                    par.Add(s);
                }
                Paragraph = par;
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
