using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Rex
    {
        protected CelAnimationSequence walkSequence;

        protected CelAnimationPlayer celAnimationPlayer;

        protected const float ScaleValue = 2.0f;

        protected Vector2 position = new Vector2(-280, 145);

        protected const int CelWidth = 251;
        protected const int CelHeight = 126;
        protected Vector2 dimensions = new Vector2((ScaleValue * CelWidth), (ScaleValue * CelHeight));        
        protected const float Speed = 100;
 
        internal Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y);
            }
        } 

        public Rex()
        {
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
            celAnimationPlayer.Draw(spriteBatch, position, SpriteEffects.None, ScaleValue);
        } // draw

        internal void StandOn(Rectangle WhatImStandingOn)
        {
            position.Y = WhatImStandingOn.Top - dimensions.Y; 
        } // stand On
    }
}
