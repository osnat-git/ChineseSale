namespace Project.BLL.Interfaces
{
    /// <summary>
    /// Service for sending emails to winners and other recipients
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Send a winner notification email
        /// </summary>
        Task<Result<string>> SendWinnerEmailAsync(Models.User winner, Models.Present present);

        /// <summary>
        /// Send winner emails to all winners
        /// </summary>
        Task<Result<string>> SendAllWinnersEmailAsync();
    }
}