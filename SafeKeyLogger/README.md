
# SafeKeyLogger - Educational Project (Windows Forms, C#)

This is a minimal scaffold of the SafeKeyLogger project tailored for educational purposes.
It contains an application-focused key-logger (only logs when the app window is focused),
storage, a safe exporter (outbox simulation), and a simple analyzer.

**Important:** This project intentionally does NOT contain global hooks, background exfiltration,
or any network-based sending code. Use only in an isolated/testing environment (VM).

Build:
- This sample is a minimal textual scaffold and may require adjustments in Visual Studio.
- Target framework: .NET 6 (Windows) or adjust csproj for your environment.
