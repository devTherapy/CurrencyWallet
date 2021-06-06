using CurrencyWallet.Application.Contract.Persistence;
using AutoMapper;
using MediatR;
using CurrencyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyWallet.Application.Features.Wallets.Command.CreateWallet
{
    public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, CreateWalletResponse>
    {
        private readonly IMapper _mapper;
        private IAsyncRepository<Wallet> _walletRepository;

        public CreateWalletHandler(IMapper mapper, IAsyncRepository<Wallet>walletRepository)
        {
            _mapper = mapper;
            _walletRepository = walletRepository;
        }
        public async Task<CreateWalletResponse> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateWalletValidator();
            var response = new CreateWalletResponse();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success == true)
            {
                var wallet = new Wallet { Currency = request.Currency, UserId = request.UserId};
                await _walletRepository.AddAsync(wallet);
                response.Wallet = _mapper.Map<CreateWalletDto>(wallet);
                response.Message = "Wallet Created Successfully";
            }
            return response;
        }
    }
}
