using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Piglatin;
using CategorizeCharacters;
using NumberOperations;
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

    #region Piglatin
    /// <summary>
    /// Test to convert string to PiglatinForm - with NoVowels 
    /// </summary>
    /// <returns></returns>
    [Fact]
        public async Task<bool> TestPiglatin_WithNoVowels()
        {

            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string sourceStr = "rythm";
            try
            {
              PiglatinForm obj = new PiglatinForm();
              string result = obj.ConvertStringToPiglatin(sourceStr);
              if (result == "-1")
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
        /// Test to convert string to PiglatinForm - with only special symbols
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestPiglatin_WithSpecialSymbols()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string sourceStr = "@#$&";
            try
            {
              PiglatinForm obj = new PiglatinForm();
              string result = obj.ConvertStringToPiglatin(sourceStr);
              if (result == "-1")
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
        /// Test to convert string to PiglatinForm - with Number String
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestPiglatin_WithNumberString()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string sourceStr = "12345";
            try
            {
              PiglatinForm obj = new PiglatinForm();
              string result = obj.ConvertStringToPiglatin(sourceStr);
              if (result == "-1")
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
        /// Test To convert source string to Piglatin, for Null value 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestPiglatin_ForNullValue()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            try
            {
              PiglatinForm piglatinForm = new PiglatinForm();
              string result = piglatinForm.ConvertStringToPiglatin(null);
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

        #region CategorizeCharacters
        /// <summary>
        /// Test to get the different types of characters - for Null Value
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestCategorizeCharacters_ForNullValue()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            try
            {
              CategorizeStringCharacters categorizeStringCharacters =
                      new CategorizeStringCharacters();
              int[] characters = categorizeStringCharacters.CategorizeCharactersFromString(null);
              if (characters == null)
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

        #region NumberOfOperations

        /// <summary>
        /// Test to get the count of division Operations on a number to get 1 - For Zero value
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestGetCountOfDivisionOperations_ForZero()
        {
            //Arrange
            bool res = false;
            int n = 0, expected = -1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            try
            {
              NumberOperation numberOperations = new NumberOperation();
              int result = numberOperations.GetCountOfDivisionOperations(n);
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
        /// Test to get the count of division Operations on a number to get 1 - For Minus Value
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestGetCountOfDivisionOperations_ForMinusValue()
        {
            //Arrange
            bool res = false;
            int n = -10, expected = -1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            try
            {
              NumberOperation numberOperations = new NumberOperation();
              int result = numberOperations.GetCountOfDivisionOperations(n);
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
    }
}
