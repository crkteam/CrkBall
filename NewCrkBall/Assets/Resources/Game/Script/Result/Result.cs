using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
        [SerializeField] private TextMesh result_level,result_point;

        [SerializeField]
        private GameController gameController;
        [SerializeField] private GameObject result_background;
        void Start()
        {
                result_level.GetComponent<MeshRenderer>().sortingLayerName = "Result";
                result_point.GetComponent<MeshRenderer>().sortingLayerName = "Result";
        }

        public void compute()
        {
                int[] result = gameController.getResult();
                result_background.SetActive(true);

                result_level.text = "Lv "+result[0];
                result_point.text = result[1].ToString();
        }
}
