using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime endDate = startDate.AddDays(dayCount - 1);
            if (weekEnds == null || weekEnds.Length == 0)
            {
                return endDate;
            }
           
            foreach (WeekEnd weekEnd in weekEnds)
            {
                if (weekEnd.StartDate < startDate && weekEnd.EndDate >= startDate)
                {
                    int extraDays = (weekEnd.EndDate - startDate).Days +1;
                    endDate = endDate.AddDays(extraDays);
                }
                if(weekEnd.StartDate <= endDate && weekEnd.StartDate >= startDate)
                {
                    if(weekEnd.EndDate <= endDate)
                    {
                        int extraDays = (weekEnd.EndDate - weekEnd.StartDate).Days + 1;
                        endDate = endDate.AddDays(extraDays);
                    }
                    else 
                    {
                        int extraDays = (weekEnd.EndDate - endDate).Days  + 1;
                        endDate = endDate.AddDays(extraDays);
                    }                   
                }             
            }           
            return endDate;
        }
    }
}
