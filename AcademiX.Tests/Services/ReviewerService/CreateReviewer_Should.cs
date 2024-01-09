using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using AcademiX.Services;
using AspNetCoreDemo.Tests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace AcademiXTests.Services
{
	[TestClass]
	public class CreateReviewer_Should
	{
		[TestMethod]
		public void ReturnCorrectReviewer_When_ParamsAreValid()
		{
			// Arrange        
			Reviewer testReviewer = TestHelper.GetTestReviewer();
			var repositoryMock = new Mock<IReviewerRepository>();

			repositoryMock
				.Setup(repo => repo.GetReviewerById(It.IsAny<int>()))
				.Throws(new EntityNotFoundException());

            repositoryMock
                .Setup(repo => repo.CreateReviewer(It.IsAny<Reviewer>()))
                .Returns(testReviewer);

            var sut = new ReviewerService(repositoryMock.Object);

			// Act
			Reviewer actualReviewer = sut.CreateReviewer(testReviewer);

			// Assert
			Assert.AreEqual(testReviewer.Id, actualReviewer.Id);
			Assert.AreEqual(testReviewer.Cabinet, actualReviewer.Cabinet);
			Assert.AreEqual(testReviewer.WorkingTime, actualReviewer.WorkingTime);

		}
	}
}
