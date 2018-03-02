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
		private GameObject[] penguins = new GameObject[3];

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
			switch (type)
			{
				case PenguinManager.PenguinType.Json:
					penguins[0].SetActive(true);
					penguins[1].SetActive(false);
					penguins[2].SetActive(false);
					break;
				case PenguinManager.PenguinType.Gun:
					penguins[0].SetActive(false);
					penguins[1].SetActive(true);
					penguins[2].SetActive(false);
					break;
				case PenguinManager.PenguinType.Gold:
					penguins[0].SetActive(false);
					penguins[1].SetActive(false);
					penguins[2].SetActive(true);
					break;
				default:
					break;
			}
			Bear.CurrentType = type;
		}
	}
}