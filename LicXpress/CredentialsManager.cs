using System;
using System.IO;
using System.Windows.Forms;

public class CredentialsManager
{
    public static Tuple<string, string> ReadCredentials()
    {
        try
        {
            string path = "credentials.txt";
            string[] lines = File.ReadAllLines(path);
            string username = lines[0].Split('=')[1].Trim();
            string password = lines[1].Split('=')[1].Trim();

            return Tuple.Create(username, password);
        }
        catch (Exception e)
        {
            MessageBox.Show($"Failed to read credentials: {e.Message}");
            return Tuple.Create(string.Empty, string.Empty);
        }
    }
}