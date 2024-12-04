using System;
using System.Collections.Generic;

namespace Glossary.Models.GlossaryLite;

public partial class Term
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual Definition? Definition { get; set; }
}
