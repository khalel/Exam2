using AutoMapper;
using QLESS.Contract.Response;
using QLESS.Controller.Service;
using System.Collections.Generic;

namespace QLESS.Domain.Service
{
    public class CardLoadHistService : ICardLoadHistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardLoadHistService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public object GetCardLoadHists()
        {
            var cardLoadHists = _unitOfWork.CardLoadHists.GetCardLoadHists();
            var response = new GetCardLoadHistsResponse();
            response.CardLoadHists = _mapper.Map<IEnumerable<Contract.Model.CardLoadHist>>(cardLoadHists);
            return response;
        }
    }
}
