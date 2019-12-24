using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLaptop_Data.Infrastructure;
using WebLaptop_Data.Repositories;
using WebLaptop_Model.Models;

namespace WebLaptop_Service
{
    public interface IFeedbackService
    {
        Feedback Create(Feedback feedback);
        void Save();
    }
    public class FeedbackService : IFeedbackService
    {
        IFeedbackRepository _feedbackRepository;
        IUnitOfWork _unitOfWork; 
        public FeedbackService(IFeedbackRepository feedbackRepository,IUnitOfWork unitOfWork)
        {
            _feedbackRepository = feedbackRepository;
            _unitOfWork = unitOfWork;
        }
        public Feedback Create(Feedback feedback)
        {
            return _feedbackRepository.Add(feedback);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
