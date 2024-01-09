using System.Collections.Generic;
using System.Linq;
using AcademiX.Repositories.Contracts;
using AspNetCoreDemo.Tests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcademiX.Models;

using Moq;
using AcademiX.Services;
using AcademiX.Exceptions;

namespace AcademiXTests.Services
{
	[TestClass]
	public class GetReviewer_Should
	{
		[TestMethod]
		public void ReturnCorrectReviewer_When_ParamsAreValid()
		{
			// Arrange        
			Reviewer expectedReviewer = TestHelper.GetTestReviewer();


			var repositoryMock = new Mock<IReviewerRepository>();
			List<Reviewer> reviewers = TestHelper.GetReviewers();

			repositoryMock
				.Setup(repo => repo.GetReviewerById(It.IsAny<int>()))
				.Returns<int>(id => reviewers.Where(b => b.Id == id).FirstOrDefault());

			var sut = new ReviewerService(repositoryMock.Object);

            // Act
            Reviewer actualReviewer = sut.GetReviewerById(id: expectedReviewer.Id);

            // Assert
            Assert.AreEqual(expectedReviewer.Id, actualReviewer.Id);
            Assert.AreEqual(expectedReviewer.Cabinet, actualReviewer.Cabinet);
            Assert.AreEqual(expectedReviewer.WorkingTime, actualReviewer.WorkingTime);
        }

		[TestMethod]
		public void ThrowException_When_ReviewerNotFound()
		{
			// Arrange
			var repositoryMock = new Mock<IReviewerRepository>();

			repositoryMock
				.Setup(repo => repo.GetReviewerById(It.IsAny<int>()))
				.Throws(new EntityNotFoundException());

			// Act
			var sut = new ReviewerService(repositoryMock.Object);

			Assert.ThrowsException<EntityNotFoundException>(() => sut.GetReviewerById(id: 1));
		}
	}
}
