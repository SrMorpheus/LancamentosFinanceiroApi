namespace LancamentosFinanceiroApi.DataObjects.Converter.Contract
{
    public interface ILancamento<O, D>
    {
        D Parse(O origin);

        List<D> Parse(List<O> origin);

    }
}
