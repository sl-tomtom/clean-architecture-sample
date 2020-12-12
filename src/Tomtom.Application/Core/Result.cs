using System;
using System.Collections.Generic;
using System.Text;

namespace Tomtom.Application.Core
{

    public class Result
    {
        protected readonly Exception p_error;

        public virtual bool IsSuccess => p_error == null;

        public Result()
        {
        }

        protected Result(Exception error)
        {
            this.p_error = error;
        }

        public Exception Error { get => p_error; }

        public static Result Failure(Exception error) => new Result(error);
        public static Result Success() => new Result();

    }

    public class Result<V> : Result
    {
        public static Result<V> Success(V value) => new Result<V>(value);
        public static new Result<V> Failure(Exception error) => new Result<V>(error);

        private readonly V _value;

        public V GetValue()
        {
            return _value;
        }

        private Result(V value)

        {
            this._value = value;
        }

        public Result<R> Map<R>(Func<V, R> mapper)
        {
            if (IsSuccess)
            {
                return Result<R>.Success(mapper.Invoke(_value));
            }

            return Result<R>.Failure(p_error);
        }

        private Result(Exception error) : base(error)
        {
        }

    }
}
