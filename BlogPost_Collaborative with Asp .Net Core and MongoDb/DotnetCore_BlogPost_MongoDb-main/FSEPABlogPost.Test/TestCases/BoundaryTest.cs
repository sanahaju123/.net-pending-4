using FSEPABlogPost.BusinessLayers.Services;
using FSEPABlogPost.BusinessLayers.Services.Repository;
using FSEPABlogPost.Entities;
using FSEPABlogPost.Test.TestCases;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FSEPABlogPost.Test.TestCases
{
    public class BoundaryTest
    {
        //injecting IBlogPostService interface to access all method
        private readonly IBlogPostServices _services;
        private readonly ITestOutputHelper _output;
        //mocking IBlogPostRepository to access all Repository method
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        public BlogPost blogPost;
        public Comment comment;
        private static string type = "Boundary";
        public BoundaryTest(ITestOutputHelper output)
        {
            _output = output;
            _services = new BlogPostServices(mockservice.Object);

            blogPost = new BlogPost
            {
              PostId = "1",
              Abstract = "Post Abstract-1",
              Description = "Post Description -1",
              PostedDate = DateTime.Now,
              Title = "Post-Title"
            };

            comment = new Comment
            {
              CommId = "1",
              CommentedDate = DateTime.Now,
              CommentMsg = "Post Title Comments -1",
              PostId = "5ef312a0f05009584c12a93f"
            };
        }

        /// <summary>
        /// validate BlogPostId
        /// </summary>
        /// <returns>return true if postId is exists write output in text file</returns>
        [Fact]
        public async Task<bool> Testfor_ValidatePostId()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string postid = "5ef312a0f05009584c12a93f";
            //Act
            try
            {
                mockservice.Setup(repo => repo.Create(blogPost)).ReturnsAsync(blogPost);
                var result = await _services.Create(blogPost);
                if (result.PostId == postid)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
           
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
        /// validate BlogPost Title Property
        /// </summary>
        /// <returns>return true if Title is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateBlogPost_TitleProperty_Empty()
        {
            //Arrange
            bool res = false;
            string postid = "5ef312a0f05009584c12a93f";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            try
            {
                //Act
                mockservice.Setup(repo => repo.Create(blogPost)).ReturnsAsync(blogPost);
                var result = await _services.Create(blogPost);
                if (result.Title != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
           
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
        /// validate BlogPost Abstract Property
        /// </summary>
        /// <returns>return true if Abstract is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateBlogPost_AbstractProperty_Empty()
        {
            //Arrange
            bool res = false;
            string postid = "5ef312a0f05009584c12a93f";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            try
            {
                //Act
                mockservice.Setup(repo => repo.Create(blogPost)).ReturnsAsync(blogPost);
                var result = await _services.Create(blogPost);
                if (result.Abstract != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
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
        /// validate BlogPost Description Property
        /// </summary>
        /// <returns>return true if Description is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateBlogPost_DescriptionProperty_Empty()
        {
            //Arrange
            bool res = false;
            string postid = "5ef312a0f05009584c12a93f";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                mockservice.Setup(repo => repo.Create(blogPost)).ReturnsAsync(blogPost);
                var result = await _services.Create(blogPost);
                if (result.Description != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            
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
        /// validate Comment CommentMsg Property
        /// </summary>
        /// <returns>return true if CommentMsg is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateComment_CommentMsgProperty_Empty()
        {
            //Arrange
            bool res = false;
            string postid = "5ef312a0f05009584c12a93f";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                mockservice.Setup(repo => repo.Comments(postid, comment)).ReturnsAsync(comment);
                var result = await _services.Comments(postid, comment);
                if (result.CommentMsg != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              //Assert
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            
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
    }
}
