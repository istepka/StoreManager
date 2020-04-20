using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagerUI.Events
{
   public  class SignUpEventArgs : EventArgs
    {

        public bool SignedUpSuccesfully { get; set; } = false;


        public string SignUpErrorText { get; set; }
        public bool CloseSignUpProcess { get; set; } = false;


    }
}
