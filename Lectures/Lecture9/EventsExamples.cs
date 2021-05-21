using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace Lecture9
{
    public class EventsExamples
    {
        public class RequestProcessor
        {
            public delegate void RequestEventHandler(object source, EventArgs args);

            public event RequestEventHandler RequestCompleted;

            public event RequestEventHandler RequestCompleting;

            public event EventHandler<SomethingHappenedEventArgs> SomethingHappened;

            public void Send(MessageRequest request)
            {
                RequestCompleting?.Invoke(this, EventArgs.Empty);

                for (var i = 0; i < 5; i++) // Long running operation emulation.
                {
                    Thread.Sleep(300);
                    Console.Write(".");
                }

                RequestCompleted?.Invoke(this, EventArgs.Empty);

                //if(RequestCompleted is not null)
                //{
                //    RequestCompleted.Invoke(this, EventArgs.Empty);
                //}

                SomethingHappened?.Invoke(this, new() { VeryImportantData = "Data" });
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

        public class SomethingHappenedEventArgs : EventArgs
        {
            public string VeryImportantData { get; set; }
        }
    }
}