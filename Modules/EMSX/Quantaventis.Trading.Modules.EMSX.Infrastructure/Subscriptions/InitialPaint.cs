using Bloomberglp.Blpapi;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions
{
    internal class InitialPaint
    {
        private ConcurrentQueue<Message> InitialPaintData { get; } = new ConcurrentQueue<Message>();

        private  bool isEnded = false;
        private readonly object lockObject = new object();

        internal void Reset() { 
            InitialPaintData.Clear();
            isEnded = false;
        }
        internal bool IsEnded
        {
            get
            {
                lock (lockObject)
                {
                    return isEnded;
                }
            }
            private set
            {
                lock (lockObject)
                {
                    isEnded = value;
                }
            }
        }
        internal void AddMessage(Message message)
        {
            lock (lockObject)
            {
                //if (IsEnded)
                //    throw new InvalidOperationException($"Message {message} can't be added to terminated InitialPaint {this}.");

                InitialPaintData.Enqueue(message);
            }

        }

            internal void End()
        {
            lock (lockObject)
            {
                isEnded = true;
            }
        }

        internal IEnumerable<Message> GetMessages()
            {
                lock (lockObject)
                {
                    return InitialPaintData.ToImmutableList(); // Using ToList to create a snapshot of the data.
                }
            }
        }
}
