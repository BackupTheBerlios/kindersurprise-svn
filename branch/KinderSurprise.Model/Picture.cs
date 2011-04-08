namespace KinderSurprise.Model
{
	public class Picture : BaseObject
	{
        public virtual string Path { get; set; }
		public virtual Serie Serie { get; set; }
		public virtual Figur Figur { get; set; }
		public virtual Instructions Instructions { get; set; }
		
		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Picture)) return false;
            return Equals((Picture)obj);
        }

        public virtual bool Equals(Picture other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other, this);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Serie != null ? Serie.GetHashCode() : 0;
            }
        }
	}
}
