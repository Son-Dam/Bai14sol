using Bai14.Objects;
using Bai14.Exceptions;
using System.Globalization;
using Microsoft.VisualBasic;
using Enums;

namespace Bai14.Program
{
    class Manager
    {
        private List<GoodStudent> GoodStudents;
        private List<NormalStudent> NormalStudents;
        public Manager() 
        {
            GoodStudents = new List<GoodStudent>();
            NormalStudents = new List<NormalStudent>();
        }

        public void AddStudent() 
        {
            
            Console.WriteLine("Enter Student's Name:");
            string input;


        ReadStudentName:
            string Name;
            try
            {
                input = Console.ReadLine();
                ValidateName(input,out Name);
            }
            catch (InvalidFullNameException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter a valid name:");
                goto ReadStudentName;
            }
            


            Console.WriteLine("Enter Student's DOB:");
        ReadStudentDOB:
            
            DateTime DOB;
            try
            {
                input = Console.ReadLine();
                ValidateDOB(input, out DOB);
                
            }
            catch (InvalidDOBException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter a valid DOB:");
                goto ReadStudentDOB;
            }

            Console.WriteLine("Enter Student's Gender:");
        ReadGender:
            Gender Gender;
            try
            {
                input = Console.ReadLine();
                if(!Enum.TryParse(input,true,out Gender)){
                    throw new Exception("Unknown input error!");
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter a valid gender (male, female):");
                goto ReadGender;
            }

            Console.WriteLine("Enter Student's Phone number:");
        ReadStudentPhoneNumber:

            string PhoneNumber;
            try
            {
                input = Console.ReadLine();
                ValidatePhoneNumber(input, out PhoneNumber);

            }
            catch (InvalidPhoneNumberException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter a valid phone number:");
                goto ReadStudentPhoneNumber;
            }

            Console.WriteLine("Please enter student's university:");
            string UniversityName = Console.ReadLine();


            Console.WriteLine("Please enter student's gradelevel(0 for Good grade level,1 for Normal grade level");
        ReadGradeLevel:
            GradeLevel gradeLevel;
            try
            {
                input = Console.ReadLine();
                if(!Enum.TryParse(input,true,out gradeLevel))
                {
                    throw new Exception("Unknown input error");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter 0 or Good for Good grade level, 1 or Normal for Normal grade level!");
                goto ReadGradeLevel;
            }

            switch (gradeLevel)
            {
                case GradeLevel.Good:
                    Console.WriteLine("Please enter GPA:");
                    double GPA;
                ReadGPA:
                    try
                    {
                        input = Console.ReadLine();
                        if (!Double.TryParse(input, out GPA) || GPA>10 ||GPA<0)
                        {
                            throw new Exception("Unknown input error!");
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Please enter a valid GPA in scale of 10");
                        goto ReadGPA;
                    }
                    Console.WriteLine("Please enter student's best award name");
                    string BestAwardName = Console.ReadLine();
                    GoodStudents.Add( new GoodStudent(Name,DOB,Gender,PhoneNumber,UniversityName,gradeLevel,GPA,BestAwardName));
                    break;
                
                case GradeLevel.Normal:
                    Console.WriteLine("Please enter entry test score:");
                    double EntryTestScore;
                ReadEntryTestScore:
                    try
                    {
                        input = Console.ReadLine();
                        if (!Double.TryParse(input, out EntryTestScore))
                        {
                            throw new Exception("Unknown input error!");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Please enter a valid entry test score:");
                        goto ReadEntryTestScore;
                    }

                    Console.WriteLine("Please enter TOEIC test score:");
                    double TOEICScore;
                ReadTOEICScore:
                    try
                    {
                        input = Console.ReadLine();
                        if (!Double.TryParse(input, out TOEICScore) )
                        {
                            throw new Exception("Unknown input error!");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Please enter a valid TOEIC score:");
                        goto ReadTOEICScore;
                    }
                    NormalStudents.Add(new NormalStudent(Name, DOB, Gender, PhoneNumber, UniversityName, gradeLevel, TOEICScore, EntryTestScore));
                    break;

                    
            }
            Console.WriteLine("Student added successfully!");
        }
        public List<Student> ChooseCandidate() {

            List<Student> students = new List<Student>();
            Console.WriteLine("Enter the number of candidates:");

            string input;
            int numCand;
        ReadNumCand:
            try
            {
                input = Console.ReadLine();
                
                if (!int.TryParse(input, out numCand) || numCand < 11 || numCand > 15)
                    throw new Exception("Unknown input error");
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please reenter the number of candidates you want to hire (11-15):");
                goto ReadNumCand;
            }

            if (GoodStudents.Count == numCand) students.AddRange(GoodStudents);
            else if(GoodStudents.Count < numCand)
            {
                students.AddRange(GoodStudents);
                NormalStudents.Sort((a,b) => {

                return a.EntryTestScore==b.EntryTestScore? ((a.TOEICScore == b.TOEICScore)?a.Name.CompareTo(b.Name):(a.TOEICScore.CompareTo(b.TOEICScore))) :a.EntryTestScore.CompareTo(b.EntryTestScore) ;
                });
                students.AddRange(NormalStudents.GetRange(GoodStudents.Count,numCand-GoodStudents.Count));
            }
            else
            {
                GoodStudents.Sort((a, b) =>
                {
                    return (a.GPA == b.GPA)? (a.Name.CompareTo(b.Name)) : a.GPA.CompareTo(b.GPA);
                });
                students.AddRange(GoodStudents.GetRange(GoodStudents.Count-numCand, numCand));
            }

            

            return students;
        }

        public List<Student> GetStudentList()
        {
            var list = new List<Student>();
            list.AddRange(GoodStudents);
            list.AddRange(NormalStudents);
            list.Sort((a, b) => a.Name==b.Name?a.PhoneNumber.CompareTo(b.PhoneNumber): b.Name.CompareTo(a.Name));
            return list;
        }
        public void Print(List<Student> collection)
        {
            Console.WriteLine();
            foreach (Student item in  collection)
            {
                Console.WriteLine(item.ShowMyInfo());
            }
            Console.WriteLine();
        }

        static void ValidateName(string input,out string Name)
        {
            if (input.Length < 10) throw new InvalidFullNameException("Name too short (less than 10 character)!");
            if (input.Length > 50) throw new InvalidFullNameException("Name too long (more than 50 characters)!");
            Name = input;
        }
        static void ValidateDOB(string input, out DateTime DOB)
        {
            if (!DateTime.TryParse(input, CultureInfo.CreateSpecificCulture("fr-FR"), out DOB))
                throw new InvalidDOBException("The DOB must be enter with (dd/mm/yyyy) format.");
        }
        static void ValidatePhoneNumber(string input,out string number)
        {
            string[] start = { "090", "098", "091", "031","035", "038" };
            bool valid = false;
            foreach (string s in start)
            {
                valid = valid|| input.StartsWith(s);
                if (valid) break;
            }
            if (!valid) throw new InvalidPhoneNumberException($"Phone number must start with {string.Join(", ", start)}!");

            number = input;
        }
    }
}
