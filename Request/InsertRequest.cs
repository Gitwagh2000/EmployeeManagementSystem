
using Employee_Management_Application.StaticModel;
using FluentValidation;
using FluentValidation.Results;

namespace Employee_Management_Application.Request
{
    public class InsertRequest
    {
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
        internal string IsValidModalState()
        {
            var validator = new InsertRequestValidator();
            ValidationResult results = validator.Validate(this);

            bool success = results.IsValid;
            IList<ValidationFailure> failures = results.Errors;

            return success ? StatusType.Ok : failures[0].ToString();
        }
    }
    public class InsertRequestValidator : AbstractValidator<InsertRequest>
    {
        public InsertRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(Message.InvalidFirstName);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(Message.InvalidLastName);
            RuleFor(x => x.EmailId).EmailAddress().WithMessage(Message.InvalidEmail);
        }
    }
}
