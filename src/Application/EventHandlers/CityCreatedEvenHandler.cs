using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zen.Domain.Events;
using ZenAchitecture.Domain.Events;

namespace ZenAchitecture.Application.EventHandlers
{
    public class CityCreatedEvenHandler : INotificationHandler<DomainEventNotification<CityCreatedEvent>>
    {
        private readonly ILogger<CityCreatedEvenHandler> _logger;

        public CityCreatedEvenHandler(ILogger<CityCreatedEvenHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(DomainEventNotification<CityCreatedEvent> notification, CancellationToken cancellationToken)
        {
            _logger.LogTrace("CityCreatedEvenHandler {@event}", notification);
        }
    }
}
