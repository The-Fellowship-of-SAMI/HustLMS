using LetterManagement.Shared.Models;

namespace LetterManagement.Client.StateContainer
{
    public class UserState
    {
        public Roles Role { get; set; } 

        public Student? Student { get; set; }

        public Manager? Manager { get; set; }

        public void ClearState()
        {
            this.Student = null;
            this.Manager = null;
        }
    }


}
