﻿namespace MobyDick.Entities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using MobyDick.Entities.Interactable.Characters;
    using MobyDick.Entities.Interactable.Items;
    using System.Collections.Generic;
    class Scene : BaseEntity<Scene>, IEntity
    {
        private Dictionary<string, Scene> LinkedScenes;
        public List<BaseItem> Obsticles;
        public List<NPC> NPCS;
        public string SceneName { get; private set; }
        public Scene(Texture2D texture, Rectangle form, Vector2 position, Color color, string sceneName)
            : base(texture, form, position, color)
        {
            this.SceneName = sceneName;
            this.NPCS = new List<NPC>();
            this.Obsticles = new List<BaseItem>();
            this.LinkedScenes = new Dictionary<string, Scene>();
        }

        public void LinkScene(string sceneName, Scene scene)
        {
            this.LinkedScenes.Add(sceneName, scene);
        }

        public Scene GetScene(string sceneName)
        {
            if (this.LinkedScenes.ContainsKey(sceneName))
            {
                return this.LinkedScenes[sceneName];
            }
            else
            {
                return null;
            }
        }

        public void AddObsticle(BaseItem obsticle)
        {
            this.Obsticles.Add(obsticle);
        }

        public void AddNPC(NPC npc)
        {
            this.NPCS.Add(npc);
        }

        public void Update(GameTime gameTime)
        {
            base.Update();
            foreach (var obsticle in this.Obsticles)
            {
                obsticle.Update();
            }
            foreach (var npc in this.NPCS)
            {
                npc.Update();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (var obsticle in this.Obsticles)
            {
                obsticle.Draw(spriteBatch);
            }
            foreach (var npc in this.NPCS)
            {
                npc.Draw();
            }
        }
    }
}