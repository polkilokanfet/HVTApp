using System;

namespace HVTApp.Infrastructure
{
    [Serializable]
    public abstract class BaseEntity : IBaseEntity, IComparable
    {
        public Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;

            if ((obj is BaseEntity other) == false) return false;
            if (Equals(this.Id, other.Id)) return true;
            return base.Equals(obj);
        }

        protected bool Equals(BaseEntity other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return Id.Equals(other.Id);
        }

        public virtual int CompareTo(object other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            return string.Compare(this.ToString(), other.ToString(), StringComparison.Ordinal);
        }
    }
}