using System.Xml;

namespace VioletBookDiary.ViewModels
{
    internal class XmlLoadSettings
    {
        private XmlReaderSettings readerSettings;

        public XmlLoadSettings(XmlReaderSettings readerSettings)
        {
            this.readerSettings = readerSettings;
        }
    }
}