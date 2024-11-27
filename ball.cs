using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monoplay
{
    public class ball
    {

        private Texture2D texture;
        private Rectangle rectangle = new Rectangle(x:390,y:230,width:20,height:20);
        private float velocityX = 5;
        private float velocityY = 1;

        public Rectangle Rectangle{
            get{return Rectangle;}
        }

        public Ball(Texture2D t){
            texture = t;
        }

        public void Reset(){
            rectangle.X = 390;
            rectangle.Y = 230;
            velocityX = 2;
            velocityY = 2;
        }
        public void Update(){
        Ball.X += (int)velocityX;
        Ball.Y += (int)velocityY;
        }

        if(ball.Y <= 0 || ball.Y + ball.Height >= 480){
            velocityY *= -1;
        }
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.LightGoldenrodYellow);
        }
    }
}