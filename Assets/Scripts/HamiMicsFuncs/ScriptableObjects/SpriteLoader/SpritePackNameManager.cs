using System.Collections.Generic;
using Modules.Singleton;
using UnityEngine;

namespace HamiMicsFuncs.ScriptableObjects.SpriteLoader
{
    public class SpritePackNameManager : SimpleSingleton<SpritePackNameManager>
    {
        private Dictionary<string, SOResourceSpriteLoader> _spritesLoaders =
            new Dictionary<string, SOResourceSpriteLoader>();

        public Sprite GetByType(string spritePackType, string spriteName)
        {
            if (!_spritesLoaders.ContainsKey(spritePackType))
                _spritesLoaders.Add(spritePackType,
                    Resources.Load<SOResourceSpriteLoader>($"ScriptableObjects/{spritePackType}")
                );
            return _spritesLoaders[spritePackType].GetByName(spriteName);
        }
    }
}