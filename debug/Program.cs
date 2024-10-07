﻿using Kpmg.CRM.BookRoom.BookRoom;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace debug
{
    internal class Program
    {
        static IOrganizationService getorgservice()
        {
            string clientid = "a82375ed-07ae-49f3-899f-bfc99e94ac49";
            string appsecret = "VZ98Q~ZrBgneQqZpw8Ku4sg-hfWeCriUhK7F5bVA";
            string authoirty = "https://login.microsoftonline.com/94957a1d-682e-469c-9db8-5ab6cb6adad3";
            string crmurl = "https://org0365d327.crm15.dynamics.com/";

            string connectstring = $"AuthType=ClientSecret;Url={crmurl};Clientid={clientid};ClientSecret={appsecret};Authority={authoirty}:RequireNewInstance=True";
            CrmServiceClient conn = new CrmServiceClient(connectstring);
            if (conn.IsReady)
                Console.WriteLine("success connection");
            else
                Console.WriteLine("failed");
            IOrganizationService _orgService = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;

            return _orgService;
        }
        static void Main(string[] args)
        {
            IOrganizationService service  = getorgservice();
             new BookRoom(service).getrooms1();
        }
    }
}