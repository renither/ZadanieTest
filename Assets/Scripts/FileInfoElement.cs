using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FileInfoElement : MonoBehaviour
{
	[SerializeField]
	private Image m_Image;

	[SerializeField]
	private TextMeshProUGUI m_NameText;
	[SerializeField]
	private TextMeshProUGUI m_FileCreationTime;

	public void SetTextData(string name, string createTime)
	{
		m_NameText.text = name;
		m_FileCreationTime.text = createTime;
	}

	public void SetSpriteToImage(Sprite sprite)
	{
		m_Image.sprite = sprite;
	}
}
