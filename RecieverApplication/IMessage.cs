using System;
using System.Collections.Generic;
using System.Text;

namespace RecieverApplication
{
    interface IMessage
    {
        public void DisplayMessage();
        public string GetResponce();
    }
}
