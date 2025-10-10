using System;

namespace HVTApp.Services.GetProductService
{
    public class DependencyParameterException : Exception
    {
        public DependencyParameterException(string s) : base(s)
        {
        }
    }
}