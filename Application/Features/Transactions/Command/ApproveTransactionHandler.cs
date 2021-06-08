using CurrencyWallet.Application.Contract.Infrastructure;
using CurrencyWallet.Application.Contract.Persistence;
using CurrencyWallet.Application.Utils.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyWallet.Application.Features.Transactions.Command
{
    public class ApproveTransactionHandler : IRequestHandler<ApproveTransactionCommand, TransactionApprovalResponse>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICurrencyConverterService _currencyConverterService;

        public ApproveTransactionHandler(IWalletRepository walletRepository, ITransactionRepository transactionRepository, ICurrencyConverterService currencyConverterService)
        {
            _walletRepository = walletRepository;
            _transactionRepository = transactionRepository;
            _currencyConverterService = currencyConverterService;
        }
        public async Task<TransactionApprovalResponse> Handle(ApproveTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new TransactionApprovalResponse();
            var transaction = await _transactionRepository.GetById(request.TransactionId);
            var mainWallet = await _walletRepository.GetById(transaction.WalletId);
            if (transaction.Currency != mainWallet.Currency)
            {
                var conversion = await _currencyConverterService.ConvertCurrency(transaction.Currency, mainWallet.Currency, transaction.Amount);
                if (transaction.TransactionType == TransactionType.credit.ToString())
                {
                    mainWallet.Balance += conversion;

                }
                else
                {
                    mainWallet.Balance -= conversion;

                }
            }
            else
            {
                if (transaction.TransactionType == TransactionType.credit.ToString())
                {
                    mainWallet.Balance -= transaction.Amount;

                }

                else
                {
                    mainWallet.Balance -= transaction.Amount;

                }

            }
            transaction.BalanceAfterTransaction = mainWallet.Balance;
            transaction.TransactionStatus = TransactionStatus.approved.ToString();
            await _walletRepository.UpdateAsync(mainWallet);
            await _transactionRepository.UpdateAsync(transaction);
            response.Message = $"transaction of Id {transaction.Id} created at {transaction.CreatedDate}, owned by wallet {transaction.WalletId}";
            response.Success = true;
            return response; 
        }
    }
}
