using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.GeneralInfos.RelatedIndex
{
    public class RelatedIndex
    {
        public RelatedIndex(Guid id)
        {
            var db3 = new Domains3.Entities.EiSDbContext();

            var target = db3.GeneralRoomInfos.Find(id);
            if (target == null)
                throw new ArgumentException("ID不存在", "id", null);

            this.List = new List<Item>();

            Domains3.Entities.GeneralRoomInfo targetTemp;

            //前
            targetTemp = target.PreGeneralRoomInfo;
            while (targetTemp != null)
            {
                this.List.Add(new Item(targetTemp, false));
                targetTemp = targetTemp.PreGeneralRoomInfo;
            }

            //当
            this.List.Add(new Item(target, true));

            //后
            targetTemp = target;
            do
            {
                targetTemp = db3.GeneralRoomInfos.FirstOrDefault(c => c.PreGeneralRoomInfoId == targetTemp.GeneralRoomInfoId);

                if (targetTemp != null)
                    this.List.Add(new Item(targetTemp, false));
                else
                    break;
            } while (true);

            this.List = this.List.OrderBy(c => c.InDepartmentTime).ToList();
        }





        public List<Item> List { get; set; }
    }
}