using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Platformer
{
    public class Platformer : Microsoft.Xna.Framework.Game
    {
        protected enum State
        {
            Playing,
            Paused,
            Over
        }

        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected Texture2D background;
        protected SpriteFont systemArialFont;
        protected String statusMessage = "Game Over. Press space bar to start again.";
        
        protected const int WindowWidth = 550;
        protected const int WindowHeight = 400;

        protected Rectangle gameBoundingBox = new Rectangle(0, 0, WindowWidth, WindowHeight);

        protected State gameState;

        //protected Player player;
        protected Rex rex;

        protected Platform p1;
        protected Platform ground;

        internal static int Gravity = 5;




        protected Obstacle testObstacle;
        public string collisionMessage = "";



        public Platformer()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {            
            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.ApplyChanges();

            gameState = State.Playing;



            testObstacle = new Obstacle(new Vector2(300, WindowHeight - 50), new Vector2(50, 50), gameBoundingBox);


            p1 = new Platform(new Vector2(100, 250), new Vector2(72, 21));
            ground = new Platform(new Vector2(0, WindowHeight - 2), new Vector2(WindowWidth, 3));

            rex = new Rex();
            
            base.Initialize();

            rex.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Background");
            systemArialFont = Content.Load<SpriteFont>("SystemArialFont");


            testObstacle.LoadContent(Content);


            p1.LoadContent(Content);
            ground.LoadContent(Content);
            rex.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            //get keyboard input
            InputKeyManager.Triggers currentKeys = InputKeyManager.Read();
            
            switch(gameState)
            {
                case State.Playing:
                    if ((currentKeys & InputKeyManager.Triggers.Pause) != 0)
                    {
                        gameState = State.Paused;
                    }

                    if ((currentKeys & InputKeyManager.Triggers.LeftArrow) != 0)
                    {
                        //rex.MoveHorizontally(-1);
                    }
                    else if ((currentKeys & InputKeyManager.Triggers.RightArrow) != 0)
                    {
                        //rex.MoveHorizontally(1);
                    }
                    else
                    {
                        //rex.MoveHorizontally(0);
                    }

                    if ((currentKeys & InputKeyManager.Triggers.Fire) != 0)
                    {
                        
                    }

                    //ground.ProcessCollisions(player);

<<<<<<< HEAD


                    testObstacle.ProcessCollisions(player, collisionMessage);



                    p1.ProcessCollisions(player);
=======
                    //p1.ProcessCollisions(player);
>>>>>>> origin/christopher

                    rex.Update(gameTime);
                    
                    break;
                case(State.Paused):
                    if ((currentKeys & InputKeyManager.Triggers.Fire) != 0)
                    {
                        gameState = State.Playing;
                    }
                    statusMessage = "Game Paused. Press space bar to start again.";
                    break;
                case State.Over:
                    statusMessage = "Game Over. Press space bar to start again.";
                    if ((currentKeys & InputKeyManager.Triggers.Fire) != 0)
                    {
                        Initialize();
                    }
                    break;
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);
            spriteBatch.Begin();
            
            switch (gameState)
            {
                case State.Playing:
                    ground.Draw(spriteBatch);


                    spriteBatch.DrawString(systemArialFont, collisionMessage, new Vector2(20.0f, 50.0f), Color.White);
                    testObstacle.Draw(spriteBatch);


                    p1.Draw(spriteBatch);
                    rex.Draw(spriteBatch);
                    break;
                case (State.Paused):
                    spriteBatch.DrawString(systemArialFont, statusMessage, new Vector2(20.0f, 50.0f), Color.White);
                    break;
                case State.Over:
                    spriteBatch.DrawString(systemArialFont, statusMessage, new Vector2(20.0f, 50.0f), Color.White);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
