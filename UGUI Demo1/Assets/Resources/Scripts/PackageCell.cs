using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PackageCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	private Transform UIIcon;
	private Transform UIHead;
	private Transform UINew;
	private Transform UISelect;
	private Transform UILevel;
	private Transform UIStars;
	private Transform UIDeleteSelect;

	private Transform UISelectAni;
	private Transform UIMouseOverAni;

	private PackageLocalItem packageLocalData;
	private PackageTableItem packageTableItem;
	private PackagePanel uiParent;

	private void Awake()
	{
		InitUIName();
	}
	private void InitUIName()
	{
		UIIcon = transform.Find("Top/Icon");
		UIHead = transform.Find("Top/Head");
		UINew = transform.Find("Top/New");
		UILevel = transform.Find("Bottom/LevelText");
		UIStars = transform.Find("Bottom/Stars");
		UISelect = transform.Find("Select");
		UIDeleteSelect = transform.Find("DeleteSelect");
		UIMouseOverAni = transform.Find("MouseOverAnimation");
		UISelectAni = transform.Find("SelectAnimation");

		UIDeleteSelect.gameObject.SetActive(false);
		UIMouseOverAni.gameObject.SetActive(false);
		UISelectAni.gameObject.SetActive(false);
		UIHead.gameObject.SetActive(false);
	}

	public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
	{
		// ���ݳ�ʼ��
		this.packageLocalData = packageLocalData;
		this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
		this.uiParent = uiParent;
		// �ȼ���Ϣ
		UILevel.GetComponent<Text>().text = "Lv." + this.packageLocalData.level.ToString();
		// �Ƿ����»�ã�
		UINew.gameObject.SetActive(this.packageLocalData.isNew);
		// ��Ʒ��ͼƬ
		Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
		Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
		UIIcon.GetComponent<Image>().sprite = temp;
		// ˢ���Ǽ�
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
	public void RefreshDeleteState()
	{
		if (this.uiParent.deleteChooseUid.Contains(this.packageLocalData.uid))
		{
			this.UIDeleteSelect.gameObject.SetActive(true);
		}
		else
		{
			this.UIDeleteSelect.gameObject.SetActive(false);

		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		print(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + this.uiParent.curMode.ToString());
		//Debug.Log("OnPointerClick: " + eventData.ToString());
		if (this.uiParent.curMode == PackageMode.delete)
		{
			this.uiParent.AddChooseDeleteUid(this.packageLocalData.uid);
		}
		if (this.uiParent.chooseUID == this.packageLocalData.uid)
			return;
		// ���ݵ���������µ�uid -> ����ˢ���������
		this.uiParent.chooseUID = this.packageLocalData.uid;
		UISelectAni.gameObject.SetActive(true);
		UISelectAni.GetComponent<Animator>().SetTrigger("In");
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		//Debug.Log("OnPointerEnter: " + eventData.ToString());
		UIMouseOverAni.gameObject.SetActive(true);
		UIMouseOverAni.GetComponent<Animator>().SetTrigger("In");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		//Debug.Log("OnPointerExit: " + eventData.ToString());
		UIMouseOverAni.GetComponent<Animator>().SetTrigger("Out");
	}

	public void OnSelectAniInCb()
	{
		UISelectAni.gameObject.SetActive(false);
	}
	public void OnMouseOverAniOutCb()
	{
		UIMouseOverAni.gameObject.SetActive(false);
	}
}