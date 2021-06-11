using System;
using System.Threading.Tasks;
using Flexbaze.Models;

namespace Flexbaze.ViewModels
{
    public class LoginViewModel
    {
        ViewModels.Request _request = new ViewModels.Request();
        public async Task<WebToken> GetToken(string usr, string pass)
        {
            WebToken result = new WebToken();
            try
            {
                result = await _request.GetToken(usr, pass);
            }
            catch (Exception ex)
            {
                Console.Write("Error en GetToken, " + ex.Message);
            }
            return result;
        }
    }
}
