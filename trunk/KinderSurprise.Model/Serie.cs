using System;

namespace KinderSurprise.Model
{
    public class Serie : Object
    {
        public virtual DateTime PublicationYear { get; set; }
        public virtual Category Category { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Serie)) return false;
            return Equals((Serie)obj);
        }

        public virtual bool Equals(Serie other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Category, Category);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Category != null ? Category.GetHashCode() : 0;
            }
        }
    }
}
