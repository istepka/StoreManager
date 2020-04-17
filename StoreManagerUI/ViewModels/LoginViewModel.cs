using Caliburn.Micro;
using StoreManagerUI.Events;
using StoreManagerUI.Helpers;
using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StoreManagerUI.ViewModels
{
    public class LoginViewModel : Screen
    {
		public event EventHandler<LogInEventArgs> LogInEvent;

        #region Privates
        private string _username;
		private string _password;
		private string _loginError;
		private UserModel _activeUser;
		private IUserDBHelper _userDBHelper;
		#endregion

		public LoginViewModel(IUserDBHelper userDBHelper)
		{
			_userDBHelper = userDBHelper;
			new WindowManager().ShowWindow(new AdminAddUserViewModel(_userDBHelper));
		}

		public UserModel ActiveUser
		{
			get { return _activeUser; }
			set { _activeUser = value; NotifyOfPropertyChange(() => ActiveUser);  }
		}

		public string LoginError
		{
			get { return _loginError; }
			set { _loginError = value; NotifyOfPropertyChange(() => LoginError); }
		}
		public string Username
		{
			get { return _username; }
			set 
			{ 
				_username = value; 
				NotifyOfPropertyChange(() => Username);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}
		public string Password
		{
			get { return _password; }
			set 
			{ 
				_password = value; 
				NotifyOfPropertyChange(() => Password); 
				NotifyOfPropertyChange(() => CanLogIn); 
			}
		}

		public bool CanLogIn
		{
			get
			{
				bool validation = false;
				if (Username?.Length > 0 && Password?.Length > 0)
				{
					validation = true;
				}
				return validation;
			}
			
		}

		public void LogIn(string username, string password)
		{
			UserModel user = _userDBHelper.GetUser(username, Password);
			if(user.Role != null)
			{
				ActiveUser = user;
				LoginError = "Login succeded";
				Username = ""; Password = "";
				LogInEvent?.Invoke(this, new LogInEventArgs(true, ActiveUser));
			}
			else
			{
				LoginError = "Login failed, try again";
				Password = "";
				ActiveUser = null;
				LogInEvent?.Invoke(this, new LogInEventArgs(false));
			}
		}

	


	}
}
