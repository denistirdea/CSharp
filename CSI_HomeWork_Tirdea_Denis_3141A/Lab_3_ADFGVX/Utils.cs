using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_ADFGVX
{
    class Utils
    {
        public static String EncryptADFGVX(String text, String key1, String key2)
        {
            Console.WriteLine("Encrypt: ");
            String firstEncryptedMessage = Utils.firstCrypt(Utils.returnFirstMatrix(key1), text);
            String secondEncyptedMessage = Utils.returnEncryptedMessage(Utils.returnSecondMatrix(key2, firstEncryptedMessage));
            return secondEncyptedMessage;
        }

        public static String DecryptADFGVX(String text, String key1, String key2)
        {
            Console.WriteLine("Decryt: ");
            String secondEncryptedMessage = Utils.getSecondMessage(Utils.buildSecondMatrixFromString(text, key2));
            String message = Utils.returnDecryptedMessage(secondEncryptedMessage, key1);
            return message;
        }

        #region ENCRYPT

        public static String[,] returnFirstMatrix(String key1)
        {
            String[,] matrix = new String[7, 7]; matrix[0, 0] = " ";
            String key = Utils.removeDuplicates(key1);
            String fillMatrix = Utils.removeDuplicates(key + "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
            String adfgvx = "ADFGVX";
            int index = 0;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = adfgvx.Substring(row - 1, 1);
                matrix[0, row] = adfgvx.Substring(row - 1, 1);
            }
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = fillMatrix.Substring(index++, 1);
                }
            }
            Utils.showMatrix(matrix);
            return matrix;
        }
        public static String firstCrypt(String[,] matrix, String textToEncrypt)
        {
            String encryptedText = "";
            for (int index = 0; index < textToEncrypt.Length; index++)
            {
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    for (int col = 1; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col].Equals(textToEncrypt.Substring(index, 1)))
                        {
                            encryptedText += matrix[row, 0] + matrix[0, col];
                        }
                    }
                }
            }
            return encryptedText;
        }
        public static String[,] returnSecondMatrix(String key2, String text)
        {
            bool statemenet = true;
            int index = 0;
            key2 = Utils.removeDuplicates(key2);
            while (statemenet)
            {
                if (text.Length % key2.Length != 0)
                {
                    text += "A";
                }
                else
                {
                    statemenet = false;
                }
            }

            String[,] matrix = new String[key2.Length, (text.Length / key2.Length) + 1];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = key2.Substring(row, 1);
            }

            for (int row = 1; row < matrix.GetLength(1); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[col, row] = text.Substring(index++, 1);
                }
            }
            Utils.showMatrix(matrix);
            return matrix;
        }
        public static String returnEncryptedMessage(String[,] matrix)
        {
            String alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String finalEncryptedMessage = "";

            for (int index = 0; index < alfabet.Length; index++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (alfabet.Substring(index, 1).Equals(matrix[row, 0]))
                    {
                        for (int col = 1; col < matrix.GetLength(1); col++)
                        {
                            finalEncryptedMessage += matrix[row, col];
                        }
                    }
                }
            }
            return finalEncryptedMessage;
        }
        public static void showMatrix(String[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
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
        #endregion
   

        #region DECRYPT

        public static String returnDecryptedMessage(String text, String key1)
        {
            if (text.Length % 2 != 0)
            {
                text += "A";
            }

            String[,] matrix = Utils.returnFirstMatrix(key1);
            String message = "";
            int x = 0; int y = 0;

            for (int index = 0; index < text.Length; index+=2)
            {
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    for (int col = 1; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, 0] == text.Substring(index, 1) && matrix[0, col] == text.Substring(index + 1, 1))
                        {
                            message += matrix[row, col];   
                        }
                    }
                }
            }
            return message;
        }
        public static String getSecondMessage(String[,] matrix)
        {
            String secondMessage = "";

            for (int row = 1; row < matrix.GetLength(1); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    secondMessage += matrix[col, row];
                }
            }
            return secondMessage;
        }
        public static String[,] buildSecondMatrixFromString(String text, String key2)
        {
            key2 = Utils.removeDuplicates(key2);
            String[,] matrix = new String[key2.Length, (text.Length / key2.Length) + 1];
            String alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = key2.Substring(row, 1);
            }

            for (int counter = 0; counter < text.Length; counter += text.Length / key2.Length)
            {
                String text1 = text.Substring(counter, text.Length / key2.Length);
                Console.WriteLine(text1);

                for (int index = 0; index < alfabet.Length; index++)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                        if (alfabet.Substring(index, 1).Equals(matrix[row, 0]))
                        {
                            alfabet = alfabet.Remove(index, 1);
                            for (int caracter = 0; caracter < text1.Length; caracter++)
                            {
                                matrix[row, caracter + 1] = text1.Substring(caracter, 1);
                            }
                            row = matrix.GetLength(0);
                            index = alfabet.Length;
                        }
                }
            }
            Utils.showMatrix(matrix);
            return matrix;
        }
        #endregion
    }
}

