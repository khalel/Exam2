using AutoMapper;
using QLESS.Contract.Response;
using QLESS.Controller.Service;
using System.Collections.Generic;

namespace QLESS.Domain.Service
{
    public class CardRegTypeService : ICardRegTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardRegTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public object GetCardRegTypes()
        {
            var cardRegTypes = _unitOfWork.CardRegTypes.GetCardRegTypes();
            var response = new GetCardRegTypesResponse();
            response.CardRegTypes = _mapper.Map<IEnumerable<Contract.Model.CardRegType>>(cardRegTypes);
            return response;
        }
    }
}
