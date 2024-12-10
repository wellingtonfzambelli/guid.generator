namespace GuidsGenerator;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        string newGuid = Guid.NewGuid().ToString();

        Clipboard.SetText(newGuid);

        ShowNotification("New GUID", $"GUID copied to clipboard:\n{newGuid}");
    }

    private static void ShowNotification(string title, string message)
    {
        using (var notifyIcon = new NotifyIcon())
        {
            notifyIcon.Visible = true;
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(3000);
     
            Thread.Sleep(3000);
        }
    }
}