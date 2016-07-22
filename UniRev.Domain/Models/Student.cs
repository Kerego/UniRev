using System;
using System.Collections.Generic;
using UniRev.Domain.Interfaces;

namespace UniRev.Domain.Models
{
	public class Student : User, IReviewer
	{
		public string Group { get; set; }
		public string Description => $"Student {Group} {Name}";
		public ICollection<Review> Reviews { get; set; } = new List<Review>();
		public Student(string name, string password) : base(name, password)
		{
		}
		protected Student()
		{
			
		}
	}
}