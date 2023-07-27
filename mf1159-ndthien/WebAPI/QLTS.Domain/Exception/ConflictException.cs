using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Domain
{
    public class ConflictException : Exception
    {
        #region Fields
        public int ErrorCode { get; set; }
        #endregion

        #region Contructors

        public ConflictException()
        {

        }

        public ConflictException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public ConflictException(string message) : base(message) { }
        public ConflictException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
        #endregion
    }
}
