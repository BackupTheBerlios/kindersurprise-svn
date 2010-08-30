namespace KinderSurprise.Mapper
{
    public class Figur
    {
        public virtual int FigurId { get; set; }
        public virtual string FigurName { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Serie Serie { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Figur)) return false;
            return Equals((Figur)obj);
        }

        public virtual bool Equals(Figur other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Serie, Serie);
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
