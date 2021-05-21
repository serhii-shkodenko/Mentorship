using System;
using static Lecture9.DelegatesExamples;
using static Lecture9.EventsExamples;
using static System.Console;

namespace Lecture9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Delegates
            //RunDelegatesExamples();
            //WriteLine("----------------- Beautiful limiter -----------------");
            //RunDelegatesExamplesWithDelegate();
            //WriteLine("----------------- Beautiful limiter -----------------");
            //RunDelegatesExamplesWithDelegateInstance();
            //WriteLine("----------------- Beautiful limiter -----------------");
            //RunDelegatesExamplesWithLambdaExpression();
            //WriteLine("----------------- Beautiful limiter -----------------");
            //RunDelegatesExamplesWithLambdaExpression();

            // Events
            RunEventsExample();
            WriteLine("----------------- Beautiful limiter -----------------");
            RunEventsExampleDelagate();

            // General
            WriteLine(Environment.NewLine);
            WriteLine("All is done!");
            ReadLine();
        }

        static void RunDelegatesExamples()
        {
            var request = new MessageRequest();
            request.Headers.Add("Original header.");

            var provider = new MessageProcessorMethodProvider();
            var logger = new Logger();
            var processor = new MessageProcessor(provider.ActualRunningMethodAnother, logger); //provider.ActualRunningMethodAnother
            var response = processor.Send(request);
        }

        static void RunDelegatesExamplesWithDelegate()
        {
            var request = new MessageRequest();
            request.Headers.Add("Original header.");

            var logger = new Logger();

            var processor = new MessageProcessor(delegate(MessageRequest messageRequest) 
            {
                messageRequest.Headers.Add("This was added by anonymous function.");
                return messageRequest;
            }, logger);

            var response = processor.Send(request);
        }

        static void RunDelegatesExamplesWithDelegateInstance()
        {
            var request = new MessageRequest();
            request.Headers.Add("Original header.");

            var provider = new MessageProcessorMethodProvider();
            var logger = new Logger();

            MessageRequestDelegate myDelegate = delegate (MessageRequest messageRequest) //  C# 10 changes here
            {
                messageRequest.Headers.Add("This was added by anonymous function from instance.");
                return messageRequest;
            };

            var processor = new MessageProcessor(myDelegate, logger);

            var response = processor.Send(request);
        }

        static void RunDelegatesExamplesWithLambdaExpression()
        {
            var request = new MessageRequest();
            request.Headers.Add("Original header.");

            var provider = new MessageProcessorMethodProvider();
            var logger = new Logger();

            var processor = new MessageProcessor((messageRequest) => 
            {
                messageRequest.Headers.Add("This was added by lambda expression.");
                return messageRequest;
            }, logger);

            var response = processor.Send(request);
        }

        static void RunEventsExample()
        {
            var requestHandler = new RequestProcessor();
            requestHandler.RequestCompleted += RequestHandler_RequestCompleted;

            var request = new EventsExamples.MessageRequest();
            requestHandler.Send(request);
        }

        static void RunEventsExampleDelagate()
        {
            var requestHandler = new RequestProcessor();
            requestHandler.SomethingHappened += RequestHandler_SomethingHappened;
            requestHandler.RequestCompleted += delegate(object source, EventArgs args) // Memory leak issue here.
            {
                WriteLine("Request is completed.");
            };

            var request = new EventsExamples.MessageRequest();
            requestHandler.Send(request);
        }

        private static void RequestHandler_SomethingHappened(object sender, SomethingHappenedEventArgs e)
        {
            WriteLine(e.VeryImportantData);
        }

        private static void RequestHandler_RequestCompleted(object source, EventArgs args)
        {
            if (source is RequestProcessor handler)
            {
                WriteLine(handler.ToString());
            };

            WriteLine("Code from handler was called.");
        }
    }
}
