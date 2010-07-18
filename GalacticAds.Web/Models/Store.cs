using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using GalacticAds.Web.Models.Interfaces;

namespace GalacticAds.Web.Models
{
    /// <summary>
    /// A store that will recieve reciepts rolls with adverts
    /// </summary>
    [ActiveRecord]
    public class Store : ActiveRecordBase<Store>, IHaveGeographicalLocation
    {
        [PrimaryKey(PrimaryKeyType.Native)]
        public int Id { get; set; }
        [Property]
        public string Name { get; set; }
        //[BelongsTo(Cascade = CascadeEnum.SaveUpdate)]
        //public Company Company { get; set; }
        //[Property]
        //public string PhoneNumber { get; set; }
        [BelongsTo(Cascade = CascadeEnum.SaveUpdate)]
        public Address GeographicalLocation { get; set; }
    }

   
}
//USE [GalacticAds]
//GO

///****** Object:  Table [dbo].[Address]    Script Date: 06/13/2010 18:33:51 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[Address](
//    [Id] [int] IDENTITY(1,1) NOT NULL,
//    [StreetAddress] [nvarchar](255) NULL,
//    [Suburb] [nvarchar](255) NULL,
//    [City] [nvarchar](255) NULL,
//    [PostCode] [nvarchar](255) NULL,
//    [Provence] [nvarchar](255) NULL,
//    [Country] [nvarchar](255) NULL,
//    [Latitude] [decimal](19, 5) NULL,
//    [Longitude] [decimal](19, 5) NULL,
//    [Location]  AS ([geography]::STPointFromText(((('Point('+CONVERT([varchar](10),[Longitude],0))+' ')+CONVERT([varchar](10),[Latitude],0))+')',(4326))),
//PRIMARY KEY CLUSTERED 
//(
//    [Id] ASC
//)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
//) ON [PRIMARY]

//GO

//EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Geographical location' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Address', @level2type=N'COLUMN',@level2name=N'Location'
//GO
