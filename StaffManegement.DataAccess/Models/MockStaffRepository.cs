using System.Collections.Generic;
using System.Linq;

namespace StaffManagement.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private List<Staff> _staffs = null;

        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff(){Id = 1, FirstName = "Malik", LastName = "Shox", Email = "usmonov@gmail.com", Department = Departmenst.Admin},
                new Staff(){Id = 2, FirstName = "Salohiddin", LastName = "Ayyubiy", Email = "usmonov@gmail.com", Department = Departmenst.Production},
                new Staff(){Id = 3, FirstName = "Usmon", LastName = "G'oziy", Email = "usmonov@gmail.com", Department = Departmenst.Sales},
            };
        }

        public Staff Create(Staff staff)
        {
            staff.Id = _staffs.Max(x => x.Id) + 1;
            _staffs.Add(staff);
            return staff;
        }

        public Staff Delete(int id)
        {
            var staff = _staffs.FirstOrDefault(x => x.Id == id);
            if (staff != null)
            {
                _staffs.Remove(staff);
            }
            return staff;
        }

        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id == id);
        }

        public IEnumerable<Staff> GetAll()
        {
            return _staffs;
        }

        public Staff Update(Staff updateStaff)
        {
            var staff = _staffs.FirstOrDefault(x => x.Id == updateStaff.Id);
            if (staff != null)
            {
                staff.FirstName = updateStaff.FirstName;
                staff.LastName = updateStaff.LastName;
                staff.Email = updateStaff.Email;
                staff.Department = updateStaff.Department;
            }
            return staff;
        }
    }
}
