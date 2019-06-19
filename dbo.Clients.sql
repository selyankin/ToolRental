﻿CREATE TABLE [dbo].[Clients] (
    [Id]                INT            NOT NULL,
    [Name]              VARCHAR (30)   NOT NULL,
    [Surname]           VARCHAR (30)   NOT NULL,
    [Patronymic]        VARCHAR (30)   NULL,
    [Sex]               VARCHAR (7)    NOT NULL,
    [City]              VARCHAR (20)   NOT NULL,
    [Street]            VARCHAR (20)   NULL,
    [Building]          VARCHAR (5)    NULL,
    [Apartment]         VARCHAR (5)    NULL,
    [HomePhone]         VARCHAR (10)   NULL,
    [OfficePhone]       VARCHAR (10)   NULL,
    [CellPhone]         VARCHAR (13)   NULL,
    [Email]             VARCHAR (30)   NULL,
    [Deposit]           BIT            NULL,
    [Balance]           INT            NULL,
    [Discount]          INT            NULL,
    [Note]              VARCHAR (4000) NULL,
    [PassPort]          BIGINT         NOT NULL,
    [IssueDate]         VARCHAR(10)    NULL,
    [WhoIssuedPassport] VARCHAR (40)   NULL,
    [ResidenceAddress]  VARCHAR (60)   NULL
);

