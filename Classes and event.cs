using System;

namespace Practice
{

    public class Memes
    {
        public int HeheScale;
        public int HaHaScale;
        volatile bool IsItAGoodMeme;
        public void Comment()
        {
            Console.WriteLine("is there a complete video?");
        }
    }
    public class Doggy : Memes
    {
        public long Cute { get; set; }
        public Doggy(int hehe, int haha)
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
