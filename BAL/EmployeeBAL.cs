using Employee_Management_Application.DAL;
using Employee_Management_Application.Model;
using Employee_Management_Application.Request;
using Employee_Management_Application.Response;
using Employee_Management_Application.StaticModel;

namespace Employee_Management_Application.BAL
{
    public class EmployeeBAL
    {

        private readonly EmployeeDAL _employeeDAL;

        public EmployeeBAL(EmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        public string Insert(InsertRequest request)
        {
            string failureMessage = request.IsValidModalState();

            if (!failureMessage.Equals(StatusType.Ok))
                return failureMessage;

            try
            {
                Employee emp = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Department = request.Department,
                    EmailID = request.EmailId,
                    DateOfJoining = request.DateOfJoining
                };

                int id = _employeeDAL.Insert(emp);

                if (id <= 0)
                {
                    return Message.InsertFailure;
                }

                return StatusType.Ok;
            }
            catch (Exception)
            {
                return Message.ExceptionOccured;
            }
        }


        public EmployeeResponse SelectByID(int EmpID, out string failureMessage)
        {
            EmployeeResponse employeeResponse = new EmployeeResponse();

            if (EmpID < 0)
            {
                failureMessage = Message.InvalidID;
                return employeeResponse;
            }

            Employee ObjModel = null;

            try
            {
                ObjModel = _employeeDAL.SelectByID(EmpID);
            }
            catch (Exception ex)
            {
                failureMessage = Message.ExceptionOccured;
                return employeeResponse;
            }

            if (ObjModel == null)
            {
                failureMessage = "Data Not Found";
                return employeeResponse;
            }

            employeeResponse.FirstName = ObjModel.FirstName;
            employeeResponse.LastName = ObjModel.LastName;
            employeeResponse.Department = ObjModel.Department;
            employeeResponse.EmpID = ObjModel.EmpID;
            employeeResponse.EmailId = ObjModel.EmailID;
            employeeResponse.DateOfJoining = ObjModel.DateOfJoining;

            failureMessage = StatusType.Ok;
            return employeeResponse;
        }

        public string Update(UpdateRequest request)
        {
            string failureMessage = request.IsValidModalState();

            if (!failureMessage.Equals(StatusType.Ok))
                return failureMessage;

            Employee ObjModel = null;

            try
            {
                ObjModel = _employeeDAL.SelectByID(request.EmpID);
            }
            catch (Exception ex)
            {
                return Message.ExceptionOccured;
            }
            if (ObjModel == null) return failureMessage;

            ObjModel.FirstName = request.FirstName;
            ObjModel.LastName = request.LastName;
            ObjModel.Department = request.Department;
            ObjModel.EmailID = request.EmailId;
            ObjModel.DateOfJoining = request.DateOfJoining;

            int rowsAffected = -1;
            try
            {
                rowsAffected = _employeeDAL.Update(ObjModel);
            }
            catch (Exception ex)
            {
                return Message.ExceptionOccured;
            }

            if (rowsAffected <= 0)
            {
                return Message.UpdateFailure;
            }

            return StatusType.Ok;
        }

        public string Delete(int EmpID)
        {
            string failureMessage = "";
            if (EmpID < 0)
            {
                return failureMessage = Message.InvalidID;
            }

            Employee ObjModel = null;

            try
            {
                ObjModel = _employeeDAL.SelectByID(EmpID);
            }
            catch (Exception ex)
            {
                return Message.ExceptionOccured;
            }
            if (ObjModel == null) return failureMessage;

            int rowsAffected = -1;
            try
            {
                rowsAffected = _employeeDAL.Delete(ObjModel);
            }
            catch (Exception ex)
            {
                return Message.ExceptionOccured;
            }

            if (rowsAffected <= 0)
            {
                return Message.DeleteFail;
            }

            return StatusType.Ok;
        }


        public List<EmployeeResponse> SearchEmployeeByFilter(SearchRequest request)
        {
            List<EmployeeResponse> list = new List<EmployeeResponse>();
            try
            {
                list = _employeeDAL.SearchEmployee(request);

                var employees = list
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                return employees;
            }
            catch
            {
                return new List<EmployeeResponse>();
            }
        }

    }
}
