using LetterManagement.Shared.Models;

namespace LetterManagement.Client.StateContainer
{
    public class UserState
    {
        public Roles Role { get; set; } 

        public Student? Student { get; set; }

        public Manager? Manager { get; set; }


    }

    public enum Roles
    {
        Student = 0,
        Manager = 1, 
        SuperManager = 2,
    }
}
