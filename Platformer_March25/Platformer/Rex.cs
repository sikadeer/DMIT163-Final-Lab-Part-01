using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Rex
    {
        protected CelAnimationSequence walkSequence;

        protected CelAnimationPlayer celAnimationPlayer;
        
        protected Vector2 position = Vector2.Zero;
        protected Vector2 velocity = Vector2.Zero;

        protected Vector2 dimensions;

        protected Rectangle gameBoundingBox;


        protected const float Speed = 100;
        protected const float JumpForce = -200;
 
        internal Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y);
            }
        } 

        public Rex(Vector2 position, Rectangle gameBoundingBox)
        {
            this.position = position;
            this.gameBoundingBox = gameBoundingBox;
            dimensions = new Vector2(251, 126);
        } // constructor

        internal void Initialize()
        {
        } // initialize

        internal void LoadContent(ContentManager Content)
        {
            walkSequence = new CelAnimationSequence(Content.Load<Texture2D>("Rex_Walking"), 251, 1 / 6f);
           
            celAnimationPlayer = new CelAnimationPlayer();
        } // loadContent
        
        internal void Update(GameTime gameTime)
        {
            //position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            celAnimationPlayer.Update(gameTime);
            //velocity.Y += Platformer.Gravity; 

            celAnimationPlayer.Play(walkSequence);
                   
        } // update

        internal void Draw(SpriteBatch spriteBatch)
        {
            celAnimationPlayer.Draw(spriteBatch, position, SpriteEffects.None);
        } // draw

        internal void StandOn(Rectangle WhatImStandingOn)
        {
            position.Y = WhatImStandingOn.Top - dimensions.Y; 
        } // stand On
    }
}
