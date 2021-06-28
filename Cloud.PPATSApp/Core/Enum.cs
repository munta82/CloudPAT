using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Core
{
    public enum ApplicationPages
    {
        Admin,
        EmployeeSettings,
        AdminSettings,
        PPAT,
        PIG,
        SS
    }

    public enum RoleName
    {
        NotAssgined,
        User,
        Supervisor,
        Admin,
        TechSupport
    }
}
