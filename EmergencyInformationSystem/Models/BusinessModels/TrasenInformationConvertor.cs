using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.BusinessModels
{
    public static class TrasenInformationConvertor
    {
        public static string FromEmployeeNumberToName(string employeeNumber)
        {
            if (employeeNumber == null)
                return employeeNumber;

            var tempEmployeeNumber = employeeNumber.Trim();
            var i = new int();

            if (tempEmployeeNumber.Length == 4 && int.TryParse(tempEmployeeNumber, out i))
            {
                var dbTrasen = new TrasenLib.TrasenDbContext("TrasenConnection");

                var itemJC_EMPLOYEE_PROPERTY = dbTrasen.JC_EMPLOYEE_PROPERTY.Where(c => c.D_CODE == tempEmployeeNumber).FirstOrDefault();
                if (itemJC_EMPLOYEE_PROPERTY != null)
                {
                    return itemJC_EMPLOYEE_PROPERTY.NAME;
                }
            }

            return employeeNumber;
        }

        public static void FromEmployeeNumberToName(RescueRoomInfo rescueRoomInfo)
        {
            rescueRoomInfo.FirstNurseName = FromEmployeeNumberToName(rescueRoomInfo.FirstNurseName);
            rescueRoomInfo.DestinationFirstContact = FromEmployeeNumberToName(rescueRoomInfo.DestinationFirstContact);
            rescueRoomInfo.HandleNurse = FromEmployeeNumberToName(rescueRoomInfo.HandleNurse);
        }

        public static void FromEmployeeNumberToName(ObserveRoomInfo observeRoomInfo)
        {
            observeRoomInfo.FirstNurseName = FromEmployeeNumberToName(observeRoomInfo.FirstNurseName);
            observeRoomInfo.DestinationFirstContact = FromEmployeeNumberToName(observeRoomInfo.DestinationFirstContact);
            observeRoomInfo.HandleNurse = FromEmployeeNumberToName(observeRoomInfo.HandleNurse);
        }

        public static void FromEmployeeNumberToName(RescueRoomConsultation rescueRoomConsultation)
        {
            rescueRoomConsultation.ConsultationDoctorName = FromEmployeeNumberToName(rescueRoomConsultation.ConsultationDoctorName);
        }
    }
}