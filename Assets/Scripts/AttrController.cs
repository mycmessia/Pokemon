using UnityEngine;
using System.Collections;
using System.Xml;

public enum Attr 
{
	None = -1,
	Normal = 0, Fire, Water, Lighting, Grass, Ice, 
	Super = 6, Fight, Poison, Ground, Fly, Bug, 
	Rock = 12, Ghost, Dragon, Evil, Iron, Monster
};

public class AttrController : MonoBehaviour 
{
	public static AttrController instance;

	float[, ] _attrRelationsArray; 
	
	void Awake ()
	{
		instance = this;
	}
	
	void Start ()
	{
		_attrRelationsArray = DataController.instance.LoadFloatArrFromXML ("AttrRelations", 18, 18);
	
//		float result = CheckAttrRelation (Attr.Fire, Attr.Bug, Attr.Grass);		
//		Debug.Log ("attr result " + result);  // 4f
	}
	
	public float CheckAttrRelation (Attr skillAttr, Attr pokemonAttr1, Attr pokemonAttr2)
	{
		int skillAttrIndex = (int) skillAttr;
		int pokemonAttr1Index = (int) pokemonAttr1;
		int pokemonAttr2Index = (int) pokemonAttr2;
		
		float result = _attrRelationsArray[skillAttrIndex, pokemonAttr1Index];
		
		return result * _attrRelationsArray[skillAttrIndex, pokemonAttr2Index];
	}
}
