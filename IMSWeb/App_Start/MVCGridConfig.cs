using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCGrid.Models;
using IMS.Models;
using MVCGrid.Web;
using System.Web.Mvc;
using IMSWeb.Core.Repository;
using IMSWeb.Core.Repository.Impl;

namespace IMSWeb.App_Start
{
    public class MVCGridConfig
    {
        public static void RegisterGrids()
        {
            ColumnDefaults colDefauls = new ColumnDefaults()
            {
                EnableSorting = true
            };

            MVCGridDefinitionTable.Add("TestGrid", new MVCGridBuilder<Client>(colDefauls)
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .WithSorting(sorting: true, defaultSortColumn: "Clientname", defaultSortDirection: SortDirection.Dsc)
                .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                .WithAdditionalQueryOptionNames("search")
                .AddColumns(cols =>
                {
                    cols.Add("Clientname").WithHeaderText("Client Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientName);
                    //cols.Add("LastName").WithHeaderText("Last Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.LastName);
                    //cols.Add("FirstName").WithHeaderText("First Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.FirstName);
                    //cols.Add("MiddleName").WithHeaderText("Middle Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MiddleName);
                    //cols.Add("Nickname").WithHeaderText("Nickname").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.NickName);
                    cols.Add("ClientType").WithHeaderText("Client Type").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientType);
                    //cols.Add("Title").WithHeaderText("Title").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Title);
                    cols.Add("DateofBirth").WithHeaderText("Date of Birth").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.DateofBirth != null ? p.DateofBirth.ToShortDateString().Replace("1/1/0001", "") : ""));
                    cols.Add("ClientAge").WithHeaderText("Age").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientAge);
                    cols.Add("OfficeName").WithHeaderText("Office Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.OfficeAddress);
                    cols.Add("HomeStreet").WithHeaderText("Home Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.HomeAddress);
                    cols.Add("MailingAddress").WithHeaderText("Mailing Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MailingAddress);
                    cols.Add("ContactNo").WithHeaderText("ContactNo").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactNo);
                    //cols.Add("Suffix").WithHeaderText("Suffix").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Suffix);
                    //cols.Add("Gender").WithHeaderText("Gender").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Gender);
                    //cols.Add("CivilStatus").WithHeaderText("Civil Status").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.CivilStatus);
                    //cols.Add("Account").WithHeaderText("Account").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Account);
                    cols.Add("Mobile").WithHeaderText("Mobile").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Mobile);
                    cols.Add("Phone").WithHeaderText("Phone").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Phone);
                    cols.Add("Email").WithHeaderText("Email").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Email);

