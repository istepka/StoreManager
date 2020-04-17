using StoreManagerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.Events
{
    public class LogInEventArgs : EventArgs 
    {
		private bool _loggedSuccesfully = false;

		/// <summary>
		/// Is validation correct
		/// </summary>
		public bool LoggedInSuccesfully
		{
			get { return _loggedSuccesfully; }
			set { _loggedSuccesfully = value; }
		}

		private UserModel _activeUser;

		/// <summary>
		/// Active logged user
		/// </summary>
		public UserModel ActiveUser
		{
			get { return _activeUser; }
			set { _activeUser = value; }
		}



		public LogInEventArgs(bool loggedIn, UserModel activeUser = null)
		{
			LoggedInSuccesfully = loggedIn;
			ActiveUser = activeUser;
		}

	}
}
