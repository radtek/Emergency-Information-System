using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TrasenLib;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos2.Create
{
    public class Create2
    {
        public Create2(string outPatientNumber)
        {
            var dbTrasen = new TrasenDbContext("TrasenConnection");

            var itemKDJB = dbTrasen.YY_KDJB.Where(c => c.KH == outPatientNumber).First();
            var listGHXX = dbTrasen.VI_MZ_GHXX.Where(c => c.BRXXID == itemKDJB.BRXXID).OrderByDescending(c => c.GHSJ).ThenBy(c => c.GHXXID).ToList();

            this.ListGhxx = listGHXX.Select(c => new ItemGhxx(c)).ToList();
        }





        public List<ItemGhxx> ListGhxx { get; set; }
    }
}