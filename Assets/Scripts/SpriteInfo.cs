using UnityEngine;

[System.Serializable]
public class SpriteInfo 
{
	public Sprite ImageSprite;
	public string Name;
	public string Time;

	public SpriteInfo(Sprite sprite, string name, string time)
	{
		ImageSprite = sprite;
		Name = name;
		Time = time;
	}
}
