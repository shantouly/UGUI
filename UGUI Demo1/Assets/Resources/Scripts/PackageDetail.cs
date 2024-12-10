using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageDetail : MonoBehaviour
{
	private Transform UIStars;
	private Transform UIDescription;
	private Transform UIIcon;
	private Transform UITitle;
	private Transform UILevelText;
	private Transform UISkillDescription;

	private PackageLocalItem packageLocalData;
	private PackageTableItem packageTableItem;
	private PackagePanel uiParent;

	private void Awake() {
		InitUIName();
		gameObject.SetActive(false);
		//Test();
	}

	// private void Test()
	// {
	//     Refresh(GameManager.Instance.GetPackageLocalData()[1], null);
	// }

	private void InitUIName()
	{
		UIStars = transform.Find("Center/Stars");
		UIDescription = transform.Find("Center/Description");
		UIIcon = transform.Find("Center/Icon");
		UITitle = transform.Find("Top/Title");
		UILevelText = transform.Find("Bottom/LevelPnl/LevelText");
		UISkillDescription = transform.Find("Bottom/Description");
	}

	public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
	{
		// ��ʼ������̬���ݡ���̬���ݡ�����Ʒ�߼�
		this.packageLocalData = packageLocalData;
		this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
		this.uiParent = uiParent;
		// �ȼ�
		UILevelText.GetComponent<Text>().text = string.Format("Lv.{0}/40", this.packageLocalData.level.ToString());
		// �������
		UIDescription.GetComponent<Text>().text = this.packageTableItem.description;
		// ��ϸ����
		UISkillDescription.GetComponent<Text>().text = this.packageTableItem.skillDescription;
		// ��Ʒ����
		UITitle.GetComponent<Text>().name = this.packageTableItem.name;
		// ͼƬ����
		Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
		Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
		UIIcon.GetComponent<Image>().sprite = temp;
		// �Ǽ�����
		RefreshStars();
	}
	public void RefreshStars()
	{
		for (int i = 0; i < UIStars.childCount; i++)
		{
			Transform star = UIStars.GetChild(i);
			if (this.packageTableItem.star > i)
			{
				star.gameObject.SetActive(true);
			}
			else
			{
				star.gameObject.SetActive(false);
			}
		}
	}
}