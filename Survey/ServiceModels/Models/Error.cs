#region

using System;
using System.Runtime.Serialization;
using Survey.Exceptions;

#endregion

namespace Survey.ServiceModels
{
    [DataContract]
    [Serializable]
    public class Error
    {
        [DataMember]
        public bool HasError { get; set; }

        [DataMember]
        public int Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Text { get; set; }

        public void Update(Exception e)
        {
            CommonException cex = e as CommonException;
            this.Code = cex != null ? cex.Code : 0;
            this.HasError = true;
            this.Message = e.Message;
            this.Text = e.ToString();

            /*if (e is DataCacheException)
            {
                SendErrorMessage(e);
            }*/
        }

        private void SendErrorMessage(Exception e)
        {
            
        }
    }
}