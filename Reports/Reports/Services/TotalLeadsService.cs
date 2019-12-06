using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reports.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Services
{
    public class TotalLeadsService : ITotalLeadsService
    {
        public readonly IServiceScopeFactory scopeFactory;
        public readonly ILogger<TotalLeadsService> logger;

        public TotalLeadsService(ILogger<TotalLeadsService> _logger, IServiceScopeFactory _scopeFactory)
        {
            logger = _logger;
            scopeFactory = _scopeFactory;
        }
            

        public void ObtenerLista()
        {
            using var scope = scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ImmigrationDbContext>();

            var hola = context.immigrationAccounts.Where(ia => ia.Name == "ARTEFACTUAL SYSTEMS INC.").SingleOrDefault();

            logger.LogInformation("resultado: {0}", hola.Id);
        }
    }

    public interface ITotalLeadsService
    {
        public void ObtenerLista();
    }
}
