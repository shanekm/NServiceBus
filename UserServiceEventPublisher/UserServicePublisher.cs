using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserServiceEventPublisher
{
    using NServiceBus;
    using NServiceBus.Logging;

    public class UserCreatorPublisher : IHandleMessages<CreateNewUserCmd>
    {
        #region Static Fields

        private static readonly ILog log = LogManager.GetLogger(typeof(UserCreator));

        #endregion

        #region Public Methods and Operators

        public void Handle(CreateNewUserCmd message)
        {
            log.InfoFormat("Creating user '{0}' with email '{1}'", message.Name, message.EmailAddress);
        }

        #endregion
    }
}
