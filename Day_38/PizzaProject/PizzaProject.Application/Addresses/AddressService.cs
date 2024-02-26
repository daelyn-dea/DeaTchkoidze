using Mapster;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Application.Validators;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IValidatorService _validator;

        public AddressService(IAddressRepository repository, IValidatorService validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<AddressResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsAddressById(id, cancellationToken))
                throw new AddressNotFoundException($"{id}");

            var result = await _repository.Get(id, cancellationToken);

            return result.Adapt<AddressResponseModel>();
        }

        public async Task<List<AddressResponseModel>> GetAllByUserId(int id, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByUserId(id, cancellationToken);

            return result.Adapt<List<AddressResponseModel>>();
        }

        public async Task Create(AddressRequestModel address, int userID, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsUserById(userID, cancellationToken))
                throw new UserNotFoundException($"{userID}");

            var result = address.Adapt<Address>();

            result.UserId = userID;

            await _repository.Create(result, cancellationToken);
        }

        public async Task Update(int id, AddressRequestModel address, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsAddressById(id, cancellationToken))
                throw new AddressNotFoundException(id.ToString());

            var addressToUpdate = address.Adapt<Address>();

            var result = await _repository.Get(id, cancellationToken);
            addressToUpdate.UserId = result.UserId;
            addressToUpdate.Id = id;

            await _repository.Update(addressToUpdate, cancellationToken);
        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsAddressById(id, cancellationToken))
                throw new AddressNotFoundException(id.ToString());

            await _repository.Delete(id, cancellationToken);
        }

        public async Task DeleteByUserId(int userId, CancellationToken cancellationToken)
        {
            if (await _validator.ExistsAddressByUserId(userId, cancellationToken))
                await _repository.DeleteByUserId(userId, cancellationToken);
        }

    }
}
