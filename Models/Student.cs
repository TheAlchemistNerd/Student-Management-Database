namespace StudentManagement.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public double Gpa { get; set; }

        public Student(Guid id, string firstName, string lastName, string emailAddress, double gpa)
        {
            Id = Id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Gpa = gpa;
        }

        // Parameterless constructor (for new() constraint and deserialisation)
        public Student()
        {
            Id = Guid.NewGuid();
        }

        // Generates a new Guid automatically
        public Student(string firstName, string lastName, string emailAddress, double gpa)
            : this(Guid.NewGuid(), firstName, lastName, emailAddress, gpa)
        {

        }
    }
}
