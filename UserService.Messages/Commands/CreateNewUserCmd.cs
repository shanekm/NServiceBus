namespace UserService.Messages.Commands
{
    using NServiceBus;

    public class CreateNewUserCmd : ICommand
    {
        #region Public Properties

        public string EmailAddress { get; set; }

        public string Name { get; set; }

        #endregion
    }
}