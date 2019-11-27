using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Rkna_Project
{
    class EAN13Class
    {
        public static String Barcode13Dighits = "";

        public static string EAN13(String chaine)
        {
            int i;
            int first;
            int checkSum = 0;
            String Barcode = "";
            bool TableA;

            if (Regex.IsMatch(chaine, "^\\d{13}$"))
            {
                for (i = 1; i < 13; i += 2)
                {
                    System.Diagnostics.Debug.WriteLine(chaine.Substring(i, 1));
                    checkSum += Convert.ToInt32(chaine.Substring(i, 1));
                }
                checkSum *= 3;

                for (i = 0; i < 13; i += 2)
                {
                    checkSum += Convert.ToInt32(chaine.Substring(i, 1));
                }
                chaine += (10 - checkSum % 10) % 10;
                Barcode13Dighits = chaine.ToString();
                Barcode = chaine.Substring(0, 1) + (char)(65 + Convert.ToInt32(chaine.Substring(1, 1)));
                first = Convert.ToInt32(chaine.Substring(0, 1));


                for (i = 2; i <= 6; i++)
                {
                    TableA = false;
                    switch (i)
                    {
                        case 2:
                            if (first >= 0 && first <= 3) TableA = true;
                            break;
                        case 3:
                            if (first == 0 || first == 4 || first == 7 || first == 8) TableA = true;
                            break;
                        case 4:
                            if (first == 0 || first == 1 || first == 4 || first == 5 || first == 9) TableA = true;
                            break;
                        case 5:
                            if (first == 0 || first == 2 || first == 5 || first == 6 || first == 7) TableA = true;
                            break;
                        case 6:
                            if (first == 0 || first == 3 || first == 6 || first == 8 || first == 9) TableA = true;
                            break;
                    }

                    if (TableA)
                    {
                        Barcode += (char)(65 + Convert.ToInt32(chaine.Substring(i, 1)));
                    }
                    else
                    {
                        Barcode += (char)(75 + Convert.ToInt32(chaine.Substring(i, 1)));

                    }

                }

                Barcode += "*";
                for (i = 7; i < 13; i++)
                {
                    Barcode += (char)(97 + Convert.ToInt32(chaine.Substring(i, 1)));
                }

                Barcode += "+";
            }

            return Barcode;

        }


    }

}
