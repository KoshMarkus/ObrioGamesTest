using System;
using OBRIOGamesTest.Project.Scripts.Saving;
using UnityEngine;

namespace OBRIOGamesTest.Project.Scripts.Managers
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private ResourcesHub resourcesHub;
        
        public static SaveManager Instance;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            ResourcesData resourcesData = SaveSystem.LoadData();

            resourcesHub.flour.Amount = resourcesData.flourAmount;
            resourcesHub.bread.Amount = resourcesData.breadAmount;
        }

        private void OnApplicationQuit()
        {
            SaveSystem.SaveData(resourcesHub);
        }
    }
}