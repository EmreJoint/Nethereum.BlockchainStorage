using System.Data.Entity;
using System.Threading.Tasks;
using Nethereum.BlockchainStore.Repositories;
using Nethereum.BlockchainStore.SQL.Context;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;

namespace Nethereum.BlockchainStore.SQL
{
  public class TransactionRepository : ITransactionRepository
  {

    public TransactionRepository()
    {

    }

    public async Task UpsertAsync(string contractAddress, string code, Nethereum.RPC.Eth.DTOs.Transaction transaction, TransactionReceipt transactionReceipt, bool failedCreatingContract, HexBigInteger blockTimestamp)
    {
      var transactionEntity = Nethereum.BlockchainStore.SQL.Transaction.CreateTransaction(
          transaction, transactionReceipt,
          failedCreatingContract, blockTimestamp, contractAddress);
      await InsertOrUpdate(transactionEntity);
    }

    public async Task UpsertAsync(Nethereum.RPC.Eth.DTOs.Transaction transaction,
      TransactionReceipt transactionReceipt,
        bool failed,
        HexBigInteger timeStamp, bool hasVmStack = false, string error = null)
    {
      var transactionEntity = Nethereum.BlockchainStore.SQL.Transaction.CreateTransaction(transaction,
          transactionReceipt,
          failed, timeStamp, hasVmStack, error);
      await InsertOrUpdate(transactionEntity);
    }

    public async Task InsertOrUpdate(Transaction transaction)
    {
      using (var context = new BlockchainStoreContext())
      {
        context.Entry(transaction).State = string.IsNullOrEmpty(transaction.Hash) ?
                                   EntityState.Added :
                                   EntityState.Modified;

        await context.SaveChangesAsync();
      }
    }

  }
}