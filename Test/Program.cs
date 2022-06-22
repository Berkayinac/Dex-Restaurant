using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _authService = InstanceFactory.GetInstance<IAuthService>();

            UserForLoginDto userForLoginDto = new UserForLoginDto();
            userForLoginDto.Email = "kaanberkay@posta.mu.edu.tr";
            userForLoginDto.Password = "987654321";

            var userLogin = _authService.Login(userForLoginDto);

            if (!userLogin.Success)
            {
                Console.WriteLine("Giriş Başarısız.");
            }

            var userAuthoritiesDto = _authService.GetUserAuthority(userLogin.Data).Data;

            Console.WriteLine(userAuthoritiesDto.Authorities);

            string result = "";
            
            foreach (var authority in userAuthoritiesDto.Authorities)
            {
                result += authority.AuthorityName;
            }

            if (!result.Contains("Admin"))
            {
                Console.WriteLine("Admin değil");
            }

            Console.WriteLine(result);

            Console.ReadLine();

        }
    }
}
