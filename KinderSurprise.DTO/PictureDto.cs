using KinderSurprise.Mapper;
using System;

namespace KinderSurprise.DTO
{
	public class PictureDto
	{
		public int Id { get; set; }
		public string Path { get; set; }
		public Figur Figur { get; set; }
		public Serie Serie { get; set; }
		public Instructions Instructions { get; set; }
		
		public PictureDto (int id, string path, Figur figur, Serie serie, Instructions instructions)
		{
			Id = id;
			Path = path;
			Figur = figur;
			Serie = serie;
			Instructions = instructions;
		}
	}
}
