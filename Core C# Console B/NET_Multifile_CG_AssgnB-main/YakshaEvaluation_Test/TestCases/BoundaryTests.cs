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
  public class BoundaryTests
  {
    private readonly ITestOutputHelper _output;
    private static string type = "Boundary";

    public BoundaryTests(ITestOutputHelper output)
    {
      _output = output;

    }


    #region Piglatin
    /// <summary>
    /// Test To convert source string to Piglatin, for All Vowels In string
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task<bool> TestPiglatin_AllVowels()
    {
      //Arrange
      bool res = false;
      string testName; string status;
      testName = CallAPI.GetCurrentMethodName();
      string sourceStr = "AEIOU";

      try
      {
        PiglatinForm piglatinForm = new PiglatinForm();
        string result = piglatinForm.ConvertStringToPiglatin(sourceStr);
        if (result == "AEIOUay")
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
    /// Test To convert source string to Piglatin, for No Vowels In string
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task<bool> TestPiglatin_NoVowels()
    {
      //Arrange
      bool res = false;
      string testName; string status;
      testName = CallAPI.GetCurrentMethodName();
      string sourceStr = "rythm";
      try
      {
        PiglatinForm piglatinForm = new PiglatinForm();
        string result = piglatinForm.ConvertStringToPiglatin(sourceStr);
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

    #endregion

    #region CategorizeCharacters
    /// <summary>
    /// Test to get the different types of characters - for No Value
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task<bool> TestCategorizeCharacters_ForNoValue()
    {
      //Arrange
      bool res = false;
      string testName; string status;
      testName = CallAPI.GetCurrentMethodName();
      try
      {
        CategorizeStringCharacters categorizeStringCharacters =
                new CategorizeStringCharacters();
        int[] characters = categorizeStringCharacters.CategorizeCharactersFromString("");
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
    /// Test to get the count of division Operations on a number to get 1- For Minimal Value
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task<bool> TestGetCountOfDivisionOperations_ForMinimal()
    {
      //Arrange
      bool res = false;
      string testName; string status;
      testName = CallAPI.GetCurrentMethodName();
      int n = 1, expected = 1;
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
    /// Test to get the count of division Operations on a number to get 1 - For Maximum Value
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task<bool> TestGetCountOfDivisionOperations_ForMaximum()
    {
      //Arrange
      bool res = false;
      string testName; string status;
      testName = CallAPI.GetCurrentMethodName();
      int n = 100000, expected = 17;
      try
      {
        NumberOperations.NumberOperation numberOperations = new NumberOperations.NumberOperation();
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

