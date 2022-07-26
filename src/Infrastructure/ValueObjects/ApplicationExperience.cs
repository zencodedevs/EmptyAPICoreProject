using System;
using System.Collections.Generic;

namespace ZenAchitecture.Domain.ValueObjects
{
    public class ApplicationExperience : Zen.Domain.Values.ValueObject
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Company { get; private set; }

        public bool IsCurrent { get; set; }

        public DateTime FromDate { get; private set; }

        public DateTime? ToDate { get; private set; }


        public static ApplicationExperience Create(string title, string description, DateTime fromDate, DateTime? toDate, string company, bool isCurrent)
        {
            var entity = new ApplicationExperience
            {
                Title = title,
                Description = description,
                FromDate = fromDate,
                ToDate = toDate,
                Company = company,
                IsCurrent = isCurrent
            };
            return entity;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Title;
            yield return Description;
            yield return Company;
            yield return FromDate;
            yield return ToDate;
        }


    }
}
