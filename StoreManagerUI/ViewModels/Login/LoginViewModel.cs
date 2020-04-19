using Caliburn.Micro;
using StoreManager.Core.Validators;
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
		private IUserValidator _userValidator;
		#endregion

		public LoginViewModel(IUserDBHelper userDBHelper, IUserValidator userValidator)
		{
			_userDBHelper = userDBHelper;
			LoginError = "";
			_userValidator = userValidator;
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
				if (user.Role != null)
				{
					ActiveUser = user;
					LoginError = "Login succeded";
					Username = ""; //Password = "";
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


		//public bool ValidateUser(string username, string password)
		//{
		//	if (_userValidator.ValidatePassword(password) == false)
		//	{
		//		LoginError = "Password length should have minimum 6 letters";
		//		return false;
		//	}
		//	if (_userValidator.ValidateUsername(username) == false)
		//	{
		//		LoginError = "Username taken or too short (min 3 letters)";
		//		return false;
		//	}
		//	else
		//		return true;


		//}

		protected override void OnDeactivate(bool close)
		{
			base.OnDeactivate(close);
			LoginError = "";
			ActiveUser = null;
			//TODO PASSWORD ISSUE
			//Password = "";
			Username = "";
		}

	}
}
