using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace Two_Server
{
    /// <summary>
    /// Base class for an event that works in real time eg. seconds rather than in turns
    /// 
    /// </summary>
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
    /// <summary>
    /// The status tick allows for the game to continue if packets fail to arrive, it sends the status of the game and all information needed for a player to play on
    /// </summary>
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
