using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Zen.Domain.Entities.Entity;
using Zen.Domain.Events;
using ZenAchitecture.Domain.Shared.Events;

namespace ZenAchitecture.Domain.Shared.Entities.Geography
{
    public class City : Entity, IHasDomainEvent
    {

        protected City() { }

        public string Name { get; private set; }

        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; }

        public static City Create(string name)
        {
            var city = new City();

            city. Name = name;
            city.DomainEvents ??= new List<DomainEvent>();
            city.DomainEvents.Add(new CityCreatedEvent(city, Guid.NewGuid()));
            return city;
        }



        public void UpdateInfo(string name) => Name = name;

        public City Copy()
        {
            var entity = new City
            {
                Name = this.Name

            };

            return entity;
        }

    }
}