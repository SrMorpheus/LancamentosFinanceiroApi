using LancamentosFinanceiroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LancamentosFinanceiroApi.Data.Context
{
    public class FinancaContextoAPI : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoLancamento> TipoLancamentos { get; set; }

        public DbSet<Lancamento> Lancamentos { get; set; }

        public FinancaContextoAPI(DbContextOptions<FinancaContextoAPI> options) : base(options)
        {
          

        }

    }
}
