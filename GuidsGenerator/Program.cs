internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        NotifyIcon trayIcon = new NotifyIcon
        {
            Icon =  new Icon("Resources/favicon.ico"),
            Visible = true,
            Text = "GUID Copier - Click to generate a GUID"
        };

        trayIcon.Click += (sender, e) =>
        {
            string newGuid = Guid.NewGuid().ToString();
            Clipboard.SetText(newGuid);
            ShowNotification(trayIcon, "New GUID", $"GUID copied to clipboard:\n{newGuid}");
        };
        
        Application.Run();

        trayIcon.Dispose();
    }

    private static void ShowNotification(NotifyIcon trayIcon, string title, string message)
    {
        trayIcon.BalloonTipTitle = title;
        trayIcon.BalloonTipText = message;
        trayIcon.ShowBalloonTip(3000);
    }
}