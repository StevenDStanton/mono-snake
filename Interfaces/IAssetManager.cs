using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace snake.Interfaces
{
    public interface IAssetManager
    {
        Texture2D GetLetterTexture(char letter);
        Texture2D GetButton(string buttonName);
        Song GetSong(string songName);
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
                _letterTextures.Add(letter, _content.Load<Texture2D>($"Letters/{letter}"));

            }

        }

        public Texture2D GetLetterTexture(char letter)
        {
            return _letterTextures.TryGetValue(letter, out var texture) ? texture : null;
        }

        public Texture2D GetButton(string buttonName)
        {
            return _content.Load<Texture2D>($"Buttons/{buttonName}");
        }

        public Song GetSong(string songName)
        {
            return _content.Load<Song>($"Music/{songName}");
        }
    }
}