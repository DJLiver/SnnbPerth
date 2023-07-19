using Common.Extensions;

using SnnbDB.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions;
//public static class ExceptionLog
//{
//    //public static HLog FormEntry(Exception ex,
//    //    [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
//    //    [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
//    //    [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0,
//    //    string additional = "Nil")
//    //{

//    //    HLog log = new HLog
//    //    {
//    //        Application = filePath.Truncate(128),
//    //        MemberName = memberName.Truncate(128),
//    //        DateStamp = DateTime.Now,
//    //        Message = ex.Message.Truncate(1024),
//    //        LineNumber = lineNumber,
//    //    };

//    //    log.Additional = additional.Truncate(1024);
//    //    if (additional == "Nil")
//    //    {
//    //        if (ex.InnerException is not null)
//    //        {
//    //            log.Additional = ex.InnerException.Message.Truncate(1024);
//    //        }
//    //    }
//    //    return log;

//    //}
//}
