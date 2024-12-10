using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GMCmd
{
	[MenuItem("CMCmd/��ȡ���")]
	public static void ReadTable()
	{
		PackageTable packageTable = Resources.Load<PackageTable>("TableData/TableItemsData");
		foreach(var item in packageTable.packageItems)
		{
			Debug.Log(string.Format("[id]:{0},[name]:{1}",item.id,item.name)); 
		}
	}
	
	[MenuItem("CMCmd/����������������")]
	public static void CreateLocalPackageData()
	{
		Debug.Log("1111");
		// ��������
		PackageLocalData.Instance.items = new List<PackageLocalItem>();
		for(int i = 0;i<8;i++)
		{
			PackageLocalItem packageLocalItem = new ()
			{
				uid = Guid.NewGuid().ToString(),
				id = i,
				num = i,
				level = i,
				isNew = i % 2 == 1
			};
			PackageLocalData.Instance.items.Add(packageLocalItem);
		}
		PackageLocalData.Instance.SavePackage();
		
		// ��ȡ����
		List<PackageLocalItem> readItems = PackageLocalData.Instance.LoadPackage();
		foreach(var item in readItems)
		{
			Debug.Log(item);
		}
	}
	
	[MenuItem("CMCmd/�򿪱���������")]
	public static void OpenPackagePanel()
	{
		UIManager.Instance.OpenPanel(UIConst.PackagePanel);
	}
}
