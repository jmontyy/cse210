class Program
{
    static void Main(string[] args)
    {
        List<Video> vids = [
         new("How to eat", "Mr. Beast", 100, [
            new("John Doe", "now i can finally stop starving!"),
            new("cooldude3", "can we collab?"),
            new("YoutubeOfficial", "Another banger")
            ]),
         new("I gave 10000 people 2 cents", "Mr. Beast", 1230, [
            new("bloonskid", "can you give me all the money instead?"),
            new("cooldude3", "can we collab?"),
            new("comrade", "As it should be")
            ]),
         new("How to punch wood", "minecraftkid1000", 10, [
            new("steve", "now i can punch wood"),
            new("alex", "now i can punch wood"),
            new("jackblack", "now i can punch wood"),
            new("lavachickenfan", "now i can punch wood"),
            new("Joe11", "why is everyone saying \"now i can punch wood\"?")
            ]),
        ];

        foreach (var item in vids)
        {
            item.Display();
            Console.WriteLine("");
        }
    }
}
