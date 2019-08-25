/*----------------------------------------------------------------------------
Author:
    caodahan@corp.netease.com
Date:
    2019/08/07
Description:
    简介：负责数据库、配置文件、设置、存档等文件的读取和写入，提供序列化和反序列化功能
    作用：方便开发者序列化和反序列化文件
    使用：调用接口即可。需要配合LitJson插件，框架中已存放
    补充：通过调用JsonMapper.ToJson(serialObject); 将object序列化为string
           调用JsonMapper.ToObject<T>(_string); 将string反序列化为T
History:
    TODO：增加更多文件类型的支持
    TODO: 之后要考虑移动平台上的路径位置
    TODO: 通常出于加密要求，正式打包时不会放在streamingAssetsPath下
----------------------------------------------------------------------------*/

using System.IO;    // For StreamWriter, StreamReader FileInfo
using LitJson;
using UnityEngine;

namespace SFramework
{
    /// <summary>
    /// 文件管理者
    /// </summary>
    public class FileMgr : Singleton<FileMgr>
    {
        public SettingData Setting { get; set; }
        private string filePath = Application.persistentDataPath + @"\";

        public FileMgr()
        {
            // 我们设置进入游戏即默认读取设置
            LoadSetting();
        }

        public void SaveSetting()
        {
            if (Setting == null)
                Setting = new SettingData();
            CreateJsonFile("Setting", Setting);
        }

        public void LoadSetting()
        {
            Setting = LoadJsonFile<SettingData>("Setting");
            if (Setting == null)
            {
                Debug.Log("未能找到设置，自动创建");
                SaveSetting();
            }
            else
                Debug.Log("已读取设置");
        }

        /// <summary>
        /// 将对象以JSON序列化保存到文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="serialObject"></param>
        public void CreateJsonFile(string fileName, object serialObject)
        {
            if (File.Exists(filePath + fileName + ".json"))   // 检查存在
            {
                File.Delete(filePath + fileName + ".json");
                Debug.Log(fileName+".json已存在，自动覆盖");
            }
            StreamWriter sw = File.CreateText(filePath + fileName + ".json");  // 如果重名就会创建失败
            sw.Write(SerializeObject(serialObject));
            sw.Close();
        }

        /// <summary>
        /// 从JSON文件读取并反序列化为对象
        /// </summary>
        /// <typeparam fileName="T"></typeparam>
        /// <param fileName="fileName"></param>
        /// <returns></returns>
        public T LoadJsonFile<T>(string fileName)
        {
            if (!File.Exists(filePath + fileName + ".json")) // 检查存在
            {
                Debug.LogError("Json文件不存在");
                return default(T);
            }
            StreamReader sr = File.OpenText(filePath + fileName + ".json");
            string data = sr.ReadToEnd();
            sr.Close();
            if (data.Length > 0)    // 检查非空
                return DeserializeObject<T>(data);
            return default(T);
        }

        /// <summary>
        /// 将对象序列化为string
        /// </summary>
        /// <param fileName="_object"></param>
        /// <returns></returns>
        private string SerializeObject(object serialObject)
        {
            string serializedString = string.Empty;
            serializedString = JsonMapper.ToJson(serialObject);
            return serializedString;
        }

        /// <summary>
        /// 将string反序列化为对象
        /// </summary>
        /// <typeparam fileName="T"></typeparam>
        /// <param fileName="_string"></param>
        /// <returns></returns>
        private T DeserializeObject<T>(string jsonStr)
        {
            T deserializedObject = default(T);  // T的默认值
            deserializedObject = JsonMapper.ToObject<T>(jsonStr);
            return deserializedObject;
        }

    }
}