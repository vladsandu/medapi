using System;
using BusinessEntities.Staff;

namespace BusinessServices.Staff {
    public interface IStaffServices {
        StaffEntity GetStaffById(int staffId);
    }
}