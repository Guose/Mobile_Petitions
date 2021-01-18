
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/05/2018 17:15:27
-- Generated from EDMX file: C:\Users\Guose\OneDrive\Desktop\SMG\SMG Mobile Petitions\Mobile_Petitions\Mobile_Petitions.DAL\MobilePetitionModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Mobile_Petition];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CirculatorSignature]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Signatures] DROP CONSTRAINT [FK_CirculatorSignature];
GO
IF OBJECT_ID(N'[dbo].[FK_CirculatorNotaryPage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NotaryPages] DROP CONSTRAINT [FK_CirculatorNotaryPage];
GO
IF OBJECT_ID(N'[dbo].[FK_CountyCodePetitionMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PetitionMasters] DROP CONSTRAINT [FK_CountyCodePetitionMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_PetitionTypePetitionMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PetitionMasters] DROP CONSTRAINT [FK_PetitionTypePetitionMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_PetitionMasterDataLinkCriteria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DataLinkCriterias] DROP CONSTRAINT [FK_PetitionMasterDataLinkCriteria];
GO
IF OBJECT_ID(N'[dbo].[FK_DataLinkCriteriaPetitionLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PetitionLines] DROP CONSTRAINT [FK_DataLinkCriteriaPetitionLine];
GO
IF OBJECT_ID(N'[dbo].[FK_NotaryPagePetitionLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PetitionLines] DROP CONSTRAINT [FK_NotaryPagePetitionLine];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Signatures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Signatures];
GO
IF OBJECT_ID(N'[dbo].[RememberUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RememberUsers];
GO
IF OBJECT_ID(N'[dbo].[Circulators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Circulators];
GO
IF OBJECT_ID(N'[dbo].[PetitionMasters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PetitionMasters];
GO
IF OBJECT_ID(N'[dbo].[PetitionTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PetitionTypes];
GO
IF OBJECT_ID(N'[dbo].[NotaryPages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NotaryPages];
GO
IF OBJECT_ID(N'[dbo].[VRImports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VRImports];
GO
IF OBJECT_ID(N'[dbo].[CountyCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CountyCodes];
GO
IF OBJECT_ID(N'[dbo].[DataLinkCriterias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataLinkCriterias];
GO
IF OBJECT_ID(N'[dbo].[PetitionLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PetitionLines];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Signatures'
CREATE TABLE [dbo].[Signatures] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Suffix] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [DLNumber] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Zip] nvarchar(max)  NOT NULL,
    [SignatureClip] nvarchar(max)  NOT NULL,
    [DateSigned] datetime  NOT NULL,
    [CirculatorID] int  NOT NULL
);
GO

-- Creating table 'RememberUsers'
CREATE TABLE [dbo].[RememberUsers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ReUser] nvarchar(max)  NOT NULL,
    [RePassword] nvarchar(max)  NOT NULL,
    [DateEntered] datetime  NOT NULL
);
GO

-- Creating table 'Circulators'
CREATE TABLE [dbo].[Circulators] (
    [CirculatorID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [County] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [ZipCode] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Admin] bit  NOT NULL,
    [CircSigClip] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PetitionMasters'
CREATE TABLE [dbo].[PetitionMasters] (
    [PetitionID] int IDENTITY(1,1) NOT NULL,
    [ProponentID] float  NOT NULL,
    [JurisdictionID] int  NOT NULL,
    [PetitionName] nvarchar(max)  NOT NULL,
    [PetitionTypeID] int  NOT NULL,
    [ProposedLawText] nvarchar(max)  NOT NULL,
    [PetitionNumber] float  NOT NULL,
    [LegalReleaseDate] datetime  NOT NULL,
    [LegalTitle] nvarchar(max)  NOT NULL,
    [LegalSummary] nvarchar(max)  NOT NULL,
    [FullTextDisplay] nvarchar(max)  NOT NULL,
    [FullTextPrint] nvarchar(max)  NOT NULL,
    [FullTextDoc] nvarchar(max)  NOT NULL,
    [BasisElectionDate] datetime  NOT NULL,
    [BasisElectionCount] float  NOT NULL,
    [NextElectionDate] datetime  NOT NULL,
    [SignaturesRequired] bit  NOT NULL,
    [PetitionDeadlineDate] datetime  NOT NULL,
    [Status] float  NOT NULL,
    [CirculatorName] nvarchar(max)  NOT NULL,
    [AutoSignature] bit  NOT NULL,
    [PetitionSubmitDate] datetime  NOT NULL,
    [CandidateID] nvarchar(max)  NOT NULL,
    [PoliticalPartyID] nvarchar(max)  NOT NULL,
    [JurisdictionValueID] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PetitionTypes'
CREATE TABLE [dbo].[PetitionTypes] (
    [PetitionTypeID] int IDENTITY(1,1) NOT NULL,
    [PetitionTypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NotaryPages'
CREATE TABLE [dbo].[NotaryPages] (
    [PageID] int IDENTITY(1,1) NOT NULL,
    [PageKey] int  NOT NULL,
    [PacketKey] nvarchar(max)  NOT NULL,
    [PageNum] nvarchar(max)  NOT NULL,
    [ScanDate] datetime  NOT NULL,
    [CirculatorID] int  NOT NULL,
    [CircultorNotaryCounty] nvarchar(max)  NOT NULL,
    [CirculatorNotaryName] nvarchar(max)  NOT NULL,
    [CirculatorCounty] nvarchar(max)  NOT NULL,
    [CirculatorName] nvarchar(max)  NOT NULL,
    [CirculatorAddress] nvarchar(max)  NOT NULL,
    [CirculatorCity] nvarchar(max)  NOT NULL,
    [CirculatorState] nvarchar(max)  NOT NULL,
    [CirculatorZipCode] nvarchar(max)  NOT NULL,
    [CirculatorDateSigned] nvarchar(max)  NOT NULL,
    [SerialNumberBackError] nvarchar(max)  NOT NULL,
    [CirculatorDataError] nvarchar(max)  NOT NULL,
    [NotaryDataError] nvarchar(max)  NOT NULL,
    [NotaryExpiredError] nvarchar(max)  NOT NULL,
    [EarlyNotarizationError] nvarchar(max)  NOT NULL,
    [CirculatorNotRegisteredError] nvarchar(max)  NOT NULL,
    [SerialNumberBackParaError] nvarchar(max)  NOT NULL,
    [CirculatorDataParaError] nvarchar(max)  NOT NULL,
    [NotaryDataParaError] nvarchar(max)  NOT NULL,
    [NotaryExpiredParaError] nvarchar(max)  NOT NULL,
    [EarlyNotarizationParaError] nvarchar(max)  NOT NULL,
    [CirculatorNotRegisteredParaError] nvarchar(max)  NOT NULL,
    [RotatePage] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VRImports'
CREATE TABLE [dbo].[VRImports] (
    [VoterKey] int  NOT NULL,
    [VoterID] int  NOT NULL,
    [DriverLicenseNumber] nvarchar(max)  NOT NULL,
    [JurisdictionVR] int  NOT NULL,
    [VoterName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [ZipCode] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [stdStreet] nvarchar(max)  NOT NULL,
    [stdCity] nvarchar(max)  NOT NULL,
    [stdState] nvarchar(max)  NOT NULL,
    [stdPostalCode] nvarchar(max)  NOT NULL,
    [stdCounty] nvarchar(max)  NOT NULL,
    [AddressExtended] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [stdSuite] nvarchar(max)  NOT NULL,
    [Email] nvarchar(50)  NULL
);
GO

-- Creating table 'CountyCodes'
CREATE TABLE [dbo].[CountyCodes] (
    [JurisdictionID] int IDENTITY(1,1) NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [County_Code] nvarchar(max)  NOT NULL,
    [County] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DataLinkCriterias'
CREATE TABLE [dbo].[DataLinkCriterias] (
    [DataLinkID] int IDENTITY(1,1) NOT NULL,
    [PetitionID] int  NOT NULL,
    [DataLinkCode] nvarchar(max)  NOT NULL,
    [CodeDescription] nvarchar(max)  NOT NULL,
    [OrderBy] float  NOT NULL,
    [UseBirthday] bit  NOT NULL
);
GO

-- Creating table 'PetitionLines'
CREATE TABLE [dbo].[PetitionLines] (
    [LineKey] int IDENTITY(1,1) NOT NULL,
    [PageID] int  NOT NULL,
    [RowIndex] int  NOT NULL,
    [LineStatus] nvarchar(max)  NOT NULL,
    [AutoAccepted] nvarchar(max)  NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [StreetAddress] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [ZipCode] nvarchar(max)  NOT NULL,
    [SignedDate] datetime  NOT NULL,
    [VoterID] nvarchar(max)  NOT NULL,
    [DataLinkID] int  NOT NULL,
    [Apt] nvarchar(max)  NOT NULL,
    [VoterRegNotFoundError] nvarchar(max)  NOT NULL,
    [MissingNameError] nvarchar(max)  NOT NULL,
    [MissingAddressError] nvarchar(max)  NOT NULL,
    [MissingDateSignedError] nvarchar(max)  NOT NULL,
    [AddressMismatchError] nvarchar(max)  NOT NULL,
    [SignatureMismatchError] nvarchar(max)  NOT NULL,
    [InvalidDateSignedError] nvarchar(max)  NOT NULL,
    [MissingSignatureParaError] nvarchar(max)  NOT NULL,
    [MissingNameParaError] nvarchar(max)  NOT NULL,
    [MissingAddressParaError] nvarchar(max)  NOT NULL,
    [MissingDateSignedParaError] nvarchar(max)  NOT NULL,
    [Suffix] nvarchar(max)  NOT NULL,
    [DriverLicenseNumber] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [WithdrawnVoterError] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Signatures'
ALTER TABLE [dbo].[Signatures]
ADD CONSTRAINT [PK_Signatures]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RememberUsers'
ALTER TABLE [dbo].[RememberUsers]
ADD CONSTRAINT [PK_RememberUsers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CirculatorID] in table 'Circulators'
ALTER TABLE [dbo].[Circulators]
ADD CONSTRAINT [PK_Circulators]
    PRIMARY KEY CLUSTERED ([CirculatorID] ASC);
GO

-- Creating primary key on [PetitionID] in table 'PetitionMasters'
ALTER TABLE [dbo].[PetitionMasters]
ADD CONSTRAINT [PK_PetitionMasters]
    PRIMARY KEY CLUSTERED ([PetitionID] ASC);
GO

-- Creating primary key on [PetitionTypeID] in table 'PetitionTypes'
ALTER TABLE [dbo].[PetitionTypes]
ADD CONSTRAINT [PK_PetitionTypes]
    PRIMARY KEY CLUSTERED ([PetitionTypeID] ASC);
GO

-- Creating primary key on [PageID] in table 'NotaryPages'
ALTER TABLE [dbo].[NotaryPages]
ADD CONSTRAINT [PK_NotaryPages]
    PRIMARY KEY CLUSTERED ([PageID] ASC);
GO

-- Creating primary key on [VoterKey], [VoterID] in table 'VRImports'
ALTER TABLE [dbo].[VRImports]
ADD CONSTRAINT [PK_VRImports]
    PRIMARY KEY CLUSTERED ([VoterKey], [VoterID] ASC);
GO

-- Creating primary key on [JurisdictionID] in table 'CountyCodes'
ALTER TABLE [dbo].[CountyCodes]
ADD CONSTRAINT [PK_CountyCodes]
    PRIMARY KEY CLUSTERED ([JurisdictionID] ASC);
GO

-- Creating primary key on [DataLinkID] in table 'DataLinkCriterias'
ALTER TABLE [dbo].[DataLinkCriterias]
ADD CONSTRAINT [PK_DataLinkCriterias]
    PRIMARY KEY CLUSTERED ([DataLinkID] ASC);
GO

-- Creating primary key on [LineKey] in table 'PetitionLines'
ALTER TABLE [dbo].[PetitionLines]
ADD CONSTRAINT [PK_PetitionLines]
    PRIMARY KEY CLUSTERED ([LineKey] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CirculatorID] in table 'Signatures'
ALTER TABLE [dbo].[Signatures]
ADD CONSTRAINT [FK_CirculatorSignature]
    FOREIGN KEY ([CirculatorID])
    REFERENCES [dbo].[Circulators]
        ([CirculatorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CirculatorSignature'
CREATE INDEX [IX_FK_CirculatorSignature]
ON [dbo].[Signatures]
    ([CirculatorID]);
GO

-- Creating foreign key on [CirculatorID] in table 'NotaryPages'
ALTER TABLE [dbo].[NotaryPages]
ADD CONSTRAINT [FK_CirculatorNotaryPage]
    FOREIGN KEY ([CirculatorID])
    REFERENCES [dbo].[Circulators]
        ([CirculatorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CirculatorNotaryPage'
CREATE INDEX [IX_FK_CirculatorNotaryPage]
ON [dbo].[NotaryPages]
    ([CirculatorID]);
GO

-- Creating foreign key on [JurisdictionID] in table 'PetitionMasters'
ALTER TABLE [dbo].[PetitionMasters]
ADD CONSTRAINT [FK_CountyCodePetitionMaster]
    FOREIGN KEY ([JurisdictionID])
    REFERENCES [dbo].[CountyCodes]
        ([JurisdictionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountyCodePetitionMaster'
CREATE INDEX [IX_FK_CountyCodePetitionMaster]
ON [dbo].[PetitionMasters]
    ([JurisdictionID]);
GO

-- Creating foreign key on [PetitionTypeID] in table 'PetitionMasters'
ALTER TABLE [dbo].[PetitionMasters]
ADD CONSTRAINT [FK_PetitionTypePetitionMaster]
    FOREIGN KEY ([PetitionTypeID])
    REFERENCES [dbo].[PetitionTypes]
        ([PetitionTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PetitionTypePetitionMaster'
CREATE INDEX [IX_FK_PetitionTypePetitionMaster]
ON [dbo].[PetitionMasters]
    ([PetitionTypeID]);
GO

-- Creating foreign key on [PetitionID] in table 'DataLinkCriterias'
ALTER TABLE [dbo].[DataLinkCriterias]
ADD CONSTRAINT [FK_PetitionMasterDataLinkCriteria]
    FOREIGN KEY ([PetitionID])
    REFERENCES [dbo].[PetitionMasters]
        ([PetitionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PetitionMasterDataLinkCriteria'
CREATE INDEX [IX_FK_PetitionMasterDataLinkCriteria]
ON [dbo].[DataLinkCriterias]
    ([PetitionID]);
GO

-- Creating foreign key on [DataLinkID] in table 'PetitionLines'
ALTER TABLE [dbo].[PetitionLines]
ADD CONSTRAINT [FK_DataLinkCriteriaPetitionLine]
    FOREIGN KEY ([DataLinkID])
    REFERENCES [dbo].[DataLinkCriterias]
        ([DataLinkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DataLinkCriteriaPetitionLine'
CREATE INDEX [IX_FK_DataLinkCriteriaPetitionLine]
ON [dbo].[PetitionLines]
    ([DataLinkID]);
GO

-- Creating foreign key on [PageID] in table 'PetitionLines'
ALTER TABLE [dbo].[PetitionLines]
ADD CONSTRAINT [FK_NotaryPagePetitionLine]
    FOREIGN KEY ([PageID])
    REFERENCES [dbo].[NotaryPages]
        ([PageID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NotaryPagePetitionLine'
CREATE INDEX [IX_FK_NotaryPagePetitionLine]
ON [dbo].[PetitionLines]
    ([PageID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------