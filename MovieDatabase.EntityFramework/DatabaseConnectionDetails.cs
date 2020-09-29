using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.EntityFramework
{
    public class DatabaseConnectionDetails
    {
        public string DatabaseServer { get; }
        public string DatabaseName { get; }
        public string DatabaseUser { get; }
        public string DatabasePassword { get; }
    }
}
