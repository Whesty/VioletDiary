namespace VDService.Model
{
    public partial class BOOK_AUTHOR
    {
        public int BOOKId { get; set; }

        public int AUTHORId { get; set; }

        public int Id { get; set; }

        public virtual AUTHOR AUTHOR { get; set; }

        public virtual BOOK BOOK { get; set; }
    }
}
