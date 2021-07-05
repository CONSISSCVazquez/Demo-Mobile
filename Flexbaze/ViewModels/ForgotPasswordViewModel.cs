using System;
using System.Threading.Tasks;
using Flexbaze.Models;

namespace Flexbaze.ViewModels
{
    public class ForgotPasswordViewModel
    {
        ViewModels.Request _request = new ViewModels.Request();
        public async Task<SendPasswordResetEmail> SendEmail(string email)
        {
            SendPasswordResetEmail result = new SendPasswordResetEmail();
            try
            {
                result = await _request.SendEmail(email);
            }
            catch (Exception ex)
            {
                Console.Write("Error en SendEmail, " + ex.Message);
            }
            return result;
        }
    }
}
