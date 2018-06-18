using System;

namespace Callboard.App.General.Results
{
    public interface IFailureResult<T> : IResult<T>
    {
        string ErrorMessage { get; }

        Exception Exception { get; }
    }
}