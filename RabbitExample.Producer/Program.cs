

using RabbitExample.Common;
using RabbitMQ.Client;
using System.Text;


try
{
	string exchange = "erol.log.fanout";
	string type = "fanout";
	string queue = "fanout-erol";
    IRabbitMqSetting _rabbit = new RabbitMqSetting();
    _rabbit.GetConnection();
    _rabbit.GetChanel();
	_rabbit.SetExchangeDeclare(exchange, type);
	_rabbit.SetQueueBind(queue, exchange, "");
	_rabbit.SetQueueDeclare(queue);

	for (int i = 1; i <= 1000; i++)
	{
        var mesaj = $"{i} Gönderilen Data";

        _rabbit.SetBasicPublish(exchange, "", mesaj);
    }
   


    /*
	var factory = new ConnectionFactory() { Uri=new Uri("amqp://guest:guest@localhost:5672") };
	var connection = factory.CreateConnection();
	var channel = connection.CreateModel();

	channel.ExchangeDeclare("log-fanout", durable: true, type: ExchangeType.Fanout);
	var mesaj = "erool";

	var body = Encoding.UTF8.GetBytes(mesaj);

	channel.BasicPublish("log-fanout", "", null, body);
	*/
}
catch (Exception ex)
{

    throw;
}


Console.WriteLine("Hello, World!");
Console.ReadKey();
