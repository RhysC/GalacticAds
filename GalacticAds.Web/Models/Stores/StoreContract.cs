using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GalacticAds.Web.Models
{
    [ActiveRecord]
    public class StoreContract : ActiveRecordBase<StoreContract>
    {
        public StoreContract() { }
        public StoreContract(DateTime startDate, decimal agreedPricePerNonPrintedRoll)
        {
            StartDate = startDate;
            AgreedPricePerNonPrintedRoll = agreedPricePerNonPrintedRoll;
            AgreedPricePerPrintedRoll = 0;
            TermInMonths = 24;
        }
        [PrimaryKey(PrimaryKeyType.Native, UnsavedValue = "0")]
        public int Id { get; set; }
        [BelongsTo("StoreId")]
        public Store Store { get; set; }
        [Property]
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Property]
        [Required]
        [DisplayName("Term (in months)")]
        public int TermInMonths { get; set; }

        [Property]
        [DisplayName("Agreed Price Per Non-Printed Roll")]
        public decimal AgreedPricePerNonPrintedRoll { get; set; }//assume South african Rand

        [Property]
        [Required]
        [DisplayName("Agreed Price Per Printed Roll")]
        public decimal AgreedPricePerPrintedRoll { get; set; }//assume rand

        [Property]
        [DisplayName("Agreed Shipping Rate")]
        public decimal AgreedShippingRate { get; set; }

        [Property(ColumnType = "BinaryBlob")]
        public byte[] Document { get; protected set; }

        [Property]
        public string DocumentMimeType { get; protected set; }

        [Property]
        public string DocumentFileName { get; protected set; }



        public DateTime EndDate { get { return StartDate.AddMonths(TermInMonths); } }
        public void AddDocument(string fileName, string mimeType, byte[] fileData)
        {
            DocumentFileName = fileName;
            DocumentMimeType = mimeType;
            Document = fileData;
        }


    }
}