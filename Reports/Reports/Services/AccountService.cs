using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reports.Data;
using Reports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Services
{
    public class AccountService : IAccountService
    {

        public readonly IServiceScopeFactory scopeFactory;
        public readonly ILogger<AccountService> logger;

        private ImmigrationDbContext ObtenerContexto()
        {
            using var scope = scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ImmigrationDbContext>();
            return context;
        }

        public AccountService(ILogger<AccountService> _logger, IServiceScopeFactory _scopeFactory)
        {
            logger = _logger;
            scopeFactory = _scopeFactory;
        }

        public List<ImmigrationAccount> ObtenerTodo()
        {
            var context = ObtenerContexto();
            var resultado = context.immigrationAccounts;
            //logger.LogInformation("resultado: {0}", hola.Id);
            return resultado.ToList();
        }
    }

    public interface IAccountService
    {
        public List<ImmigrationAccount> ObtenerTodo();
    }
}
