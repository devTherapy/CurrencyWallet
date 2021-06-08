using AutoMapper;
using CurrencyWallet.Application.Contract.Identity;
using CurrencyWallet.Application.Contract.Infrastructure;
using CurrencyWallet.Application.Contract.Persistence;
using CurrencyWallet.Application.Exceptions;
using CurrencyWallet.Application.Utils.Enums;
using CurrencyWallet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyWallet.Application.Features.Wallets.Command.FundWallet
{
    public class FundWalletHandler : IRequestHandler<FundWalletCommand, FundWalletResponse>
    {
        private readonly IWalletRepository _walletRepo;
        private readonly ITransactionRepository _transactionRepo;
        private readonly ICurrencyConverterService _currencyConverterService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;

        public FundWalletHandler(IWalletRepository walletRepo, ITransactionRepository transactionRepo, ICurrencyConverterService currencyConverterService, IMapper mapper, IUserRepository userRepo)
        {
            _walletRepo = walletRepo;
            _transactionRepo = transactionRepo;
            _currencyConverterService = currencyConverterService;
            _mapper = mapper;
            _userRepo = userRepo;
        }
        public async Task<FundWalletResponse> Handle(FundWalletCommand request, CancellationToken cancellationToken)
        {
            var validator = new FundWalletValidator(_currencyConverterService);
            var validationResult = await validator.ValidateAsync(request);
            var response = new FundWalletResponse();
            if (validationResult.Errors.Count > 0)
            {
                response.ValidationErrors = new List<string>();
                validationResult.Errors.ForEach(x => response.ValidationErrors.Add(x.ErrorMessage));
                return response;
            }
            var user = await _userRepo.GetById(request.UserId);
            if (user == null)
            {
                response.Message = $"User with {request.UserId} cannot be found";
                return response;
            }
            var userRoles = await _userRepo.GetUserRoles(user);
            var userWallet = await _walletRepo.GetWalletByUserId(user.Id);
            var WalletWithCurrency = userWallet.FirstOrDefault(x => x.Currency == request.Currency);

            if (userRoles.Contains(Roles.Elite.ToString()))
            {
                if (WalletWithCurrency == null)
                {
                    var wallet = new Wallet() { Id = Guid.NewGuid().ToString(), Currency = request.Currency, Balance = request.Amount, Main = false, UserId = request.UserId };
                    //add transaction
                    var transaction = new Transaction() { Id = Guid.NewGuid().ToString(), Amount = request.Amount, Currency = request.Currency, TransactionType = TransactionType.credit.ToString(), TransactionStatus = Utils.Enums.TransactionStatus.approved.ToString(), WalletId = WalletWithCurrency.Id };


                    await _walletRepo.AddAsync(wallet);
                    await _transactionRepo.AddAsync(transaction);
                    response.Success = true;
                    response.Message = "Transaction successful";
                    response.TransactionId = transaction.Id;
                    return response;

                }
                else
                {
                    WalletWithCurrency.Balance += request.Amount;
                    //add transaction
                    var transaction = new Transaction() { Id = Guid.NewGuid().ToString(), Amount = request.Amount, Currency = request.Currency, TransactionType = TransactionType.credit.ToString(), TransactionStatus = Utils.Enums.TransactionStatus.approved.ToString(), WalletId = WalletWithCurrency.Id };

                    await _walletRepo.UpdateAsync(WalletWithCurrency);
                    await _transactionRepo.AddAsync(transaction);
                    response.Success = true;
                    response.Message = "Transaction successful";
                    response.TransactionId = transaction.Id;

                }
                return response;
            }
            else if (userRoles.Contains(Roles.Noob.ToString()))
            {
                var userMainWallet = userWallet.FirstOrDefault(x => x.Main);


                //var userMainCurrency = userMainWallet.Currency;
                //var transactionAmountInMainCurrency = await _currencyConverterService.ConvertCurrency(request.Currency, userMainCurrency, request.Amount);
                //userMainWallet.Balance += transactionAmountInMainCurrency;admin approval
                var transaction = new Transaction() { Id = Guid.NewGuid().ToString(), Amount = request.Amount, Currency = request.Currency, TransactionType = TransactionType.credit.ToString(), TransactionStatus = Utils.Enums.TransactionStatus.pending.ToString(), WalletId = userMainWallet.Id, BalanceBeforeTransaction = userMainWallet.Balance, BalanceAfterTransaction = userMainWallet.Balance };
                await _transactionRepo.AddAsync(transaction);
                response.Success = true;
                response.Message = "Transaction successful, Pending approval";
                response.TransactionId = transaction.Id;
                return response;
            }
            return response;
        }
    }
}
