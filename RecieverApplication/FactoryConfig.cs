using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecieverApplication
{
    public class FactoryConfig
    {
        Message myMessage;
        public FactoryConfig()
        {
            myMessage = new Message();
        }

        #region Recieve messagen Factory Settings
        public void RecieveMessage()
        {
            
            try
            {
                ConnectionFactory factory = new ConnectionFactory { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "IQBusinessQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    EventingBasicConsumer reciver = new EventingBasicConsumer(channel);
                    reciver.Received += (sender, e) =>
                    {
                        var body = e.Body.ToArray();
                        myMessage.name = Encoding.UTF8.GetString(body);
                        myMessage.DisplayMessage();
                     
                    };
                    channel.BasicConsume("IQBusinessQueue", autoAck: true, consumer: reciver);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops, something went wrong trying to retrieve the message, please try again: " + Environment.NewLine + "More Information: " + ex.ToString());
            }
        }
        #endregion

        #region To send Defauls Message Back and Communicate back
        public void SendResponse(string msg)
        {

            try
            {
                ConnectionFactory factory = new ConnectionFactory { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "IQBusinessQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var body = Encoding.UTF8.GetBytes(msg);
                    channel.BasicPublish(exchange: "", routingKey: "IQBusinessQueue", basicProperties: null, body: body);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops, something went wrong, please try again: " + Environment.NewLine + "More Information: " + ex.ToString());
            }

        }
        #endregion

    }
}
