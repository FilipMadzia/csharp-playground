using NAudio.Wave;

class Program
{
    static WaveOutEvent _waveOutDevice = new();
    static AudioFileReader? _audioFileReader;
    static readonly string[] AudioFilePaths =
    {
        "a-steak.mp3",
        "i-made-a-steak.mp3",
        "invincible-pretty-sure.mp3",
        "omni-man-are-you-sure.mp3",
        "sea-salt.mp3",
        "stand-ready-for-my-arrival-worm.mp3",
        "where-is-omni-man.mp3"
    };
    static int _intervalInSeconds;

    static void Main(string[] args)
    {
        _intervalInSeconds = args.Length > 0 ? int.Parse(args[0]) : 5;
        _waveOutDevice = new WaveOutEvent();
        InitializeAudio();

        while (true)
        {
            var audioFilePath = GetRandomAudioFilePath();
            SetAudioFile(audioFilePath);

            _waveOutDevice.Play();

            Thread.Sleep(_intervalInSeconds * 1000);
        }
    }

    static void InitializeAudio()
    {
        _audioFileReader = new AudioFileReader($"Audios/{AudioFilePaths[0]}");
        _waveOutDevice.Init(_audioFileReader);
    }

    static string GetRandomAudioFilePath() => AudioFilePaths[Random.Shared.Next(AudioFilePaths.Length)];

    static void SetAudioFile(string fileName)
    {
        _waveOutDevice.Stop();
        _audioFileReader?.Dispose();

        _audioFileReader = new AudioFileReader($"Audios/{fileName}");
        _waveOutDevice.Init(_audioFileReader);
    }
}
