using System;
using System.Collections;
using OBRIOGamesTest.Project.Scripts.Saving;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace OBRIOGamesTest.Project.Scripts
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private Resource resourceProduced;
        
        [SerializeField] private Resource resourceRequired;
        [SerializeField] private int quantityRequired;
        
        [SerializeField] private MessagePanel messagePanel;
        
        [SerializeField] private ProgressBar progressBar;
        
        [SerializeField] private ResourcesHub resourcesHub;

        [SerializeField] private UnityEvent onProduce;

        private bool producing;

        public void Reset()
        {
            resourceProduced.Amount = 0;
        }
        
        public void Produce()
        {
            if (producing)
            {
                messagePanel.ShowMessage("Завод ещё занят!");
            }
            else
            {
                if (resourceRequired != null)
                {
                    if (resourceRequired.Amount >= quantityRequired)
                    {
                        producing = true;
                        onProduce.Invoke();
                        resourceRequired.Amount -= quantityRequired;
                        progressBar.FillProgressBar();
                    }
                    else
                    {
                        messagePanel.ShowMessage("Слишком мало требуемого ресурса! Нужно " + quantityRequired + ".");
                    }
                }
                else
                {
                    producing = true;
                    progressBar.FillProgressBar();
                }
            }
        }

        public void AddResource()
        {
            resourceProduced.Amount++;
            producing = false;
        }
    }
}