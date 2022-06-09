using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace YakshaEvaluation_Test.TestCases
{
   public class FunctionalTests
  {

        private readonly ITestOutputHelper _output;
        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
          _output = output;

        }
        #region HCF 
        /// <summary>
        /// Test to find HCF of 2 numbers - result is returned as expected
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFindHCF_ExpectedValue()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int expected = 5;

            int n1 = 5, n2 = 10;
            try
            {
              HCFCalculation hCFCalculation = new HCFCalculation();
              //Act
              int result = hCFCalculation.FindHCF(n1, n2);

              //Assertion
              if (result == expected)
              {
                res = true;
              }
            }
            
            catch (Exception)
            {
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }

              // Assert
              status = Convert.ToString(res);
              if (res == true)
              {
                _output.WriteLine(testName + ":Passed");
              }
              else
              {
                _output.WriteLine(testName + ":Failed");
              }
              await CallAPI.saveTestResult(testName, status, type);
              return res;
            }
        #endregion

        #region DateClass
        /// <summary>
        /// Test to check MonthPart of Date, is in the range (1-12)
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_CheckMonthRange_ExpectedValue()
        {
            ////Arrange
           bool res=false, expected = true;
          string testName; string status;
          testName = CallAPI.GetCurrentMethodName();
          string strDateTime = DateTime.Today.ToString();
          try
          {
              DateClassOperations dateClassOperations
                  = new DateClassOperations();
              res = dateClassOperations.CheckMonthRange(strDateTime);
              //Assertion
              if (res == expected)
              {
                res = true;
              }
            }
            catch (Exception)
            {
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }

            // Assert
            status = Convert.ToString(res);
            if (res == true)
            {
              _output.WriteLine(testName + ":Passed");
            }
            else
            {
              _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
    }

        /// <summary>
        /// Test to check Given Date is in the range 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_CheckDayRange_ExpectedValue()
        {
            ////Arrange
            bool res=false, expected = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string strDateTime = DateTime.Today.ToString();
            try
            {
              DateClassOperations dateClassOperations
                      = new DateClassOperations();
              res = dateClassOperations.CheckDayRange(strDateTime);
              if (res == expected)
              {
                res = true;
              }
            }

            catch (Exception)
            {
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }

            // Assert
            status = Convert.ToString(res);
            if (res == true)
            {
              _output.WriteLine(testName + ":Passed");
            }
            else
            {
              _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
          }

        /// <summary>
        /// Test to Find Week Day for the provided date is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_GetWeekDay_ExpectedValue()
        {
            ////Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string expected = DateTime.Today.DayOfWeek.ToString();

                try
                {
                  DateClassOperations dateClassOperations
                          = new DateClassOperations();
                  string result = dateClassOperations.GetWeekDayOfDate(DateTime.Today.ToString());
                  if (expected == result)
                  {
                    res = true;
                  }
                }

                catch (Exception)
                {
                  status = Convert.ToString(res);
                  _output.WriteLine(testName + ":Failed");
                  await CallAPI.saveTestResult(testName, status, type);
                  return false;
                }

                // Assert
                status = Convert.ToString(res);
                if (res == true)
                {
                  _output.WriteLine(testName + ":Passed");
                }
                else
                {
                  _output.WriteLine(testName + ":Failed");
                }
                await CallAPI.saveTestResult(testName, status, type);
                return res;
              }
        #endregion

        #region IntToString

        /// <summary>
        /// Test to Write Int To String - result is returned as expected
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestWriteIntToString_ExpectedValue()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string expexted = "Five Zero Zero";
                  int number = 500;
            try
            {
              ConvertIntToString convertIntToString = new ConvertIntToString();
              string result = convertIntToString.WriteIntToString(number);
              if (result == expexted)
              {
                res = true;
              }
            }
              catch (Exception)
              {
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
              }

              // Assert
              status = Convert.ToString(res);
              if (res == true)
              {
                _output.WriteLine(testName + ":Passed");
              }
              else
              {
                _output.WriteLine(testName + ":Failed");
              }
              await CallAPI.saveTestResult(testName, status, type);
              return res;
            }

        #endregion
    }
}
