namespace KinderSurprise.Model
{
	public class Instructions : BaseObject
	{
		public virtual string Name { get; set; }
		public virtual Figur Fk_Figur_Id { get; set; }
		
		public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Instructions)) return false;
            return Equals((Instructions)obj);
        }

        public virtual bool Equals(Instructions other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other, this);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return this != null ? this.GetHashCode() : 0;
            }
        }
	}
}
