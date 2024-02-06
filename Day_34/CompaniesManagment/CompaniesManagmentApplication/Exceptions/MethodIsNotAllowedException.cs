using System.Runtime.Serialization;

namespace CompaniesManagmentApplication.Exceptions
{
    [Serializable]
    public class MethodIsNotAllowedException : Exception
    {
        public string Code = "MethodDontAllowed";

        public MethodIsNotAllowedException(string message = "Method isn't allowed ") : base(message) { }
    }
}