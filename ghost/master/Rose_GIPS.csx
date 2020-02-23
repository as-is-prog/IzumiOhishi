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
    HashSet<string> ExceptionHashSet = new HashSet<string>();

    bool DebugSuccessful = true;

    int debugTryCount = 0;

    public string OnGIPSStart(IDictionary<int, string> reference)
    {
        return new TalkBuilder().AppendLine("【OnGIPSStart】")
                                .AppendLine(reference[0])
                                .AppendLine(reference[1])
                                .AppendLine(reference[2])
                                .AppendLine(reference[3])
                                .AppendLine(reference[4])
                                .AppendLine(reference[5]).Build();
    }

    public string OnGIPSExceptionOccurred(IDictionary<int, string> reference)
    {
        DebugSuccessful = false;

        reference.TryGetValue(0, out var lang);
        reference.TryGetValue(1, out var className);
        reference.TryGetValue(2, out var fileName);
        reference.TryGetValue(3, out var rowNum);
        reference.TryGetValue(4, out var advice);

        var isKnown = ExceptionHashSet.Contains(className);

        return isKnown
            ? OnIsKnownExceptionOccurred(lang, className, fileName, rowNum, advice)
            : OnIsUnKnownExceptionOccurred(lang, className, fileName, rowNum, advice);
    }

    private string OnIsKnownExceptionOccurred(string lang, string className, string fileName, string rowNum, string advice)
    {
        return new TalkBuilder().Append(fileName).Append("の").Append(rowNum).AppendLine("行目で")
                                .Append(className).AppendLine("が発生したみたい。")
                                .AppendLine(Util.RandomChoice("またしても"+className+"ね……。"))
                                .BuildWithAutoWait();
    }

    private string OnIsUnKnownExceptionOccurred(string lang, string className, string fileName, string rowNum, string advice)
    {
        ExceptionHashSet.Add(className);

        const string SEARCH = "検索する";
        const string CANCEL = "キャンセル";

        return new TalkBuilder().Append(fileName).Append("の").Append(rowNum).AppendLine("行目で")
                                .Append(className).AppendLine("が発生したみたい。")
                                .LineFeed()
                                .HalfLine()
                                .Marker().AppendChoice(SEARCH).LineFeed()
                                .Marker().AppendChoice(CANCEL)
                                .BuildWithAutoWait()
                                .ContinueWith((id) =>
                                {
                                    switch (id)
                                    {
                                        case SEARCH:
                                            return new TalkBuilder()
                                                    .EmbedValue("\\![open,browser,https://www.google.co.jp/search?q="+className+"]").Build();
                                        default:
                                            return new TalkBuilder().Build();
                                    }
                                });
    }

    public string OnGIPSStateChangeToDesign(IDictionary<int, string> reference)
    {
        var talkBuilder = new TalkBuilder();

        var oldNowDebugging = false;

        if (SaveData is SaveData saveData)
        {
            oldNowDebugging = saveData.NowDebugging;

            saveData.NowDebugging = !DebugSuccessful;
        }

        if (DebugSuccessful && oldNowDebugging == false)
            return talkBuilder.Build();

        return DebugSuccessful
                    ? talkBuilder.AppendLine("無事実行できたね。おめでとう。")
                                 .BuildWithAutoWait()
                    : talkBuilder.AppendLine("残念……。ちょっと落ち着いて考えてみようか。")
                                 .BuildWithAutoWait();
    }

    public string OnGIPSStateChangeToBreak(IDictionary<int, string> reference)
    {
        return new TalkBuilder()//.AppendLine("【OnGIPSStateChangeToBreak】")
                                .Build();
    }

    public string OnGIPSStateChangeToRun(IDictionary<int, string> reference)
    {
        DebugSuccessful = true;

        return new TalkBuilder()//.AppendLine("【OnGIPSStateChangeToRun】")
                                .Build();
    }
}
