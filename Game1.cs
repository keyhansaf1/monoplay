
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monoplay;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;
    SpriteFont fontScore;

    Rectangle paddleLeft = new Rectangle(10,200,20,100);
    Rectangle paddleRight = new Rectangle(770,200,20,100);
    Rectangle ball = new Rectangle(390,230,20,20);

    float velocityX = 5;
    float velocityY = 1;

    int scoreLeftPlayer = 0;

    int scoreRightPlayer = 0;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        pixel = Content.Load<Texture2D>(assetName:"pixel");
        fontScore = Content.Load<SpriteFont>(assetName: "score.spritefont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState kState = Keyboard.GetState();
        if(kState.IsKeyDown(key: Keys.W) && paddleLeft.Y > 0){
            paddleLeft.Y-=10;
        }

        if(kState.IsKeyDown(key: Keys.S) && paddleLeft.Y + paddleLeft.Height < 480){
            paddleLeft.Y+=10;
        }

        if(kState.IsKeyDown(key: Keys.Up) && paddleRight.Y + paddleRight.Height > 480){
            paddleRight.Y+=10;
        }

        if(kState.IsKeyDown(key: Keys.Down) && paddleRight.Y > 0){
            paddleRight.Y-=10;
        }

        ball.X += (int)velocityX;
        ball.Y += (int)velocityY;
        if(ball.Intersects(paddleRight)||
           ball.Intersects(value:paddleLeft)){
            velocityX*= -1.1f;
            velocityY*= 1.1f;
        }

        if(ball.Y <= 0 || ball.Y + ball.Height >= 400){
            velocityY *= -1;
        }

        if(ball.X <= 0 || ball.X + ball.Width >= 800){
            ball.X = 390;
            ball.Y = 230;
            velocityX = 2;
            velocityY = 2;
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.DrawString(spriteFont: fontScore,
        text: scoreLeftPlayer.ToString(),
        position: new Vector2(x:10,y:10),
        color: Color.DarkOrange);

        _spriteBatch.DrawString(spriteFont: fontScore,
        text: scoreRightPlayer.ToString(),
        position: new Microsoft.Xna.Framework.Vector2(x: 410,y: 10),
        color: Color.DarkOrange);

        _spriteBatch.Draw(pixel, paddleLeft,Color.HotPink);
        _spriteBatch.Draw(pixel, paddleRight,Color.HotPink);
        _spriteBatch.Draw(pixel, ball,Color.Yellow);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
