using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingSystem.Application.Interfaces
{
    public interface IGetAllQueryHandler< TResult>
    {
      public  Task<TResult> Handle(); 
    }
}
