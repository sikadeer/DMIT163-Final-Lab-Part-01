using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Obstacle
    {
        protected CelAnimationSequence animationSequence;
        protected CelAnimationPlayer celAnimationPlayer;
        
        protected Vector2 position = Vector2.Zero;
        protected Vector2 velocity = Vector2.Zero;
        protected Vector2 dimensions = Vector2.Zero;
        protected const float Speed = 100;

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

        public Obstacle(Vector2 position, Rectangle gameBoundingBox)
        {
            this.position = position;
            this.gameBoundingBox = gameBoundingBox;
            dimensions = new Vector2(85, 97);
        }

        internal void Initialize()
        {
            
        }

        internal void LoadContent(ContentManager Content)
        {
            animationSequence = new CelAnimationSequence(Content.Load<Texture2D>("blackelmer_standing"), 74, 1 / 4f);

            celAnimationPlayer = new CelAnimationPlayer();
            celAnimationPlayer.Play(animationSequence);
        }
        
        internal void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            celAnimationPlayer.Update(gameTime);
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            celAnimationPlayer.Draw(spriteBatch, position, SpriteEffects.None);
        }

        internal void ProcessCollision()
        {
            // todo: process collision - if a collision is detected bump player position back one "notch"
        } 
    }
}
