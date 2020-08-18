using System;
using Topshelf;

namespace TownCrierService
{
   

    class Program
    {
       
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   //1
            {
                x.Service<TownCrierService>(s =>                                   //2
                {
                    s.ConstructUsing(name => new TownCrierService());                //3
                    s.WhenStarted(tc => tc.FooStart());                         //4
                    s.WhenStopped(tc => tc.BarStop());                          //5
                });
                x.RunAsLocalSystem();                                       //6

                x.SetDescription("Town Crier Service description goes here.");                   //7
                x.SetDisplayName("Town Crier Service");                                  //8
                x.SetServiceName("TownCrierService");                                  //9
            });                                                             //10

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            Environment.ExitCode = exitCode;
        }
    }
}
