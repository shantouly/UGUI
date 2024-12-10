using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PackageTable")]
public class PackageTable : ScriptableObject
{
	public List<PackageTableItem> packageItems = new List<PackageTableItem>();
}

[System.Serializable]
public class PackageTableItem
{
	public int id;
	public int type;
	public int star;
	public string name;
	public string description;
	public string skillDescription;
	public string imagePath;
	public int num;
}

