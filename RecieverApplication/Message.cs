using System;
using System.Collections.Generic;
using System.Text;

namespace RecieverApplication
{

    public class Message
    {
        public string name { set; get; }
        public string responce { set; get; }
        public string message { set; get; } = "{0}, I am your father. ";
        public Message()
        {

        }

        public void DisplayMessage()
        {

            Console.WriteLine(message, name);

        }
        public string GetResponce()
        {
            Console.Write("Enter response: ");
            responce = Console.ReadLine();
            return responce;
        }
    }
}
