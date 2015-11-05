using UnityEngine;
using System.Collections;

public class State {
	
	int _duringTurn = 0;
	
	public int duringTurn 
	{
		get
		{
			return _duringTurn;
		}
		set
		{
			_duringTurn = value;
		}
	}
	
}
