using System;
using System.Threading.Tasks;

using Tomtom.Shared.Result;

namespace Tomtom.Shared.Result
{
    public static class TaskResultExtensions
    {
        public static Task<Result<R>> Map<I, R>(this Task<Result<I>> source, Func<I, R> mapper)
        {
            return source.ContinueWith(before =>
            {
                if (before.IsCompletedSuccessfully)
                {
                    return before.Result.Map(mapper);
                }
                return Result<R>.Failure(before.Exception);
            });
        }
    }
}
