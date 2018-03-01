using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sho
{
	public class ModeChanger : MonoBehaviour
	{
		[SerializeField]
		List<ModeChanger> other_buttons = new List<ModeChanger>();

		private Button button = null;
		public Button Buttons
		{
			get { return button; }
		}

		[SerializeField]
		private Text mode_text;

		[SerializeField]
		private PenguinManager.PenguinType type;


		private PolarBear Bear { get; set; }
		// Use this for initialization
		void Start()
		{
			button = this.GetComponent<Button>();
			Bear = GameObject.Find("PolarBear").GetComponent<PolarBear>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void OnClick()
		{
			foreach (var item in other_buttons)
			{
				break;
			}
			if (mode_text)
			{
				switch (type)
				{
					case PenguinManager.PenguinType.Json:
						mode_text.text = "Json Mode";
						break;
					case PenguinManager.PenguinType.Gun:
						mode_text.text = "Gun Mode";
						break;
					case PenguinManager.PenguinType.Gold:
						mode_text.text = "Gold Mode";
						break;
					default:
						break;
				}
			}
			Bear.CurrentType = type;
		}
	}
}