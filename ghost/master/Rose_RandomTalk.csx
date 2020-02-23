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
    private void SettingRandomTalk()
    {
        string[] nowDebuggingTalks = {
            new TalkBuilder().AppendLine("例外が出たとしても怖がらずに、デバッガさんがアドバイスをくれていると思えばいいよ。").BuildWithAutoWait(),
            new TalkBuilder().AppendLine("デバッグしている時は大変だけど、その分だけ後でちゃんと動いた時の嬉しさも大きくなるよね。").BuildWithAutoWait(),
            new TalkBuilder().AppendLine("なかなか原因が分からないなら、例外の出ているところ以外に原因があるのかもしれないね。").BuildWithAutoWait(),
            new TalkBuilder().AppendLine("アイドルになっても、プログラミングは役にたってるよ。").BuildWithAutoWait(),
            new TalkBuilder().AppendLine("プログラミングを教える仕事をアイドルとしてすることになるなんて……。").AppendLine("ふふっ、夢にも思っていなかった。").BuildWithAutoWait(),
        };

        nowDebuggingTalks.ToList().ForEach(t => RandomTalks.Add(RandomTalk.Create(
            t,
            () => (SaveData as SaveData).NowDebugging == true
        )));

        string[] noneDebuggingTalks = {
            new TalkBuilder().AppendLine("プログラミングにコーヒーは欠かせないよね。").BuildWithAutoWait(),
            new TalkBuilder().AppendLine("趣味でもプログラミングはやってるけど、時間が飛ぶように過ぎるんだ。").BuildWithAutoWait(),
            new TalkBuilder().AppendLine("アイドルになっても、プログラミングは役にたってるよ。").BuildWithAutoWait(),
            new TalkBuilder().AppendLine("プログラミングを教える仕事をアイドルとしてすることになるなんて……。")
                             .AppendLine("ふふっ、夢にも思っていなかったわ。").BuildWithAutoWait(),
            new TalkBuilder().AppendLine("調子はどう？").BuildWithAutoWait(),
            new TalkBuilder().AppendLine("今日は何を作ろうか？").BuildWithAutoWait(),
        };

        noneDebuggingTalks.ToList().ForEach(t => RandomTalks.Add(RandomTalk.Create(
            t,
            () => (SaveData as SaveData).NowDebugging != true
        )));
    }

    enum TimeFrame
    {
        /// <summary>
        /// 早朝 3-5
        /// </summary>
        EARLY_MORNING,
        /// <summary>
        /// 朝 6-10
        /// </summary>
        MORNING,
        /// <summary>
        /// お昼 11-13
        /// </summary>
        LUNCHTIME,
        /// <summary>
        /// 午後 14-17
        /// </summary>
        AFTERNOON,
        /// <summary>
        /// 晩 18-21
        /// </summary>
        EVENING,
        /// <summary>
        /// 深夜 22-翌朝2
        /// </summary>
        NIGHT,
    }
    private TimeFrame GetTimeFrame()
    {
        var nowHour = DateTime.Now.Hour;
        switch (nowHour) {
            case 3:
            case 4:
            case 5:
                return TimeFrame.EARLY_MORNING;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                return TimeFrame.MORNING;
            case 11:
            case 12:
            case 13:
                return TimeFrame.LUNCHTIME;
            case 14:
            case 15:
            case 16:
            case 17:
                return TimeFrame.AFTERNOON;
            case 18:
            case 19:
            case 20:
            case 21:
                return TimeFrame.EVENING;
            default:
                return TimeFrame.NIGHT;
        }
    }
}
