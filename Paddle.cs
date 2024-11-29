using System.Net;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monoplay
{
    public class Paddle
    {
        private Texture2D texture;
        private Rectangle rectangle;

        private int speed = 1;

        private Keys up;

        private Keys Down;

        public Rectangle Rectangle{
            get{return rectangle;}
        }

        public Paddle(Texture2D t, Rectangle r){
            texture = t;
            rectangle = r;
            up = u;
            Down = d;
        }


        public void Update(){
            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(up)){
                rectangle.Y -= speed;
            }
            if(kState.IsKeyDown(key:Down)){
                rectangle.Y += speed;
            }
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.HotPink)
        }
    }
}