using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileInfoManager : MonoBehaviour
{
	[SerializeField]
	private FileInfoElement m_ElementPrefab;

	[SerializeField]
	private Transform m_Content;

	[SerializeField]
	private Button m_RefreshButton;

	private List<FileInfoElement> m_FilesList = new List<FileInfoElement>();

	private void Awake()
	{
		m_RefreshButton.onClick.AddListener(delegate { LoadSprites(); });

		LoadSprites();
	}

	private void LoadSprites()
	{
		SpriteLoader loader = new SpriteLoader(Application.dataPath + "/Sprites/");
		List<SpriteInfo> imagesData = loader.LoadSprites();

		SpawnElementIfNeeded(imagesData.Count);
		DisableAllElements();
		for (int i = 0; i < imagesData.Count; i++)
		{
			if (i < m_FilesList.Count)
			{
				SpriteInfo info = imagesData[i];
				FileInfoElement file = m_FilesList[i];
				file.SetSpriteToImage(info.ImageSprite);
				file.SetTextData(info.Name, info.Time);
				file.gameObject.SetActive(true);
			}
		}
	}

	private void DisableAllElements()
	{
		foreach (var element in m_FilesList)
		{
			element.gameObject.SetActive(false);
		}
	}

	private void SpawnElementIfNeeded(int count)
	{
		while (m_FilesList.Count < count)
		{
			FileInfoElement element = Instantiate(m_ElementPrefab, m_Content);
			m_FilesList.Add(element);
		}
	}
}
