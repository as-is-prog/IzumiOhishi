#r "Rosalind.dll"
using Shiorose;
using Shiorose.Resource;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[DataContract]
public class SaveData : BaseSaveData {
    /* BaseSaveDataで定義済み */
    // int TalkInterval => ランダムトークの間隔
    // string UserName => ユーザ名

    // 項目追加したい場合の定義はこんな感じ
    // [DataMember]
    // public string TestData { get; set; }

    /// <summary>
    /// デバッグ中か（ハンドリングしていない例外でデバッグ実行が終了しているか）
    /// </summary>
    public bool NowDebugging { get; set; }

    /// <summary>
    /// デフォルト値はここで設定
    /// ただしsavedataのファイルがある際は初期化されないので、
    /// 後からメンバを増やした際は注意！！
    /// </summary>
    public SaveData()
    {
        UserName = "";
        TalkInterval = 180;
    }
}

// SaveFileの名前を変えたい場合
// SaveDataManager.SaveFileName = "save.json";