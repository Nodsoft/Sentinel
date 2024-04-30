using System;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;
using Serilog.Core;
using Serilog.Events;

namespace Nodsoft.Serilog.Sinks.ToastNotifications;

/// <summary>
/// A sink for Serilog that sends log messages as UWP toast notifications.
/// </summary>
public sealed class ToastNotificationsSink : ILogEventSink
{
    private readonly IFormatProvider _formatProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ToastNotificationsSink"/> class.
    /// </summary>
    /// <param name="formatProvider">The format provider to use when rendering log messages.</param>
    public ToastNotificationsSink(IFormatProvider formatProvider)
    {
        _formatProvider = formatProvider;
    }
    
    /// <inheritdoc />
    public void Emit(LogEvent logEvent)
    {
        // Render the message
        string message = logEvent.RenderMessage(_formatProvider);
        
        // Show the toast notification
        new ToastContentBuilder()
            .AddText(message)
            .Show();
    }
}