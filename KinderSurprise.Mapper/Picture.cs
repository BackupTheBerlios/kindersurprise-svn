using System;

namespace KinderSurprise.Mapper
{
	public class Picture
	{
		public virtual int Id { get; set; }
        public virtual string Path { get; set; }
		public virtual Serie Fk_Serie_Id { get; set; }
		public virtual Figur Fk_Figur_Id { get; set; }
		public virtual Instructions Fk_Instructions_Id { get; set; }
		
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
                return this != null ? this.GetHashCode() : 0;
            }
        }
	}
}
