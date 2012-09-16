using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace Two_Server
{
    public  class TimedEvent
    {
        public TwoServerWindow TwoServer;
        public float TimeToEvent;
        public bool IsRunning = true;
        private Thread _runningThread;
        public String Type ;
        public TimedEvent(TwoServerWindow twoServer, float timeToEvent )
        {
            TwoServer = twoServer;
            TimeToEvent = timeToEvent;
        }

        public virtual void Execute()
        {
        }

        public void Start()
        {
            IsRunning = true;
            _runningThread = new Thread(Running);
            _runningThread.Start();
        }
        public void Running()
        {
            while (IsRunning)
            {
                if (TimeToEvent < 0)
                {
                    Execute();
                    return;
                }
                Thread.Sleep(500);
                TimeToEvent -= .5f;
            }
        }
    }
    public class StatusTick : TimedEvent
    {
        public StatusTick(TwoServerWindow twoServer, float timeToEvent) : base(twoServer, timeToEvent)
        {
            TwoServer = twoServer;
            TimeToEvent = timeToEvent;
        }
        public override void Execute()
        {
            if (!IsRunning)
            {
                return;
            }
            TwoServer.SendStatus();
            TimeToEvent = 2.0f;
            Start();
        }
    }
}
