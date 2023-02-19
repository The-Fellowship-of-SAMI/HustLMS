using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterManagement.Shared.Models
{
    public class Notification : BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public String Title { get; set; }

        public string Content { get; set; }
    }
}
