using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CusJoEmailWeb
{
	public class EmailList
	{[Key]
		public Guid Id { get; set; }
		public string email { get; set; }
		public bool emailverified { get; set; }
		public int countsent { get; set; }
		public bool replysent { get; set; }

		
	}
}
