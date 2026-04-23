using _5_Dependency_Inversion_principle.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Dependency_Inversion_principle.Services
{
    public interface IAppLogReader
    {
        List<Log> GetAll();
    }
}
