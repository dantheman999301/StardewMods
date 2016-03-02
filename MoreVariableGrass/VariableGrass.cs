using StardewModdingAPI;
using StardewModdingAPI.Inheritance;
using StardewValley;
using System;

namespace MoreVariableGrass
{
    public class VariableGrass : Mod
    {
        public override string Name
        {
            get { return "VariableGrass"; }
        }

        public override string Authour
        {
            get { return "dantheman999"; }
        }

        public override string Version
        {
            get { return "1.1"; }
        }

        public override string Description
        {
            get { return "Grass grows at variable rates - More Version"; }
        }

        public override void Entry()
        {
            Events.CurrentLocationChanged += Events_CurrentLocationChanged;
        }

        private int day;
        private int min = 0;
        private int max = 4;
        Random rnd = new Random();

        void Events_CurrentLocationChanged(GameLocation Location)
        {
            Console.WriteLine("Location changed :: " + Location.Name);

            if (!SGame.hasLoadedGame)
                return;

            Console.WriteLine("Current day :: " + day);
            Console.WriteLine("Current game day :: " + SGame.dayOfMonth);

            if (day == SGame.dayOfMonth)
                return;

            day = SGame.dayOfMonth;
            Console.WriteLine("Getting farm...");
            Farm farm = SGame.getLocationFromName("Farm") as Farm;
            Console.WriteLine("Got farm... GROW!");
            var growAmount = rnd.Next(min, max);
            Console.WriteLine("Grow amount :: " + growAmount);
            farm.growWeedGrass(growAmount);
        }

    }
}
