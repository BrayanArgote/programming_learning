using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Dependency_Inversion_principle.Services
{
    public interface IAppLogger
    {
        bool Add(int? userId, string action, string level);
    }
}
