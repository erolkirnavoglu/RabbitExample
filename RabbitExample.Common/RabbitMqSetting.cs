using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace RabbitExample.Common
{
    public class RabbitMqSetting : IRabbitMqSetting
    {
        private IConnection _connection;
        private IModel _chanel;

        public IConnection GetConnection()
        {
            if (_connection is not null) return _connection;

            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            _connection = factory.CreateConnection();

            return _connection;
        }
        public IModel GetChanel()
        {
            if (_connection.IsOpen)
            {
                //if(_chanel.IsOpen) return _chanel;

                _chanel = _connection.CreateModel();
                return _chanel;
            }
            else
            {
                GetConnection();
                _chanel = _connection.CreateModel();
                return _chanel;
            }

        }
        public void SetExchangeDeclare(string chanel, string type)
        {
            _chanel.ExchangeDeclare(chanel, type, durable: true, autoDelete: false, null);
        }
        public void SetQueueDeclare(string queue)
        {
            _chanel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false, null);
        }
        public void SetQueueBind(string queue, string exchange, string routingKey)
        {
            _chanel.QueueBind(queue, exchange, routingKey, null);
        }
        public void SetBasicPublish(string exchange, string routingKey, string msj)
        {
            var body = Encoding.UTF8.GetBytes(msj);
            _chanel.BasicPublish(exchange, routingKey, null, body);

        }
        public void ReceivedData(string queue)
        {
            string result = string.Empty;
            var consumer = new EventingBasicConsumer(_chanel);
            consumer.Received += (sender,e) => 
            {
                var by = e.Body.ToArray();
                var body = Encoding.UTF8.GetString(by);
                Console.WriteLine(body);
            };
            _chanel.BasicConsume(queue, true, consumer);
        }
        
    }
}
