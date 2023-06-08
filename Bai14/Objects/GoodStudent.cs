using Enums;

namespace Bai14.Objects
{
    class GoodStudent : Student
    {
        public double GPA { get; set; }
        public string BestAwardName { get; set; }
        public GoodStudent(string Name, DateTime Dob, Gender Gender, string PhoneNumber, string UniversityName, GradeLevel GradeLevel, double GPA, string BestAwardName) : base(Name, Dob, Gender, PhoneNumber, UniversityName, GradeLevel)
        {
            this.GPA = GPA;
            this.BestAwardName = BestAwardName;
        }
        public override string ShowMyInfo()
        {
            return base.ShowMyInfo()+ $", GPA: {GPA}, Best Award: {BestAwardName}";

        }
    }
}
