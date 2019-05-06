using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_DES
{
    class Utils
    {
        public static void StartProgram(string text, string key)
        {
            Utils.returnTextIntoBinary(text);
            Utils.createSubKeys(PermutKey(buildBinaryKey(key)));
        }
        public static String checkStringLenght(String text)
        {
            bool statement = true;
            while (statement)
            {
                if (text.Length % 16 != 0)
                {
                    text += "0";
                    statement = true;
                }
                else
                    statement = false;
            }
            return text;
        }
        public static void returnTextIntoBinary(String text)
        {
            text = checkStringLenght(text);
            Console.WriteLine("Text: " + text);
            for (int counter = 0; counter < text.Length; counter += 16)
            {
                String binaryText = "";
                for (int index = counter; index < text.Length; index++)
                {
                    switch (text.Substring(index, 1))
                    {
                        case "0":
                            binaryText += "0000";
                            break;
                        case "1":
                            binaryText += "0001";
                            break;
                        case "2":
                            binaryText += "0010";
                            break;
                        case "3":
                            binaryText += "0011";
                            break;
                        case "4":
                            binaryText += "0100";
                            break;
                        case "5":
                            binaryText += "0101";
                            break;
                        case "6":
                            binaryText += "0110";
                            break;
                        case "7":
                            binaryText += "0111";
                            break;
                        case "8":
                            binaryText += "1000";
                            break;
                        case "9":
                            binaryText += "1001";
                            break;
                        case "A":
                            binaryText += "1010";
                            break;
                        case "B":
                            binaryText += "1011";
                            break;
                        case "C":
                            binaryText += "1100";
                            break;
                        case "D":
                            binaryText += "1101";
                            break;
                        case "E":
                            binaryText += "1110";
                            break;
                        case "F":
                            binaryText += "1111";
                            break;
                    }
                }
                Console.WriteLine("Binary text: " + binaryText + " (b)" +binaryText.Length);
                String left = binaryText.Substring(0, 32);
                String right = binaryText.Substring(32, 32);
                Console.WriteLine("Left: " + left + " (b)" + left.Length + Environment.NewLine + "Right: " + right + " (b)" + right.Length);
            }
        }
        public static String buildBinaryKey(String key)
        {
            String binaryKey = "";
            key = checkStringLenght(key);
            Console.WriteLine(Environment.NewLine + "Key: " + key);
            for (int counter = 0; counter < key.Length; counter++)
            {
                switch (key.Substring(counter, 1))
                {
                    case "0":
                        binaryKey += "0000";
                        break;
                    case "1":
                        binaryKey += "0001";
                        break;
                    case "2":
                        binaryKey += "0010";
                        break;
                    case "3":
                        binaryKey += "0011";
                        break;
                    case "4":
                        binaryKey += "0100";
                        break;
                    case "5":
                        binaryKey += "0101";
                        break;
                    case "6":
                        binaryKey += "0110";
                        break;
                    case "7":
                        binaryKey += "0111";
                        break;
                    case "8":
                        binaryKey += "1000";
                        break;
                    case "9":
                        binaryKey += "1001";
                        break;
                    case "A":
                        binaryKey += "1010";
                        break;
                    case "B":
                        binaryKey += "1011";
                        break;
                    case "C":
                        binaryKey += "1100";
                        break;
                    case "D":
                        binaryKey += "1101";
                        break;
                    case "E":
                        binaryKey += "1110";
                        break;
                    case "F":
                        binaryKey += "1111";
                        break;
                }
            }
            Console.WriteLine("Binary Key: " + binaryKey + " (b)" + binaryKey.Length);
            return binaryKey;
        }
        public static String PermutKey(String key)
        {
            String keyPlus = "";
            int[] table = new int[56]
            {   57, 49, 41, 33, 25, 17, 9 ,
                1,  58, 50, 42, 34, 26, 18,
                10, 2, 59, 51, 43, 35, 27 ,
                19, 11, 3, 60, 52, 44, 36 ,
                63, 55, 47, 39, 31, 23, 15,
                7,  62, 54, 46, 38, 30, 22,
                14, 6, 61, 53, 45, 37, 29 ,
                21, 13, 5, 28, 20, 12,  4
            };
            for (int index = 0; index < table.Length; index++)
            {
                keyPlus += key.Substring(table[index] - 1, 1);
            }
            Console.WriteLine("Permuted key: " + keyPlus + " (b)" + keyPlus.Length);
            Console.WriteLine(Environment.NewLine+"SubKeys: " );
            return keyPlus;
        }
        public static String PermutSubKey(String key)
        {
            String subKey = "";
            int[] table = new int[48]
            {   14, 17, 11, 24, 1, 5,
                3, 28, 15, 6, 21, 10,
                23, 19, 12, 4, 26, 8,
                16, 7, 27, 20, 13, 2,
                41, 52, 31, 37, 47,55,
                30, 40, 51, 45, 33,48,
                44, 49, 39, 56, 34, 53,
                46, 42, 50, 36, 29, 32
            };
            for (int index = 0; index < table.Length; index++)
            {
                subKey += key.Substring(table[index] - 1, 1);
            }
            return subKey;
        }
        public static String[] PermuteSubKeys(String[] keys) {

            for (int index = 0; index < keys.Length; index++)
            {
                keys[index] = PermutSubKey(keys[index]);
            }
            return keys;
        }
        public static void createSubKeys(String keyPlus)
        {
            string C0 = keyPlus.Substring(0, 28);
            string D0 = keyPlus.Substring(28, 28);
            int[] iterates = new int[16] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

            String[] keys = new string[16];

            for (int counter = 0; counter < keys.Length; counter++)
            {
                keys[counter] = iterateString(C0, iterates[counter]) + iterateString(D0, iterates[counter]);
                C0 = iterateString(C0, iterates[counter]);
                D0 = iterateString(D0, iterates[counter]);
            }
            foreach (string s in keys)
                Console.WriteLine(s + " (b)" + s.Length);
            keys = PermuteSubKeys(keys);
            Console.WriteLine(Environment.NewLine + "Permuted sub-keys: ");
            foreach (string s in keys)
                Console.WriteLine(s + " (b)" + s.Length);
        }

        public static String iterateString(string text, int iterateNumber)
        {
            String temp = "";

            for (int counter = 0; counter < iterateNumber; counter++)
            {
                for (int index = 1; index <= text.Length; index++)
                {
                    if (index == text.Length)
                    {
                        temp += text.Substring(0, 1);

                    }
                    else
                    {
                        temp += text.Substring(index, 1);
                    }
                }
                text = temp;
                temp = "";
            }
            return text;
        }
    }
}
