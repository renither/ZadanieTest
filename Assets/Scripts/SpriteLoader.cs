using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpriteLoader
{
    public SpriteLoader(string path)
	{
        m_LoadPath = path;
    }

    private string m_LoadPath;

    public List<SpriteInfo> LoadSprites()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(m_LoadPath);
        FileInfo[] infoFiles = directoryInfo.GetFiles("*.png");

        List<SpriteInfo> m_Sprites = new List<SpriteInfo>();
        foreach (FileInfo file in infoFiles)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(file.FullName);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            m_Sprites.Add(new SpriteInfo(sprite, file.Name, file.CreationTime.ToShortTimeString()));
        }
        return m_Sprites;
    }
}
