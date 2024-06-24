using System.Collections.Generic;

namespace StaffManagement.Models
{
    public interface IStaffRepository
    {
        Staff Get(int id);

        IEnumerable<Staff> GetAll();

        Staff Create(Staff staff);

        Staff Update(Staff staff);

        Staff Delete(int id);
    }
}
