using System;
using System.Collections;
using ClimbFind.Model.Enum;

namespace ClimbFind.Content
{
    //-- Change this class into some sort of culture manager
    
    public static class FlagList
    {
        private static Hashtable countryCodeHashTable = new Hashtable();

        static FlagList()
        {
            countryCodeHashTable.Add(Nation.Andorra, "ad");
            countryCodeHashTable.Add(Nation.UnitedArabEmirates, "ae");
            countryCodeHashTable.Add(Nation.Afghanistan, "af");
            countryCodeHashTable.Add(Nation.AntiguaAndBarbuda, "ag");
            countryCodeHashTable.Add(Nation.Anguilla, "ai");
            countryCodeHashTable.Add(Nation.Albania, "al");
            countryCodeHashTable.Add(Nation.Armenia, "am");
            countryCodeHashTable.Add(Nation.NetherlandsAntilles, "an");
            countryCodeHashTable.Add(Nation.Angola, "ao");
            countryCodeHashTable.Add(Nation.Antarctica, "aq");
            countryCodeHashTable.Add(Nation.Argentina, "ar");
            countryCodeHashTable.Add(Nation.AmericanSamoa, "as");
            countryCodeHashTable.Add(Nation.Austria, "at");
            countryCodeHashTable.Add(Nation.Australia, "au");
            countryCodeHashTable.Add(Nation.Aruba, "aw");
            countryCodeHashTable.Add(Nation.Azerbaijan, "az");
            countryCodeHashTable.Add(Nation.BosniaAndHerzegovina, "ba");
            countryCodeHashTable.Add(Nation.Barbados, "bb");
            countryCodeHashTable.Add(Nation.Bangladesh, "bd");
            countryCodeHashTable.Add(Nation.Belgium, "be");
            countryCodeHashTable.Add(Nation.BurkinaFaso, "bf");
            countryCodeHashTable.Add(Nation.Bulgaria, "bg");
            countryCodeHashTable.Add(Nation.Bahrain, "bh");
            countryCodeHashTable.Add(Nation.Burundi, "bi");
            countryCodeHashTable.Add(Nation.Benin, "bj");
            countryCodeHashTable.Add(Nation.SaintBarthélemy, "bl");
            countryCodeHashTable.Add(Nation.Bermuda, "bm");
            countryCodeHashTable.Add(Nation.BruneiDarussalam, "bn");
            countryCodeHashTable.Add(Nation.Bolivia, "bo");
            countryCodeHashTable.Add(Nation.Brazil, "br");
            countryCodeHashTable.Add(Nation.Bahamas, "bs");
            countryCodeHashTable.Add(Nation.Bhutan, "bt");
            countryCodeHashTable.Add(Nation.BouvetIsland, "bv");
            countryCodeHashTable.Add(Nation.Botswana, "bw");
            countryCodeHashTable.Add(Nation.Belarus, "by");
            countryCodeHashTable.Add(Nation.Belize, "bz");
            countryCodeHashTable.Add(Nation.Canada, "ca");
            countryCodeHashTable.Add(Nation.CocosIslands, "cc");
            countryCodeHashTable.Add(Nation.CongoDemocraticRepublic, "cd");
            countryCodeHashTable.Add(Nation.CentralAfricanRepublic, "cf");
            countryCodeHashTable.Add(Nation.Congo, "cg");
            countryCodeHashTable.Add(Nation.Switzerland, "ch");
            countryCodeHashTable.Add(Nation.CôtedIvoire, "ci");
            countryCodeHashTable.Add(Nation.CookIslands, "ck");
            countryCodeHashTable.Add(Nation.Chile, "cl");
            countryCodeHashTable.Add(Nation.Cameroon, "cm");
            countryCodeHashTable.Add(Nation.China, "cn");
            countryCodeHashTable.Add(Nation.Colombia, "co");
            countryCodeHashTable.Add(Nation.CostaRica, "cr");
            countryCodeHashTable.Add(Nation.Cuba, "cu");
            countryCodeHashTable.Add(Nation.CapeVerde, "cv");
            countryCodeHashTable.Add(Nation.ChristmasIsland, "cx");
            countryCodeHashTable.Add(Nation.Cyprus, "cy");
            countryCodeHashTable.Add(Nation.CzechRepublic, "cz");
            countryCodeHashTable.Add(Nation.Germany, "de");
            countryCodeHashTable.Add(Nation.Djibouti, "dj");
            countryCodeHashTable.Add(Nation.Denmark, "dk");
            countryCodeHashTable.Add(Nation.Dominica, "dm");
            countryCodeHashTable.Add(Nation.DominicanRepublic, "do");
            countryCodeHashTable.Add(Nation.Algeria, "dz");
            countryCodeHashTable.Add(Nation.Ecuador, "ec");
            countryCodeHashTable.Add(Nation.Estonia, "ee");
            countryCodeHashTable.Add(Nation.Egypt, "eg");
            countryCodeHashTable.Add(Nation.WesternSahara, "eh");
            countryCodeHashTable.Add(Nation.Eritrea, "er");
            countryCodeHashTable.Add(Nation.Spain, "es");
            countryCodeHashTable.Add(Nation.Ethiopia, "et");
            countryCodeHashTable.Add(Nation.Finland, "fi");
            countryCodeHashTable.Add(Nation.Fiji, "fj");
            countryCodeHashTable.Add(Nation.FalklandIslands, "fk");
            countryCodeHashTable.Add(Nation.Micronesia, "fm");
            countryCodeHashTable.Add(Nation.FaroeIslands, "fo");
            countryCodeHashTable.Add(Nation.France, "fr");
            countryCodeHashTable.Add(Nation.Gabon, "ga");
            countryCodeHashTable.Add(Nation.UnitedKingdom, "gb");
            countryCodeHashTable.Add(Nation.Grenada, "gd");
            countryCodeHashTable.Add(Nation.Georgia, "ge");
            countryCodeHashTable.Add(Nation.FrenchGuiana, "gf");
            countryCodeHashTable.Add(Nation.Guernsey, "gg");
            countryCodeHashTable.Add(Nation.Ghana, "gh");
            countryCodeHashTable.Add(Nation.Gibraltar, "gi");
            countryCodeHashTable.Add(Nation.Greenland, "gl");
            countryCodeHashTable.Add(Nation.Gambia, "gm");
            countryCodeHashTable.Add(Nation.Guinea, "gn");
            countryCodeHashTable.Add(Nation.Guadeloupe, "gp");
            countryCodeHashTable.Add(Nation.EquatorialGuinea, "gq");
            countryCodeHashTable.Add(Nation.Greece, "gr");
            countryCodeHashTable.Add(Nation.SouthGeorgiaAndSouthSandwichIslands, "gs");
            countryCodeHashTable.Add(Nation.Guatemala , "gt");
            countryCodeHashTable.Add(Nation.Guam, "gu");
            countryCodeHashTable.Add(Nation.GuineaBissau, "gw");
            countryCodeHashTable.Add(Nation.Guyana, "gy");
            countryCodeHashTable.Add(Nation.HongKong, "hk");
            countryCodeHashTable.Add(Nation.HeardIslandAndMcDonaldIslands, "hm");
            countryCodeHashTable.Add(Nation.Honduras, "hn");
            countryCodeHashTable.Add(Nation.Croatia, "hr");
            countryCodeHashTable.Add(Nation.Haiti, "ht");
            countryCodeHashTable.Add(Nation.Hungary, "hu");
            countryCodeHashTable.Add(Nation.Indonesia , "id");
            countryCodeHashTable.Add(Nation.Ireland, "ie");
            countryCodeHashTable.Add(Nation.Israel, "il");
            countryCodeHashTable.Add(Nation.IsleOfMan , "im");
            countryCodeHashTable.Add(Nation.India, "in");
            countryCodeHashTable.Add(Nation.BritishIndianOceanTerritory, "io");
            countryCodeHashTable.Add(Nation.Iraq, "iq");
            countryCodeHashTable.Add(Nation.Iran, "ir");
            countryCodeHashTable.Add(Nation.Iceland, "is");
            countryCodeHashTable.Add(Nation.Italy, "it");
            countryCodeHashTable.Add(Nation.Jersey, "je");
            countryCodeHashTable.Add(Nation.Jamaica, "jm");
            countryCodeHashTable.Add(Nation.Jordan, "jo");
            countryCodeHashTable.Add(Nation.Japan, "jp");
            countryCodeHashTable.Add(Nation.Kenya, "ke");
            countryCodeHashTable.Add(Nation.Kyrgyzstan, "kg");
            countryCodeHashTable.Add(Nation.Cambodia, "kh");
            countryCodeHashTable.Add(Nation.Kiribati, "ki");
            countryCodeHashTable.Add(Nation.Comoros, "km");
            countryCodeHashTable.Add(Nation.SaintKittsAndNevis, "kn");
            countryCodeHashTable.Add(Nation.KoreaDemocraticPeoplesRepublic, "kp");
            countryCodeHashTable.Add(Nation.Korea, "kr");
            countryCodeHashTable.Add(Nation.Kuwait, "kw");
            countryCodeHashTable.Add(Nation.CaymanIslands, "ky");
            countryCodeHashTable.Add(Nation.Kazakhstan, "kz");
            countryCodeHashTable.Add(Nation.Lao, "la");
            countryCodeHashTable.Add(Nation.Lebanon, "lb");
            countryCodeHashTable.Add(Nation.SaintLucia, "lc");
            countryCodeHashTable.Add(Nation.Liechtenstein, "li");
            countryCodeHashTable.Add(Nation.SriLanka, "lk");
            countryCodeHashTable.Add(Nation.Liberia, "lr");
            countryCodeHashTable.Add(Nation.Lesotho, "ls");
            countryCodeHashTable.Add(Nation.Lithuania, "lt");
            countryCodeHashTable.Add(Nation.Luxembourg, "lu");
            countryCodeHashTable.Add(Nation.Latvia, "lv");
            countryCodeHashTable.Add(Nation.LibyanArabJamahiriya, "ly");
            countryCodeHashTable.Add(Nation.Morocco, "ma");
            countryCodeHashTable.Add(Nation.Monaco, "mc");
            countryCodeHashTable.Add(Nation.Moldova, "md");
            countryCodeHashTable.Add(Nation.Montenegro, "me");
            countryCodeHashTable.Add(Nation.SaintMartin, "mf");
            countryCodeHashTable.Add(Nation.Madagascar, "mg");
            countryCodeHashTable.Add(Nation.MarshallIslands, "mh");
            countryCodeHashTable.Add(Nation.Macedonia, "mk");
            countryCodeHashTable.Add(Nation.Mali, "ml");
            countryCodeHashTable.Add(Nation.Myanmar, "mm");
            countryCodeHashTable.Add(Nation.Mongolia, "mn");
            countryCodeHashTable.Add(Nation.Macao, "mo");
            countryCodeHashTable.Add(Nation.NorthernMarianaIslands, "mp");
            countryCodeHashTable.Add(Nation.Martinique, "mq");
            countryCodeHashTable.Add(Nation.Mauritania, "mr");
            countryCodeHashTable.Add(Nation.Montserrat, "ms");
            countryCodeHashTable.Add(Nation.Malta, "mt");
            countryCodeHashTable.Add(Nation.Mauritius, "mu");
            countryCodeHashTable.Add(Nation.Maldives, "mv");
            countryCodeHashTable.Add(Nation.Malawi, "mw");
            countryCodeHashTable.Add(Nation.Mexico, "mx");
            countryCodeHashTable.Add(Nation.Malaysia, "my");
            countryCodeHashTable.Add(Nation.Mozambique, "mz");
            countryCodeHashTable.Add(Nation.Namibia, "na");
            countryCodeHashTable.Add(Nation.NewCaledonia, "nc");
            countryCodeHashTable.Add(Nation.Niger, "ne");
            countryCodeHashTable.Add(Nation.NorfolkIsland, "nf");
            countryCodeHashTable.Add(Nation.Nigeria, "ng");
            countryCodeHashTable.Add(Nation.Nicaragua, "ni");
            countryCodeHashTable.Add(Nation.Netherlands, "nl");
            countryCodeHashTable.Add(Nation.Norway, "no");
            countryCodeHashTable.Add(Nation.Nepal, "np");
            countryCodeHashTable.Add(Nation.Nauru, "r");
            countryCodeHashTable.Add(Nation.Niue, "nu");
            countryCodeHashTable.Add(Nation.NewZealand, "nz");
            countryCodeHashTable.Add(Nation.Oman, "om");
            countryCodeHashTable.Add(Nation.Panama, "pa");
            countryCodeHashTable.Add(Nation.Peru, "pe");
            countryCodeHashTable.Add(Nation.FrenchPolynesia, "pf");
            countryCodeHashTable.Add(Nation.PapuaNewGuinea, "pg");
            countryCodeHashTable.Add(Nation.Philippines, "ph");
            countryCodeHashTable.Add(Nation.Pakistan, "pk");
            countryCodeHashTable.Add(Nation.Poland, "pl");
            countryCodeHashTable.Add(Nation.SaintPierreAndMiquelon, "pm");
            countryCodeHashTable.Add(Nation.Pitcairn, "pn");
            countryCodeHashTable.Add(Nation.PuertoRico, "pr");
            countryCodeHashTable.Add(Nation.PalestinianTerritory , "ps");
            countryCodeHashTable.Add(Nation.Portugal, "pt");
            countryCodeHashTable.Add(Nation.Palau, "pw");
            countryCodeHashTable.Add(Nation.Paraguay, "py");
            countryCodeHashTable.Add(Nation.Qatar, "qa");
            countryCodeHashTable.Add(Nation.Réunion, "re");
            countryCodeHashTable.Add(Nation.Romania, "ro");
            countryCodeHashTable.Add(Nation.Serbia, "rs");
            countryCodeHashTable.Add(Nation.RussianFederation, "ru");
            countryCodeHashTable.Add(Nation.Rwanda, "rw");
            countryCodeHashTable.Add(Nation.SaudiArabia, "sa");
            countryCodeHashTable.Add(Nation.SolomonIslands, "sb");
            countryCodeHashTable.Add(Nation.Seychelles, "sc");
            countryCodeHashTable.Add(Nation.Sudan, "sd");
            countryCodeHashTable.Add(Nation.Sweden, "se");
            countryCodeHashTable.Add(Nation.Singapore, "sg");
            countryCodeHashTable.Add(Nation.SaintHelena, "sh");
            countryCodeHashTable.Add(Nation.Slovenia, "si");
            countryCodeHashTable.Add(Nation.SvalbardAndJanMayen, "sj");
            countryCodeHashTable.Add(Nation.Slovakia, "sk");
            countryCodeHashTable.Add(Nation.SierraLeone, "sl");
            countryCodeHashTable.Add(Nation.SanMarino, "sm");
            countryCodeHashTable.Add(Nation.Senegal, "sn");
            countryCodeHashTable.Add(Nation.Somalia, "so");
            countryCodeHashTable.Add(Nation.Suriname, "sr");
            countryCodeHashTable.Add(Nation.SaoTomeAndPrincipe, "st");
            countryCodeHashTable.Add(Nation.ElSalvador, "sv");
            countryCodeHashTable.Add(Nation.SyrianArabRepublic, "sy");
            countryCodeHashTable.Add(Nation.Swaziland, "sz");
            countryCodeHashTable.Add(Nation.TurksAndCaicosIslands, "tc");
            countryCodeHashTable.Add(Nation.Chad, "td");
            countryCodeHashTable.Add(Nation.Togo, "tg");
            countryCodeHashTable.Add(Nation.Thailand, "th");
            countryCodeHashTable.Add(Nation.Tajikistan, "tj");
            countryCodeHashTable.Add(Nation.Tokelau, "tk");
            countryCodeHashTable.Add(Nation.Turkmenistan, "tm");
            countryCodeHashTable.Add(Nation.Tunisia, "tn");
            countryCodeHashTable.Add(Nation.Tonga, "to");
            countryCodeHashTable.Add(Nation.Turkey, "tr");
            countryCodeHashTable.Add(Nation.TrinidadAndTobago, "tt");
            countryCodeHashTable.Add(Nation.Tuvalu, "tv");
            countryCodeHashTable.Add(Nation.Taiwan, "tw");
            countryCodeHashTable.Add(Nation.Tanzania, "tz");
            countryCodeHashTable.Add(Nation.Ukraine, "ua");
            countryCodeHashTable.Add(Nation.Uganda, "ug");
            countryCodeHashTable.Add(Nation.UnitedStates, "us");
            countryCodeHashTable.Add(Nation.Uruguay, "uy");
            countryCodeHashTable.Add(Nation.Uzbekistan, "uz");
            countryCodeHashTable.Add(Nation.Venezuela, "ve");
            countryCodeHashTable.Add(Nation.VietNam, "vn");
            countryCodeHashTable.Add(Nation.Vanuatu, "vu");
            countryCodeHashTable.Add(Nation.Samoa, "ws");
            countryCodeHashTable.Add(Nation.Yemen, "ye");
            countryCodeHashTable.Add(Nation.SouthAfrica, "za");
            countryCodeHashTable.Add(Nation.Zambia, "zm");
            countryCodeHashTable.Add(Nation.Zimbabwe, "zw");

            countryCodeHashTable.Add(Nation.England, "england");
            countryCodeHashTable.Add(Nation.Scotland, "scotland");
            countryCodeHashTable.Add(Nation.Wales, "wales");

        }

        public static string GetFlag(Nation nation)
        {
            if (countryCodeHashTable.ContainsKey(nation))
            {
                return countryCodeHashTable[nation].ToString() + ".png";   
            }
            else
            {
                return "nn.png";
            }
        }

        public static string GetCountryName(Nation nation)
        {
            string p = nation.ToString();
            string friendlyName = p[0].ToString();

            for (int i=1;i < p.Length; i++)
            {
                if (Char.IsLower(p[i])) { friendlyName += p[i]; }
                else { friendlyName += " " + p[i].ToString(); }
            }

            return friendlyName;
        }
   
    }
}
