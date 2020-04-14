using Caliburn.Micro;
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
        #region Privates
        private string _username;
		private string _password;


        #endregion


        public string Username
		{
			get { return _username; }
			set { _username = value; NotifyOfPropertyChange(() => Username);}
		}
		public string Password
		{
			get { return _password; }
			set 
			{ 
				_password = value; 
				NotifyOfPropertyChange(() => Password); 
			}
		}

		public bool CanLogin(string username, string password)
		{
			bool validation = false;
			if(username.Length>0  && password.Length>0)
			{
				validation= true;
			}
			return validation;
			
		}

		public void Login(string username, string password)
		{
			Console.WriteLine("Logged in");
		}

		


	}
}
