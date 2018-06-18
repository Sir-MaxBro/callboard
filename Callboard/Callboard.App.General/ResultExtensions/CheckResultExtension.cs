using Callboard.App.General.Results;

namespace Callboard.App.General.ResultExtensions
{
    public static class CheckResultExtension
    {
        public static bool IsSuccess<T>(this IResult<T> result)
        {
            return result is ISuccessResult<T>;
        }

        public static bool IsFailure<T>(this IResult<T> result)
        {
            return result is IFailureResult<T>;
        }

        public static bool IsNone<T>(this IResult<T> result)
        {
            return result is INoneResult<T>;
        }
    }
}