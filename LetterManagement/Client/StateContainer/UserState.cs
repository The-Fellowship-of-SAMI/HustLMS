using LetterManagement.Shared.Models;

namespace LetterManagement.Client.StateContainer
{
    public class UserState
    {
        public string? Token { get; set; }

        public DateTime ExpiredDate { get; set; }

        public string? Email { get; set; }

        public Guid UserId { get; set; }
        public Roles Role { get; set; } 

        public Student? Student { get; set; }

        public Manager? Manager { get; set; }

        public async Task Set(UserState userState)
        {
            this.Token = Token;
            this.Manager = userState.Manager;
            this.Student = userState.Student;
            this.Role = userState.Role;
            this.UserId = userState.UserId;
            this.Email = userState.Email;
            NotifyStateChanged();
        }

        public void SetStudent(Student student)
        {
            this.Student = student;
            this.Role = Roles.Student;
            NotifyStateChanged();
        }

        public void SetManager(Roles role, Manager manager)
        {
            this.Manager = manager;
            this.Role = role;
            NotifyStateChanged();
        }
        public void ClearState()
        {
            this.Student = null;
            this.Manager = null;
            this.Token = null;
            this.Email = null;
            NotifyStateChanged();
        }

        
        public override string ToString()
        {
            return $"{nameof(Role)}: {Role}, {nameof(Student)}: {Student}, {nameof(Manager)}: {Manager}";
        }
        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }


}
