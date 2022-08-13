using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Models.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LancamentosFinanceiroApi.Data.Configure
{
    public class TipoLancamentoEntityTypeConfigutation
    {
        public void Configure(EntityTypeBuilder<TipoLancamento> builder)
        {


            builder.Property(T => T.DescricaoLancamento)
                .HasConversion(
            v => v.ToString(),
            v => (EnumDescricaoLancamento)Enum.Parse(typeof(EnumDescricaoLancamento), v))
                .IsRequired();

            builder.HasData(
                new TipoLancamento { Id = 1, DescricaoLancamento = EnumDescricaoLancamento.Entrada },
                new TipoLancamento { Id = 2, DescricaoLancamento = EnumDescricaoLancamento.Saída }
            
                );

        }

    }
}
