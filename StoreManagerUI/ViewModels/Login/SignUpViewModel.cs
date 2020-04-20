using Caliburn.Micro;
using StoreManager.Core.Validators;
using StoreManagerUI.Events;
using StoreManagerUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.ViewModels.Login
{
    public class SignUpViewModel : Screen
    {
        public event EventHandler<SignUpEventArgs> SignUpEvent;

        IUserValidator _userValidator;
        IUserDBHelper _userDBHelper;
        private string  _repeatedPassword;
        private string _username;
        private string _password;

        public SignUpViewModel(IUserValidator userValidator, IUserDBHelper userDBHelper)
        {
            _userValidator = userValidator;
            _userDBHelper = userDBHelper;
            SignUpEvent += SignUpViewModel_SignUpEvent;
        }

        private void SignUpViewModel_SignUpEvent(object sender, SignUpEventArgs e)
        {
           ErrorText = e?.SignUpErrorText;
            NotifyOfPropertyChange(() => ErrorText);
        }

        public string Username
        {
            get { return _username; }
            set { _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanSignUp);
            }
        }
       
        public string Password
        {
            get { return _password; }
            set { _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanSignUp);
            }
        }
       
        public string  RepeatedPassword
        {
            get { return _repeatedPassword; }
            set { _repeatedPassword = value;
                NotifyOfPropertyChange(() => RepeatedPassword);
                NotifyOfPropertyChange(() => CanSignUp);
            }
        }
        public string ErrorText { get; set; }


        public bool CanSignUp
        {
            get
            {
               if( _userValidator.ValidatePassword(Password) == false)
                {
                    SignUpEvent.Invoke(this, new SignUpEventArgs()
                    {
                        SignedUpSuccesfully = false,
                        SignUpErrorText = "Password length should\nbe greater than 5 characters"
                    });
                    return false;
                }
                if (_userValidator.ValidateUsername(Username) == false)
                {
                    SignUpEvent.Invoke(this, new SignUpEventArgs()
                    {
                        SignedUpSuccesfully = false,
                        SignUpErrorText = "Username taken or shorter than 3 letters"
                    });
                    return false;
                }
                if(Password != RepeatedPassword)
                {
                    SignUpEvent.Invoke(this, new SignUpEventArgs()
                    {
                        SignedUpSuccesfully = false,
                        SignUpErrorText = "Passwords does not match"
                    });
                    return false;
                }
                return true;

            }
        }
  



        public void SignUp()
        {
            _userDBHelper.AddNewUser(Username, Password);
            CloseForm();
        }

        public void CloseForm()
        {
            SignUpEvent.Invoke(this, new SignUpEventArgs()
            {
                CloseSignUpProcess = true
            });
        }




    }
}
