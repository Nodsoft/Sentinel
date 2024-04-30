using System;
using Serilog;
using Serilog.Configuration;

namespace Nodsoft.Serilog.Sinks.ToastNotifications;

/// <summary>
/// Contains extension methods for configuring the toast notifications sink.
/// </summary>
public static class ToastNotificationsSinkExtensions
{
    /// <summary>
    /// Adds a sink that sends log messages as UWP toast notifications.
    /// </summary>
    /// <param name="loggerConfiguration">The logger configuration.</param>
    /// <param name="formatProvider">The format provider to use when rendering log messages.</param>
    /// <returns>The logger configuration.</returns>
    public static LoggerConfiguration ToastNotifications(this LoggerSinkConfiguration loggerConfiguration, IFormatProvider formatProvider = null) 
        => loggerConfiguration.Sink(new ToastNotificationsSink(formatProvider));
}