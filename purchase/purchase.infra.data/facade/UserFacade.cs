using System;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using purchase.domain.entities.dtos;
using purchase.domain.entities.interfaces.facade;
using purchase.infra.data.facade.api;

namespace purchase.infra.data.facade
{
    public class UserFacade: CoreApi, IUserFacade
    {
        protected readonly string _url;
        protected readonly string _apiUser;
        protected readonly int _timeOut;
        public UserFacade(IConfiguration configuration)
        {
            _url = configuration.GetSection("UserApi:Url").Value;
            _apiUser = configuration.GetSection("UserApi:Users").Value;

            _timeOut = Convert.ToInt32(configuration.GetSection("UserApi:ApiTimeOut").Value);
        }
        public UserResponse UserById(int id)
        {
            var userRequest = new UserRequest() { Id = id };
            var endPoint = string.Format(_url + _apiUser, id);
            var data = CallApiExternal<UserResponse>(HttpMethod.Get, endPoint, userRequest,timeout: _timeOut);
            return data;
        }
    }
}
