using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReversoContextGetExample.Models
{
	public class ReversoContextExample
	{
        public Guid Id { get; set; }
		public string? SourceLanguage { get; set; }
		public string? Content { get; set; }
	}
}

