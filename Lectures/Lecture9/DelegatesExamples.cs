using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lecture9
{
    public delegate MessageRequest MessageRequestDelegate(MessageRequest request);

    public class DelegatesExamples
    {
        public interface IMessageProcessor
        {
            MessageResponse Send(MessageRequest request);
        }

        public class MessageProcessor : IMessageProcessor
        {
            private readonly MessageRequestDelegate _handler;
            private readonly ILogger _logger;

            public MessageProcessor(MessageRequestDelegate handler, ILogger logger)
            {
                _handler = handler ?? throw new ArgumentNullException(nameof(handler));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public MessageResponse Send(Predicate<MessageRequest> predicate, MessageRequest request)
            {
                throw new NotImplementedException();
            }

            public MessageResponse Send(MessageRequest request)
            {
                var changedRequest = _handler.Invoke(request);

                // Pretending we send request somewhere and get the response.
                var response = new MessageResponse
                {
                    Headers = new[]
                    {
                        "Returned from server."
                    },
                };

                _logger.Log(changedRequest.ToString());
                _logger.Log(response.ToString());

                return response;
            }
        }

        public class MessageResponse
        {
            public ICollection<string> Headers { get; set; } = new Collection<string>();

            public override string ToString()
            {
                return nameof(MessageResponse) + Environment.NewLine + string.Join(Environment.NewLine, Headers);
            }
        }
    }

    public class MessageRequest
    {
        public ICollection<string> Headers { get; set; } = new Collection<string>();

        public override string ToString()
        {
            return nameof(MessageRequest) + Environment.NewLine + string.Join(Environment.NewLine, Headers);
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class MessageProcessorMethodProvider
    {
        public MessageRequest ActualRunningMethod(MessageRequest request)
        {
            request.Headers.Add($"This was added by {nameof(ActualRunningMethod)}.");
            return request;
        }

        public MessageRequest ActualRunningMethodAnother(MessageRequest request)
        {
            request.Headers.Add($"New very important header from {nameof(ActualRunningMethod)}.");
            return request;
        }
    }
}