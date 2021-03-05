using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RecieverApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FactoryConfig myFactory = new FactoryConfig();
            myFactory.RecieveMessage();
            Message myMessage = new Message();
            myFactory.SendResponse(myMessage.GetResponce());
            Console.ReadLine();


            
        }
    }
}
