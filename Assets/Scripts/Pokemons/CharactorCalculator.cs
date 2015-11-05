using UnityEngine;
using System.Collections;

public enum Charactor
{
	Hardy = 0,	Lonely,	Brave,	Adamant, Naughty,	Bold,  Docile, Relaxed, impish,
	Lax = 9, 	Timid,	Hasty,	Serious, Jolly,	 	Naive, Modest, Mild, Quiet, Shy,
	Rash = 19,	Calm,	Gentle,	Sassy,	 Careful,	Quirky						
}

public class CharactorCalculator : MonoBehaviour {

	public static CharactorCalculator instance;
	
	float[, ] _charactorsArray; 
	
	void Awake ()
	{
		instance = this;
	}
	
	void Start ()
	{
		_charactorsArray = DataController.instance.LoadFloatArrFromXML ("PokemonCharactors", 25, 5);
	}
	
	public float GetCharactorRatio (Charactor ch, PokeValue pv)
	{
		return _charactorsArray[(int)ch, (int)pv];
	}
	
	public void CharactorRevise (Pokemon pokemon)
	{
		pokemon.attack *= GetCharactorRatio (pokemon.charactor, PokeValue.Attack);
		pokemon.magicAttack *= GetCharactorRatio (pokemon.charactor, PokeValue.MagicAttack);
		pokemon.defend *= GetCharactorRatio (pokemon.charactor, PokeValue.Defend);
		pokemon.magicDefend *= GetCharactorRatio (pokemon.charactor, PokeValue.MagicDefend);
		pokemon.attack *= GetCharactorRatio (pokemon.charactor, PokeValue.Attack);
	}
}
