namespace Callboard.App.General.Results
{
    public interface ISuccessResult<T> : IResult<T>
    {
        T Value { get; }
    }
}