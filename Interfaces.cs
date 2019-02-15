using System;

namespace Practice
{
    internal class Size
    {
        int width;
        int height;
        public Size(int h, int w)
        {
            height = h;
            width = w;
        }
    }

    interface IArt
    {
        long Price { get; }
        Size Size(int height, int width);
        string Name { get; set; }
        string Painter { get; set; }
    }
    interface IClient
    {
        string Name { get; }
    }

    internal class Painting : IArt, IClient
    {
        public long Price { get; }
        public string Name { get; set; }
        public string Painter { get; set; }
        public Size Size(int height, int width)
        {
            throw new Exception();
        }
        string ClientName { get; }
    }

    class Proram
    { 


    }
}
