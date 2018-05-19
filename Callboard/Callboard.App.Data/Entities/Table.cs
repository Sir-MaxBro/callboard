using System.Collections.Generic;

namespace Callboard.App.Data.Entities
{
    internal class Table
    {
        public string Name { get; set; }

        public IReadOnlyCollection<Procedure> Procedures { get; set; }

        public IReadOnlyCollection<Column> Columns { get; set; }
    }
}
