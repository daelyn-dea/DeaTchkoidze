using Mapster;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Application.Validators;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.RankHistories
{
    public class RankHistoryService : IRankHistoryService
    {
        private readonly IRankHistoryRepository _repository;
        private readonly IValidatorService _validator;

        public RankHistoryService(IRankHistoryRepository repository, IValidatorService validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async  Task Create(RankHistoryRequestModel rankModel,  CancellationToken cancellationToken)
        {
            if(! await _validator.ExistsUserById(rankModel.UserId, cancellationToken))
            {
                throw new UserNotFoundException($"{rankModel.UserId}");
            }
            if (!await _validator.ExistsPizzaById(rankModel.PizzaId, cancellationToken))
            {
                throw new PizzaNotFoundException($"{rankModel.PizzaId}");
            }
            if (!await _validator.ExistsRankByUserIdAndPizzaId(rankModel.UserId, rankModel.PizzaId, cancellationToken))
            {
                throw new UserDoesnotHaveOrderOfThisPizza($"{rankModel.UserId}, {rankModel.PizzaId}");
            }
            var rankToInsert = rankModel.Adapt<RankHistory>();

            await _repository.Create(rankToInsert, cancellationToken);
        }

        public async Task<RankHistoryResponseModel> Get(int pizzaId, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsPizzaById(pizzaId, cancellationToken))
                throw new PizzaNotFoundException($"{pizzaId}");

            var result = await _repository.Get(pizzaId, cancellationToken);
            return result;
        }
    }
}
