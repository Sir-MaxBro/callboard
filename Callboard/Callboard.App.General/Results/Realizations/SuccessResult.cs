namespace Callboard.App.General.Results.Realizations
{
    public class SuccessResult<T> : ISuccessResult<T>
    {
        private T _value;
        public SuccessResult(T value)
        {
            _value = value;
        }

        public T Value => _value;
    }
}