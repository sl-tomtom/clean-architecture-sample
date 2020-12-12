using System;
using System.Threading.Tasks;

namespace Tomtom.Application.Core
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
