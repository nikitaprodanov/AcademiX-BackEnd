using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;
using System;

namespace AcademiX.Services
{
    public class ReviewerService : IReviewerService
    {
        private readonly IReviewerRepository _repository;
        public ReviewerService(IReviewerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Reviewer> GetAllReviewers()
        {
            return _repository.GetAllReviewers();
        }


        public Reviewer GetReviewerById(int id)
        {
            try
            {
                return _repository.GetReviewerById(id);
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Reviewer with this id was not found.");

            }
        }

        public Reviewer CreateReviewer(Reviewer Reviewer)
        {
            try
            {
                var id = _repository.GetAllReviewers()
                    .OrderByDescending(sp => sp.Id)
                    .Select(sp => sp.Id)
                    .FirstOrDefault();

                Reviewer.Id = ++id;

               return _repository.CreateReviewer(Reviewer);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public int UpdateReviewer(Reviewer Reviewer)
        {
            try
            {

                var ReviewerToChange = _repository.GetReviewerById(Reviewer.Id);

                return _repository.UpdateReviewer(ReviewerToChange, Reviewer);

            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Reviewer with this id was not found.");

            }
        }

        public int DeleteReviewer(int id)
        {
            try
            {
                _repository.GetReviewerById(id);

                return _repository.DeleteReviewer(id);
            }

            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException();
            }
        }

    }
}
