using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitExample.Common
{
    public interface IRabbitMqSetting
    {
        public IConnection GetConnection();
        public IModel GetChanel();
        public void SetExchangeDeclare(string chanel, string type);
        public void SetQueueDeclare(string queue);
        public void SetQueueBind(string queue, string exchange, string routingKey);
        public void SetBasicPublish(string exchange, string routingKey, string msj);
        public void ReceivedData(string queue);
    }
}
