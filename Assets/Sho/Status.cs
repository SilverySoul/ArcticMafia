using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	[System.Serializable]
	public class Status
	{
		[SerializeField]
		private int hp = 0;
		public int Hp
		{
			get { return hp; }
			set { hp = value; }
		}

		[SerializeField]
		private float speed = 1.0f;
		public float Speed
		{
			get { return speed; }
			set { speed = value; }
		}

		[SerializeField]
		private int attack_power = 1;
		public int AttackPower
		{
			get { return attack_power; }
			set { attack_power = value; }
		}

		[SerializeField]
		private int defence_power = 1;
		public int DefencePower
		{
			get { return defence_power; }
			set { defence_power = value; }
		}

		// amount of experience which can get when kill this object
		[SerializeField]
		private int exp = 10;
		public int Exp
		{
			get { return exp; }
			set { exp = value; }
		}

		[SerializeField]
		private float angular = 30.0f;
		public float Angular
		{
			get { return angular; }
		}
	}

	public interface StatusBehavior
	{
		/// <summary>
		/// Add Damage
		/// </summary>
		/// <param name="damage"></param>
		/// <returns>if after get damage,the unit dead,return true else return false</returns>
		bool Damage(int damage);

		void AddExp(int exp);
	}
}