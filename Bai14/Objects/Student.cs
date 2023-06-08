using Enums;

namespace Bai14.Objects
{
    class Student
    {
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string UniversityName { get; set; }

        public GradeLevel GradeLevel { get; set; }

        public Student(string Name, DateTime Dob, Gender Gender, string PhoneNumber, string UniversityName, GradeLevel GradeLevel)
        {
            this.Name = Name;
            this.Dob = Dob;
            this.Gender = Gender;
            this.PhoneNumber = PhoneNumber;
            this.UniversityName = UniversityName;
            this.GradeLevel = GradeLevel;
        }
        public virtual string ShowMyInfo()
        {
            return $"Name: {Name}, Dob: {Dob}, Gender: {Gender}, Phone number: {PhoneNumber}, Grade Level: {GradeLevel}";
        }

    }
}
