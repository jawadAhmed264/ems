using ems.Controllers;
using ems.Data.Models;
using ems.Data.Repository;
using ems.DTO;
using ems.Service.ServiceImplimentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ems.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EmployeeRepo empRepo = new EmployeeRepo();
            EmployeeService employeeService = new EmployeeService(empRepo);
            // Set up Prerequisites   
            var controller = new EmployeeController(employeeService);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.Get(1);
            var contentResult = response as OkNegotiatedContentResult<EmployeeDto>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("Jawad Ahmed", contentResult.Content.EmpName);
        }
    }
}
