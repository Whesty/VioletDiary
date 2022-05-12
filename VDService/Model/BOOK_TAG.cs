namespace VDService.Model
{
    public partial class BOOK_TAG
    {
        public int BOOKId { get; set; }

        public int TAGId { get; set; }

        public int Id { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual TAG TAG { get; set; }
    }
}
