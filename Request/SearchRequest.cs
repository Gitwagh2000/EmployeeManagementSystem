
namespace Employee_Management_Application.Request
{
    public class SearchRequest
    {

        public DateTime? ToDate;

        public DateTime? FromDate;

        private int _PageNumber;

        public int PageNumber
        {
            get => _PageNumber;
            set => _PageNumber = value;
        }

        private int _PageSize;

        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = value;
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
    }
}
