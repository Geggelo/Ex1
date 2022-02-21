namespace EX.Entities
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string address { get; set; }

        public Person(string firstName, string lastName, int age, string address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
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
