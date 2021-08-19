using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactDemo.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Author { get; set; }
		public string CommentText { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
