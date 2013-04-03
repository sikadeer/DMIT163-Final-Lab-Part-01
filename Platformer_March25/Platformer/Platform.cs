using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Platform
    {
        protected Vector2 position = Vector2.Zero;
        protected Vector2 dimensions;

        protected Collider leftCollider;
        protected Collider rightCollider;
        protected Collider topCollider;
        protected Collider bottomCollider;

        protected Texture2D texture;

        public Platform(Vector2 position, Vector2 dimensions)
        {
            this.position = position;
            this.dimensions = dimensions;

            leftCollider = new Collider
                                (
                                    new Vector2(position.X, position.Y + 1), 
                                    new Vector2(1, dimensions.Y - 2), 
                                    Collider.ColliderType.Left
                                );
            rightCollider = new Collider
                                (
                                    new Vector2(position.X + dimensions.X, position.Y + 1),
                                    new Vector2(1, dimensions.Y - 2), 
                                    Collider.ColliderType.Right
                                );
            topCollider = new Collider
                                (
                                    new Vector2(position.X + 2, position.Y),
                                    new Vector2(dimensions.X - 4, 1),
                                    Collider.ColliderType.Top
                                );
            bottomCollider = new Collider
                                (
                                    new Vector2(position.X, position.Y + dimensions.Y),
                                    new Vector2(dimensions.X, 1),
                                    Collider.ColliderType.Bottom
                                );

        }

        internal void LoadContent(ContentManager Content)
        {
            //texture = Content.Load<Texture2D>("Mosquito");
            leftCollider.LoadContent(Content);
            rightCollider.LoadContent(Content);
            topCollider.LoadContent(Content);
            bottomCollider.LoadContent(Content);

        }
        
        internal void Update(GameTime gameTime)
        {
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture,...);
            leftCollider.Draw(spriteBatch);
            rightCollider.Draw(spriteBatch);
            topCollider.Draw(spriteBatch);
            bottomCollider.Draw(spriteBatch);
        }

        internal void ProcessCollisions(Rex rex)
        {
            leftCollider.ProcessCollisions(rex);
            rightCollider.ProcessCollisions(rex);
            topCollider.ProcessCollisions(rex);
            bottomCollider.ProcessCollisions(rex);
        }
    }
}
