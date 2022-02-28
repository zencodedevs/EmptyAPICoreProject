﻿using System;
using Zen.Domain.Entities.Attributes;
using Zen.Domain.Events;
using ZenAchitecture.Domain.Entities.Geography;

namespace ZenAchitecture.Domain.Events
{
    [ProcessedByEventProcessor]
    public class CityCreatedEvent : DomainEvent
    {
        public CityCreatedEvent(City item, Guid? tenantId) : base(streamId: item?.Id.ToString(), tenatId: tenantId)
        {
            Item = item;
        }
        public City Item { get; }
    }
}
