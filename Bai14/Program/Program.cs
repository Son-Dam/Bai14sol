


using System.Net.Quic;

namespace Bai14.Program
{
    enum UserAction
    {
        
        Add,
        Recruit,
        Print,
        Quit
        
    }
    class Program
    {
        public static void Main()
        {
            bool quit = false;
            Manager manager = new Manager();
        ReadUserAction:

            Console.WriteLine("Hello, this is the candidate manager.\n" +
                "Please choose one of the folllowing actions to continue:\n" +
                "Type Add or 0 to add a new student into the candidate database\n" +
                "Type Recruit or 1 to see the best candidates for you pick by the system\n" +
                "Type Print or 2 to see of all the candidates we have in the database\n" +
                "Type Quit or 3 to quit the program.");


        
            
            UserAction userAction;
            try
            {
                string input = Console.ReadLine();
                if(!Enum.TryParse(input,true, out userAction))
                {
                    throw new Exception("Unknown input error!");

                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter one of the valid actions.");
                goto ReadUserAction;
                
            }

            
            switch(userAction)
            {
                case UserAction.Add:
                    manager.AddStudent();
                    break;
                case UserAction.Recruit:
                    manager.Print(manager.ChooseCandidate());
                    break;
                case UserAction.Print:
                    manager.Print(manager.GetStudentList());
                    break;
                case UserAction.Quit:
                    Console.WriteLine("Program exitting...");
                    quit = true;
                    break;

            }
            if( !quit ) { goto ReadUserAction; }

        }
    }
}