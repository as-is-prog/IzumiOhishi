#r "Rosalind.dll"
#load "SaveData.csx"
using Shiorose;
using Shiorose.Resource;
using Shiorose.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class MyGhost : Ghost
{
    public override string OnBoot(IDictionary<int, string> references, string shellName = "", bool isHalt = false, string haltGhostName = "")
    {
        // ランダムに何か返したいときはUtil.RandomChoiceを使う
        // この場合何を飲むか聞いてくれる場合とただ挨拶するだけの場合がランダムで返される
        return Util.RandomChoice(
            () => new TalkBuilder().Append("今日もよろしくね。").BuildWithAutoWait()
        );
    }

    public override string OnFirstBoot(IDictionary<int, string> reference, int vanishCount = 0)
    {
        return new TalkBuilder().Append("お手伝いをさせてもらう大石泉です。よろしくね。").BuildWithAutoWait();
    }

    public override string OnClose(IDictionary<int, string> reference, string reason = "")
    {
        return new TalkBuilder().Append("お疲れさま。").BuildWithAutoWait();
    }
}