using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProject.Common.ToastAlert.Interfaces
{
    public interface IToastAlert
    {
        void ShortAlert(string message);
        void LongAlert(string message);
    }
}
