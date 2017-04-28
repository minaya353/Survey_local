#region

using System;

#endregion

namespace Survey.Exceptions
{
    /// <summary>
    /// This class extends 'Exception' including an additional int property to 
    /// represent a SMRT specific Exception code
    /// </summary>
    public class CommonException : Exception
    {
        public int Code { get; set; }

        public CommonException(int code, string message) :
            base(message)
        {
            this.Code = code;
        }
    }
}