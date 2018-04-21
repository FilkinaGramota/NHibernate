using System;
namespace Demo.Entities
{
    public class Name
    {
        public string FirstName { get; protected set; }
        public string MiddleName { get; protected set; }
        public string LastName { get; protected set; }

        public Name()
        {
            FirstName = "defaultFirstName";
            MiddleName = "defaultMiddleName";
            LastName = "defaultLastName";
        }

        public Name (string FirstName, string MiddleName, string LastName)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentException("First name must be defined!");
            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("Last name must be defined!");
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = FirstName.GetHashCode();
                result = (result * 397) ^ (MiddleName == null ? 0 : MiddleName.GetHashCode());
                result = (result * 397) ^ LastName.GetHashCode();
                return result;
            }
        }

        public bool Equals(Name other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Equals(this.LastName, other.LastName) &&
                Equals(this.MiddleName, other.MiddleName) &&
                Equals(this.FirstName, other.FirstName);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Name);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
        }
    }
}
