using System;

namespace WebApi.Core.Entities
{
  public abstract class EntityBase
  {
    public Guid Id { get; private set; }

    public EntityBase()
    {
      Id = Guid.NewGuid();
    }
  }
}
