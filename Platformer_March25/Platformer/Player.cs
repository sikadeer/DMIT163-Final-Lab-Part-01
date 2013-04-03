using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Player
    {
        public enum State
        {
            Idle,
            Walking,
            Jumping,
            Dead,
            Transitioning
        }
        protected State state = State.Idle;

        protected CelAnimationSequence idleSequence;
        protected CelAnimationSequence walkSequence;
        protected CelAnimationSequence jumpSequence;
        protected CelAnimationPlayer celAnimationPlayer;
        protected Texture2D texture;
        
        protected Vector2 position = Vector2.Zero;
        protected Vector2 velocity = Vector2.Zero;
        protected Vector2 positionBeforeMovingBack = Vector2.Zero;
        protected Vector2 velocityBeforeMovingBack = Vector2.Zero;

        internal Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
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

        public Player(Vector2 position, Rectangle gameBoundingBox)
        {
            this.position = position;
            this.gameBoundingBox = gameBoundingBox;
            dimensions = new Vector2(85, 97);
        }

        internal void Initialize()
        {
            state = State.Idle;
        }

        internal void LoadContent(ContentManager Content)
        {
            //idleSequence = new CelAnimationSequence(Content.Load<Texture2D>("blackelmer_standing"), 74, 1 / 4f);
            //walkSequence = new CelAnimationSequence(Content.Load<Texture2D>("blackelmer_walking"), 68, 1 / 8f);
            //jumpSequence = new CelAnimationSequence(Content.Load<Texture2D>("blackelmer_jumping2"), 85, 1 / 8f);
            texture = Content.Load<Texture2D>("rock");
           
            celAnimationPlayer = new CelAnimationPlayer();
            celAnimationPlayer.Play(idleSequence);
        }
        
        internal void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            celAnimationPlayer.Update(gameTime);
            velocity.Y += Platformer.Gravity; 

            if (velocity.Y > 16 * Platformer.Gravity)
            {
                state = State.Jumping;
            }

            if(state == State.Transitioning)
            {
                if((positionBeforeMovingBack.X - position.X) >= 150)
                {
                    state = State.Idle;
                    velocity = velocityBeforeMovingBack;
                }
            }
            

            switch (state)
            {
                case (State.Idle):
                    celAnimationPlayer.Play(idleSequence);
                    break;
                case (State.Walking):
                    celAnimationPlayer.Play(walkSequence);
                    break;
                case (State.Jumping):
                    celAnimationPlayer.Play(jumpSequence);
                    break;
                case (State.Dead):
                    break;
            } 
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            celAnimationPlayer.Draw(spriteBatch, position, SpriteEffects.None, 1);
            switch (state)
            {
                case (State.Idle):
                    break;
                case (State.Walking):
                    break;
                case (State.Jumping):
                    break;
                case (State.Dead):
                    break;
            } 
        }

        internal void MoveHorizontally(float direction)
        {
            if(state != State.Transitioning)
            {
                velocity.X = direction * Speed;

                if (state != State.Jumping)
                {
                    state = State.Walking;
                }

                if (direction == 0 && state != State.Jumping)
                {
                    state = State.Idle;
                } 
            }
            

            
        }

        internal void MoveVertically(float direction)
        {
            velocity.Y = direction * Speed;
        }

        internal void Jump()
        {
            state = State.Jumping;
            velocity.Y = JumpForce;
        }

        internal void Land()
        {
            if (state == State.Jumping)
            {
                velocity.Y = 0;
                state = State.Idle;
            }
        }
        internal void StandOn(Rectangle WhatImStandingOn)
        {
            position.Y = WhatImStandingOn.Top - dimensions.Y; 
            velocity.Y -= Platformer.Gravity;
        } 

        internal void MoveBack()
        {
            velocityBeforeMovingBack = velocity;
            positionBeforeMovingBack = position;
            state = State.Transitioning;
            velocity = new Vector2(-100, 0);
        }
    }
}
