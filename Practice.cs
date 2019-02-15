using System;

namespace Practice
{
    public class Memes
    {
        public int HeheScale;
        public int HaHaScale;
        volatile bool IsItAGoodMeme;
        delegate void Comments();
        public void Comment(string memeType)
        {
            Comments wat;
            Console.WriteLine("is there a complete video?");
            if (DateTime.Now.Year < 2000)
            {
                wat = ISeeThisMeme;
            }
            else wat = IsThisANewJoke;
        }
  
        private static void ISeeThisMeme()
        {
            Console.WriteLine("Yeah that's funny");
        }
        private static void IsThisANewJoke()
        {
            Console.WriteLine("I see it for the first time");
        }
    }
    public class Doggy : Memes
    {
        public long Cute
        {
            get { return 333333; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("dude, dogs are nicer than you think");
                }
            }
        }
        public Doggy(int hehe, int haha = 100)
        {
            HeheScale = hehe;
            HaHaScale = haha;
        }
    }

    internal class NewMemeEventArgs : EventArgs
    {
        private readonly string typeOfMemes, MemeFrom;

        public NewMemeEventArgs(string type, string mFrom)
        {
            typeOfMemes = type;
            MemeFrom = mFrom;
        }

        public string From { get { return MemeFrom; } }
        public string Meme { get { return "Ha-ha"; } }
    }
}
