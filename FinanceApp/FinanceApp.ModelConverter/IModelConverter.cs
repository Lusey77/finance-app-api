namespace FinanceApp.ModelConverter
{
    public interface IModelConverter<TInput, TOutput>
    {
        TOutput Convert(TInput model);
        TInput Revert(TOutput model);
    }
}