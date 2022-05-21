
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
        public string Webpage = "page.html";
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
        private int chapterSelected;
        public int Chapter_selection { get => chapterSelected; set
            {
                chapterSelected = value;
                OnPropertyChanged("Chapter_selection");
            }
        }
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
                int i = 0;
                foreach (var item in _fb2File.Bodies[i].Sections.ToList())
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
                int j = 0;
                    var body = _fb2File.Bodies.ToList()[j].Sections.ToList()[chapter];
                Chapter_selectionTitel = body.Title.ToString();
                int i;
                FileStream veb = new FileStream("page.html", FileMode.Create);
                List<string> par = new List<string>();
                veb.Write(Encoding.UTF8.GetBytes("<html><head></head><body>"), 0, Encoding.UTF8.GetBytes("<html><head></head><body>").Length);
                for (i=0;  i < body.Content.LongCount(); i++)
                {
                    string str = _fb2File.Bodies.ToList()[j].Sections.ToList()[chapter].Content.ToList()[i].ToXML().ToString();
                    
                    //getStyleHelp(s);
                    //veb.Write(Encoding.UTF8.GetBytes(str), 0, str.Length);
                    veb.Write(Encoding.Default.GetBytes(str), 0, str.Length);
                    par.Add(str);
                }
                veb.Write(Encoding.UTF8.GetBytes("</body></html>"), 0, Encoding.UTF8.GetBytes("</body></html>").Length);
                veb.Close();
                //veb.Write(Encoding.UTF8.GetBytes(par.ToString()), 0, par.ToString().Length);
                //Paragraph = par;
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

        #region #Commands
        public ICommand next => new DelegateCommand(Next);
        private void Next()
        {
            if (Chapter_selection < Chapter.Count - 1)
            {
                Chapter_selection++;
                CurentWindows.reedBook.Chapters.SelectedIndex = Chapter_selection;
            }
        }
        public ICommand prev => new DelegateCommand(Prev);
        private void Prev()
        {
            if (Chapter_selection > 0)
            {
                Chapter_selection--;
                CurentWindows.reedBook.Chapters.SelectedIndex = Chapter_selection;
            }
        }

        #endregion

    }
}
