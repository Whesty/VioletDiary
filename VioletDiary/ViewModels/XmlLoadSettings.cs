using System.Xml;

namespace VioletDiary.ViewModels
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