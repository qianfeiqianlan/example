using Authing.ApiClient.Domain.Client.Impl.AuthenticationClient;
using Authing.ApiClient.Domain.Client.Impl.ManagementBaseClient;
using System;
using Xunit;

namespace example_test
{
    public class ExampleTest
    {
        private AuthenticationClient authenticationClient;
        private ManagementClient managementClient;

        public ExampleTest()
        {
            this.authenticationClient = new AuthenticationClient(init: opt =>
            {
                opt.UserPoolId = "61f60429f70052e2dbe26b10";
                opt.Secret = "ea195be04885106b05e623b19965989d";
            });

            this.managementClient = new ManagementClient(init: opt =>
            {
                opt.UserPoolId = "61f60429f70052e2dbe26b10";
                opt.Secret = "ea195be04885106b05e623b19965989d";
            });
        }
        

        [Fact]
        public async void RegisterByEmail()
        {
            //https://docs.authing.cn/v2/reference/sdk-for-csharp/authentication/AuthenticationClient.html#%E4%BD%BF%E7%94%A8%E9%82%AE%E7%AE%B1%E6%B3%A8%E5%86%8C
            var user = await authenticationClient.RegisterByEmail("liyangyang@authing.cn", "123456", null, null);
            Console.WriteLine(user);
            Console.WriteLine("注册成功!");
            //await managementClient.Users.Delete(user.Id);
        }

        [Fact]
        public async void SendSmsCode()
        {
            //https://docs.authing.cn/v2/reference/sdk-for-csharp/authentication/AuthenticationClient.html#%E5%8F%91%E9%80%81%E7%9F%AD%E4%BF%A1%E9%AA%8C%E8%AF%81%E7%A0%81

            await authenticationClient.SendSmsCode("13889333417");
        }

        [Fact]
        public async void RegisterByPhoneCode()
        {
            //https://docs.authing.cn/v2/reference/sdk-for-csharp/authentication/AuthenticationClient.html#%E4%BD%BF%E7%94%A8%E6%89%8B%E6%9C%BA%E5%8F%B7%E6%B3%A8%E5%86%8C
            var user = await authenticationClient.RegisterByPhoneCode("13889333417", "4832", "123132123", null, null);
            Console.WriteLine(user);
            Console.WriteLine("注册成功!");
            //await managementClient.Users.Delete(user.Id);
        }
    }
}
