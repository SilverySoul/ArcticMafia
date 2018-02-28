using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class SeaRionStats : MonoBehaviour
	{
		[SerializeField]
		int hp = 0;
		public int Hp
		{
			get
			{
				return hp;
			}
			private set
			{
				hp = value;
			}
		}



		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}