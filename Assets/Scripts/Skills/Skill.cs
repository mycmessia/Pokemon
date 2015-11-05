using UnityEngine;
using System.Collections;
using System.Collections.Generic;			// for List Dictionary

public enum SkillType
{
	None,
	SkillDamage
}

public enum SkillCategory 
{
	None,
	Magic,
	Physical
}

public class Skill 
{
	protected int _id;
	protected int _index;
	protected string _name;
	protected string _des;
	protected Attr _attr;
	protected SkillCategory _category;
	protected float _power;
	protected float _hit;
	protected int _PP;
	protected int _curPP;
	protected int _preLv;
	protected int _curTurn;
	
//	public static Skill Create (SkillType skt, int skillIndex)
//	{
//		switch (skt)
//		{
//			case SkillType.SkillDamage:
//			return new SkillDamage (skillIndex);
//		}
//		
//		// return new SkillEmpty;
//	}
	
	public virtual void Use (Pokemon self, Pokemon target)
	{
		
	}
	
	public int id { get { return _id; } }
	
	public int index { get { return _index; } }

	public string name { get { return _name; } }
	
	public string des { get { return _des; } }
	
	public Attr attr { get { return _attr; } }
	
	public SkillCategory category { get { return _category; } }
	
	public float power { get { return _power; } }
	
	public float hit { get { return _hit; } }
	
	public int PP { get { return _PP; } }
	
	public int curPP { get { return _curPP; } set { if (value >= 0) _curPP = value; } }
	
	public int preLv { get { return _preLv; } }
}
