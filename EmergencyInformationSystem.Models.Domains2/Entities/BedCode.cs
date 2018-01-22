using System;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Flags]
    public enum BedCode
    {
        Empty = 0,
        RescueRoom = 1,
        ObserveRoom = 2,
    }
}