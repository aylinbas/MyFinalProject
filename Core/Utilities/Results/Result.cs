using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success)//this(success) sayesinde eğer iki parametre gelirse alttaki constructor da çalışır.
        {
            Message = message;
        }
        //overloading for without message
        public Result(bool success)
        {
            Success = success;
        }
        //setter yazmadık bu değişkenlerin sadece getter methodu var
        //fakat readonlyler constructurda set edilebilir yukardaki gibi.
        public bool Success { get; }

        public string Message { get; }
    }
}
