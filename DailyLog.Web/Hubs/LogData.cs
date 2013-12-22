using System;
using System.Collections.Generic;
using config = System.Configuration.ConfigurationManager;
using DailyLog.Domain;
using DailyLog.Persistence;
using Microsoft.AspNet.SignalR;

namespace DailyLog.Web.Hubs
{
    public class LogData : Hub
    {
        private static readonly DayLogRepository _logDataRepository;

        static LogData()
        {
            _logDataRepository = new DayLogRepository(config.ConnectionStrings["mongo"].ConnectionString);
        }

        public DayLog GetLogData(DateTime date)
        {
            var dayLog = _logDataRepository.GetByDate(date.Date);

            if (dayLog != null)
            {
                return dayLog;
            }

            //TODO: make a new one from defaults
            return new DayLog
            {
                Date = date,
                LogItems = new List<LogItem>
                {
                    new LogItem {Name = "Push Ups", Number = 0},
                    new LogItem {Name = "Sit Ups", Number = 0},
                }
            };
        }

        public void Save(DayLog dayLog)
        {
            dayLog.Date = dayLog.Date.Date;
            _logDataRepository.Save(dayLog);
        }
    }
}