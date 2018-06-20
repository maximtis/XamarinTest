using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AuthProject.Common.ValidationHelpers
{
    public class PasswordRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
                return false;
            var str = value as string;
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            Match match = regex.Match(str);

            return match.Success;
        }
    }
}
