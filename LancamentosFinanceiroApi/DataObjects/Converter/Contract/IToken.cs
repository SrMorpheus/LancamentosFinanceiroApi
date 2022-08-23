namespace LancamentosFinanceiroApi.DataObjects.Converter.Contract
{
    public interface IToken<O, D>
    {
        D Parse(O origin);

        List<D> Parse(List<O> origin);

    
    }
}
