using System;
using System.Linq;
using UnityEngine;

namespace HamiMicsFuncs.ScriptableObjects.SpriteLoader
{
    [Serializable]
    public struct SpriteStructure
    {
        public string name;
        public Sprite sprite;
    }

    [CreateAssetMenu(fileName = "New Sprite package", menuName = "New Sprite Package ", order = 51)]
    public class SOResourceSpriteLoader : ScriptableObject
    {
        [SerializeField] private SpriteStructure[] Sprites;

        public Sprite GetByName(string spriteName)=>
            Sprites.FirstOrDefault(a => a.name == spriteName).sprite;
    }
}    