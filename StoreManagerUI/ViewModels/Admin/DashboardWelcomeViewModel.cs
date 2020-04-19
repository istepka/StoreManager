using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.ViewModels.Admin
{
    public class DashboardWelcomeViewModel 
    {
        public event EventHandler<bool> ActivateProductsTab;
        public event EventHandler<bool> ActivateUsersTab;

        public void ProductButton()
        {
            ActivateProductsTab.Invoke(null, true);  
        }

        public void UserButton()
        {
            ActivateUsersTab.Invoke(null,true);
        }

      
    }
}
