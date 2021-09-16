using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OBRIOGamesTest.Project.Scripts.Saving
{
    public static class SaveSystem
    {
        public static void SaveData(ResourcesHub resourcesHub)
        {
            var formatter = new BinaryFormatter();
            var path = Application.persistentDataPath + "/resourcesData.save";
            var stream = new FileStream(path, FileMode.Create);

            var data = new ResourcesData
            {
                flourAmount = resourcesHub.flour.Amount,
                breadAmount = resourcesHub.bread.Amount
            };

            formatter.Serialize(stream, data);
            stream.Close();
        }
        
        public static ResourcesData LoadData()
        {
            var path = Application.persistentDataPath + "/resourcesData.save";

            if (File.Exists(path))
            {
                var formatter = new BinaryFormatter();
                var stream = new FileStream(path, FileMode.Open);

                var data = formatter.Deserialize(stream) as ResourcesData;
                stream.Close();
                
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}