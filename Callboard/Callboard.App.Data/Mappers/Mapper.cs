using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Mappers
{
    public class Mapper<TInput, TOutput>
    {
        public Func<TInput, IReadOnlyCollection<TOutput>> MapCollection { get; set; }

        public Func<TInput, TOutput> MapItem { get; set; }

        public Func<TOutput, IDictionary<string, object>> MapValues { get; set; }
    }
}