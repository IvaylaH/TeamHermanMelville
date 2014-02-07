﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using MobyDick.Entities.Interactable.Characters;

namespace MobyDick.Entities.Interactable.Characters
{
    class NPC<TNPC> : Character<TNPC> where TNPC : ICharacter
    {
        public NPC(Texture2D texture, Rectangle form, int health, Vector2 position, Color color)
            : base(texture, form, health, position,color)
        {

        }
    }
}