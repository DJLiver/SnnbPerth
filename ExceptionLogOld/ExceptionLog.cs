﻿using ExceptionLog.Models;

using Common.Extensions;
namespace ExceptionLog;
public static class ExLog
{
    public static void Log(Exception ex, 
        [System.Runtime.CompilerServices.CallerFilePathAttribute] string filePath = "",
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0,
        string additional = "Nil")
    {
        ExceptionLogContext elc = new ExceptionLogContext();

        Log log = new Log
        {
            Application = filePath.Truncate(128),
            MemberName = memberName.Truncate(128),
            DateStamp = DateTime.Now,
            Message = ex.Message.Truncate(1024),
            LineNumber = lineNumber,
        };

        log.Additional = additional.Truncate(1024);
        if (additional == "Nil")
        {
            if(ex.InnerException is not null)
            { 
                log.Additional = ex.InnerException.Message.Truncate(1024);
            }
        }

        elc.Logs.Add(log);
        elc.SaveChanges();
    }

}
