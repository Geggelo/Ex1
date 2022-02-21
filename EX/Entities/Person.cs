namespace EX.Entities
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public int number { get; set; }
        public string City { get; set; }
    }
}
