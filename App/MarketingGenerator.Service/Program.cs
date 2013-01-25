using System.ServiceProcess;

namespace MarketingGenerator.Service
{
    static class Program
    {
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
                                          { 
                                              new MarketingGeneratorService() 
                                          };
            
            ServiceBase.Run(servicesToRun);
        }
    }
}
