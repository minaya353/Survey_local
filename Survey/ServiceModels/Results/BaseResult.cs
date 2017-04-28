#region

using SMRTLib.Models;

#endregion

namespace EP.ServiceModels.Results
{
    /// <summary>
    /// This class is a SMRT web-server response base class from which all other web server responses
    /// are derived. It provides error handling to devices for unsucsessful requests to the SMRT web server
    /// </summary>
    public class BaseResult
    {
        public string Status { get; set; }
        public Error Error { get; set; }

        public BaseResult()
        {
            Error = new Error();
        }
    }
}