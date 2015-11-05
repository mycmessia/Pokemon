using UnityEngine;
using System.Collections;

public class StatePoison : State {

	const float LOSS_HP_PERCENT_EACH_TURN = 0.1f;

	bool Use (Pokemon pokemon)
	{
		pokemon.curHP -= pokemon.HP * LOSS_HP_PERCENT_EACH_TURN;
		
		return true;
	}
}
