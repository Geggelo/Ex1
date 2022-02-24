namespace EX.Entities
{
    public class Person
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public Guid cityId { get; set; }

        public Person(string firstName, string lastName, int age, string address, Guid cityId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
            this.cityId = cityId;
        }

        public void Updater(string firstName, string lastName, int age, string address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
        }
    }
}
