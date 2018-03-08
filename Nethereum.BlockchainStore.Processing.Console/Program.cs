using System;
using System.Diagnostics;

namespace Nethereum.BlockchainStore.Processing.Console
{
  internal class Program
  {
    private static readonly string prefix = "Morden";

    private static readonly string connectionString =
        "DefaultEndpointsProtocol=https;AccountName=XX;AccountKey=XXX";

    private static void Main(string[] args)
    {
      //string url = "http://localhost:8045";
      //int start = 500599;
      //int end = 1000000;
      //bool postVm = true;

      var url = "http://178.211.50.190:8545";
      //var url = "https://mainnet.infura.io/2riHiBOAVSxHOkL6DfLi";
      var start = 2778984;
      var end = 2779984;
      var postVm = false;
      //if (args.Length > 2)
      //  if (args[3].ToLower() == "postvm")
      //    postVm = true;

      var proc = new StorageProcessor(url, connectionString, prefix, postVm);
      proc.Init().Wait();
      var result = proc.ExecuteAsync(start, end).Result;

      Debug.WriteLine(result);
      System.Console.WriteLine(result);
      System.Console.ReadLine();
    }
  }
}