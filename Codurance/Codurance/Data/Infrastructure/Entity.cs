
using System;

namespace Codurance.Data.Infrastructure
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }

        #region Public Methods

        public bool IsTransient()
        {
            return this.Id == Guid.Empty;
        }

        public void GenerateNewIdentity()
        {
            if (IsTransient())
                this.Id = Guid.NewGuid();
        }

        public void ChangeCurrentIdentity(Guid identity)
        {
            if (identity != Guid.Empty)
                this.Id = identity;
        }

        #endregion

        #region Overrides Methods

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            var item = (Entity)obj;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion

    }
}
