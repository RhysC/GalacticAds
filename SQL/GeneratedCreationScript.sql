
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF09E17196BABA5EE]') AND parent_object_id = OBJECT_ID('StoreContract'))
alter table StoreContract  drop constraint FKF09E17196BABA5EE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK81CEEDE4299973A8]') AND parent_object_id = OBJECT_ID('Advertiser'))
alter table Advertiser  drop constraint FK81CEEDE4299973A8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5FC5F1E3406826CE]') AND parent_object_id = OBJECT_ID('AdvertiserCategory'))
alter table AdvertiserCategory  drop constraint FK5FC5F1E3406826CE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5FC5F1E348C8510]') AND parent_object_id = OBJECT_ID('AdvertiserCategory'))
alter table AdvertiserCategory  drop constraint FK5FC5F1E348C8510


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5C0EC3F7299973A8]') AND parent_object_id = OBJECT_ID('Store'))
alter table Store  drop constraint FK5C0EC3F7299973A8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEF67B50E6BABA5EE]') AND parent_object_id = OBJECT_ID('RollUsage'))
alter table RollUsage  drop constraint FKEF67B50E6BABA5EE


    if exists (select * from dbo.sysobjects where id = object_id(N'StoreContract') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table StoreContract

    if exists (select * from dbo.sysobjects where id = object_id(N'Advertiser') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Advertiser

    if exists (select * from dbo.sysobjects where id = object_id(N'AdvertiserCategory') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table AdvertiserCategory

    if exists (select * from dbo.sysobjects where id = object_id(N'Address') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Address

    if exists (select * from dbo.sysobjects where id = object_id(N'Store') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Store

    if exists (select * from dbo.sysobjects where id = object_id(N'RollUsage') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table RollUsage

    if exists (select * from dbo.sysobjects where id = object_id(N'Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Category

    if exists (select * from dbo.sysobjects where id = object_id(N'Company') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Company

    create table StoreContract (
        Id INT IDENTITY NOT NULL,
       StartDate DATETIME null,
       TermInMonths INT null,
       AgreedPricePerNonPrintedRoll DECIMAL(19,5) null,
       AgreedPricePerPrintedRoll DECIMAL(19,5) null,
       AgreedShippingRate DECIMAL(19,5) null,
       Document VARBINARY(8000) null,
       DocumentMimeType NVARCHAR(255) null,
       DocumentFileName NVARCHAR(255) null,
       StoreId INT null,
       primary key (Id)
    )

    create table Advertiser (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       GeographicalLocation INT null,
       primary key (Id)
    )

    create table AdvertiserCategory (
        AdvertiserId INT not null,
       CategoryId INT not null
    )

    create table Address (
        Id INT IDENTITY NOT NULL,
       StreetAddress NVARCHAR(255) null,
       Suburb NVARCHAR(255) null,
       City NVARCHAR(255) null,
       PostCode NVARCHAR(255) null,
       Provence NVARCHAR(255) null,
       Country NVARCHAR(255) null,
       Latitude DECIMAL(19,5) null,
       Longitude DECIMAL(19,5) null,
       IsGeoLocationConfirmed BIT null,
       primary key (Id)
    )

    create table Store (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       GeographicalLocation INT null,
       primary key (Id)
    )

    create table RollUsage (
        Id INT IDENTITY NOT NULL,
       NumberOfRollsUsed INT null,
       StoreId INT null,
       StartDate DATETIME null,
       EndDate DATETIME null,
       primary key (Id)
    )

    create table Category (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       primary key (Id)
    )

    create table Company (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       primary key (Id)
    )

    alter table StoreContract 
        add constraint FKF09E17196BABA5EE 
        foreign key (StoreId) 
        references Store

    alter table Advertiser 
        add constraint FK81CEEDE4299973A8 
        foreign key (GeographicalLocation) 
        references Address

    alter table AdvertiserCategory 
        add constraint FK5FC5F1E3406826CE 
        foreign key (CategoryId) 
        references Category

    alter table AdvertiserCategory 
        add constraint FK5FC5F1E348C8510 
        foreign key (AdvertiserId) 
        references Advertiser

    alter table Store 
        add constraint FK5C0EC3F7299973A8 
        foreign key (GeographicalLocation) 
        references Address

    alter table RollUsage 
        add constraint FKEF67B50E6BABA5EE 
        foreign key (StoreId) 
        references Store
