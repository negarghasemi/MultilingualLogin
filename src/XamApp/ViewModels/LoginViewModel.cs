using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Bit.ViewModel;
using MultilingualLogin.Resources;

namespace MultilingualLogin.ViewModels
{
    public class LoginViewModel : BitViewModelBase
    {
        public string UserNameText { get; set; }

        public string PassWordText { get; set; }
        public BitDelegateCommand LoginCommand { get; set; }

        public IUserDialogs UserDialogs { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new BitDelegateCommand(Login);
        }

        private async Task Login()
        {

            if (!string.IsNullOrEmpty(UserNameText) && !string.IsNullOrEmpty(PassWordText))
            {
                if(Regex.IsMatch(UserNameText, "^[0][9][1][0-9]{8,8}$"))
                    await UserDialogs.AlertAsync(string.Format(Strings.LoginText, UserNameText, PassWordText));
                else
                {
                    await UserDialogs.AlertAsync(string.Format(Strings.LoginError2));
                }
            }
            else
            {

                await UserDialogs.AlertAsync(string.Format(Strings.LoginError));

            }
        }

    }
}
