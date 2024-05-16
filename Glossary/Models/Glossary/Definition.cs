using System;
using System.Collections.Generic;

namespace Glossary.Models.Glossary
{
    public partial class Definition
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int TermId { get; set; }

        public virtual Term Term { get; set; } = null!;
    }
}
