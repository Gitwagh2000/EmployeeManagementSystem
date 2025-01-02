using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_Application.Model
{
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }

        private string _FirstName;

        [Required]
        [DataType("varchar(100)")]
        public string FirstName
        {
            get => _FirstName;
            set => _FirstName = value;
        }

        private string _LastName;

        [Required]
        [DataType("varchar(100)")]
        public string LastName
        {
            get => _LastName;
            set => _LastName = value;
        }

        private string _Department;

        [Column(TypeName = "varchar(50)")]
        public string Department
        {
            get => _Department;
            set => _Department = value;
        }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Column(TypeName = "varchar(70)")]
        public string EmailID { get; set; }

        public DateTime DateOfJoining { get; set; }
    }
}
