using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace EmergencyInformationSystem.Models.Domains.Entities
{
    /// <summary>
    /// EiS数据上下文。
    /// </summary>
    public class EiSDbContext : DbContext
    {
        /// <summary>
        /// 初始化实例<see cref="EiSDbContext"/>。
        /// </summary>
        public EiSDbContext() : base("LocalConnection")
        {
        }

        /// <summary>
        /// 初始化实例<see cref="EiSDbContext"/>。
        /// </summary>
        /// <param name="connection">连接字符串。</param>
        public EiSDbContext(string connection) : base(connection)
        {
        }





        /// <summary>
        /// 床位。
        /// </summary>
        public DbSet<Bed> Beds { get; set; }

        /// <summary>
        /// 危重等级。
        /// </summary>
        public DbSet<CriticalLevel> CriticalLevels { get; set; }

        /// <summary>
        /// 去向。
        /// </summary>
        public DbSet<Destination> Destinations { get; set; }

        /// <summary>
        /// 绿色通道——急性心肌梗死。
        /// </summary>
        public DbSet<GreenPathAmi> GreenPathAmis { get; set; }

        /// <summary>
        /// 绿色通道类型。
        /// </summary>
        public DbSet<GreenPathCategory> GreenPathCategories { get; set; }

        /// <summary>
        /// 绿色通道——急性脑卒中。
        /// </summary>
        public DbSet<GreenPathStk> GreenPathStks { get; set; }

        /// <summary>
        /// 影像类型。
        /// </summary>
        public DbSet<ImageCategory> ImageCategories { get; set; }

        /// <summary>
        /// 进入留观室方式。
        /// </summary>
        public DbSet<InObserveRoomWay> InObserveRoomWays { get; set; }

        /// <summary>
        /// 进入抢救室方式。
        /// </summary>
        public DbSet<InRescueRoomWay> InRescueRoomWays { get; set; }

        /// <summary>
        /// 留观室病例。
        /// </summary>
        public DbSet<ObserveRoomInfo> ObserveRoomInfos { get; set; }

        /// <summary>
        /// 抢救效果。
        /// </summary>
        public DbSet<RescueResult> RescueResults { get; set; }

        /// <summary>
        /// 抢救室会诊项。
        /// </summary>
        public DbSet<RescueRoomConsultation> RescueRoomConsultations { get; set; }

        /// <summary>
        /// 抢救室用药项。
        /// </summary>
        public DbSet<RescueRoomDrugRecord> RescueRoomDrugRecords { get; set; }

        /// <summary>
        /// 抢救室影像项。
        /// </summary>
        public DbSet<RescueRoomImageRecord> RescueRoomImageRecords { get; set; }

        /// <summary>
        /// 抢救室治疗项。
        /// </summary>
        public DbSet<RescueRoomTreatmentRecord> RescueRoomTreatmentRecords { get; set; }

        /// <summary>
        /// 抢救室病例。
        /// </summary>
        public DbSet<RescueRoomInfo> RescueRoomInfos { get; set; }

        public DbSet<RescueRoomDrugRecordDefinition> RescueRoomDrugRecordDefinitions { get; set; }

        public DbSet<RescueRoomTreatmentRecordDefinition> RescueRoomTreatmentRecordDefinitions { get; set; }

        public DbSet<TransferReason> TransferReasons { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RescueRoomInfo>()
                .HasOptional(c => c.NextObserveRoomInfo)
                .WithOptionalDependent(c => c.PreviousRescueRoomInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ObserveRoomInfo>()
                .HasOptional(c => c.NextRescueRoomInfo)
                .WithOptionalDependent(c => c.PreviousObserveRoomInfo)
                .WillCascadeOnDelete(false);
        }
    }
}