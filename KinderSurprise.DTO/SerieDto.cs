using System;
using KinderSurprise.Mapper;

namespace KinderSurprise.DTO
{
    public class SerieDto
    {
        public int SerieId { get; set; }
        public string SerieName { get; set; }
        public string Description { get; set; }
        public DateTime PublicationYear { get; set; }
        public Category Category { get; set; }

        public SerieDto(int id, string name, string desc, DateTime pubYear, Category category)
        {
            SerieId = id;
            SerieName = name;
            Description = desc;
            PublicationYear = pubYear;
            Category = category;
        }
    }
}
