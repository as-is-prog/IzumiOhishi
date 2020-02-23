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
    public override string OnCommunicate(IDictionary<int, string> reference, string senderName = "", string script = "", IEnumerable<string> extInfo = null)
    {
        if (senderName == "user")
        {
            if (script.Contains("こんにちは"))
                return new TalkBuilder().Append("こんにちは、").Append(SaveData.UserName).BuildWithAutoWait();
            if (script.Contains("おはよう"))
                return new TalkBuilder().Append("おはようございます、").Append(SaveData.UserName).BuildWithAutoWait();
            if (script.Contains("こんばんは"))
                return new TalkBuilder().Append("こんばんは、").Append(SaveData.UserName).BuildWithAutoWait();

            return new TalkBuilder().Append(SaveData.UserName).Append("、何か言いましたか？").BuildWithAutoWait();
        }
        else
        {
            if (script.Contains("こんにちは"))
                return new TalkBuilder().Append("こんにちは、").Append(senderName).BuildWithAutoWait();
            if (script.Contains("おはよう"))
                return new TalkBuilder().Append("おはようございます、").Append(senderName).BuildWithAutoWait();
            if (script.Contains("こんばんは"))
                return new TalkBuilder().Append("こんばんは、").Append(senderName).BuildWithAutoWait();

            return "";
        }
    }
}
