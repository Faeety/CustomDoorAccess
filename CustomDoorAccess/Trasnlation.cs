using System.ComponentModel;
using Exiled.API.Interfaces;

namespace CustomDoorAccess
{
    public class Trasnlation : ITranslation
    {
        [Description("Text displayed after using the generator")]
        public string GeneratorCanOpen { get; set; } = "<color=green>ACCESS GRANTED</color>";
        public string GeneratorCantOpen { get; set; } = "<color=red>ACCESS DENIED</color>";
        [Description("Text displayed after using the lockers")]
        public string LockerCanOpen{ get; set; } = "<color=green>ACCESS GRANTED</color>";
        public string LockerCantOpen { get; set; } = "<color=red>ACCESS DENIED</color>";
        [Description("Text displayed after using the workstation")]
        public string WorkstationCanActivate { get; set; } = "<color=green>ACCESS GRANTED</color>";
        public string WorkstationCantActivate { get; set; } = "<color=red>ACCESS DENIED</color>";
        [Description("Text displayed after using the elevator")]
        public string ElevatorCanUse { get; set; } = "<color=green>ACCESS GRANTED</color>";
        public string ElevatorCantUse { get; set; } = "<color=red>ACCESS DENIED</color>";
    }
}
