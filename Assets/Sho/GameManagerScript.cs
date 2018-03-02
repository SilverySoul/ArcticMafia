using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sho
{
	public class GameManagerScript : MonoBehaviour
	{
		[SerializeField]
		private PenguinManager pmanager;
		[SerializeField]
		private SeaRion searion;
		[SerializeField]
		private PolarBear polar_bear;

		[SerializeField]
		private GameObject[] result = new GameObject[2];

		private AudioSource[] srcs = new AudioSource[2];

		// Use this for initialization
		void Start()
		{
			srcs = this.GetComponentsInChildren<AudioSource>();
		}

		// Update is called once per frame
		void Update()
		{
			if (searion.status.Hp <= 0)
			{
				if (!result[0].activeSelf)
				{
					result[0].SetActive(true);
					srcs[0].Play();
					StartCoroutine(EndGame());
				}
			}
			else
			{
				if (pmanager.PenguinsCountInField <= 0 && polar_bear.Money <= 0)
				{
					if (!result[1].activeSelf)
					{
						result[1].SetActive(true);
						srcs[1].Play();
						StartCoroutine(EndGame());
					}
				}
			}
		}

		private IEnumerator EndGame()
		{
			yield return new WaitForSeconds(5.0f);
			SceneManager.LoadScene(0);
		}
	}
}