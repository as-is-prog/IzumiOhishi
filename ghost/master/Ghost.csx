#r "Rosalind.dll"
#load "SaveData.csx"
#load "Rose_GIPS.csx"
#load "Rose_RandomTalk.csx"
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
    public MyGhost()
    {
        // 更新URL
        Homeurl = "https://raw.githubusercontent.com/as-is-prog/IzumiOhishi/master/";

        // 必ず読み込んでください
        _saveData = SaveDataManager.Load<SaveData>();


        SettingRandomTalk();

        SettingSakuraRecommendSite();
        SettingSakuraPortalSite();

        Resource.ReadmeButtonCaption = () => Util.RandomChoice("ReadMe.Open();");
        Resource.VanishButtonCaption = () => Util.RandomChoice("Delete();");
    }

    private void SettingSakuraRecommendSite()
    {
        Resource.SakuraRecommendButtonCaption = () => "Favorites.ToList();";

        var mobaCinderella = new Site("アイドルマスターシンデレラガールズ", "https://cinderella.idolmaster.jp/");
        SakuraRecommendSites.Add(mobaCinderella);

        var starlightStage = new Site("スターライトステージ", "https://cinderella.idolmaster.jp/sl-stage/");
        SakuraRecommendSites.Add(starlightStage);

        var starlightSpot = new Site("スターライトスポット", "https://cinderella.idolmaster.jp/sl-stage/sl-spot/");
        SakuraRecommendSites.Add(starlightSpot);

        var sepa = new Site("----------------------", "");
        SakuraRecommendSites.Add(sepa);

        var ssp = new Site("SSP", "http://ssp.shillest.net/");
        SakuraRecommendSites.Add(ssp);
    }

    private void SettingSakuraPortalSite()
    {
        Resource.SakuraPortalButtonCaption = () => "Portal.ToList();";

        SakuraPortalSites.Add(new Site("Internet.Search(str);", "https://www.google.co.jp/"));
    }
}

return new MyGhost();