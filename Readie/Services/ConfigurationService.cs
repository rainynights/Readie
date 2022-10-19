using Newtonsoft.Json;
using Readie.MVVM.Model;

namespace Readie.Services;

public static class ConfigurationService
{
    private static ConfigurationData _configurationData;

    public static ConfigurationData ConfigurationData => _configurationData ??= LoadConfiguration().Result;

    private static async Task<ConfigurationData> LoadConfiguration()
    {
        string jsonString = await SecureStorage.Default.GetAsync("ConfigurationData");

        return !string.IsNullOrEmpty(jsonString) 
            ? JsonConvert.DeserializeObject<ConfigurationData>(jsonString) 
            : new ConfigurationData()
            {
                Texts = new Text[] { new Text { Pages = new string[] { "Bir zamanlar biz de millet, hem nasıl milletmişiz:\r\n\r\nGelmişiz, dünyaya milliyet nedir öğretmişiz!\r\n\r\nKapkaranlıkkken bütün afakı insaniyyetin,\r\n\r\nNur olup fışkırmışız tâ sinesinden zulmetin,\r\n\r\nYarmışız edvâr-ı fetretten kalan yeldaları;\r\n\r\nFikr-i ferda doğmadan yağdırmışız ferdaları!\r\n\r\nÖyle ferdalar ki: Kaldırmış serapa alemi;\r\n\r\nDideler bir cavidani fecrin olmuş mahremi.\r\n\r\nYirmi beş yıl, yirmi beş bin yıl kadar feyyaz imiş!\r\n\r\nBak ne ani bir tekamül! Bak ki: Hala mündehiş\r\n\r\nYad-ı fevka’l-ı i’tiyadından onun tarihler;\r\n\r\nGörmemiş benzer o müdhiş seyre, hem görmez beşer,\r\n\r\nBir taraftan dinimiz, ahlakımız, irfanımız;\r\n\r\nBir taraftan seyfe makrun adlimiz, ihsanımız;\r\n\r\nYükselip akvamı almış fevc fevc ağuşuna;\r\n\r\nHepsi dalmış vahdetin aheng-i cuşucuşuna,\r\n\r\nEmr-i bi?l ma?ruf imiş ihvan-ı İslam?ın işi;\r\n\r\nNehy edermiş, bir fenalık görse, kardeş kardeşi.\r\n\r\nKimse haksızlıktan etmezmiş tegafül ihtiyar;\r\n\r\nFerde raci’ sadmeden efrad olurmuş lerzedar.\r\n\r\nBiz, neyiz? Seyreyle artık; bir de fikr et, neymişiz?\r\n\r\nDin de kürkün aynı olmuş: Ters çevirmiş giymişiz!\r\n\r\nNehy-i ma’rûf emr-i münkerdir gezen meydanda bak!\r\n\r\nEn metîn ahlâkımız, yâhud, görüp aldırmamak!\r\n\r\nYıktı bin mel´un kalem nâmûsu, bizler uymadık:\r\n\r\n“Susmak evlâdır´” deyip sustuk… Sanırsın duymadık!\r\n\r\nKustu bin murdar ağız şer´in bütün ahkâmına;\r\n\r\nÂh, bir ses bâri yükselseydi nefret nâmına!\r\n\r\nAltı yüz bin can gider; milyonla îmân eksilir;\r\n\r\nKimseler görmez! Gören sersem de Allah´tan bilir!\r\n\r\nSonra, şâyet,sahsının incinse, hattâ, bir tüyü:\r\n\r\nYer yıkılmış zanneder seyr eyleyen gümbürtüyü!\r\n\r\nKırkın aylıktan biraz, yâhud geciksin vermeyin;\r\n\r\nFodla çiy kalsın, ´pilâv bitmiş” deyin, göstermeyin,\r\n\r\nFes, külâh, kalpak, sarık vermiş bakarsın el ele;\r\n\r\nMi´delerden fışkırır tâ Arş´a aç bir velvele!\r\n\r\nOrtalık altüst olurken ses çıkarmazdım, hani,\r\n\r\nÖyle bir dernekte seyret gel de artık sen beni!\r\n\r\nGöster, Allah’ım, bu millet kurtulur, tek mu?cize:\r\n\r\nBir “utanmak hissi” ver gâib hazînenden bize!" }, Title = "Deneme" } },
                SelectedText = new Text { Pages = new string[] { "Bir zamanlar biz de millet, hem nasıl milletmişiz:\r\n\r\nGelmişiz, dünyaya milliyet nedir öğretmişiz!\r\n\r\nKapkaranlıkkken bütün afakı insaniyyetin,\r\n\r\nNur olup fışkırmışız tâ sinesinden zulmetin,\r\n\r\nYarmışız edvâr-ı fetretten kalan yeldaları;\r\n\r\nFikr-i ferda doğmadan yağdırmışız ferdaları!\r\n\r\nÖyle ferdalar ki: Kaldırmış serapa alemi;\r\n\r\nDideler bir cavidani fecrin olmuş mahremi.\r\n\r\nYirmi beş yıl, yirmi beş bin yıl kadar feyyaz imiş!\r\n\r\nBak ne ani bir tekamül! Bak ki: Hala mündehiş\r\n\r\nYad-ı fevka’l-ı i’tiyadından onun tarihler;\r\n\r\nGörmemiş benzer o müdhiş seyre, hem görmez beşer,\r\n\r\nBir taraftan dinimiz, ahlakımız, irfanımız;\r\n\r\nBir taraftan seyfe makrun adlimiz, ihsanımız;\r\n\r\nYükselip akvamı almış fevc fevc ağuşuna;\r\n\r\nHepsi dalmış vahdetin aheng-i cuşucuşuna,\r\n\r\nEmr-i bi?l ma?ruf imiş ihvan-ı İslam?ın işi;\r\n\r\nNehy edermiş, bir fenalık görse, kardeş kardeşi.\r\n\r\nKimse haksızlıktan etmezmiş tegafül ihtiyar;\r\n\r\nFerde raci’ sadmeden efrad olurmuş lerzedar.\r\n\r\nBiz, neyiz? Seyreyle artık; bir de fikr et, neymişiz?\r\n\r\nDin de kürkün aynı olmuş: Ters çevirmiş giymişiz!\r\n\r\nNehy-i ma’rûf emr-i münkerdir gezen meydanda bak!\r\n\r\nEn metîn ahlâkımız, yâhud, görüp aldırmamak!\r\n\r\nYıktı bin mel´un kalem nâmûsu, bizler uymadık:\r\n\r\n“Susmak evlâdır´” deyip sustuk… Sanırsın duymadık!\r\n\r\nKustu bin murdar ağız şer´in bütün ahkâmına;\r\n\r\nÂh, bir ses bâri yükselseydi nefret nâmına!\r\n\r\nAltı yüz bin can gider; milyonla îmân eksilir;\r\n\r\nKimseler görmez! Gören sersem de Allah´tan bilir!\r\n\r\nSonra, şâyet,sahsının incinse, hattâ, bir tüyü:\r\n\r\nYer yıkılmış zanneder seyr eyleyen gümbürtüyü!\r\n\r\nKırkın aylıktan biraz, yâhud geciksin vermeyin;\r\n\r\nFodla çiy kalsın, ´pilâv bitmiş” deyin, göstermeyin,\r\n\r\nFes, külâh, kalpak, sarık vermiş bakarsın el ele;\r\n\r\nMi´delerden fışkırır tâ Arş´a aç bir velvele!\r\n\r\nOrtalık altüst olurken ses çıkarmazdım, hani,\r\n\r\nÖyle bir dernekte seyret gel de artık sen beni!\r\n\r\nGöster, Allah’ım, bu millet kurtulur, tek mu?cize:\r\n\r\nBir “utanmak hissi” ver gâib hazînenden bize!" }, Title = "Deneme" },
                ReadingOptions = new ReadingOptions()
            };
    }

    public static async Task SaveConfiguration()
    {
        string jsonString = JsonConvert.SerializeObject(_configurationData);
        await SecureStorage.Default.SetAsync("ConfigurationData", jsonString);
    }
}
