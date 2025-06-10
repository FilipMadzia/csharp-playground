using System.Diagnostics;

string? siteUrl;

do
{
    Console.Write("Enter site url (e.g. http://example.com): ");
    siteUrl = Console.ReadLine();
} while (string.IsNullOrEmpty(siteUrl));

var refreshRateInSeconds = 2;

Console.Write("Enter refresh rate in seconds: ");
refreshRateInSeconds = int.Parse(Console.ReadLine() ?? "2");

var running = true;
var command = $"ping \"{siteUrl}\"";

var process = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "cmd.exe",
        Arguments = $"/C {command}",
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    }
};

while (running)
{
    process.Start();
    
    var output = process.StandardOutput.ReadToEnd();
    var error = process.StandardError.ReadToEnd();

    process.WaitForExit();
    
    Console.WriteLine("Output:");
    Console.WriteLine(output);

    if (!string.IsNullOrEmpty(error))
    {
        Console.WriteLine("Error:");
        Console.WriteLine(error);
    }

    if (!output.Contains($"Ping request could not find host {siteUrl}. Please check the name and try again."))
    {
        Console.WriteLine("Site is online");
        
        for (var i = 0; i < 5; i++)
        {
            Console.Beep();
            await Task.Delay(2000);
        }

        running = false;
    }
    
    await Task.Delay(refreshRateInSeconds * 1000);
}

Console.ReadKey();