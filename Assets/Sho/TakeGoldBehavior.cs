using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class TakeGoldBehavior : Internal.PenguinBehavior
	{
        public AudioBearScript SoundScript;
		private bool is_carring_gold = false;
		public bool IsCarringGold
		{
			get { return is_carring_gold; }
			set
			{
				is_carring_gold = value;
				if(value)
				{
					StopCoroutine(SearchGold);
					Target = GameObject.Find("PolarBear");
				}
				else
				{
					SearchGold = StartCoroutine(SearchGoldNearByMe());
				}
			}
		}
		public int GoldCount { get; set; }

		private GoldManager Manager { get; set; }

		private Coroutine SearchGold { get; set; }

		// Use this for initialization
		void Start()
		{
			Manager = GameObject.Find("GoldManager").GetComponent<GoldManager>();
			SearchGold = StartCoroutine(SearchGoldNearByMe());
			Parent.Type = PenguinManager.PenguinType.Gold;
		}

		// Update is called once per frame
		void Update()
		{
			if(IsCarringGold)
			{
				Agent.destination = Target.transform.position;
			}
		}

		public void TakeGold(int gold)
		{
            GoldCount += gold;
			IsCarringGold = true;
		}


		public IEnumerator SearchGoldNearByMe()
		{
			while (true)
			{
				var g = Manager.SearchNearGold(this.transform.position);
				if (!Manager.IsInValidValue(g))
				{
					Agent.destination = g;
				}
				yield return new WaitForSeconds(Storage.SearchGoldSpan);
			}
		}
	}
}