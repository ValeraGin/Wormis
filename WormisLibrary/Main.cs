using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wormis
{
    public class utils
    {
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
    }

    [Serializable]
    public class ResultByOne
    {
        public int position;
        public string name;
        public int finalMass;
        public int maxMass;

        public int GetPTS()
        {
            switch (position)
            {
                case 1: return 20;
                case 2: return 15;
                case 3: return 10;
                default:
                    if (position < 11)
                        return 11 - position;
                    else
                        return 1;
            }
        }

        public int GetMoney()
        {
            switch (position)
            {
                case 1: return 4000;
                case 2: return 2000;
                case 3: return 1000;
                default: return 0;
            }
        }

        public bool GetCoupon()
        {
            if (3 < position & position < 11)
                return true;
            else
                return false;
        }

        public ResultByOne(int position, string name, int finalMass, int maxMass)
        {
            this.position = position;
            this.name = name;
            this.finalMass = finalMass;
            this.maxMass = maxMass;
        }
    }
    [Serializable]
    public class Tournament : List<ResultByOne>
    {
        public int number;
        public Tournament(int number)
        {
            this.number = number;
        }
    }

    [Serializable]
    public class Tournaments : List<Tournament>
    {
        public string user;
        public int minIndex, maxIndex;
        public DateTime time;
    }
}
