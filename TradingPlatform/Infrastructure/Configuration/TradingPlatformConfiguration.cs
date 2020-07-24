using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Infrastructure.Configuration
{
    public class TradingPlatformConfiguration
    {
        public Notification Notification { get; set; }

        public double SyncCurrencyRateFrequencyHours { get; set; }

        public CurrencyApi CurrencyApi { get; set; }

    }

    public class Notification
    {
        public Sms Sms { get; set; }

        public Email Email { get; set; }
    }

    public class Sms
    {

    }

    public class Email
    {
        public string SmtpServer { get; set; }

        public string SenderEmail { get; set; }

        public string AuthenticationEmail { get; set; }

        public string AuthenticationEmailPassword { get; set; }

        public string DefaultEmailSubject { get; set; }

    }

    public class CurrencyApi
    {
        public string ApiHost { get; set; }

        public string ApiUrl { get; set; }
    }
}
