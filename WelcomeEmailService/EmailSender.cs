namespace WelcomeEmailService
{
    using NServiceBus;
    using NServiceBus.Logging;
    using UserService.Messages.Events;

    public class EmailSender : IHandleMessages<IUserCreatedEvent>
    {
        #region Static Fields

        private static readonly ILog Log = LogManager.GetLogger(typeof(EmailSender));

        #endregion

        #region Public Properties

        public IBus Bus { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Handle(IUserCreatedEvent message)
        {
            Log.InfoFormat("Sending welcome email to {0}", message.EmailAddress);
        }

        #endregion
    }
}