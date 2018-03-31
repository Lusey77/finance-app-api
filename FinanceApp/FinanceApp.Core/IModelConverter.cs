namespace FinanceApp.Core
{
    public interface IModelConverter<TInput, TOutput>
    {
        TOutput Convert(TInput model);
        TInput Revert(TOutput model);
    }
}