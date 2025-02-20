using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            DateTime startDate = new DateTime(2021, 12, 1);
            int count = 10;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count-1), result);
        }

        [TestMethod]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25))
            }; 

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25)),
                new WeekEnd(new DateTime(2021, 4, 29), new DateTime(2021, 4, 29))
            };
            
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
        }
        [TestMethod]
        public void TestWeekendOneDayWeekend()
        {
            DateTime starDate = new DateTime(2025, 2, 19);
            int count = 4;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd (new DateTime(2025, 2, 22), new DateTime(2025, 2, 22))
            };
            DateTime result = new WorkDayCalculator().Calculate(starDate, count, weekends);
            Assert.IsTrue(result.Equals(new DateTime(2025, 2, 23)));
        }
        [TestMethod]
        public void TestWeekendWeekendAfterWorkDay()
        {
            DateTime starDate = new DateTime(2025, 2, 19);
            int count = 3;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd (new DateTime(2025, 2, 22), new DateTime(2025, 2, 22))
            };
            DateTime result = new WorkDayCalculator().Calculate(starDate, count, weekends);
            Assert.IsTrue(result.Equals(new DateTime(2025, 2, 21)));
        }
        [TestMethod]
        public void TestWeekendWeekendWasBeenWrong()
        {
            DateTime starDate = new DateTime(2021, 4, 21);
            int count = 7;
            WeekEnd[] weekends = new WeekEnd[3]
            {
                new WeekEnd (new DateTime(2021, 4, 20), new DateTime(2021, 4, 21)),
                new WeekEnd (new DateTime(2021, 4, 28), new DateTime(2021, 4, 28)),
                new WeekEnd (new DateTime(2021, 4, 29), new DateTime(2021, 4, 29)),
            };
            DateTime result = new WorkDayCalculator().Calculate(starDate, count, weekends);
            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 30)));
        }
    }
}
