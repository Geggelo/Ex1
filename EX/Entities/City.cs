namespace EX.Entities
{
    public class City
    {
        public string name { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public int postalCode { get; set; }
        public List<Person> people { get; set; }
    }
}
