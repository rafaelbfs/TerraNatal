using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Database;
using Microsoft.EntityFrameworkCore;

namespace Entities.DAO
{
  public class AccountCharts: GenericCRUDDao<AccountChart, int>
  {
    

    public AccountCharts(FinanceContext financeContext): base(financeContext.AccountChart, financeContext)
    {
      
    }

    public struct Create
    {
      public string Standard { get; set; }
      public string CountryCode { get; set; }
      public string Description { get; set; }
      public int? Flags { get; set; }
      public int? Owner { get; set; }
    }

    public async Task<AccountChart> SaveNew(Create cmd)
    {
      Func<AccountChart> func = () => new AccountChart
      {
        CountryCode = cmd.CountryCode,
        Description = cmd.Description,
        Standard = cmd.Standard
      };

      return await SaveNew(func);

    }
  }
}
