using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EmergencyInformationSystem.Models.ViewModels.ObserveRoomInfos.Index
{
    /// <summary>
    /// 导航。
    /// </summary>  
    public class Route
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Route"/> class.
        /// </summary>
        /// <param name="inTimeStart">入室时间开始点。</param>
        /// <param name="inTimeEnd">入室时间结束点。</param>
        /// <param name="outTimeStart">离室时间开始点。</param>
        /// <param name="outTimeEnd">离室时间结束点。</param>       
        /// <param name="isLeave">是否已离室。</param>
        /// <param name="patientName">患者姓名。</param>
        /// <param name="outPatientNumber">卡号。</param>
        /// <param name="page">页码。</param>
        /// <param name="perPage">每页项目数。</param>
        /// <param name="count">项目总数。</param>
        public Route(DateTime? inTimeStart, DateTime? inTimeEnd, DateTime? outTimeStart, DateTime? outTimeEnd, bool? isLeave, string patientName, string outPatientNumber, int page, int perPage, int count)
        {
            this.InTimeStart = inTimeStart;
            this.InTimeEnd = inTimeEnd;
            this.OutTimeStart = outTimeStart;
            this.OutTimeEnd = outTimeEnd;
            this.IsLeave = isLeave;
            this.PatientName = patientName;
            this.OutPatientNumber = outPatientNumber;

            this.Page = page;
            this.PerPage = perPage;

            this.Count = count;
        }





        /// <summary>
        /// 入室时间开始点。
        /// </summary>
        [Display(Name = "入室时间")]
        public DateTime? InTimeStart { get; set; }

        /// <summary>
        /// 入室时间结束点。
        /// </summary>
        public DateTime? InTimeEnd { get; set; }

        /// <summary>
        /// 离室时间开始点。
        /// </summary>
        [Display(Name = "离室时间")]
        public DateTime? OutTimeStart { get; set; }

        /// <summary>
        /// 离室时间结束点。
        /// </summary>
        public DateTime? OutTimeEnd { get; set; }

        /// <summary>
        /// 是否已离室。
        /// </summary>
        [Display(Name = "离室")]
        public bool? IsLeave { get; set; }

        /// <summary>
        /// 卡号。
        /// </summary>
        [Display(Name = "卡号")]
        public string OutPatientNumber { get; set; }

        /// <summary>
        /// 患者姓名。
        /// </summary>
        [Display(Name = "患者姓名")]
        public string PatientName { get; set; }





        /// <summary>
        /// 页码。
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页项目数。
        /// </summary>
        public int PerPage { get; set; }





        /// <summary>
        /// 项目总数。
        /// </summary>
        public int Count { get; set; }





        /// <summary>
        /// 最大页码。
        /// </summary>
        public int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((double)this.Count / this.PerPage);
            }
        }





        /// <summary>
        /// 获取指定页码导航。
        /// </summary>
        /// <param name="page">页码。</param>
        public Route GetRoute(int page)
        {
            return new Route(this.InTimeStart, this.InTimeEnd, this.OutTimeStart, this.OutTimeEnd, this.IsLeave, this.PatientName, this.OutPatientNumber, page, this.PerPage, this.Count);
        }
    }
}