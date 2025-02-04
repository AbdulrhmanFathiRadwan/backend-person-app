﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record PersonDTO
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Address { get; set; }
    }
}
