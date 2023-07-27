﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Domain
{
    public class NotFoundException : Exception
    {
        #region Fields
        public int ErrorCode { get; set; }
        #endregion

        #region Contructors

        public NotFoundException()
        {

        }

        public NotFoundException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        } 
        #endregion

    }
}
