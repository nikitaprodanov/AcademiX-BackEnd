using System.Collections.Generic;

using AcademiX.Models;

namespace AspNetCoreDemo.Tests.Services
{
	public class TestHelper
    {
		public static Reviewer GetTestReviewer()
		{
			return new Reviewer()
			{
				Id = 1,
				Cabinet = 7,
				WorkingTime = "12:00 - 17:00"
			};
		}

        public static List<Reviewer> GetReviewers()
        {
            List<Reviewer> reviewers = new List<Reviewer>()
            {
                new Reviewer()
                {
                   Id = 1,
                   Cabinet = 7,
                   WorkingTime = "12:00 - 17:00"
                },
                new Reviewer
                {
                   Id = 2,
                   Cabinet = 8,
                   WorkingTime = "12:00 - 17:00"
                },
                new Reviewer
                {
                   Id = 3,
                   Cabinet = 9,
                   WorkingTime = "12:00 - 17:00"
                }
            };

            return reviewers;
        }
    }
}
