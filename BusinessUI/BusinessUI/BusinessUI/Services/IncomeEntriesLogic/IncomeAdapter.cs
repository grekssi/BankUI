using System;
using System.Collections.Generic;
using System.Text;
using BusinessUI.Models;

namespace BusinessUI.Services.IncomeEntriesLogic
{
    public sealed class IncomeAdapter
    {
        public IncomeModel[] GetBy(Login login)
        {
            //Query result
            return new List<IncomeModel>().ToArray();
        }

        public bool Update(IncomeModel model)
        {
            //Query result
            return false;
        }

        public bool Remove(IncomeModel model)
        {
            //Query result
            return false;
        }
    }
}
