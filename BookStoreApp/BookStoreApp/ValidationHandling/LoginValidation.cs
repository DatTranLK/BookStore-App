namespace BookStoreApp.ValidationHandling
{
    public class LoginValidation
    {
        public string CheckValidationLoginForm(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return "Please enter username or password";
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return "You have press white space, so does not have data please enter correct username and password";
            return "ok";
        }
    }
}
