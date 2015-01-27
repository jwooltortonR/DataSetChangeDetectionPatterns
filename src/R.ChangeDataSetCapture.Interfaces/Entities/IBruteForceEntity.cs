using System;

namespace R.DataSetChangeDetection.Strategies.Interfaces.Entities
{
    public interface IBruteForceEntity
    {        
        Guid Id { get; set; }
        string Key { get; set; }
        object Value { get; set; }
    }
}
