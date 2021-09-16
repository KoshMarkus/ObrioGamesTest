using OBRIOGamesTest.Project.Scripts.Saving;
using UnityEngine;
using TMPro;

namespace OBRIOGamesTest.Project.Scripts
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private GameObject counter;
        private GameObject Counter => counter;
        
        [SerializeField] private int amount;
        public int Amount 
        { 
            get => amount;
            set
            {
                var oldAmount = amount;
                var color = new Color();

                amount = value;

                if (amount > oldAmount)
                {
                    color = Color.green;
                }
                else if(amount < oldAmount)
                {
                    color = Color.red;
                }
                else
                {
                    color = Color.white;
                }
                
                Counter.GetComponent<TextMeshProUGUI>().text = amount.ToString();
                Counter.GetComponent<Counter>().TextColorJump(Counter.transform, 1, color);
            }
        }
        
        
    }
}