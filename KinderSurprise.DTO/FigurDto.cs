using System;
using KinderSurprise.Mapper;

namespace KinderSurprise.DTO
{
    public class FigurDto
    {
        
        public int FigurId { get; set; }
        public string FigurName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Serie Serie { get; set; }

		public FigurDto(int id, string name, string desc, decimal price, Serie serie)
        {
            FigurId = id;
            FigurName = name;
            Description = desc;
            Price = price;
            Serie = serie;
        }
    }
}