                    cols.Add("ContactOf").WithHeaderText("Contact Of").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactOf);
                    cols.Add("ReferredBy").WithHeaderText("Referred By").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ReferredBy);
                    cols.Add("Createdby").WithHeaderText("Created by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Createdby);
                    cols.Add("Createdate").WithHeaderText("Create date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Createdate != null ? p.Createdate.ToShortDateString() : ""));
                    cols.Add("Updatedby").WithHeaderText("Updated by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Updatedby);
                    cols.Add("Updatedate").WithHeaderText("Update date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Updatedate != null ? p.Updatedate.ToShortDateString() : ""));

                    //cols.Add("Notes").WithHeaderText("Notes").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Notes);
                })
                //.WithAdditionalSetting(MVCGrid.Rendering.BootstrapRenderingEngine.SettingNameTableClass, "notreal") // Example of changing table css class
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;

                    int totalRecords;

                    var repo = new ClientRepository(); //DependencyResolver.Current.GetService<IClientRepository>();

                    string globalSearch = options.GetAdditionalQueryOptionString("search");

                    string sortColumn = options.GetSortColumnData<string>();
                    
                    var items = repo.GetNoNicknames(out totalRecords, globalSearch, options.GetLimitOffset(), options.GetLimitRowcount(),
                        sortColumn, options.SortDirection == SortDirection.Dsc);

                    return new QueryResult<Client>()
                    {
                        Items = items,
                        TotalRecords = totalRecords
                    };
                })
            );

            MVCGridDefinitionTable.Add("NoBday", new MVCGridBuilder<Client>(colDefauls)
                           .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                           .WithSorting(sorting: true, defaultSortColumn: "Clientname", defaultSortDirection: SortDirection.Dsc)
                           .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                           .WithAdditionalQueryOptionNames("search")
                           .AddColumns(cols =>
                           {
                               cols.Add("Clientname").WithHeaderText("Client Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientName);
                    //cols.Add("LastName").WithHeaderText("Last Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.LastName);
                    //cols.Add("FirstName").WithHeaderText("First Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.FirstName);
                    //cols.Add("MiddleName").WithHeaderText("Middle Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MiddleName);
                    
                               cols.Add("ClientType").WithHeaderText("Client Type").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientType);
                               cols.Add("Nickname").WithHeaderText("Nickname").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.NickName);
                               //cols.Add("Title").WithHeaderText("Title").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Title);
                               //cols.Add("DateofBirth").WithHeaderText("Date of Birth").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.DateofBirth != null ? p.DateofBirth.ToShortDateString().Replace("1/1/0001", "") : ""));
                               //cols.Add("ClientAge").WithHeaderText("Age").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientAge);
                               cols.Add("OfficeName").WithHeaderText("Office Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.OfficeAddress);
                               cols.Add("HomeStreet").WithHeaderText("Home Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.HomeAddress);
                               cols.Add("MailingAddress").WithHeaderText("Mailing Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MailingAddress);
                               cols.Add("ContactNo").WithHeaderText("ContactNo").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactNo);
                    //cols.Add("Suffix").WithHeaderText("Suffix").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Suffix);
                    //cols.Add("Gender").WithHeaderText("Gender").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Gender);
                    //cols.Add("CivilStatus").WithHeaderText("Civil Status").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.CivilStatus);
                    //cols.Add("Account").WithHeaderText("Account").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Account);
                    cols.Add("Mobile").WithHeaderText("Mobile").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Mobile);
                               cols.Add("Phone").WithHeaderText("Phone").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Phone);
                               cols.Add("Email").WithHeaderText("Email").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Email);

                               cols.Add("ContactOf").WithHeaderText("Contact Of").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactOf);
                               cols.Add("ReferredBy").WithHeaderText("Referred By").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ReferredBy);
                               cols.Add("Createdby").WithHeaderText("Created by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Createdby);
                               cols.Add("Createdate").WithHeaderText("Create date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Createdate != null ? p.Createdate.ToShortDateString() : ""));
                               cols.Add("Updatedby").WithHeaderText("Updated by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Updatedby);
                               cols.Add("Updatedate").WithHeaderText("Update date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Updatedate != null ? p.Updatedate.ToShortDateString() : ""));

                    //cols.Add("Notes").WithHeaderText("Notes").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Notes);
                })
                           //.WithAdditionalSetting(MVCGrid.Rendering.BootstrapRenderingEngine.SettingNameTableClass, "notreal") // Example of changing table css class
                           .WithRetrieveDataMethod((context) =>
                           {
                               var options = context.QueryOptions;

                               int totalRecords;

                               var repo = new ClientRepository(); //DependencyResolver.Current.GetService<IClientRepository>();

                               string globalSearch = options.GetAdditionalQueryOptionString("search");

                               string sortColumn = options.GetSortColumnData<string>();

                               var items = repo.GetNoBirthday(out totalRecords, globalSearch, options.GetLimitOffset(), options.GetLimitRowcount(),
                                   sortColumn, options.SortDirection == SortDirection.Dsc);

                               return new QueryResult<Client>()
                               {
                                   Items = items,
                                   TotalRecords = totalRecords
                               };
                           })
                       );

            MVCGridDefinitionTable.Add("Bday", new MVCGridBuilder<Client>(colDefauls)
                           .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                           .WithSorting(sorting: true, defaultSortColumn: "Clientname", defaultSortDirection: SortDirection.Dsc)
                           .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                           .WithPageParameterNames("Mon")
                           .WithAdditionalQueryOptionNames("search")
                           .AddColumns(cols =>
                           {
                               cols.Add("Clientname").WithHeaderText("Client Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientName);
                               //cols.Add("LastName").WithHeaderText("Last Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.LastName);
                               //cols.Add("FirstName").WithHeaderText("First Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.FirstName);
                               //cols.Add("MiddleName").WithHeaderText("Middle Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MiddleName);

                               cols.Add("ClientType").WithHeaderText("Client Type").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientType);
                               cols.Add("Nickname").WithHeaderText("Nickname").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.NickName);
                               //cols.Add("Title").WithHeaderText("Title").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Title);
                               cols.Add("DateofBirth").WithHeaderText("Date of Birth").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.DateofBirth != null ? p.DateofBirth.ToShortDateString().Replace("1/1/0001", "") : ""));
                               cols.Add("ClientAge").WithHeaderText("Age").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientAge);
                               cols.Add("OfficeName").WithHeaderText("Office Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.OfficeAddress);
                               cols.Add("HomeStreet").WithHeaderText("Home Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.HomeAddress);
                               cols.Add("MailingAddress").WithHeaderText("Mailing Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MailingAddress);
                               //cols.Add("ContactNo").WithHeaderText("ContactNo").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactNo);
                               //cols.Add("Suffix").WithHeaderText("Suffix").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Suffix);
                               //cols.Add("Gender").WithHeaderText("Gender").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Gender);
                               //cols.Add("CivilStatus").WithHeaderText("Civil Status").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.CivilStatus);
                               //cols.Add("Account").WithHeaderText("Account").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Account);
                               cols.Add("Mobile").WithHeaderText("Mobile").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Mobile);
                               cols.Add("Phone").WithHeaderText("Phone").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Phone);
                               cols.Add("Email").WithHeaderText("Email").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Email);

                               cols.Add("ContactOf").WithHeaderText("Contact Of").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactOf);
                               cols.Add("ReferredBy").WithHeaderText("Referred By").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ReferredBy);
                               cols.Add("Createdby").WithHeaderText("Created by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Createdby);
                               cols.Add("Createdate").WithHeaderText("Create date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Createdate != null ? p.Createdate.ToShortDateString() : ""));
                               cols.Add("Updatedby").WithHeaderText("Updated by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Updatedby);
                               cols.Add("Updatedate").WithHeaderText("Update date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Updatedate != null ? p.Updatedate.ToShortDateString() : ""));

                               //cols.Add("Notes").WithHeaderText("Notes").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Notes);
                           })
                           //.WithAdditionalSetting(MVCGrid.Rendering.BootstrapRenderingEngine.SettingNameTableClass, "notreal") // Example of changing table css class
                           .WithRetrieveDataMethod((context) =>
                           {
                               var options = context.QueryOptions;

                               int totalRecords;

                               var repo = new ClientRepository(); //DependencyResolver.Current.GetService<IClientRepository>();

                               string globalSearch = options.GetAdditionalQueryOptionString("search");

                               string sortColumn = options.GetSortColumnData<string>();
                               int mon = int.Parse(options.GetPageParameterString("mon"));
                               var items = repo.GetBirthday(out totalRecords, globalSearch, options.GetLimitOffset(), options.GetLimitRowcount(),
                                   sortColumn, options.SortDirection == SortDirection.Dsc, mon);

                               return new QueryResult<Client>()
                               {
                                   Items = items,
                                   TotalRecords = totalRecords
                               };
                           })
                       );



            MVCGridDefinitionTable.Add("NoMobile", new MVCGridBuilder<Client>(colDefauls)
                           .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                           .WithSorting(sorting: true, defaultSortColumn: "Clientname", defaultSortDirection: SortDirection.Dsc)
                           .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                           .WithAdditionalQueryOptionNames("search")
                           .AddColumns(cols =>
                           {
                               cols.Add("Clientname").WithHeaderText("Client Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientName);
                               //cols.Add("LastName").WithHeaderText("Last Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.LastName);
                               //cols.Add("FirstName").WithHeaderText("First Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.FirstName);
                               //cols.Add("MiddleName").WithHeaderText("Middle Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MiddleName);

                               cols.Add("ClientType").WithHeaderText("Client Type").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientType);
                               cols.Add("Nickname").WithHeaderText("Nickname").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.NickName);
                               //cols.Add("Title").WithHeaderText("Title").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Title);
                               cols.Add("DateofBirth").WithHeaderText("Date of Birth").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.DateofBirth != null ? p.DateofBirth.ToShortDateString().Replace("1/1/0001", "") : ""));
                               cols.Add("ClientAge").WithHeaderText("Age").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientAge);
                               cols.Add("OfficeName").WithHeaderText("Office Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.OfficeAddress);
                               cols.Add("HomeStreet").WithHeaderText("Home Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.HomeAddress);
                               cols.Add("MailingAddress").WithHeaderText("Mailing Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MailingAddress);
                               //cols.Add("ContactNo").WithHeaderText("ContactNo").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactNo);
                               //cols.Add("Suffix").WithHeaderText("Suffix").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Suffix);
                               //cols.Add("Gender").WithHeaderText("Gender").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Gender);
                               //cols.Add("CivilStatus").WithHeaderText("Civil Status").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.CivilStatus);
                               //cols.Add("Account").WithHeaderText("Account").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Account);
                               cols.Add("Mobile").WithHeaderText("Mobile").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Mobile);
                               cols.Add("Phone").WithHeaderText("Phone").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Phone);
                               cols.Add("Email").WithHeaderText("Email").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Email);

                               cols.Add("ContactOf").WithHeaderText("Contact Of").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactOf);
                               cols.Add("ReferredBy").WithHeaderText("Referred By").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ReferredBy);
                               cols.Add("Createdby").WithHeaderText("Created by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Createdby);
                               cols.Add("Createdate").WithHeaderText("Create date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Createdate != null ? p.Createdate.ToShortDateString() : ""));
                               cols.Add("Updatedby").WithHeaderText("Updated by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Updatedby);
                               cols.Add("Updatedate").WithHeaderText("Update date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Updatedate != null ? p.Updatedate.ToShortDateString() : ""));

                               //cols.Add("Notes").WithHeaderText("Notes").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Notes);
                           })
                           //.WithAdditionalSetting(MVCGrid.Rendering.BootstrapRenderingEngine.SettingNameTableClass, "notreal") // Example of changing table css class
                           .WithRetrieveDataMethod((context) =>
                           {
                               var options = context.QueryOptions;

                               int totalRecords;

                               var repo = new ClientRepository(); //DependencyResolver.Current.GetService<IClientRepository>();

                               string globalSearch = options.GetAdditionalQueryOptionString("search");

                               string sortColumn = options.GetSortColumnData<string>();

                               var items = repo.GetNoMobile(out totalRecords, globalSearch, options.GetLimitOffset(), options.GetLimitRowcount(),
                                   sortColumn, options.SortDirection == SortDirection.Dsc);

                               return new QueryResult<Client>()
                               {
                                   Items = items,
                                   TotalRecords = totalRecords
                               };
                           })
                       );

            MVCGridDefinitionTable.Add("NoMobileWithEmail", new MVCGridBuilder<Client>(colDefauls)
                                       .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                                       .WithSorting(sorting: true, defaultSortColumn: "Clientname", defaultSortDirection: SortDirection.Dsc)
                                       .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                                       .WithAdditionalQueryOptionNames("search")
                                       .AddColumns(cols =>
                                       {
                                           cols.Add("Clientname").WithHeaderText("Client Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientName);
                               //cols.Add("LastName").WithHeaderText("Last Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.LastName);
                               //cols.Add("FirstName").WithHeaderText("First Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.FirstName);
                               //cols.Add("MiddleName").WithHeaderText("Middle Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MiddleName);

                               cols.Add("ClientType").WithHeaderText("Client Type").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientType);
                                           cols.Add("Nickname").WithHeaderText("Nickname").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.NickName);
                               //cols.Add("Title").WithHeaderText("Title").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Title);
                               cols.Add("DateofBirth").WithHeaderText("Date of Birth").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.DateofBirth != null ? p.DateofBirth.ToShortDateString().Replace("1/1/0001", "") : ""));
                                           cols.Add("ClientAge").WithHeaderText("Age").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientAge);
                                           cols.Add("OfficeName").WithHeaderText("Office Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.OfficeAddress);
                                           cols.Add("HomeStreet").WithHeaderText("Home Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.HomeAddress);
                                           cols.Add("MailingAddress").WithHeaderText("Mailing Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MailingAddress);
                               //cols.Add("ContactNo").WithHeaderText("ContactNo").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactNo);
                               //cols.Add("Suffix").WithHeaderText("Suffix").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Suffix);
                               //cols.Add("Gender").WithHeaderText("Gender").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Gender);
                               //cols.Add("CivilStatus").WithHeaderText("Civil Status").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.CivilStatus);
                               //cols.Add("Account").WithHeaderText("Account").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Account);
                               cols.Add("Mobile").WithHeaderText("Mobile").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Mobile);
                                           cols.Add("Phone").WithHeaderText("Phone").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Phone);
                                           cols.Add("Email").WithHeaderText("Email").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Email);

                                           cols.Add("ContactOf").WithHeaderText("Contact Of").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactOf);
                                           cols.Add("ReferredBy").WithHeaderText("Referred By").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ReferredBy);
                                           cols.Add("Createdby").WithHeaderText("Created by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Createdby);
                                           cols.Add("Createdate").WithHeaderText("Create date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Createdate != null ? p.Createdate.ToShortDateString() : ""));
                                           cols.Add("Updatedby").WithHeaderText("Updated by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Updatedby);
                                           cols.Add("Updatedate").WithHeaderText("Update date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Updatedate != null ? p.Updatedate.ToShortDateString() : ""));

                               //cols.Add("Notes").WithHeaderText("Notes").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Notes);
                           })
                                       //.WithAdditionalSetting(MVCGrid.Rendering.BootstrapRenderingEngine.SettingNameTableClass, "notreal") // Example of changing table css class
                                       .WithRetrieveDataMethod((context) =>
                                       {
                                           var options = context.QueryOptions;

                                           int totalRecords;

                                           var repo = new ClientRepository(); //DependencyResolver.Current.GetService<IClientRepository>();

                               string globalSearch = options.GetAdditionalQueryOptionString("search");

                                           string sortColumn = options.GetSortColumnData<string>();

                                           var items = repo.GetNoMobileWithEmail(out totalRecords, globalSearch, options.GetLimitOffset(), options.GetLimitRowcount(),
                                               sortColumn, options.SortDirection == SortDirection.Dsc);

                                           return new QueryResult<Client>()
                                           {
                                               Items = items,
                                               TotalRecords = totalRecords
                                           };
                                       })
                                   );

            MVCGridDefinitionTable.Add("WithMobile", new MVCGridBuilder<Client>(colDefauls)
                           .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                           .WithSorting(sorting: true, defaultSortColumn: "Clientname", defaultSortDirection: SortDirection.Dsc)
                           .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                           .WithAdditionalQueryOptionNames("search")
                           .AddColumns(cols =>
                           {
                               cols.Add("Clientname").WithHeaderText("Client Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientName);
                               //cols.Add("LastName").WithHeaderText("Last Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.LastName);
                               //cols.Add("FirstName").WithHeaderText("First Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.FirstName);
                               //cols.Add("MiddleName").WithHeaderText("Middle Name").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MiddleName);

                               cols.Add("ClientType").WithHeaderText("Client Type").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientType);
                               cols.Add("Nickname").WithHeaderText("Nickname").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.NickName);
                               //cols.Add("Title").WithHeaderText("Title").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Title);
                               cols.Add("DateofBirth").WithHeaderText("Date of Birth").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.DateofBirth != null ? p.DateofBirth.ToShortDateString().Replace("1/1/0001", "") : ""));
                               cols.Add("ClientAge").WithHeaderText("Age").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ClientAge);
                               cols.Add("OfficeName").WithHeaderText("Office Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.OfficeAddress);
                               cols.Add("HomeStreet").WithHeaderText("Home Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.HomeAddress);
                               cols.Add("MailingAddress").WithHeaderText("Mailing Address").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.MailingAddress);
                               //cols.Add("ContactNo").WithHeaderText("ContactNo").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactNo);
                               //cols.Add("Suffix").WithHeaderText("Suffix").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Suffix);
                               //cols.Add("Gender").WithHeaderText("Gender").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Gender);
                               //cols.Add("CivilStatus").WithHeaderText("Civil Status").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.CivilStatus);
                               //cols.Add("Account").WithHeaderText("Account").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Account);
                               cols.Add("Mobile").WithHeaderText("Mobile").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Mobile);
                               cols.Add("Phone").WithHeaderText("Phone").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Phone);
                               cols.Add("Email").WithHeaderText("Email").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Email);

                               cols.Add("ContactOf").WithHeaderText("Contact Of").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ContactOf);
                               cols.Add("ReferredBy").WithHeaderText("Referred By").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.ReferredBy);
                               cols.Add("Createdby").WithHeaderText("Created by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Createdby);
                               cols.Add("Createdate").WithHeaderText("Create date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Createdate != null ? p.Createdate.ToShortDateString() : ""));
                               cols.Add("Updatedby").WithHeaderText("Updated by").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Updatedby);
                               cols.Add("Updatedate").WithHeaderText("Update date").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression((p => p.Updatedate != null ? p.Updatedate.ToShortDateString() : ""));

                               //cols.Add("Notes").WithHeaderText("Notes").WithVisibility(visible: true, allowChangeVisibility: true).WithValueExpression(p => p.Notes);
                           })
                           //.WithAdditionalSetting(MVCGrid.Rendering.BootstrapRenderingEngine.SettingNameTableClass, "notreal") // Example of changing table css class
                           .WithRetrieveDataMethod((context) =>
                           {
                               var options = context.QueryOptions;

                               int totalRecords;

                               var repo = new ClientRepository(); //DependencyResolver.Current.GetService<IClientRepository>();

                               string globalSearch = options.GetAdditionalQueryOptionString("search");

                               string sortColumn = options.GetSortColumnData<string>();

                               var items = repo.GetWithMobile(out totalRecords, globalSearch, options.GetLimitOffset(), options.GetLimitRowcount(),
                                   sortColumn, options.SortDirection == SortDirection.Dsc);

                               return new QueryResult<Client>()
                               {
                                   Items = items,
                                   TotalRecords = totalRecords
                               };
                           })
                       );
        }
    }
}