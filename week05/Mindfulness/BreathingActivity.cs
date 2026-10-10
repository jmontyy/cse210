// I showed creativity by making Reflection questions/prompts not repeating until all have been used
// I also animated the breathing section
class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }
    public override void PerformActivity()
    {
        int elapsed = 0;
        int duration = GetDuration();
        while (elapsed < duration)
        {
            int inhaleSeconds = Math.Min(4, duration - elapsed);
            if (inhaleSeconds <= 0)
                break;

            Console.WriteLine();
            Console.WriteLine("Breathe in...");
            AnimateBreath(inhaleSeconds, true);
            elapsed += inhaleSeconds;
            if (elapsed >= duration)
                break;

            int exhaleSeconds = Math.Min(6, duration - elapsed);
            Console.WriteLine();
            Console.WriteLine("Breathe out...");
            AnimateBreath(exhaleSeconds, false);
            elapsed += exhaleSeconds;
        }
    }

    private static void AnimateBreath(int seconds, bool inhale)
    {
        for (int i = 1; i <= seconds; i++)
        {
            double progress = (double)i / seconds;

            int barLength = inhale
                ? (int)(progress * 20)
                : (int)((1 - progress) * 20);

            if (barLength < 1)
            {
                barLength = 1;
            }

            string bar = new('=', barLength);
            Console.Write($"\r[{bar,-20}] {i}");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }
}
