using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Infrastructure.Services.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(string type, string text, string subject, string receiverData);

        Task SendEmailAsync(string message, string subject, string receiverEmail);
    }
}
