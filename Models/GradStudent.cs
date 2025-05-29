namespace StudentManagement.Models
{
    public class GradStudent : Student
    {
        public bool FacultyAdvisor { get; set; }
        public bool TuitionCredit { get; set; }

        public GradStudent(string firstName, string lastName, string emailAddress, 
                           double gpa, bool facultyAdvisor, bool tuitionCredit)
            : base(firstName, lastName, emailAddress, gpa)
        {
            FacultyAdvisor = facultyAdvisor;
            TuitionCredit = tuitionCredit;
        }
        
        public GradStudent()
        {

        }
    }
}
