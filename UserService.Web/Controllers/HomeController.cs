namespace UserService.Web.Controllers
{
    using System.Text;
    using System.Web.Mvc;

    using NServiceBus;

    using UserService.Messages.Commands;

    public class HomeController : Controller
    {
        #region Public Methods and Operators

        public ActionResult CreateUser(string name, string email)
        {
            var cmd = new CreateNewUserCmd { Name = "Shane", EmailAddress = "me@yahoo.com" };

            ServiceBus.Bus.Send(cmd);
            return this.Json(new { sent = cmd });
        }

        public ActionResult Index()
        {
            return this.Json(new { text = "Hello world." });
        }

        #endregion

        #region Methods

        protected override JsonResult Json(
            object data, 
            string contentType, 
            Encoding contentEncoding, 
            JsonRequestBehavior behavior)
        {
            return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}