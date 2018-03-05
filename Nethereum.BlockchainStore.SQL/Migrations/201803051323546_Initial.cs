namespace Nethereum.BlockchainStore.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressTransactions",
                c => new
                    {
                        Hash = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        AddressTo = c.String(),
                        BlockNumber = c.String(),
                        BlockHash = c.String(),
                        AddressFrom = c.String(),
                        TimeStamp = c.Long(nullable: false),
                        TransactionIndex = c.Long(nullable: false),
                        Value = c.String(),
                        Gas = c.Long(nullable: false),
                        GasPrice = c.Long(nullable: false),
                        Input = c.String(),
                        Nonce = c.Long(nullable: false),
                        Failed = c.Boolean(nullable: false),
                        ReceiptHash = c.String(),
                        GasUsed = c.Long(nullable: false),
                        CumulativeGasUsed = c.Long(nullable: false),
                        HasLog = c.Boolean(nullable: false),
                        Error = c.String(),
                        HasVmStack = c.Boolean(nullable: false),
                        NewContractAddress = c.String(),
                        FailedCreateContract = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Hash);
            
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        BlockNumber = c.String(nullable: false, maxLength: 128),
                        Hash = c.String(),
                        ParentHash = c.String(),
                        Nonce = c.String(),
                        ExtraData = c.String(),
                        Difficulty = c.Long(nullable: false),
                        TotalDifficulty = c.Long(nullable: false),
                        Size = c.Long(nullable: false),
                        Miner = c.String(),
                        GasLimit = c.Long(nullable: false),
                        GasUsed = c.Long(nullable: false),
                        TimeStamp = c.Long(nullable: false),
                        TransactionCount = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.BlockNumber);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Address = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ABI = c.String(),
                        Code = c.String(),
                        Code1 = c.String(),
                        Code2 = c.String(),
                        Code3 = c.String(),
                        Code5 = c.String(),
                        Code6 = c.String(),
                        Code7 = c.String(),
                        Code8 = c.String(),
                        Code9 = c.String(),
                        Code10 = c.String(),
                        Creator = c.String(),
                        TransactionHash = c.String(),
                    })
                .PrimaryKey(t => t.Address);
            
            CreateTable(
                "dbo.TransactionLogs",
                c => new
                    {
                        TransactionHash = c.String(nullable: false, maxLength: 128),
                        LogIndex = c.Long(nullable: false),
                        Address = c.String(),
                        Topics = c.String(),
                        Topic0 = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => new { t.TransactionHash, t.LogIndex });
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Hash = c.String(nullable: false, maxLength: 128),
                        BlockNumber = c.String(),
                        AddressTo = c.String(),
                        BlockHash = c.String(),
                        AddressFrom = c.String(),
                        TimeStamp = c.Long(nullable: false),
                        TransactionIndex = c.Long(nullable: false),
                        Value = c.String(),
                        Gas = c.Long(nullable: false),
                        GasPrice = c.Long(nullable: false),
                        Input = c.String(),
                        Nonce = c.Long(nullable: false),
                        Failed = c.Boolean(nullable: false),
                        ReceiptHash = c.String(),
                        GasUsed = c.Long(nullable: false),
                        CumulativeGasUsed = c.Long(nullable: false),
                        HasLog = c.Boolean(nullable: false),
                        Error = c.String(),
                        HasVmStack = c.Boolean(nullable: false),
                        NewContractAddress = c.String(),
                        FailedCreateContract = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Hash);
            
            CreateTable(
                "dbo.TransactionVmStacks",
                c => new
                    {
                        Address = c.String(nullable: false, maxLength: 128),
                        TransactionHash = c.String(nullable: false, maxLength: 128),
                        StructLogs1 = c.String(),
                        StructLogs2 = c.String(),
                        StructLogs3 = c.String(),
                        StructLogs4 = c.String(),
                        StructLogs5 = c.String(),
                        StructLogs6 = c.String(),
                        StructLogs7 = c.String(),
                        StructLogs8 = c.String(),
                        StructLogs9 = c.String(),
                        StructLogs10 = c.String(),
                        StructLogs11 = c.String(),
                        StructLogs12 = c.String(),
                        StructLogs13 = c.String(),
                        StructLogs14 = c.String(),
                        StructLogs15 = c.String(),
                        StructLogs16 = c.String(),
                        StructLogs17 = c.String(),
                        StructLogs18 = c.String(),
                        StructLogs19 = c.String(),
                        StructLogs20 = c.String(),
                        StructLogs21 = c.String(),
                        StructLogs22 = c.String(),
                        StructLogs23 = c.String(),
                        StructLogs24 = c.String(),
                        StructLogs25 = c.String(),
                    })
                .PrimaryKey(t => new { t.Address, t.TransactionHash });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransactionVmStacks");
            DropTable("dbo.Transactions");
            DropTable("dbo.TransactionLogs");
            DropTable("dbo.Contracts");
            DropTable("dbo.Blocks");
            DropTable("dbo.AddressTransactions");
        }
    }
}
