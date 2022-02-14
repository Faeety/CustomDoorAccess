using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace CustomDoorAccess
{
    public class Configs : IConfig
    {
        [Description("Enable or disable CustomDoorAccess.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Allow or disallow revocation of the access to all the other keycards.")]
        public bool RevokeAll { get; set; } = false;

        [Description("Allow or disallow SCPs to open doors that you set with scp_access_doors.")]
        public bool ScpAccess { get; set; } = false;

        [Description("Gives access to the door with the item(s) that you set.")]
        public Dictionary<string, string> AccessSet { get; set; } = new Dictionary<string, string> {{"INTERCOM", "5&7"}};

        [Description("List of the doors that SCPs can open. Only works if door is edited on the access_set config.")]
        public List<string> ScpAccessDoors { get; set; } = new List<string> { "CHECKPOINT_LCZ_A", "CHECKPOINT_LCZ_B", "CHECKPOINT_EZ_HCZ" };

        [Description("Allow or disallow SCP-079 bypass.")]
        public bool Scp079Bypass { get; set; } = false;

        [Description("List of item(s) that are allowed to open the generator doors. (If empty the default keycards will be used)")]
        public List<int> GeneratorAccess { get; set; } = new List<int>();

        [Description("List of item(s) that are allowed to use the elevators. (If empty no access will be set)")]
        public Dictionary<string, string> ElevatorAccess { get; set; } = new Dictionary<string, string>();

        [Description("List of item(s) that are allowed to open lockers. (If empty the default keycards will be used or no access will be set)")]
        public Dictionary<string, string> LockersAccess { get; set; } = new Dictionary<string, string>();

        [Description("List of item(s) that are allowed to activate the workstation. (If empty can be activated without anything)")]
        public List<int> WorkStationAccess { get; set; } = new List<int>();
    }
}