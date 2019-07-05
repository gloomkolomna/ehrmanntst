namespace Ehrmann.Core.Models.Interfaces
{
    /// <summary>
    /// Значения
    /// </summary>
    public interface ICoreValues
    {
        /// <summary>
        /// Ретро
        /// </summary>
        int Retro { get; set; }
        /// <summary>
        /// Ретро, дистр
        /// </summary>
        int RetroDistr { get; set; }
        /// <summary>
        /// РКУ
        /// </summary>
        int Rku { get; set; }
        /// <summary>
        /// РКУ, дистр
        /// </summary>
        int RkuDistr { get; set; }
    }
}