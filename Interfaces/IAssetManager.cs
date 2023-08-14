using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace snake.Interfaces
{
    public interface IAssetManager
    {
        Texture2D GetLetterTexture(char letter);
    }

    public class AssetManager : IAssetManager
    {
        private readonly ContentManager _content;
        private Dictionary<char, Texture2D> _letterTextures;
        
        public AssetManager(ContentManager content)
        {
            _content = content;
            LoadAssets();
        }

        private void LoadAssets()
        {
            _letterTextures = new Dictionary<char, Texture2D>();

            foreach(char letter in "SNAKE")
            {
                _letterTextures.Add(letter, _content.Load<Texture2D>(letter.ToString()));
            }
        }

        public Texture2D GetLetterTexture(char letter)
        {
            return _letterTextures.TryGetValue(letter, out var texture) ? texture : null;
        }
    }
}