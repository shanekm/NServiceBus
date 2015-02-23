namespace UserService.Messages.Events
{
    using System;
    using NServiceBus;

    public interface IUserCreatedEvent : IEvent
    {
        #region Public Properties

        string Name { get; set; }

        Guid UserId { get; set; }

        string EmailAddress { get; set; }

        #endregion
    }
}