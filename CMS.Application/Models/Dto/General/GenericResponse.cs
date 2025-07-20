using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMS.Application.Models.Dto.General
{
    public class GenericResponse<T> : UseCaseResponseMessage
    {
        public T Data;
        public IEnumerable<Error> Errors;
        public GenericResponse(IEnumerable<Error> errors, bool success = false, string message = null)
            : base(success, message)
        {
            Errors = errors;
        }
        public GenericResponse(T data, bool success = false, string message = null)
        : base(success, message)
        {
            Data = data;
        }
        public GenericResponse(bool success = false, string message = null)
            : base(success, message)
        {

        }
    }

    public abstract class UseCaseResponseMessage
    {
        public bool Success { get; }
        public string Message { get; }

        protected UseCaseResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }
    }

    public sealed class Error
    {
        public string Code { get; }
        public string Description { get; }
#if DEBUG
        public string Stack { get; }
#endif

        public Error(string code, string description, string stack = null)
        {
            Code = code;
            Description = description;
            Stack = stack;
        }
    }
}
