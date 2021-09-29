namespace AssignmentGenerator
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class AppExtensions
    {
        public static IHost Generate(this IHost host)
        {
            using IServiceScope scope = host.Services.CreateScope();
            scope.ServiceProvider.GetService<Generator>().Execute();

            return host;
        }
    }
}
