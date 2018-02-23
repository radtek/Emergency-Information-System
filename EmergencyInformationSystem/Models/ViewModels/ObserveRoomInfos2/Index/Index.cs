﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos2.Index
{
    public class Index
    {
        public Index(Route route)
        {
            var db3 = new Domains3.Entities.EiSDbContext();

            var query = db3.GeneralRoomInfos.Where(c => c.Room.IsObserveRoom);

            if (route.InDepartmentTimeStart != null)
                query = query.Where(c => route.InDepartmentTimeStart.Value <= c.InDepartmentTime);
            if (route.InDepartmentTimeEnd != null)
                query = query.Where(c => c.InDepartmentTime < route.InDepartmentTimeEnd);
            if (route.OutDepartmentTimeStart != null)
                query = query.Where(c => route.OutDepartmentTimeStart.Value <= c.OutDepartmentTime);
            if (route.OutDepartmentTimeEnd != null)
                query = query.Where(c => c.OutDepartmentTime < route.OutDepartmentTimeEnd);
            if (route.IsLeave != null)
                query = query.Where(c => c.OutDepartmentTime.HasValue == route.IsLeave);
            if (!string.IsNullOrWhiteSpace(route.PatientName))
            {
                route.PatientName = route.PatientName.Trim();
                query = query.Where(c => c.PatientName == route.PatientName);
            }
            if (!string.IsNullOrWhiteSpace(route.OutPatientNumber))
            {
                route.OutPatientNumber = route.OutPatientNumber.Trim();
                query = query.Where(c => c.OutPatientNumber == route.OutPatientNumber);
            }
            if (route.InRoomWayId != null)
                query = query.Where(c => c.InRoomWayId == route.InRoomWayId);
            if (route.DestinationId != null)
                query = query.Where(c => c.DestinationId == route.DestinationId);

            route.Count = query.Count();

            var queryOrdered = query.OrderByDescending(c => c.InDepartmentTime).ThenBy(c => c.GeneralRoomInfoId);
            var queryCurrentPage = queryOrdered.Skip((route.Page - 1) * route.PerPage).Take(route.PerPage);

            this.Route = route;

            this.List = queryCurrentPage.ToList().Select(c => new Item(c)).ToList();
        }





        public Route Route { get; set; }

        public List<Item> List { get; set; }
    }
}