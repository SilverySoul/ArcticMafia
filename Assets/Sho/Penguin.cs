using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{

	public class Penguin : MonoBehaviour , StatusBehavior
	{
		// unique
		[SerializeField]
		private int id = -1;
		public int ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		[SerializeField]
		private Status status = new Status();

		public float Speed 
		{ 
			get { return status.Speed; }
		}
		public int AttackPower
		{
			get { return status.AttackPower; }
		}

		private PenguinManager manager { get; set; }

		public PenguinManager.PenguinType Type { get; set; }

		// Use this for initialization
		void Start()
		{
			manager = GameObject.Find("PenguinManager").GetComponent<PenguinManager>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		public bool Damage(int damage)
		{
			status.Hp -= damage;
			if(status.Hp <= 0)
			{
				Debug.Log("Killed Penguin No." + ID.ToString());
				Destroy(this.gameObject);
				manager.DeadPenguin(this);
				return true;
			}
			return false;
		}

		public void AddExp(int exp)
		{
			
		}
	}
}