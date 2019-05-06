using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI_HomeWork_Tirdea_Denis_3141A
{
    class Utils
    {
        public static List<string> returnTextWithoutDuplicates(string textToEncrypt)
        {
            List<string> characters = new List<string>();

            for (int counter = 0; counter < textToEncrypt.Length; counter++)
            {
                characters.Add(textToEncrypt.Substring(counter, 1));
            }

            for (int counter = 0; counter < characters.Count - 1; counter += 2)
            {
                if (characters.ElementAt(counter) == characters.ElementAt(counter + 1))
                {
                    characters.Insert(counter + 1, "X");
                    counter = 0;
                }
            }

            if (characters.Count % 2 == 1)
            {
                characters.Add("X");
            }
            for (int counter = 0; counter < characters.Count - 1; counter += 2)
            {
                Console.Write(characters.ElementAt(counter) + " " + characters.ElementAt(counter + 1) + Environment.NewLine);
            }

            return characters;
        }

        public static string removeDuplicates(string text)
        {
            for (int elementAt = 0; elementAt < text.Length; elementAt++)
            {
                if (text.Substring(elementAt, 1) == " ") { text = text.Remove(elementAt, 1); text.Insert(elementAt, ""); }
                for (int counter = 0; counter < text.Length; counter++)
                {
                    if (elementAt != counter)
                    {
                        if (text.Substring(elementAt, 1) == text.Substring(counter, 1))
                        {
                            text = text.Remove(counter, 1);
                            counter = 0;
                        }
                    }
                }
            }
            return text;
        }

        public static string[,] buildMatrixWithKeys(List<string> characters, string key, string alphabet)
        {
            string[,] matrix = new string[5, 5];
            string charactersToEnter = removeDuplicates(key + alphabet);
            int counter = 0;

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    matrix[row, col] = charactersToEnter.Substring(counter, 1);
                    counter++;
                }
            }
            Console.WriteLine();
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            return matrix;
        }

        public static string EncryptPlayFair(List<string> list, string[,] matrix)
        {
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            string ecryptedMessage = "";

            for (int counter = 0; counter < list.Count - 1; counter += 2)
            {
                for (int row = 0; row < 5; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        if (list.ElementAt(counter).ToString() == matrix[row, col])
                        {
                            x1 = row; y1 = col;
                        }
                        if (list.ElementAt(counter + 1).ToString() == matrix[row, col])
                        {
                            x2 = row; y2 = col;
                        }
                    }
                }
                if (x1 == x2)
                {
                    if (y1 == 4) y1 = -1; if (y2 == 4) y2 = -1;
                    ecryptedMessage += matrix[x1, y1 + 1] + matrix[x2, y2 + 1];
                }
                else if (x1 != x2 && y1 != y2)
                {
                    ecryptedMessage += matrix[x1, y2] + matrix[x2, y1];
                }
                else if (y1 == y2)
                {
                    if (x1 == 4) x1 = -1; if (x2 == 4) x2 = -1;
                    ecryptedMessage += matrix[x1 + 1, y1] + matrix[x2 + 1, y2];
                }
            }
            return ecryptedMessage;
        }
        public static string DecryptPlayFair(List<string> list, string[,] matrix)
        {
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            string ecryptedMessage = "";

            for (int counter = 0; counter < list.Count - 1; counter += 2)
            {
                for (int row = 0; row < 5; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        if (list.ElementAt(counter).ToString() == matrix[row, col])
                        {
                            x1 = row; y1 = col;
                        }
                        if (list.ElementAt(counter + 1).ToString() == matrix[row, col])
                        {
                            x2 = row; y2 = col;
                        }
                    }
                }
                if (x1 == x2)
                {
                    if (y1 == 0) y1 = 5; if (y2 == 0) y2 = 5;
                    ecryptedMessage += matrix[x1, y1 - 1] + matrix[x2, y2 - 1];
                }
                else if (x1 != x2 && y1 != y2)
                {
                    ecryptedMessage += matrix[x1, y2] + matrix[x2, y1];
                }
                else if (y1 == y2)
                {
                    if (x1 == 0) x1 = 5; if (x2 == 0) x2 = 5;
                    ecryptedMessage += matrix[x1 - 1, y1] + matrix[x2 - 1, y2];
                }
            }
            return ecryptedMessage;
        }

        public static string returnTextWithoutX(string text)
        {
            string textToReturn = "";
            for (int counter = 0; counter < text.Length; counter++)
            {
                if(text.Substring(counter,1).ToString() != "X")
                {
                    textToReturn += text.Substring(counter, 1).ToString();
                }
            }

            return textToReturn;
        }

        public static string Encrypt(string text, string key)
        {
            List<string> list;
            string[,] matrix = new string[5, 5];
            string ecryptedMessage = "";

            list = Utils.returnTextWithoutDuplicates(text);
            matrix = Utils.buildMatrixWithKeys(list, key, "ABCDEFGHIKLMNOPQRSTUVWXYZ");
            ecryptedMessage = Utils.EncryptPlayFair(list, matrix);

            return ecryptedMessage;
        }
        public static string Decrypt(string text, string key)
        {
            List<string> list;
            string[,] matrix = new string[5, 5];

            list = Utils.returnTextWithoutDuplicates(text);
            matrix = Utils.buildMatrixWithKeys(list, key, "ABCDEFGHIKLMNOPQRSTUVWXYZ");

            return Utils.returnTextWithoutX(Utils.DecryptPlayFair(list, matrix));
           
        }
    }
}
