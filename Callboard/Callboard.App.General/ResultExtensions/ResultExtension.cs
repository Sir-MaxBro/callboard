using Callboard.App.General.Results;

namespace Callboard.App.General.ResultExtensions
{
    public static class ResultExtension
    {
        public static T GetSuccessResult<T>(this IResult<T> result)
        {
            var successResult = result as ISuccessResult<T>;
            return successResult != null ? successResult.Value : default(T);
        }

        public static string GetFailureMessage<T>(this IResult<T> result)
        {
            var failureResult = result as IFailureResult<T>;
            return failureResult != null ? failureResult.ErrorMessage : string.Empty;
        }
    }
}