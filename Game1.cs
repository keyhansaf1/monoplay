
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


    Paddle paddleLeft;

    Paddle paddleRight;

    Ball ball;

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

        ball = new Ball(t:pixel);
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

        if(kState.IsKeyDown(key: Keys.Up) && paddleRight.Y + paddleRight.Height < 480){
            paddleRight.Y+=10;
        }

        if(kState.IsKeyDown(key: Keys.Down) && paddleRight.Y + p> 0){
            paddleRight.Y-=10;
        }




        ball.Update();

        if(ball.X <= 0){
            ball.Reset();
            scoreRightPlayer++;
        }
        else if(ball.Rectangle.X + ball.Rectangle.Width >= 800){
            ball.Reset();
            scoreLeftPlayer++;
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.DrawString(spriteFont: fontScore,scoreLeftPlayer.ToString(),
        new Vector2(x:10,y:10),
        Color.Green);

        _spriteBatch.DrawString(spriteFont: fontScore,
        text: scoreRightPlayer.ToString(),
        position: new Microsoft.Xna.Framework.Vector2(x: 410,y: 10),
        color: Color.DarkOrange);

        paddleLeft.Draw(_spriteBatch);
        paddleRight.Draw(_spriteBatch);
        ball.Draw(spriteBatch:_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
