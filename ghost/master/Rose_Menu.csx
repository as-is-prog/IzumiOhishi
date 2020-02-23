#r "Rosalind.dll"
#load "SaveData.csx"
using Shiorose;
using Shiorose.Resource;
using Shiorose.Resource.ShioriEvent;
using Shiorose.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class MyGhost : Ghost
{
    public override string OnMouseDoubleClick(IDictionary<int, string> reference, string mouseX, string mouseY, string charId, string partsName, string buttonName, DeviceType deviceType)
    {
        switch (partsName)
        {
            default:
                return OnRandomTalk();
        }
    }

    private string OpenMenu()
    {
        const string RAND = "ランダムトーク";
        const string COMMUNICATE = "話しかける";
        const string INPUT_NAME = "名前を教える";
        const string CANCEL = "キャンセル";

        return new TalkBuilder().AppendLine("メニューです。")
                                .LineFeed()
                                .HalfLine()
                                .Marker().AppendChoice(RAND).LineFeed()
                                .Marker().AppendChoice(COMMUNICATE).LineFeed()
                                .Marker().AppendChoice(INPUT_NAME).LineFeed()
                                .Marker().AppendChoice(CANCEL)
                                .BuildWithAutoWait()
                                .ContinueWith((id) =>
                                {
                                    switch (id)
                                    {
                                        case RAND:
                                            return OnRandomTalk();
                                        case COMMUNICATE:
                                            return new TalkBuilder().Append("なんですか？").AppendCommunicate().Build();
                                        case INPUT_NAME:
                                            return new TalkBuilder().Append("ここに入力してください。")
                                                                    .AppendUserInput()
                                                                    .Build()
                                                                    .ContinueWith((name) => {
                                                                        SaveData.UserName = name;
                                                                        return new TalkBuilder().Append(name).Append("ですね、覚えました。").BuildWithAutoWait();
                                                                    });
                                        default:
                                            return new TalkBuilder().Append("キャンセルしました。").BuildWithAutoWait();
                                    }
                                });
    }
}
