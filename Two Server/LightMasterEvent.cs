using System.Collections.Generic;

namespace Two_Server
{
    /// <summary>
    /// A timed event to handle lightmaster rounds
    /// </summary>
    public class LightMasterEvent : TimedEvent
    {
        /// <summary>
        /// Constructor, must have a twoserver and time till round finishes 
        /// </summary>
        /// <param name="twoServer"></param>
        /// <param name="timeToEvent"></param>
        public LightMasterEvent(TwoServerWindow twoServer, float timeToEvent) : base(twoServer, timeToEvent)
        {
            TwoServer = twoServer;
            TimeToEvent = timeToEvent;
            Type = "LIGHTMASTER";
        }

        /// <summary>
        /// Triggers when the lightmaster event expires
        /// </summary>
        public override void Execute()
        {
            List<string> nameList = new List<string>();
            foreach (Player p in TwoServer.PlayerList.PlayerArray)
            {
                
                if( !p.LightOn)
                {
                    nameList.Add(p.Name);
                    TwoServer.PlayerPickupCard(2,p);
                }
            }
            if (nameList.Count == 0)
                return;
            string toSend = nameList[0];
            for( int i = 0; i < nameList.Count - 1; i ++)
            {
                if( i == nameList.Count -1)
                {
                    toSend += string.Format("and {0}", nameList[i+1]);

                }else
                {
                    toSend += string.Format(", {0}", nameList[i + 1]);
                }
                
            }
            toSend += " didn't even see the light! Two cards!";
            TwoServer.PlayerList.ResetLightMaster();
            TwoServer.SendAnnounce(toSend);
        }
    }
}