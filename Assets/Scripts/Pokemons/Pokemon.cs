using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PokeValue
{
	Attack, MagicAttack, Defend, MagicDefend, Speed, HP
}

public class Pokemon 
{
	int _id;
	int _index;
	
	string _nameC;
	public string nameC { get { return _nameC; } set { _nameC = value; }}
	string _nameE;
	public string nameE { get { return _nameE; } set { _nameE = value; }}
	
	Attr _attr1;
	Attr _attr2;
	
	int _lv;
	
	Charactor _charactor;
	public Charactor charactor { get { return _charactor; } }
	
	const int POKEMON_VALUE_COUNTS = 6; 
	float[] _valueArr = new float[POKEMON_VALUE_COUNTS];
	public float attack 
	{ 
		get { return _valueArr[0]; } 
		set { if (value >= 0f ) { _valueArr[0] = value; } else { _valueArr[0] = 0f; } } 
	}
	public float magicAttack 
	{ 
		get { return _valueArr[1]; } 
		set { if (value >= 0f ) { _valueArr[1] = value; } else { _valueArr[1] = 0f; } } 
	}
	public float defend 
	{
		get { return _valueArr[2]; } 
		set { if (value >= 0f ) { _valueArr[2] = value; } else { _valueArr[2] = 0f; } } 
	}
	public float magicDefend 
	{ 
		get { return _valueArr[3]; } 
		set { if (value >= 0f ) { _valueArr[3] = value; } else { _valueArr[3] = 0f; } } 
	}
	public float speed 
	{ 
		get { return _valueArr[4]; } 
		set { if (value >= 0f ) { _valueArr[4] = value; } else { _valueArr[4] = 0f; } } 
	}
	
	float _HP;
	public float HP 
	{ 
		get { return _HP; } 
		set { if (value >= 0f ) { _HP = value; } else { _HP = 0f; } } 
	}
	float _curHP;
	public float curHP 
	{ 
		get { return _curHP; } 
		set { if (value >= 0f ) { _curHP = value; } else { _curHP = 0f; } } 
	}
	
	Buff _attackBuff;
	Buff _magicAttackBuff;
	Buff _defendBuff;
	Buff _magicDefendBuff;
	Buff _speedBuff;
	
	public Buff attackBuff { get { return _attackBuff; } set { _attackBuff = value; } }
	public Buff magicAttackBuff { get { return _magicAttackBuff; } set { _magicAttackBuff = value; } }
	public Buff defendBuff { get { return _defendBuff; } set { _defendBuff = value; } }
	public Buff magicDefendBuff { get { return _magicDefendBuff; } set { _magicDefendBuff = value; } }
	public Buff speedBuff { get { return _speedBuff; } set { _speedBuff = value; } }
	
	Skill _skill1;
	Skill _skill2;
	Skill _skill3;
	Skill _skill4;
	
	public Skill skill1 { get { return _skill1; } set { _skill1 = value; } }
	public Skill skill2 { get { return _skill2; } set { _skill2 = value; } }
	public Skill skill3 { get { return _skill3; } set { _skill3 = value; } }
	public Skill skill4 { get { return _skill4; } set { _skill4 = value; } }
	
	public List<State> stateList = new List<State> ();
	
	public List<int> canLearnSkillList = new List<int> ();
	
	private GameObject _go;
	public GameObject go { get { return _go; } set { _go = value; } }
	
	private string _generation;
	public string generation { get { return _generation; } set { _generation = value; }} 
	
	public Pokemon (int index)
	{
		Dictionary<string, string> dict = DataController.instance.pokemonsDataList[index - 1];
	
		_id = IDController.id;
		_nameC = dict["nameC"];
		_nameE = dict["nameE"];
		
		_lv = 100;
		
		_charactor = Charactor.Hardy;
		
		_attr1 = (Attr) int.Parse (dict["attr1"]);
		_attr2 = (Attr) int.Parse (dict["attr2"]);
		
		attack = CalcADSValue (dict, "attackRV");
		magicAttack = CalcADSValue (dict, "magicAttackRV");
		defend = CalcADSValue (dict, "defendRV");
		magicDefend = CalcADSValue (dict, "magicDefendRV");
		speed = CalcADSValue (dict, "speedRV");
		
		CharactorCalculator.instance.CharactorRevise (this);
		
		HP = CalcHPValue (dict);
		curHP = HP;
		
		_attackBuff = new Buff (BuffType.Attack, this);
		_magicAttackBuff = new Buff (BuffType.MagicAttack, this);
		_defendBuff = new Buff (BuffType.Defend, this);
		_magicDefendBuff = new Buff (BuffType.MagicDefend, this);
		_speedBuff = new Buff (BuffType.Speed, this);
		
		_skill1 = SkillGenerator.Create ();
		_skill2 = SkillGenerator.Create ();
		_skill3 = SkillGenerator.Create ();
		_skill4 = SkillGenerator.Create ();
		
		string[] skillIndex = dict["canLearnSkillsList"].Split (',');
		for (int i = 0; i < skillIndex.Length; i++)
		{
			canLearnSkillList.Add (int.Parse (skillIndex[i]));
		}
		
		_generation = dict["generation"];
	}
	
	float CalcHPValue (Dictionary<string, string> dict)
	{
		// (种族值 * 2 + 天赋 + (努力值 / 4)) * Lv / 100 + 10 + Lv 
		return (float.Parse (dict["hpRV"]) * 2f + 31f + (256f / 4f)) * _lv / 100f + 10f + _lv;
	}
	
	float CalcADSValue (Dictionary<string, string> dict, string valueName)
	{
		// ((种族值 * 2 + 天赋 + (努力值 / 4)) * Lv / 100 + 5) * 性格修正 (after all assignment)
		return ((float.Parse (dict[valueName]) * 2f + 31f + (256f / 4f)) * _lv / 100f + 5);
	}
	
	void Attack (Skill skill, Pokemon target)
	{
		skill.Use (this, target);
	}
}