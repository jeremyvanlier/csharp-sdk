﻿using System;
using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Collections.Specialized;
using PAYNLSDK.Exceptions;

namespace PAYNLSDK.API.PaymentMethod.GetAll
{
    public class Request : RequestBase
    {
        public string apiToken;

        public string serviceId;

        public string GetApiToken()
        {
            return apiToken;
        }

        public void SetApiToken(string value)
        {
            apiToken = value;
        }

        public string GetServiceId()
        {
            return serviceId;
        }

        public void SetServiceId(string value)
        {
            serviceId = value;
        }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "PaymentMethod"; }
        }

        public override string Method
        {
            get { return "getAll"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override System.Collections.Specialized.NameValueCollection GetParameters()
        {
            NameValueCollection nvc = base.GetParameters();

            if (RequiresApiToken)
            {
                if (!String.IsNullOrEmpty(GetApiToken()))
                {
                    nvc.Add("token", GetApiToken());
                }
            }

            if (RequiresServiceId)
            {
                if (!String.IsNullOrEmpty(GetServiceId()))
                {
                    nvc.Add("serviceId", GetServiceId());
                }
            }

            return nvc;
        }


        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            PAYNLSDK.Objects.PaymentMethod[] pm = JsonConvert.DeserializeObject<PAYNLSDK.Objects.PaymentMethod[]>(RawResponse);
            Response r = new Response
            {
                PaymentMethods = pm
            };
            response = r;
        }
    }
}
