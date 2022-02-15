using AutoMapper;
using Microsoft.Extensions.Configuration;
using QLESS.Contract.Request;
using QLESS.Contract.Response;
using QLESS.Controller.Service;
using System;
using System.Collections.Generic;

namespace QLESS.Domain.Service
{
    public class CardService : ICardService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardService(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public object GetCards()
        {
            var cards = _unitOfWork.Cards.GetCards();
            var response = new GetCardsResponse();
            response.Cards = _mapper.Map<IEnumerable<Contract.Model.Card>>(cards);
            return response;
        }

        public object AddCard()
        {
            DateTime currDate = DateTime.Now;
            var card = _unitOfWork.Cards.AddCard(
                new Model.Card 
                { 
                    SerialNumber = Guid.NewGuid().ToString("N").ToUpper(),
                    PurchaseDate = currDate,
                    LastUsed = currDate
                });
            var cardLoadHist = _unitOfWork.CardLoadHists.AddCardLoadHist(
                new Model.CardLoadHist
                {
                    CardLoadRef = Guid.NewGuid(),
                    CardId = card.Id,
                    CardLoadDate = currDate,
                    CardLoadFr = 0,
                    CardLoadTo = decimal.Parse(_configuration["CardSettings:MinLoadValue"]),
                });

            return card;

        }

        public object GetCardBySerialNumber(string serialNumber)
        {
            var card = _unitOfWork.Cards.GetCardBySerialNumber(serialNumber);
            var response = _mapper.Map<Contract.Model.Card>(card);
            return response;
        }

        public object CardRegister(PostCardRegisterRequest request)
        {
            DateTime currDate = DateTime.Now;
            var card = _unitOfWork.Cards.GetCardBySerialNumber(request.SerialNumber);

            card.CardRegTypeId = request.CardRegTypeId;
            card.FirstName = request.FirstName;
            card.LastName = request.LastName;
            card.MiddleName = request.MiddleName;
            card.RegisterDate = currDate;

            _unitOfWork.Cards.UpdateCard(card);

            return card;
        }

        public object CardUse(string serialNumber)
        {
            DateTime currDate = DateTime.Now;
            var card = _unitOfWork.Cards.GetCardBySerialNumber(serialNumber);

            var cardLoadHist = new Model.CardLoadHist
            {
                CardLoadRef = Guid.NewGuid(),
                CardId = card.Id,
                CardLoadDate = currDate,
                CardLoadFr = card.CardLoad,
                Fare = decimal.Parse(_configuration["CardSettings:RegularFareMatrix"]),
            };

            if (card.CardRegTypeId > 1)
            {
                cardLoadHist.FareDiscount = decimal.Parse(_configuration["CardSettings:Discounts:DefaultDiscount"]);
                cardLoadHist.FareDailyAdditionalDiscount = decimal.Parse(_configuration["CardSettings:Discounts:DailyAdditionalDiscount"]);
            }

            card.LastUsed = currDate;

            // TODO: Add logic to check max daily additional discount has been consumed
            card.CardLoad
                = card.CardLoad
                - (cardLoadHist.Fare
                - (cardLoadHist.Fare * (cardLoadHist.FareDiscount + cardLoadHist.FareDailyAdditionalDiscount) / 100));
            
            cardLoadHist.CardLoadTo = card.CardLoad;
            cardLoadHist = _unitOfWork.CardLoadHists.AddCardLoadHist(cardLoadHist);

            _unitOfWork.Cards.UpdateCard(card);

            return card;
        }

        public object CardReload(string serialNumber, int amount)
        {
            DateTime currDate = DateTime.Now;
            var card = _unitOfWork.Cards.GetCardBySerialNumber(serialNumber);

            var cardLoadHist = new Model.CardLoadHist
            {
                CardLoadRef = Guid.NewGuid(),
                CardId = card.Id,
                CardLoadDate = currDate,
                CardLoadFr = card.CardLoad,
                CardLoadTo = card.CardLoad + amount,
                Fare = 0,
                FareDiscount = 0,
                FareDailyAdditionalDiscount = 0,
            };

            card.CardLoad = card.CardLoad + amount;

            cardLoadHist = _unitOfWork.CardLoadHists.AddCardLoadHist(cardLoadHist);

            _unitOfWork.Cards.UpdateCard(card);

            return card;
        }

    }
}
