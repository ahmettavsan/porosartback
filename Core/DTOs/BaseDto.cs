using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class BaseDto:IEntity
    {
        public int Id { get; set; } 
    }
}
