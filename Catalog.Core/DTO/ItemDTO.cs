﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.DTO
{
    public record ItemDTO
    {
        public Guid Id {  get; init; }
        public string Name {  get; init; }
        public decimal Price {  get; init; }
        public DateTimeOffset CreatedDate {  get; set; }
    }
}
