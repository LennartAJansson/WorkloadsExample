namespace AssignmentGenerator
{
    using Microsoft.Extensions.Logging;

    using System;
    using System.Diagnostics;

    using WorkloadsDb;
    using WorkloadsDb.Model;

    public class Generator
    {
        private readonly ILogger<Generator> logger;
        private readonly WorkloadsContext context;

        public Generator(ILogger<Generator> logger, WorkloadsContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public void Execute()
        {
            Stopwatch total = new Stopwatch();
            Stopwatch stopwatch = new Stopwatch();
            total.Start();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                string guid = Guid.NewGuid().ToString();

                Assignment a = new Assignment
                {
                    Customername = $"Customer {guid}",
                    Contact = $"Contact for {guid}",
                    Description = $"Project at {guid}"
                };

                context.Assignments.Add(a);
                if (i % 1000 == 0)
                {
                    int saved = context.SaveChanges();
                    logger.LogInformation("Creating random assignments {index}", i);
                    logger.LogInformation("Saved {count}", saved);
                    logger.LogInformation("Execution time last 1000: {time}", stopwatch.Elapsed);
                    stopwatch.Restart();
                }
            }
            context.SaveChanges();
            logger.LogInformation("Execution time total: {time}", total.Elapsed);
        }
    }
}
