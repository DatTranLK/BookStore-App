using BusinessObject.Models;
using System.Text.RegularExpressions;

namespace PRN221_SE1503_A2_TranThanhDat.ValidationHandling
{
    public class RegisterValidation
    {
        public string CheckRegisterValidation(Account account)
        {
            if (string.IsNullOrEmpty(account.Username) || string.IsNullOrEmpty(account.Password))
                return "Please enter username or password please";
            if (string.IsNullOrWhiteSpace(account.Username) || string.IsNullOrWhiteSpace(account.Password))
                return "You have press white space, so does not have data please enter correct username and password";
            return "ok";
        }
    }
}
