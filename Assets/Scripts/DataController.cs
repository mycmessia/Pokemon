using UnityEngine;
using System.Collections;
using System.Collections.Generic;			// for List
using System.Xml;

public class DataController : MonoBehaviour {

	public static DataController instance;

	List<Dictionary<string, string>> _pokemonsDataList;
	List<Dictionary<string, string>> _skillsDataList;

	void Awake ()
	{
		instance = this;
	}
	
	void Start ()
	{
		_pokemonsDataList = LoadDictListFromXML ("Pokemons", "PokemonsGeneration1");
		_skillsDataList = LoadDictListFromXML ("Skills", "SkillsGeneration1");
		
		Skill skill1 = SkillGenerator.Create ();
	}
	
	public float[, ] LoadFloatArrFromXML (string fileName, int col, int row)
	{
		float[, ] resultArr = new float[col, row];
		
		string xmlStr = Resources.Load ("Data/" + fileName).ToString ();
		
		XmlDocument xml = new XmlDocument ();
		
		xml.LoadXml (xmlStr);
		
		XmlNodeList xmlNodeList = xml.SelectSingleNode ("data").ChildNodes;
		int i = 0, j;
		foreach (XmlElement xmlE in xmlNodeList)
		{
			j = 0;
			foreach (XmlElement xmlEE in xmlE)
			{
				resultArr[i, j] = float.Parse (xmlEE.InnerText);
				j++;
			}
			i++;
		}
		
		return resultArr;
	}
	
	List<Dictionary<string, string>> LoadDictListFromXML (string folderName, string fileName)
	{
		List<Dictionary<string, string>> dataList = new List<Dictionary<string, string>> ();
		
		string xmlStr = Resources.Load ("Data/" + folderName + "/" + fileName).ToString ();
		
		XmlDocument xml = new XmlDocument ();
		xml.LoadXml (xmlStr);
		
		XmlNodeList xmlNodeList = xml.SelectSingleNode ("data").ChildNodes;
		foreach (XmlElement xmlE in xmlNodeList)
		{
			Dictionary<string, string> dictItem = new Dictionary<string, string> ();
			foreach (XmlElement xmlEE in xmlE)
			{
//				Debug.Log (xmlEE.Name + xmlEE.InnerText);
				dictItem.Add (xmlEE.Name, xmlEE.InnerText);
			}
			dataList.Add (dictItem);
		}
		
		return dataList;
	}
	
	public List<Dictionary<string, string>> pokemonsDataList
	{
		get
		{
			return _pokemonsDataList;	
		}
	}
	
	public List<Dictionary<string, string>> skillsDataList
	{
		get
		{
			return _skillsDataList;
		}
	}
}
