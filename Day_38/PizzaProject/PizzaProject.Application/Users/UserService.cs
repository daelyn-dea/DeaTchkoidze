using Mapster;
using PizzaProject.Application.Addresses;
using PizzaProject.Application.Exceptions;
using PizzaProject.Application.Repositories;
using PizzaProject.Application.Validators;
using PizzaProject.Domain.Entity;

namespace PizzaProject.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IAddressService _addressService;
        private readonly IValidatorService _validator;
        public UserService(IUserRepository repository, IAddressService addressService, IValidatorService validator)
        {
            _repository = repository;
            _addressService = addressService;
            _validator = validator;
        }
        public async Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(cancellationToken);

            if (result == null)
                throw new UserNotFoundException("User Notfound");
            else
            {
                var resultInResponseModel = result.Adapt<List<UserResponseModel>>();
                for (int i = 0; i < result.Count; i++)
                {
                    int j = i;
                    resultInResponseModel[j].AddressList = await _addressService.GetAllByUserId(result[j].Id, cancellationToken);
                }
                return resultInResponseModel.Adapt<List<UserResponseModel>>();
            }
        }
        //TODO: გასატანია რეპოზიტორში რო პიცის რეპოზიტორი ჩაიხსნას
        public async Task<UserResponseModel> Get(int id, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsUserById(id, cancellationToken))
                throw new UserNotFoundException(id.ToString());

            var result = await _repository.Get(id, cancellationToken);
            var resultInResponseModel =  result.Adapt<UserResponseModel>();
            resultInResponseModel.AddressList = await _addressService.GetAllByUserId(id, cancellationToken); 

            return resultInResponseModel;
        }

        public async Task Create(UserRequestModel user, CancellationToken cancellationToken)
        {
            var userToInsert = user.Adapt<User>();
            var id = await _repository.Create(userToInsert, cancellationToken);

            for (int i = 0; i < userToInsert.AddressList.Count; i++)
            {
                int j = i;
                await _addressService.Create(user.AddressList[j], id, cancellationToken);
            }
        }

        public async Task Update(int id, UserRequestModel user, CancellationToken cancellationToken)
        {
             if (!await _validator.ExistsUserById(id, cancellationToken))
                throw new UserNotFoundException(id.ToString());

            var userToUpdate = user.Adapt<User>();
            userToUpdate.Id = id;
            await _repository.Update(userToUpdate, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            if (!await _validator.ExistsUserById(id, cancellationToken))
                throw new UserNotFoundException(id.ToString());

            await _repository.Delete(id, cancellationToken);
            await _addressService.DeleteByUserId(id, cancellationToken);

        }
    }
}
