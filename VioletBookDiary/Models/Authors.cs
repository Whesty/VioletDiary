namespace VioletBookDiary.Models
{
    public class Authors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public Authors(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
        public Authors()
        {

        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
