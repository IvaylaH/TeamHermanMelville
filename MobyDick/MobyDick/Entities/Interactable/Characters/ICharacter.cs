﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using MobyDick.Entities.Interactable.Items;

namespace MobyDick.Entities.Interactable.Characters
{
    interface ICharacter : IAnimatedEntity
    {
        int Health { get; set; }
        int Velocity { get; set; }
        List<ItemType> BackPack {get; set;}
        int Level { get; set; }
        int Experience { get; set; }
    }
}
