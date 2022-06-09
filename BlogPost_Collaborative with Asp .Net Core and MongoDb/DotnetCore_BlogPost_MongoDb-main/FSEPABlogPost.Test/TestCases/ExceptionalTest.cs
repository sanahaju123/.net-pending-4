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

namespace FSEPABlogPost.Test.TestCase
{
    public class ExceptionalTest
    {
        //injecting IBlogPostService interface to access all method.
        private readonly ITestOutputHelper _output;
        private readonly IBlogPostServices _services;
        //mocking IBlogPostRepository to access all Repository method
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        public BlogPost blogPost;
        public Comment comments;
        private static string type = "Exceptional";
        public ExceptionalTest(ITestOutputHelper output)
        {
            _services = new BlogPostServices(mockservice.Object);
            _output = output;
            blogPost = new BlogPost
            {
              PostId = "1",
              Abstract = "Post Abstract-1",
              Description = "Post Description -1",
              PostedDate = DateTime.Now,
              Title = "Post-Title"
            };

            comments = new Comment
            {
              CommId = "1",
              CommentedDate = DateTime.Now,
              CommentMsg = "Post Title Comments -1",
              PostId = "5ef312a0f05009584c12a93f"
            };
        }

        
        /// <summary>
        /// Create new post if object null throw error
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> CreateNewPost_Null_Failure()
        {
            // Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            blogPost = null;
            //Act 
            try
            {
                mockservice.Setup(blogRepo => blogRepo.Create(blogPost));
                var result = await _services.Create(blogPost);
                if (result == null)
                {
                    res = true;
                }
            }
            catch(Exception)
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
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> CreateNewComment_Null_Failure()
        {
            // Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            string PostId = "5ef312a0f05009584c12a93f";
            comments = null;
            //Act 
            try
            {
                mockservice.Setup(blogRepo => blogRepo.Comments(PostId, comments));
                var result = await _services.Comments(PostId, comments);
                if (result == null)
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
