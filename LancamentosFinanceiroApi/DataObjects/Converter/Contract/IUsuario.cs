namespace LancamentosFinanceiroApi.DataObjects.Converter.Contract
{
    public interface IUsuario<O, D>
    {
        D Parse(O origin);

        List<D> Parse(List<O> origin);


    }
}
