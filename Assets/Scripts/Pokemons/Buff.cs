using UnityEngine;
using System.Collections;

public enum BuffType
{
	Attack, MagicAttack, Defend, MagicDefend, Speed
}

public class Buff
{
	const int MAX_LV = 6;

	int _level;
	BuffType _buffType;
	Pokemon _attachPokemon;

	public Buff (BuffType bf, Pokemon pokemon)
	{
		_level = 0;
		_buffType = bf;
		_attachPokemon = pokemon;
	}

	public int level
	{
		get
		{
			return _level;
		}
	}

	Pokemon attachPokemon
	{
		get
		{
			return _attachPokemon;
		}

		set
		{
			_attachPokemon = value;
		}
	}

	public void Upgrade ()
	{
		if (_level < MAX_LV)
		{
			_level++;
		}
	}

	public void Degrade ()
	{
		if (_level > -MAX_LV)
			_level--;
	}
}
