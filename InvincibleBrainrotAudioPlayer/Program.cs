using NAudio.Wave;

class Program
{
	static WaveOutEvent waveOutDevice = new();
	static AudioFileReader audioFileReader = new("Audios/a-steak.mp3");
	static string[] audioFilePaths = [
		"a-steak.mp3",
		"i-made-a-steak.mp3",
		"invincible-pretty-sure.mp3",
		"omni-man-are-you-sure.mp3",
		"sea-salt.mp3",
		"stand-ready-for-my-arrival-worm.mp3",
		"where-is-omni-man.mp3"
	];
	static int intervalInSeconds;

	static void Main(string[] args)
	{
		intervalInSeconds = args.Length > 0 ? int.Parse(args[0]) : 5;

		while (true)
		{
			var audioFilePath = GetRandomAudioFilePath();
			SetAudioFile(audioFilePath);

			waveOutDevice.Play();

			Thread.Sleep(intervalInSeconds * 1000);
		}
	}

	static string GetRandomAudioFilePath() => audioFilePaths[Random.Shared.Next(audioFilePaths.Length)];

	static void SetAudioFile(string fileName)
	{
		waveOutDevice.Stop();

		audioFileReader?.Dispose();
		
		audioFileReader = new AudioFileReader($"Audios/{fileName}");
		waveOutDevice.Init(audioFileReader);
	}
}