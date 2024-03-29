﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using EmergencyInformationSystem.Models.Domains.Entities;

namespace EmergencyInformationSystem.Models.ViewModels.RescueRoomInfos.Index
{
    /// <summary>
    /// 抢救室——一览。
    /// </summary>
    public class Index
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="route">导航对象。</param>
        public Index(Route route)
        {
            var db = new EiSDbContext();

            var query = db.RescueRoomInfos.AsQueryable();

            if (route.InDepartmentTimeStart != null)
                query = query.Where(c => route.InDepartmentTimeStart.Value <= c.InDepartmentTime);
            if (route.InDepartmentTimeEnd != null)
                query = query.Where(c => c.InDepartmentTime < route.InDepartmentTimeEnd);
            if (route.OutDepartmentTimeStart != null)
                query = query.Where(c => route.OutDepartmentTimeStart.Value <= c.OutDepartmentTime);
            if (route.OutDepartmentTimeEnd != null)
                query = query.Where(c => c.OutDepartmentTime < route.OutDepartmentTimeEnd);
            if (route.GreenPathCategoryId != null)
                query = query.Where(c => c.GreenPathCategoryId == route.GreenPathCategoryId);
            if (route.IsRescue != null)
                query = query.Where(c => c.IsRescue == route.IsRescue);
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
            if (route.InRescueRoomWayId != null)
                query = query.Where(c => c.InRescueRoomWayId == route.InRescueRoomWayId);
            if (route.DestinationId != null)
                query = query.Where(c => c.DestinationId == route.DestinationId);

            route.Count = query.Count();
            var queryOrdered = query.OrderByDescending(c => c.InDepartmentTime).ThenBy(c => c.RescueRoomInfoId);
            var queryCurrentPage = queryOrdered.Skip((route.Page - 1) * route.PerPage).Take(route.PerPage);

            this.Route = route;

            this.List = queryCurrentPage.ToList().Select(c => new Item(c)).ToList();
        }





        /// <summary>
        /// 导航。
        /// </summary>
        public Route Route { get; set; }





        /// <summary>
        /// 列表项。
        /// </summary>
        public List<Item> List { get; set; }
    }
}