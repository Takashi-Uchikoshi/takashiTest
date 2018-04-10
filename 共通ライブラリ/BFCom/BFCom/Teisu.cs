using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2.BestFunction
{
    public class Teisu
    {
        //商品コード区分
        public const int ShouhinCodeKubunTouitu = 0;
        public const int ShouhinCodeKubunJan = 1;
        public const int ShouhinCodeKubunGtin = 2;
        public const int ShouhinCodeKubunSonota = 9;


        //発注伝票区分
        public const int HacchuDenpyouKubunShiire = 0;
        public const int HacchuDenpyouKubunTenkanIdouIrai = 1;
        public const int HacchuDenpyouKubunJyoujyuIrai = 2;

        //発注取引区分
        public const int HacchuTorihikiKubunHacchu = 0;

        
        //入庫伝票区分
        public const int NyukoDenpyouKubunShiire = 0;
        public const int NyukoDenpyouKubunTenkanIdou = 1;
        public const int NyukoDenpyouKubunJyoujyu = 2;
        public const int NyukoDenpyouKubunZaikoChousei = 3;
        public const int NyukoDenpyouKubunSample = 4;

        //入庫取引区分
        public const int NyukoTorihikiKubunNyuko = 0;
        public const int NyukoTorihikiKubunHenpin = 1;
        public const int NyukoTorihikiKubunNebiki = 2;
        public const int NyukoTorihikiKubunNemasi = 3;


        //出庫伝票区分
        public const int ShukkoDenpyouKubunUriage = 0;
        public const int ShukkoDenpyouKubunTenkanIdou = 1;
        public const int ShukkoDenpyouKubunJyouyo = 2;
        public const int ShukkoDenpyouKubunZaikoChousei = 3;
        public const int ShukkoDenpyouKubunSample = 4;
        public const int ShukkoDenpyouKubunHaikiYakuhin = 5;
        public const int ShukkoDenpyouKubunHaikiMayaku = 6;
        public const int ShukkoDenpyouKubunHaikiKouseisinyaku = 7;
        public const int ShukkoDenpyouKubunJishaShouhi = 8;
        public const int ShukkoDenpyouKubunShanaihanbai = 9;
        public const int ShukkoDenpyouKubunOtcUriage = 10;
        public const int ShukkoDenpyouKubunChouzai = 20;

        //出庫取引区分
        public const int ShukkoTorihikiKubunShukko = 0;
        public const int ShukkoTorihikiKubunHenpin = 1;
        public const int ShukkoTorihikiKubunNebiki = 2;
        public const int ShukkoTorihikiKubunNemasi = 3;


    }
}
