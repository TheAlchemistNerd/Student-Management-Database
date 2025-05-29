namespace StudentManagement.Models
{
    public enum YearRank
    {
        Freshman,
        Sophomore,
        Junior,
        Senior
    }
    public class Undergrad : Student
    {
        public YearRank YearRank { get; set; }

        public Undergrad(Guid id, string firstName, string lastName, string emailAddress, double gpa, YearRank yearRank)
            : base(id, firstName, lastName, emailAddress, gpa)
        {
            YearRank = yearRank;
        }

        public Undergrad() : base()
        {

        }

        public Undergrad(string firstName, string lastName, string emailAddress, double gpa, YearRank yearRank)
           : base(Guid.NewGuid(), firstName, lastName, emailAddress, gpa)
        {
            YearRank = yearRank;
        }
    }
}
