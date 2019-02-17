using System;
using System.Reflection;
using System.Threading;

namespace Practice
{
    class Program
    {
        static void Main()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Base Directory: {0}", domain.BaseDirectory);
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(asm.GetName().Name);
            }
        }

        public sealed class MonitoringDomain : IDisposable
        {
            public AppDomain domain;
            public TimeSpan ADCpu;
            public long UseADMemory;
            public long ADMemory;
            static MonitoringDomain()
            {
                AppDomain.MonitoringIsEnabled = true;
            }

            public MonitoringDomain(AppDomain ad)
            {
                domain = ad ?? AppDomain.CurrentDomain;
                ADCpu = domain.MonitoringTotalProcessorTime;
                UseADMemory = domain.MonitoringSurvivedMemorySize;
                ADMemory = domain.MonitoringTotalAllocatedMemorySize;                    
            }
            public void Dispose()
            {
                GC.Collect();
                Console.WriteLine(domain.FriendlyName + (domain.MonitoringTotalProcessorTime
                    - ADCpu).TotalMilliseconds);
            }
        }
    }
}
