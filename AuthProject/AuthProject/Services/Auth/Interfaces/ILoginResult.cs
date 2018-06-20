using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProject.Services.Auth.Interfaces
{
    public interface IAuthResult<T> where T:class
    {
        bool IsSuccess { get; set; }
        IEnumerable<string> Errors { get; set; }
        T GetData();
    }
}
