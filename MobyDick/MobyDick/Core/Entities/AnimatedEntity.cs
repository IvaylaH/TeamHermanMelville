﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using MobyDick.Entities.Interactable;

namespace MobyDick.Entities
{
    internal abstract class AnimatedEntity : BaseEntity<AnimatedEntity>, IAnimatedEntity
    {
        public float Timer { get; set; }
        public float Interval { get; set; }
        public int CurrentFrameNumber { get; set; }
        public int MaxFrames { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public SpriteEffects Effect { get; set; }
        public Directions currentDirection { get; set; }
        public int SpriteRows { get; set; }
        public Rectangle CurrentFrame
        {
            get
            {
                return new Rectangle((this.Texture.Width / this.MaxFrames * this.CurrentFrameNumber),
                    this.Texture.Height / this.SpriteRows * (int)this.currentDirection,
                    this.Form.Width,
                    this.Form.Height);
            }
        }
        public AnimatedEntity(Texture2D texture, Rectangle form, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, position, color)
        {
            this.Timer = 0f;
            this.CurrentFrameNumber = 0;
            this.MaxFrames = 3;
            this.Interval = 1000f/10f;
            this.Effect = SpriteEffects.None;
            this.spriteBatch = spriteBatch;
            this.SpriteRows = 4;
        }
        public AnimatedEntity(Texture2D texture, Rectangle form, Vector2 position, Color color, SpriteBatch spriteBatch, 
            int currentFrame, int maxFrames, int spriteRows,float interval = 1000f/10f)
            : base(texture, form, position, color)
        {
            this.Timer = 0f;
            this.CurrentFrameNumber = currentFrame;
            this.MaxFrames = maxFrames;
            this.Interval = interval;
            this.spriteBatch = spriteBatch;
            this.Effect = SpriteEffects.None;
            this.SpriteRows = spriteRows;
        }

        protected void AnimateMovement(GameTime gameTime)
        {
            this.Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.Timer > this.Interval)
            {
                this.CurrentFrameNumber++;
                this.CurrentFrameNumber = this.CurrentFrameNumber % this.MaxFrames;
                this.Timer = 0f;
            }
        }

        public override void Update()
        {
            base.Update();
        }
        public virtual void Draw()
        {
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.Texture, this.Position, this.CurrentFrame, this.Color, 0, new Vector2(0, 0), 1, this.Effect, 0);
            this.spriteBatch.End();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
