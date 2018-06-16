using Callboard.App.General.Results;

namespace Callboard.App.General.ResultExtensions
{
    public static class CastResultExtension
    {
        public static ISuccessResult<T> GetSuccessResult<T>(this IResult<T> result)
        {
            return result as ISuccessResult<T>;
        }

        public static IFailureResult<T> GetFailureResult<T>(this IResult<T> result)
        {
            return result as IFailureResult<T>;
        }
    }
}