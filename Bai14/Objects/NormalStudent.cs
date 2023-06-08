using Enums;

namespace Bai14.Objects
{
    class NormalStudent : Student
    {
        public double TOEICScore { get; set; }
        public double EntryTestScore { get; set; }

        public NormalStudent(string Name, DateTime Dob, Gender Gender, string PhoneNumber, string UniversityName, GradeLevel GradeLevel, double tOEICScore, double entryTestScore) : base(Name, Dob, Gender, PhoneNumber, UniversityName, GradeLevel)
        {
            TOEICScore = tOEICScore;
            EntryTestScore = entryTestScore;
        }

        public override string ShowMyInfo()
        {
            return base.ShowMyInfo() + $", TOEIC Score: {TOEICScore}, Entry Test Score: {EntryTestScore}";

        }
    }
}
