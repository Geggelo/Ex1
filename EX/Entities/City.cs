namespace EX.Entities
{
    public class City
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public int postalCode { get; set; }
        public List<Person> people { get; set; }

        public City(string name, string province, string country, int postalCode)
        {
            this.name = name;
            this.province = province;
            this.country = country;
            this.postalCode = postalCode;
            this.people = new List<Person>();
        }

        public void Updater(string name, string province, string country, int postalCode)
        {
            this.name = name;
            this.province = province;
            this.country = country;
            this.postalCode = postalCode;
        }
    }

    
}
