using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace EmergencyInformationSystem.Models.Domains3.Entities
{
    public class EiSDbContext : DbContext
    {
        public EiSDbContext() : base("EiSConnection3")
        {

        }

        public EiSDbContext(string connection) : base(connection)
        {

        }





        public virtual DbSet<Bed> Beds { get; set; }

        public virtual DbSet<CriticalLevel> CriticalLevels { get; set; }

        public virtual DbSet<Destination> Destinations { get; set; }

        public virtual DbSet<GreenPathCategory> GreenPathCategories { get; set; }

        //public virtual DbSet<ImageCategory> ImageCategorys { get; set; }

        public virtual DbSet<InRoomWay> InRoomWays { get; set; }

        public virtual DbSet<RescueResult> RescueResults { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<TransferReason> TransferReasons { get; set; }





        //public virtual DbSet<DrugRecordDefinition> DrugRecordDefinitions { get; set; }





        public virtual DbSet<GeneralRoomInfo> GeneralRoomInfos { get; set; }

        //public virtual DbSet<GreenPathAmiInfo> GreenPathAmiInfos { get; set; }

        //public virtual DbSet<Consultation> Consultations { get; set; }

        //public virtual DbSet<DrugRecord> DrugRecords { get; set; }

        //public virtual DbSet<ImageRecord> ImageRecords { get; set; }

        //public virtual DbSet<TreatmentRecord> TreatmentRecords { get; set; }





        public virtual DbSet<GreenPathInfo> GreenPathInfos { get; set; }

        public virtual DbSet<GreenPathAmiInfo> GreenPathAmiInfos { get; set; }
    }
}
