using LancamentosFinanceiroApi.Data.Configure;
using LancamentosFinanceiroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LancamentosFinanceiroApi.Data.Context
{
    public class FinancaContextoAPI : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<TipoLancamento> TipoLancamentos { get; set; }

        public DbSet<Lancamento> Lancamentos { get; set; }

        public FinancaContextoAPI(DbContextOptions<FinancaContextoAPI> options) : base(options)
        {

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //new EmailEntityTypeConfiguration().Configure(modelBuilder.Entity<Email>());

            new TipoLancamentoEntityTypeConfigutation().Configure(modelBuilder.Entity<TipoLancamento>());

        }



    }
}
