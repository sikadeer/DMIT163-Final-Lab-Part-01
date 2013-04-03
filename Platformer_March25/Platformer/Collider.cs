using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{

    /// <summary>
    /// This is a GitHub test to verify things and stuff
    /// </summary>

    public class Collider
    {
        public enum ColliderType
        {
            Left,
            Right,
            Top,
            Bottom
        }

        protected ColliderType colliderType;
        protected Vector2 position = Vector2.Zero;
        protected Vector2 dimensions;

        protected Texture2D texture;

        internal Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y);
            }
        }

        public Collider(Vector2 position, Vector2 dimensions, ColliderType colliderType)
        {
            this.position = position;
            this.dimensions = dimensions;
            this.colliderType = colliderType;
        }

        internal void LoadContent(ContentManager Content)
        {
            if (colliderType == ColliderType.Left)
            {
                texture = Content.Load<Texture2D>("ColliderLeft");
            }
            else if (colliderType == ColliderType.Right)
            {
                texture = Content.Load<Texture2D>("ColliderRight");
            }
            else if (colliderType == ColliderType.Top)
            {
                texture = Content.Load<Texture2D>("ColliderTop");
            }
            else
            {
                texture = Content.Load<Texture2D>("ColliderBottom");
            }
        }
        
        internal void Update(GameTime gameTime)
        {
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, BoundingBox, new Rectangle(0, 0, (int)dimensions.X, (int)dimensions.Y), Color.White);
        }

        internal void ProcessCollisions(Rex rex)
        {
            //if(BoundingBox.Intersects(player.BoundingBox))
            if (rex.BoundingBox.Intersects(BoundingBox))
            {
                switch (colliderType)
                {
                    case ColliderType.Left:
                        if (rex.Velocity.X > 0)
                        {
                            rex.MoveHorizontally(0);
                        }
                        break;
                    case ColliderType.Right:
                        if (rex.Velocity.X < 0)
                        {
                            rex.MoveHorizontally(0);
                        }
                        break;
                    case ColliderType.Top:
                        rex.Land();
                        rex.StandOn(BoundingBox);
                        break;
                    case ColliderType.Bottom:
                        if (rex.Velocity.Y < 0)
                        {
                            rex.MoveVertically(0);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
