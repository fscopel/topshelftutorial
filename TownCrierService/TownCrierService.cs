using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;

namespace TownCrierService
{
    public class TownCrierService
    {
        readonly Timer _timer;
        public TownCrierService()
        {
            _timer = new Timer(1000) { AutoReset = true };
#if DEBUG
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} and all is well", DateTime.Now);
#else
            _timer.Elapsed += (sender, eventArgs) => File.AppendAllLines(@"c:\temp\towncrier.log", new string[] { string.Format("It is {0} and all is well", DateTime.Now) });
#endif
        }

        public void FooStart() { _timer.Start(); }
        
        public void BarStop() { _timer.Stop(); }
    }
}
