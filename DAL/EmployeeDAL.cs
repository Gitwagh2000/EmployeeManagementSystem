using Employee_Management_Application.Model;
using Employee_Management_Application.Request;
using Employee_Management_Application.Response;

namespace Employee_Management_Application.DAL
{
    public class EmployeeDAL
    {

        private readonly DatabaseContext _context;

        public EmployeeDAL(DatabaseContext context)
        {
            _context = context;
        }

        public int Insert(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee.EmpID;
        }

        internal int Update(Employee model)
        {
            int result = -1;
            _context.Employee.Update(model);
            _context.SaveChanges();
            result = model.EmpID;

            return result;
        }

        internal int Delete(Employee ObjModel)
        {
            _context.Employee.Remove(ObjModel);
            _context.SaveChanges();
            return ObjModel.EmpID;
        }

        internal Employee SelectByID(int EmpID)
        {
            return _context.Employee.Find(EmpID);
        }

        public List<EmployeeResponse> SearchEmployee(SearchRequest request)
        {
            List<EmployeeResponse> list = new List<EmployeeResponse>();

           list = (from emp in _context.Employee

                    select new EmployeeResponse
                    {
                        EmpID = emp.EmpID,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        DateOfJoining = emp.DateOfJoining,
                        Department = emp.Department,
                        EmailId = emp.EmailID,
                    }).ToList(); ;

            if (!string.IsNullOrEmpty(request.FirstName))
            {
                list = list.Where(e => e.FirstName.Contains(request.FirstName)).ToList();
            }

            if (!string.IsNullOrEmpty(request.LastName))
            {
                list = list.Where(e => e.LastName.Contains(request.LastName)).ToList();
            }

            if (!string.IsNullOrEmpty(request.Department))
            {
                list = list.Where(e => e.Department == request.Department).ToList();
            }

            if (request.FromDate.HasValue)
            {
                list = list.Where(e => e.DateOfJoining >= request.FromDate).ToList();
            }

            if (request.ToDate.HasValue)
            {
                list = list.Where(e => e.DateOfJoining <= request.ToDate).ToList();
            }

            return list;

        }
    }
}
