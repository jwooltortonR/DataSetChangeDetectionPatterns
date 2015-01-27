using System;
using R.DataSetChangeDetection.Strategies.Interfaces.Entities;

namespace R.DataSetChangeDetection.Strategies.Entities
{
    public class BruteForceEntity : IBruteForceEntity
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
