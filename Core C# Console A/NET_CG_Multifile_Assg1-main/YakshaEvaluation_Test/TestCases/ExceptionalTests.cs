using DateClass;
using HCF;
using IntToString;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace YakshaEvaluation_Test.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private static string type = "Exceptional";

        public ExceptionalTests(ITestOutputHelper output)
        {
          _output = output;

        }

        #region HCF

        /// <summary>
        /// Test to find HCF for negative values 
        /// </summary>
        /// <returns></returns>
        [Fact]
            public async Task<bool> TestFindHCFFor_NegativeValues()
            {

                //Arrange
                bool res = false;
                string testName; string status;
                testName = CallAPI.GetCurrentMethodName();
                int n1 = -5, n2 = -10;
                try
                {
                  HCFCalculation hCF = new HCFCalculation();
                  int result = hCF.FindHCF(n1, n2);
                  if (result == 0)
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
            /// Test to find HCF of 2 Max numbers result is returned as expected
            /// </summary>
            /// <returns></returns>
            [Fact]
            public async Task<bool> TestFindHCF_ForMaxValues()
            {
                //Arrange
                bool res = false;
                string testName; string status;
                testName = CallAPI.GetCurrentMethodName();
                int expexted = 0;
                int n1 = 2147483647, n2 = 2147483647;
                try
                {
                  HCFCalculation hCFCalculation = new HCFCalculation();
                  int result = hCFCalculation.FindHCF(n1, n2);
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

        #region DateClass

        /// <summary>
        /// Test to check Month range - For Null value 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_CheckMonthRange_ForNullValue()
        {
            ////Arrange
            bool res = false,  expected = false; ;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            try
            {
              DateClassOperations dateClassOperations
                            = new DateClassOperations();
              bool result = dateClassOperations.CheckMonthRange(null);

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

        /// <summary>
        /// Test to check Month range - For Invalid Date Foramt 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_CheckMonthRange_ForInvalidDate()
        {
            ////Arrange
            bool expected = false, res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string strDateTime = "123/234/0000";
            try
            {
              DateClassOperations dateClassOperations
                      = new DateClassOperations();
              bool result = dateClassOperations.CheckMonthRange(strDateTime);
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

        /// <summary>
        /// Test to check Month range - For string value 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_CheckMonthRange_ForString()
        {
            ////Arrange
            bool res = false, expected = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string strDateTime = "thisisstring";
            try
            {
              DateClassOperations dateClassOperations
                      = new DateClassOperations();
              bool result = dateClassOperations.CheckMonthRange(strDateTime);
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

        /// <summary>
        /// Test to check Date range - For Null value 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_CheckDayRange_ForNullValue()
        {
            ////Arrange
            bool res = false, expected = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            try
            {
              DateClassOperations dateClassOperations
                      = new DateClassOperations();
              bool result = dateClassOperations.CheckDayRange(null);
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

        /// <summary>
        /// Test to check Date range - For Invalid Date Foramt 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_CheckDayRange_ForInvalidDate()
        {
            ////Arrange
            bool res = false, expected = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string strDateTime = "123/234/0000";
            try
            {
              DateClassOperations dateClassOperations
                      = new DateClassOperations();
              bool result = dateClassOperations.CheckDayRange(strDateTime);
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


        /// <summary>
        /// Test to check Date range - For string value 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_CheckDayRange_ForString()
        {
            ////Arrange
            bool res = false, expected = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string strDateTime = "samplestring";
            try
            {
              DateClassOperations dateClassOperations
                      = new DateClassOperations();
              bool result = dateClassOperations.CheckDayRange(strDateTime);
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

        /// <summary>
        /// Test to Find Week Day for the Null Value
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_GetWeekDay_ForNullValue()
        {
            ////Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            try
            {
              DateClassOperations dateClassOperations
                      = new DateClassOperations();
              string result = dateClassOperations.GetWeekDayOfDate(null);
              if (result == "Format Exception Occurred")
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
        /// Test to Find Week Day For Invalid Date Foramt
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_GetWeekDay_ForInvalidDate()
        {
            ////Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string strDateTime = "123/234/0000";
            try
            {
              DateClassOperations dateClassOperations
                     = new DateClassOperations();
              string result = dateClassOperations.GetWeekDayOfDate(strDateTime);

              if (result == "Format Exception Occurred")
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
        /// Test to Find Week Day - For string value 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestDateFun_GetWeekDay_ForString()
        {
            ////Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string strDateTime = "TestString";
            try
            {
              DateClassOperations dateClassOperations
                      = new DateClassOperations();
              string result = dateClassOperations.GetWeekDayOfDate(strDateTime);
              if (result == "Format Exception Occurred")
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

        #region WriteIntToString
        /// <summary>
        /// Test to Write Int To String - for Negative value
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestWriteIntToString_ForNegativeValue()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int number = -500;
            try
            {
              ConvertIntToString convertIntToString = new ConvertIntToString();
              string result = convertIntToString.WriteIntToString(number);
              if (result == null)
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
