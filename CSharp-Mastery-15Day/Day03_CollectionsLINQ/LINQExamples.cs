// LINQExamples.cs
// LINQ usage examples
using System;
using System.Linq;
using System.Collections.Generic;
namespace RecordsDemo
{
    
class Program
{
    public static void Main()
    {
        var accounts = new[] {
            new { Id = 1, Type = "Savings", Balance = 5000 },
            new { Id = 2, Type = "Current", Balance = 15000 },
            new { Id = 3, Type = "Savings", Balance = 8000 }
        };
        var SavingsAccount = accounts
                            .Where  ( a=> a.Type=="Savings")
                            .Select (a=> new { a.Id, a.Balance });
     PrintCollections(SavingsAccount,"Basisc filtering");
        
       
//****************************Grouping*************************************
   var transactions = new[] {
            new { AccountId = 1, Amount = 1000 },
            new { AccountId = 1, Amount = -500 },
            new { AccountId = 2, Amount = 2000 }
        };
    var groupedBy = transactions.GroupBy(t=>t.AccountId==1)
                    .Select(g=> new {
                        AccountId=g.Key,
                        Total=g.Sum(x => x.Amount)
                    });
        PrintCollections(groupedBy,"Grouping and aggregateing");
      
//***************************Joins***********************************************
        var customers = new[] {
            new { Id = 1, Name = "Sreyas" },
            new { Id = 2, Name = "Indhu" },
            new { Id = 3, Name = "Yashwin" },
        };

        var accountsg = new[] {
            new { CustomerId = 1, Type = "Savings" },
            new { CustomerId = 2, Type = "Current" }
        };

        var customersAccount = customers.Join(accountsg,
            c=>c.Id,
            a=>a.CustomerId,
            (c,a) => new {c.Name,a.Type} );
           PrintCollections(customersAccount,"Joins with method query") ;

          var anotherCustom = from c in customers 
                             join ac in accountsg on c.Id equals ac.CustomerId into joinedAccounts
                             from ja in joinedAccounts
                             select new { c.Name,ja.Type };  
         PrintCollections(anotherCustom,"Query Syntax") ;

        //  var leftCollection = from c in customers join a in accountsg on c.Id equals a.CustomerId
        //                       into custAcc 
        //                       from ca in custAcc.DefaultIfEmpty() 
        //                       select(new {ca.Type,c.Name});
        //   PrintCollections(leftCollection,"Left join Query Syntax");              

         //*****************************Defered Execution******************
          var numbers = Enumerable.Range(1,10);
          var query = numbers.Where(n=> n %2 ==0);//note executed;
          PrintCollections(query,"Defered Query Execution");
         
         //******************** UNION *************************
            List<int> list1 = new List<int>{1,2,3,4,5};
            List<int> list2 = new List<int>{4,5,6,7};
 
        PrintCollections(list1.Union(list2),"Union colllection");
        PrintCollections(list1.Intersect(list2),"Intersect common item colllection");
        PrintCollections(list1.Except(list2),"except list one not exists in list 2  colllection");

        PrintCollections(list1.Take(3),"Take first 3");
        PrintCollections(list1.Skip(2),"Skip first 3");
       //PrintCollections(list1.TakeWhile(3),"Take from value 3");
       // PrintCollections(list1.SkipWhile(4),"Skip till 3");

    }

    public static void PrintCollections(dynamic bfsiCollections,string messaging)
    {
        Console.WriteLine("********** Printing result for "+messaging+" ***************");
        foreach (var item in bfsiCollections)
        {
            Console.WriteLine(item);
        }
    }
}
}