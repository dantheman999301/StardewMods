using StardewModdingAPI;
using StardewModdingAPI.Inheritance;
using StardewValley;
using System;

namespace VariableGrass
{
    public class VariableGrass : Mod
    {
        private const string MIN_ITERATIONS_KEY = "MinIterations";
        private const string MAX_ITERATIONS_KEY = "MinIterations";

        //Current day
        private int day;

        //Minimum Iterations
        private int min;

        //Maximum Iterations
        private int max;

        //Random gen
        Random rnd = new Random();

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
            get { return "1.2"; }
        }

        public override string Description
        {
            get { return "Grass grows at variable rates"; }
        }

        public override void Entry()
        {
            Events.CurrentLocationChanged += Events_CurrentLocationChanged;

            //Get settings
            var settings = new IniFile("VariableGrass.ini");
            min = int.Parse(settings.Read(MIN_ITERATIONS_KEY));
            max = int.Parse(settings.Read(MAX_ITERATIONS_KEY));
        }

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
