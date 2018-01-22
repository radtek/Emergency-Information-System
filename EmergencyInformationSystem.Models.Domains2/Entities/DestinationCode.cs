using System;

namespace EmergencyInformationSystem.Models.Domains2.Entities
{
    [Flags]
    public enum DestinationCode
    {
        Empty = 0,
        UseForRescueRoom = 1,
        UseForObserveRoom = 2,
        UseForSubscription = 4,
        UseForConsultation = 8,
        ToInDepartment = 16,
        ToOutDepartment = 32,
        ToLeave = 64,
        ToOther = 128,
        HasAdditionalInfo = 256,
        TransferHospital = 512,
        NeedProfessional = 1024,
    }
}
