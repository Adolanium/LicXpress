using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicXpress
{
    internal class Configuration
    {
        internal string Username { get; private set; }
        internal string Password { get; private set; }

        internal Configuration(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                Username = lines[0].Split('=')[1].Trim();
                Password = lines[1].Split('=')[1].Trim();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to read credentials: {e.Message}");
                Username = string.Empty;
                Password = string.Empty;
            }
        }
    }
}
