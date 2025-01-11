using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingSystem.Application.Interfaces
{
    public interface IGetQueryHandler<Tin, TRes>
    {
        public Task<TRes> Handle(Tin input);
    }
}
