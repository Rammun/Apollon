using DataSprite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon
{
    public class Sprites
    {
        SortedList<string, Sprite> sprites;
        Graph graph;

        public Sprites(int width, int height)
        {
            sprites = new SortedList<string, Sprite>();
            graph = new Graph(width, height);

            InitSprites();
        }

        public Bitmap GetBitmap { get { return graph.GetBitmap; } }

        void InitSprites()
        {
            sprites.Add("moon", new Sprite(SerializerSprite.LoadFromBit("moon.sprt")));
            sprites.Add("ship", new Sprite(SerializerSprite.LoadFromBit("ship.sprt")));
            sprites.Add("star", new Sprite(SerializerSprite.LoadFromBit("star.sprt")));
            sprites.Add("fire", new Sprite(SerializerSprite.LoadFromBit("fire.sprt")));
            sprites.Add("earth", new Sprite(SerializerSprite.LoadFromBit("earth.sprt")));
        }

        public SortedList<string, Sprite> GetSprites { get { return sprites; } }

        public void Show(string spriteName, int shiftX, int shiftY, float zoom)
        {
            graph.Draw(sprites[spriteName], shiftX, shiftY, zoom);
        }

        public void Show(string spriteName)
        {
            graph.Draw(sprites[spriteName]);
        }

        public void Clear()
        {
            graph.Clear();
        }
    }
}
