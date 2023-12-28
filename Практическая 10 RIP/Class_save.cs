using Newtonsoft.Json;

namespace Пятёрочка
{
    internal class Class_save
    {
        static public string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void Serialize<T>(T workers, string file)
        {
            string json = JsonConvert.SerializeObject(workers);
            File.WriteAllText(path + "\\" + file, json);
        }

        public static T Deserialize<T>(string file)
        {
            string json = File.ReadAllText(path + "\\" + file);
            T workers = JsonConvert.DeserializeObject<T>(json);

            return workers;
        }
    }
}