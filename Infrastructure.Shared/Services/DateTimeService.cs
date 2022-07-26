
using ZenAchitecture.Domain.Interfaces;
using System;

namespace ZenAchitecture.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
