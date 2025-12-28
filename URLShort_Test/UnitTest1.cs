using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using URLShort.Controllers;
using URLShort.Models;
using URLShort.Models.AccountViewModels;

namespace URLShort_Test
{
    public class UnitTest1
    {
       UserManager<ApplicationUser> userManager;
            SignInManager<ApplicationUser> signInManager;
            ILoggerFactory loggerFactory;


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IEmailSender _emailSender;
        // private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        [Fact]
        public void HomeController_Test()
        {
            HomeController controller = new HomeController();
            ActionResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);

        }
        [Fact]
        public void AccounControllerLogin_Test()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Login = "Admin12";
            loginViewModel.Password = "Admin_1";
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new UserManager<ApplicationUser>(userStore.Object, null, null, null, null, null, null, null, null);
            var signInManager = new SignInManager<ApplicationUser>(userManager,
                                                        Mock.Of<IHttpContextAccessor>(),
                                                        Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
                                                        null,
                                                        Mock.Of<ILogger<SignInManager<ApplicationUser>>>(),
                                                        Mock.Of<IAuthenticationSchemeProvider>(),
                                                        Mock.Of<IUserConfirmation<ApplicationUser>>());
            var mockLogger = new Mock<ILogger<AccountController>>();
            // Setup the Log method to accept any call
            mockLogger.Setup(
                m => m.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>()))
                             .Returns(() => mockLogger.Object);
            AccountController accountController = new AccountController(userManager,signInManager,mockLoggerFactory.Object);
            ActionResult result = accountController.Login(loginViewModel).Result as ViewResult;
            Assert.NotNull(result);
        }
    }
}
