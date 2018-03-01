using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sho
{
	public class PolarBear : MonoBehaviour
	{
		[SerializeField]
		private int money = 0;
		public int Money
		{
			get { return money; }
			set
			{
				money = value;
				if (text)
				{
					text.text = value.ToString();
				}
			}
		}
		[SerializeField]
		private Text text = null;

		public PenguinManager.PenguinType CurrentType
		{
			get;
			set;
		}

		[SerializeField, Header("Index is PenguinManager.PenguinType to Int")]
		private int[] penguins_price = new int[2];

		// Use this for initialization
		void Start()
		{
			// Update Text
			Money = Money;
		}

		// Update is called once per frame
		void Update()
		{

		}

		/// <summary>
		/// Check the money to be able to Buy Current Type Penguin.
		/// This Function only check . It will not change Money
		/// </summary>
		/// <returns>if you can ,return true.otherwise return false</returns>
		public bool CheckCanBuyPenguin()
		{
			if (Money < penguins_price[(int)CurrentType]) return false;
			return true;
		}
		public PenguinManager.PenguinType BuyPenguin()
		{
			if(!CheckCanBuyPenguin())
			{
				Debug.Assert(false, "Plz Call CheckCanBuyPenguin before you call this func");
			}
			Money -= penguins_price[(int)CurrentType];
			return CurrentType;
		}

		private void OnTriggerEnter(Collider other)
		{
			if(other.tag == "Penguin")
			{
				var p = other.GetComponent<Penguin>();
				if(p.Type == PenguinManager.PenguinType.Gold)
				{
					var gp = p.gameObject.GetComponent<TakeGoldBehavior>();
					if(gp.IsCarringGold)
					{
						Money += gp.GoldCount;
						gp.IsCarringGold = false;
						var nnn = gp.GetComponentInChildren<GoldBehavior>();
						if (nnn)
						{
							Destroy(gp.GetComponentInChildren<GoldBehavior>().gameObject);
						}
					}
				}
			}
		}
	}
}