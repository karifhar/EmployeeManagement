using System.ComponentModel.DataAnnotations;


namespace EmployeeManagement.Ultilities
{
    public class ValidEmailDomain : ValidationAttribute
    {
        private readonly string _allowedDomain;

        public ValidEmailDomain(string allowedDomain)
        {
            _allowedDomain = allowedDomain;
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string[] strings= value!.ToString().Split('@');
            return strings[1]?.ToUpper() == _allowedDomain.ToUpper();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}