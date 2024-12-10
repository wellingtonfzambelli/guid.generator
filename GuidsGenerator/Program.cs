internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var trayIcon = new NotifyIcon
        {
            Icon = new Icon("Resources/favicon.ico"),
            Visible = true,
            Text = "GUID Copier - Click to generate a GUID"
        };
        
        var contextMenu = new ContextMenuStrip();
        
        contextMenu.Items.Add("Exit", null, (sender, e) =>
        {
            trayIcon.Visible = false;
            Application.Exit();
        });

        trayIcon.ContextMenuStrip = contextMenu;
        trayIcon.MouseClick += (sender, e) =>
        {
            if (e.Button == MouseButtons.Left)
            {
                string newGuid = Guid.NewGuid().ToString();
                Clipboard.SetText(newGuid);
                ShowNotification(trayIcon, "New GUID", $"GUID copied to clipboard:\n{newGuid}");
            }
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