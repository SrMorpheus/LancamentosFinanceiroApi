namespace LancamentosFinanceiroApi.DataObjects.Converter.Contract
{
    public interface ITipoLancamento<O, D>
    {
        D Parse(O origin);

        List<D> Parse(List<O> origin);



    }
}
