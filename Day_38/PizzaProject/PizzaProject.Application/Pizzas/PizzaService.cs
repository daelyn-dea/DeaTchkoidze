using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Application.Validators;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Pizzas
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _repository;
        private readonly IValidatorService _validator;

        public PizzaService(IPizzaRepository repository, IValidatorService validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<PizzaResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsPizzaById(id, cancellationToken))
                throw new PizzaNotFoundException(id.ToString());

            var result = await _repository.Get( id, cancellationToken);

                return result.Adapt<PizzaResponseModel>();
        }
        public async  Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(cancellationToken);

            if (result == null)
                throw new PizzaNotFoundException("Pizza Notfound");
            else
                return result.Adapt<List<PizzaResponseModel>>();
        }

        public async Task Create( PizzaRequestModel pizza, CancellationToken cancellationToken)
        {
            var pizzaToInsert = pizza.Adapt<Pizza>();

            await _repository.Create(pizzaToInsert, cancellationToken);
        }

        public async Task Update(int id,PizzaRequestModel pizza, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsPizzaById( id, cancellationToken))
                throw new PizzaNotFoundException(id.ToString());

            var pizzaToUpdate = pizza.Adapt<Pizza>();
            pizzaToUpdate.Id = id;
            await _repository.Update(pizzaToUpdate, cancellationToken);
        }

        public async Task UpdatePrice(int id, decimal price, CancellationToken cancellationToken)
        {
            if(!await _validator.ExistsPizzaById(id, cancellationToken))
                throw new PizzaNotFoundException(id.ToString());


            await _repository.UpdatePrice(id, price, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (! await _validator.ExistsPizzaById( id, cancellationToken))
                throw new PizzaNotFoundException(id.ToString());

            await _repository.Delete(id, cancellationToken);
        }
    }
}
