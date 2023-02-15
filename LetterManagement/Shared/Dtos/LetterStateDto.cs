using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterManagement.Shared.Dtos
{
    public class LetterStateDto
    {
        public Guid LetterId { get; set; }
        public DateTime? ReceivedDate { get; set; } 

        public DateTime? FinishedDate { get; set; } 
    }
}
