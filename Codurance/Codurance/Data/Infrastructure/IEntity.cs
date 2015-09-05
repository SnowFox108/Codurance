using System;

namespace Codurance.Data.Infrastructure
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
