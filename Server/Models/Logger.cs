﻿using Microsoft.Extensions.Logging;

internal static class Log
{
    internal static ILoggerFactory LoggerFactory { get; set; }
    internal static ILogger CreateLogger<t>() => LoggerFactory.CreateLogger<t>();
    internal static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
}