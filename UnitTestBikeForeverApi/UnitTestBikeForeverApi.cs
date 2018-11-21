using BikeForeverApi.Controllers;
using BikeForeverApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UnitTestBikeForeverApi
{
    class UnitTestBikeForeverApi
    {
        [TestClass]
        public class PutUnitTests
        {
            // Insert your code here
            public static readonly DbContextOptions<BikeForeverContext> options
                = new DbContextOptionsBuilder<BikeForeverContext>()
                .UseInMemoryDatabase(databaseName: "testDatabase").Options;

            public static IConfiguration configuration = null;
            public static readonly IList<string> postTitiles = new List<string> { "sportbike", "superbike" };

            [TestInitialize]
            public void SetupDb()
            {
                using (var context = new BikeForeverContext(options))
                {
                    PostItem postItem1 = new PostItem()
                    {
                        Title = postTitiles[0]
                    };

                    PostItem postItem2 = new PostItem()
                    {
                        Title = postTitiles[1]
                    };

                    context.PostItem.Add(postItem1);
                    context.PostItem.Add(postItem2);
                    context.SaveChanges();
                }
            }

            [TestCleanup]
            public void ClearDb()
            {
                using (var context = new BikeForeverContext(options))
                {
                    context.PostItem.RemoveRange(context.PostItem);
                    context.SaveChanges();
                };
            }

            [TestMethod]
            public async Task TestPutPostItemUpdate()
            {
                using (var context = new BikeForeverContext(options))
                {
                    // Given
                    string title = "updatePost";
                    PostItem postItem1 = context.PostItem.Where(x => x.Title == postTitiles[0]).Single();
                    postItem1.Title = title;

                    // When
                    PostItemsController postController = new PostItemsController(context, configuration);
                    IActionResult result = await postController.PutPostItem(postItem1.Id, postItem1) as IActionResult;

                    // Then
                    postItem1 = context.PostItem.Where(x => x.Title == title).Single();
                }
            }

            [TestMethod]
            public void TestGetPostItem()
            {
                using (var context = new BikeForeverContext(options))
                {
                    // Given
                    PostItem postItem1 = context.PostItem.Where(x => x.Title == postTitiles[0]).Single();
                    PostItem postItem2 = context.PostItem.Where(x => x.Title == postTitiles[1]).Single();

                    // When
                    PostItemsController postController = new PostItemsController(context, configuration);

                    // Then
                    IEnumerable<PostItem> results = postController.GetPostItem();
                }
            }

            [TestMethod]
            public async Task TestPostPostItem()
            {
                using (var context = new BikeForeverContext(options))
                {
                    PostItem postItem = new PostItem();
                    PostItemsController postController = new PostItemsController(context, configuration);
                    IActionResult result = await postController.PostPostItem(postItem) as IActionResult;
                }
            }

            [TestMethod]
            public async Task TestDeletePostItem()
            {
                using (var context = new BikeForeverContext(options))
                {
                    int id = 1;
                    PostItemsController postController = new PostItemsController(context, configuration);
                    IActionResult result = await postController.DeletePostItem(id) as IActionResult;
                    
                }
            }
        }
    }
}
