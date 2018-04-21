using System;

namespace Demo.Entities
{
    public abstract class Entity<T> where T : Entity<T>
    {
        public virtual int ID { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as T;
            if (other == null)
                return false;
            var thisIsNew = ID == 0;
            var otherIsNew = other.ID == 0;
            if (thisIsNew && otherIsNew)
                return ReferenceEquals(this, other);
            
            return ID.Equals(other.ID);
        }

        private int? oldHashCode;

        public override int GetHashCode()
        {
            if (oldHashCode.HasValue)
                return oldHashCode.Value;
            var thisIsNew = ID == 0;
            if (thisIsNew)
            {
                oldHashCode = base.GetHashCode();
                return oldHashCode.Value;
            }
            
            return ID.GetHashCode();
        }

        public static bool operator == (Entity<T> left, Entity<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator != (Entity<T> left, Entity<T> right)
        {
            return !Equals(left, right);
        }
    }
}
