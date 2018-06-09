using Apache.NMS;
using System;
using System.Linq;

namespace SendEmailApp
{
    class QueueListener
    {

        public static String ReadNextMessageQueue2()
        {
            string queueName = "formatedFile";

            string brokerUri = $"activemq:tcp://localhost:61616";
            NMSConnectionFactory factory = new NMSConnectionFactory(brokerUri);

            using (IConnection connection = factory.CreateConnection())
            {
                connection.Start();
                using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                using (IDestination dest = session.GetQueue(queueName))
                using (IMessageConsumer consumer = session.CreateConsumer(dest))
                {
                    IMessage msg = consumer.Receive();

                    if (msg is ITextMessage)
                    {
                        ITextMessage txtMsg = msg as ITextMessage;
                        string body = txtMsg.Text;

                        return body;
                    }
                    else
                    {
                        return "error";
                    }
                }
            }
        }
            


     






        public static bool ReadNextMessageQueue()
        {
            string queueName = "formatedFile";

            string brokerUri = $"activemq:tcp://localhost:61616";
            NMSConnectionFactory factory = new NMSConnectionFactory(brokerUri);

            using (IConnection connection = factory.CreateConnection())
            {
                connection.Start();
                using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                using (IDestination dest = session.GetQueue(queueName))
                using (IMessageConsumer consumer = session.CreateConsumer(dest))
                {
                    IMessage msg = consumer.Receive();

                    //string = consumer.Receive();

                    if (msg is ITextMessage)
                    {
                    ITextMessage txtMsg = msg as ITextMessage;
                    string body = txtMsg.Text;

                        Console.WriteLine("cia yra kazkas");
                        Console.WriteLine(body);
                        Console.WriteLine("cia yra kazkas");

                        string emailString = body.Split(new[] { '\r', '\n' }).FirstOrDefault();
                        Console.WriteLine(emailString + "this is my email");


                        Console.WriteLine($"Received message: {txtMsg.Text}");

                    return true;
                     }
                    else
                    {
                        
                      //Console.WriteLine("Unexpected message type: " + msg.GetType().Name);
                    }
                    }
                     }
                

                    return false;
                }
            }
        }
    
