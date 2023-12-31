﻿using VirtualStore.Catalog.Core.Configurations.Enums;

namespace VirtualStore.Catalog.Core.Responses;

public class ExceptionResponse
{
    public ExceptionType ResponseType { get; set; }

    public string Tittle { get; set; }

    public string[] Messages { get; set; }
}