namespace Employee_Management_Application.Response
{
    public class EmployeeResponse
    {
        private int _EmpID;

        public int EmpID
        {
            get => _EmpID;
            set => _EmpID = value;
        }

        private string _FirstName;

        public string FirstName
        {
            get => _FirstName;
            set => _FirstName = value;
        }

        private string _LastName;

        public string LastName
        {
            get => _LastName;
            set => _LastName = value;
        }

        private string _Department;

        public string Department
        {
            get => _Department;
            set => _Department = value;
        }

        private string _EmailId;

        public string EmailId
        {
            get => _EmailId;
            set => _EmailId = value;
        }

        private DateTime _DateOfJoining;

        public DateTime DateOfJoining
        {
            get => _DateOfJoining;
            set => _DateOfJoining = value;
        }

    }
}
