using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.Core.Models.Impls
{
    internal class CoreConditionTypeImpl : ICoreConditionType
    {
        public int Retro { get; set; }
        public int RetroDistr { get; set; }
        public int Rku { get; set; }
        public int RkuDistr { get; set; }
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
    }
}