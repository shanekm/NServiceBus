namespace UserService
{
    using System;
    using NServiceBus;
    using NServiceBus.Logging;
    using UserService.Messages.Commands;
    using UserService.Messages.Events;

    public class UserCreator : IHandleMessages<CreateNewUserCmd>
    {
        #region Static Fields

        private static readonly ILog log = LogManager.GetLogger(typeof(UserCreator));

        #endregion

        #region Public Properties

        public IBus Bus { get; set; }

        #endregion

        // Command comes here
        #region Public Methods and Operators

        public void Handle(CreateNewUserCmd message)
        {
            // End of ICommand process after this line
            log.InfoFormat("Creating user '{0}' with email '{1}'", message.Name, message.EmailAddress);
            

            // This is where the user would be added to the database.
            // The database command would auto-enlist in the ambient
            // transaction and either succeed or fail along with the message being processed.

            // Send event onward to subscriber (WelcomeEmailService)
            this.Bus.Publish<IUserCreatedEvent>(
                evt =>
                    {
                        evt.UserId = Guid.NewGuid();
                        evt.Name = message.Name;
                        evt.EmailAddress = message.EmailAddress;
                    });
        }

        #endregion
    }
}