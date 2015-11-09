using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration1del1
{
    class Camera
    {
        int sizeOfTile = 64;
        int borderSize = 64;
        public float scale;

        public int getTileSize { get { return sizeOfTile; }
        }
        public Vector2 returnPosition(int x, int y) //tar emot en x och ett y position
        {
            int visualX = borderSize + x * sizeOfTile;
            int visualY = borderSize + y * sizeOfTile;

            return new Vector2(visualX, visualY);
        }
        public Vector2 rotationOfField(int x, int y) //tar emot en x och ett y position
        {
            int visualX = (sizeOfTile * 8 + borderSize - sizeOfTile) - (x * sizeOfTile);
            int visualY = (sizeOfTile * 8 + borderSize - sizeOfTile) - (y * sizeOfTile);

            return new Vector2(visualX, visualY);
        }
        public void scaleField(float height, float width)
        {

        }
    }

}
