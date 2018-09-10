using NHunspell;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RemixTranslate
{
    public static class Translater
    {
        private static string PathAff
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"c:\users\1007787\documents\visual studio 2015\Projects\RemixTranslate\RemixTranslate\dicio\pt_BR.aff");
            }
        }
        private static string PathDic
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"c:\users\1007787\documents\visual studio 2015\Projects\RemixTranslate\RemixTranslate\dicio\pt_BR.dic");
            }
        }

        public static string[] removeNonLetter(string str)
        {
            try
            {
                string vStr = str;
                string nStr = "";
                foreach (var c in str)
                    if (((int)c > 47 && (int)c < 58) || ((int)c > 64 && (int)c < 91) || ((int)c > 96 && (int)c < 123) || ((int)c > 127) || c == '\n')
                        nStr += c;
                string removed = vStr.Replace(nStr, "");
                if (string.IsNullOrEmpty(removed))
                    removed = "";
                return new string[] { removed, nStr };
            }
            catch
            {
                return new string[] { "", str };
            }
        }

        public static string VariationToLeaYiokari(this string yiokari)
        {
            string variation = " " + yiokari;

            variation = variation.Replace(" ih ", " ï ").Replace(" ah ", " ä ");
            variation = variation.Replace(" di ", " di").Replace(" dih ", " dï ");
            variation = variation.Replace(" da ", " da").Replace(" dah ", " dä ");
            variation = variation.Replace(" li ", " li").Replace(" lih ", " lï ");
            variation = variation.Replace(" la ", " la").Replace(" lah ", " lä ");

            variation = variation.Replace(" hoc ", " hoc");
            variation = variation.Replace(" hacli", " hacli ");

            variation = variation.Replace(" ilge", " ilge ");
            variation = variation.Replace(" pla", " pla ");

            variation = variation.Replace("hh", "rr").Replace("ll", "ül");
            variation = variation.Replace("tl", "tïl").Replace("dl", "dïl");
            variation = variation.Replace("lh", "ll");
            variation = variation.Replace("hb", "rb").Replace("bb", "x");
            variation = variation.Replace("hg", "rg").Replace("ht", "rt");
            variation = variation.Replace("hp", "rp");

            /* influência do idioma comum */
            variation = variation.Replace("bi ", "be ").Replace("ci ", "ce ");
            variation = variation.Replace("di ", "de ").Replace("fi ", "fe ");
            variation = variation.Replace("gi ", "ge ").Replace("hi ", "he ");
            variation = variation.Replace("ji ", "je ").Replace("ki ", "ke ");
            variation = variation.Replace("li ", "le ").Replace("pi ", "pe ");
            variation = variation.Replace("ri ", "re ").Replace("si ", "se ");
            variation = variation.Replace("vi ", "ve ");

            variation = variation.Substring(1, variation.Length - 1);

            var txtlist = variation.Split(' ');
            for (int i = 0; i < txtlist.Count(); i++)
                if (!string.IsNullOrEmpty(txtlist[i]))
                {
                    if (txtlist[i].Last() == 'h') txtlist[i] = txtlist[i].Replace(txtlist[i].Last().ToString(), "'s");
                    if (txtlist[i].First() == '\'')
                    {
                        var txt = txtlist[i].ToCharArray();
                        txt[0] = ' ';
                        txt[1] = 'h';
                        txtlist[i] = new String(txt).Trim();
                    }
                    if (txtlist[i].Count() == 4)
                    {
                        txtlist[i] += " ";
                        txtlist[i] = txtlist[i].Replace("a ", "ä ").Replace("e ", "ë ").Replace("o ", "ü ");
                    }
                    /* influência do idioma comum */
                    txtlist[i] = txtlist[i].Replace("hoczolda", "zoldahoc");
                }
            variation = String.Join(" ", txtlist).Replace("  ", " ");

            variation = variation.Replace("cie", "cë");
            variation = variation.Replace("ada's", "ära's");
            variation = variation.Replace("qa", "ka").Replace("qe", "que");

            return variation;
        }

        public static string VariationToYiokal(this string yiokari)
        {
            string variation = " " + yiokari;

            variation = variation.Replace(" ih ", " i-").Replace(" ah ", " ah-");
            variation = variation.Replace(" di ", " di-").Replace(" dih ", " dih-");
            variation = variation.Replace(" da ", " da-").Replace(" dah ", " dah-");
            variation = variation.Replace(" li ", " li-").Replace(" lih ", " lih-");
            variation = variation.Replace(" la ", " la-").Replace(" lah ", " lah-");

            variation = variation.Replace(" hoc ", " hoke");
            variation = variation.Replace(" hacli", " racli ");

            variation = variation.Replace(" ilge", " ilge ");
            variation = variation.Replace(" pla", " pla ");

            variation = variation.Replace("hh", "hr").Replace("ll", "ll");
            variation = variation.Replace("tl", "tt").Replace("dl", "d");
            variation = variation.Replace("lh", "lh");
            variation = variation.Replace("hb", "b").Replace("bb", "b");
            variation = variation.Replace("hg", "g").Replace("ht", "t");

            variation = variation.Substring(1, variation.Length - 1);

            var txtlist = variation.Split(' ');
            for (int i = 0; i < txtlist.Count(); i++)
                if (!string.IsNullOrEmpty(txtlist[i]))
                {
                    if (txtlist[i].Last() == 'h') txtlist[i] = txtlist[i].Replace(txtlist[i].Last().ToString(), "ys");
                    if (txtlist[i].First() == 'y')
                    {
                        var txt = txtlist[i].ToCharArray();
                        txt[0] = ' ';
                        txt[1] = 'h';
                        txtlist[i] = new string(txt).Trim();
                    }
                    txtlist[i] = txtlist[i].Replace("hoczolda", "zoldahoc");
                }
            variation = string.Join(" ", txtlist).Replace("  ", " ");
            variation = variation.Replace("ys-", "h-").Replace("-ys", "h");

            variation = variation.Replace("cie", "ke");

            return variation;
        }

        public static string TranslateToYiokari(this string word)
        {
            using (var hspell = new Hunspell(PathAff, PathDic))
            {
                string translate = string.Empty;
                string lPorts = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÄËÏÖÜÃÕáéíóúàèìòùâêîôûäëïöüãõç 1234567890-([{?!.:;,$%_+=/\\<>^\"\'}])\t\n";
                string lYioks = "ICBDIQTSEVKRZLAPQLHGOJWXYMicbdiqtsevkrzlapqlhgojwxymIIEAOIIEAOIIEAOIIEAOIAiieaoiieaoiieaoiieaoiab 1234567890-([{?!.:;,$%_+=/\\<>^\"\'}])\t\n";

                foreach (var c in word)
                    for (int i = 0; i < lPorts.Length; i++)
                        if (c == lPorts.ToCharArray()[i])
                            translate += lYioks.ToCharArray()[i];

                string verb = word;

                var removal = removeNonLetter(verb);
                string ch = removal[0];
                verb = removal[1];
                
                if (!hspell.Spell(word))
                    translate = verb + ch;

                translate = translate + " ";
                translate = translate.Replace("x", "sc");

                return translate;
            }
        }

        public static string TranslateToArconte(this string word)
        {
            using (var hspell = new Hunspell(PathAff, PathDic))
            {
                string translate = " " + word + " ";
                translate = translate
                    .Replace("ão ", "äi ")
                    .Replace("ãos ", "air ")
                    .Replace("õe ", "öi ")
                    .Replace("ões ", "oir ")
                    .Replace("am ", "amnu ")
                    .Replace("em ", "emnu ")
                    .Replace("im ", "imnu ")
                    .Replace("om ", "omnu ")
                    .Replace("um ", "umne ")
                    .Replace("as ", "ärur ")
                    .Replace("es ", "ërum ")
                    .Replace("is ", "ïrum ")
                    .Replace("os ", "örur ")
                    .Replace("la ", "lan ")
                    .Replace("le ", "len ")
                    .Replace("li ", "lin ")
                    .Replace("lo ", "lon ")
                    .Replace("lu ", "lum ")
                    .Replace("ch", "k")
                    .Replace("sh", "ch")
                    .Replace("t", "h")
                    .Replace("d", "t")
                    .Replace("cs", "d")
                    .Replace("x", "cs")
                    .Replace("á", "ra")
                    .Replace(" ", "");

                string verb = word;

                var removal = removeNonLetter(verb);
                string ch = removal[0];
                verb = removal[1];

                if (!hspell.Spell(word))
                    translate = verb + ch;

                translate = translate + " ";

                return translate;
            }
        }
    }
}
