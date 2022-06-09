using CategorizeCharacters;
using NumberOperations;
using Piglatin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

    #region Piglatin
    /// <summary>
    /// Test to convert the source string to Piglatin form - result is returned as expected
    /// </summary>
    /// <returns></returns>
    [Fact]
        public async Task<bool> TestStringToPiglatinForm_ExpectedValue()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string sourceStr = "techademy", expected = "echademytay";
            try
            {
              PiglatinForm piglatinForm = new PiglatinForm();
              string result = piglatinForm.ConvertStringToPiglatin(sourceStr);
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

    #region CategorizeCharacters
    /// <summary>
    /// Test to get the different types of characters - result is returned as expected
    /// </summary>
    /// <returns></returns>
    [Fact]
        public async Task<bool> TestCategorizeCharacters_ExpectedValue()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string sourceStr = "SampLE23$#";
            int specCharacters = 2, capitalCharacters = 3, lowerChars = 3, numbers = 2, a = 0, b = 0, c = 0, d = 0;
            int diffCharTypes = 4;//
            try
            {
              CategorizeStringCharacters categorizeStringCharacters =
                      new CategorizeStringCharacters();
              int[] characters = categorizeStringCharacters.CategorizeCharactersFromString(sourceStr);
              if (characters != null)
              {
                a = characters[0];//numbers
                b = characters[1];//lowercase
                c = characters[2];//upperchars
                d = characters[3];//specialchars

                //Assertion
                if (characters.Length == diffCharTypes
                && a == numbers && b == lowerChars
                && capitalCharacters == c && specCharacters == d)
                {
                  res = true;
                }
              }
              else
                res = false;
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
        /// Test to get the count of division Operations on a number to get the 1
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestGetCountOfDivisionOperations_ExpectedValue()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int n = 100, expected = 7;
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
