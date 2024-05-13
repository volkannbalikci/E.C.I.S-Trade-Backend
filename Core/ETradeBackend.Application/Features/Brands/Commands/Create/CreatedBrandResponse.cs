﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Brands.Commands.Create;

public class CreatedBrandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string WebsiteUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}