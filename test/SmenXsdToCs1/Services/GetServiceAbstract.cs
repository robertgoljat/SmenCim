using CIM;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmenXsdToCs1.Services
{
    public abstract class GetServiceAbstract<TGetReq, TGetReqT, TGetResp, TGetRespT, TNoun, TPayl>
    {
        protected ILogger _log;
        protected string _noun;


        protected virtual TGetResp _get(TGetReq request)
        {
            TGetResp response = default(TGetResp);

            _log.LogInformation("{0} invoked...", MethodName());

            if (request == null)
                throw new Exception("Empty request!");

            //request.
            //if (request. == null)
            //    throw new Exception("Empty request object!");


            return _getData(request);
        }
        protected abstract TGetResp _getData(TGetReq request);

        private string MethodName()
        {
            return $"Get{_noun}";
        }
    }
}
