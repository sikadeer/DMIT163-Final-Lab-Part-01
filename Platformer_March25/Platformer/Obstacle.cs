using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Platformer
{
    public class Obstacle
    {
        protected enum State
        {
            Active,
            Inactive
        }

        protected State state;
        
        protected Vector2 position = Vector2.Zero;
        protected Vector2 velocity = Vector2.Zero;
        protected Vector2 dimensions = Vector2.Zero;
        protected const float Speed = 100;

        // protected CelAnimationSequence animationSequence;
        // protected CelAnimationPlayer celAnimationPlayer;

        protected Texture2D texture;
        protected string textureName;

        internal Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        protected Rectangle gameBoundingBox;

        internal Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y);
            }
        } 

        public Obstacle(Vector2 position, Vector2 dimensions, Rectangle gameBoundingBox)
        {
            this.position = position;
            this.gameBoundingBox = gameBoundingBox;
            this.dimensions = dimensions;
            ///////////////////////////////////////////////
            state = State.Active;
        }

        internal void Initialize()
        {
            
        }

        internal void LoadContent(ContentManager Content)
        {
            // animationSequence = new CelAnimationSequence(Content.Load<Texture2D>("blackelmer_standing"), 74, 1 / 4f);
            // celAnimationPlayer = new CelAnimationPlayer();
            // celAnimationPlayer.Play(animationSequence);

            texture = Content.Load<Texture2D>("rock");
            dimensions.X = texture.Width;
            dimensions.Y = texture.Height;
        }
        
        internal void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            // celAnimationPlayer.Update(gameTime);
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            // celAnimationPlayer.Draw(spriteBatch, position, SpriteEffects.None);
            spriteBatch.Draw(texture, BoundingBox, new Rectangle(0, 0, (int)dimensions.X, (int)dimensions.Y), Color.White);
        }

        internal void ProcessCollisions(Player player, String collisionMessage)
        {
            // todo: process collision - if a collision is detected bump player position back one "notch"
            if(state == State.Active && player.BoundingBox.Intersects(BoundingBox))
            {
                // collision detected
                player.MoveBack();
                collisionMessage = "Collision detected";
                // state = State.Inactive;
                // todo: play animation

            }
            else
            {
                collisionMessage = "";
            }
        } 
    }
}
