
using RabbitExample.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

try
{
    string exchange = "erol.log.fanout";
    string type = "fanout";
    string queue = "fanout-erol";
    IRabbitMqSetting _rabbit = new RabbitMqSetting();
    _rabbit.GetConnection();
    _rabbit.GetChanel();
   // _rabbit.SetQueueBind(queue, exchange, "");
    _rabbit.ReceivedData(queue);


    Console.ReadKey();

    /*
    var factory = new ConnectionFactory() { Uri = new Uri("amqp://guest:guest@localhost:5672") };
    var connection = factory.CreateConnection();
    var channel = connection.CreateModel();

    // channel.QueueDeclare("mesaj.kuyruk", true, false, false);
    // channel.ExchangeDeclare("log-fanout", durable: true, type: ExchangeType.Fanout);

    var randomQueue = "log-fanout-save"; //channel.QueueDeclare().QueueName;
    channel.QueueDeclare(randomQueue, true, false, false);
   // channel.QueueBind(randomQueue, "log-fanout", "", null);

    channel.BasicQos(0, 1, false);
    var consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume(randomQueue, false, consumer);
    Console.WriteLine("loglar dinleniyor");
    consumer.Received += (sender, e) =>
    {
        var body = e.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        channel.BasicAck(e.DeliveryTag, false);
        Console.WriteLine(message);
    };

    Console.ReadKey();
    */

}
catch (Exception ex)
{

    throw;
}

