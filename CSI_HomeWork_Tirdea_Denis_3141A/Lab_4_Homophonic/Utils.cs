using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Homophonic
{
    class Utils
    {
  
        public static String Enrypt(String text, String key1)
        {
            return Utils.returnCryptedMessage(Utils.buildMatrix(key1), text);
        }

        public static String Decyrpt(String text, String key1) {
            return Utils.returnDecryptedMessage(text, key1);
        }

        #region ENCRYPT

        public static String[,] buildMatrix(String key1)
        {
            String alfabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            String[,] matrix = new String[key1.Length + 1, alfabet.Length];

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = alfabet.Substring(col, 1);
            }
           
            int val = 1;
            
            for (int index = 0; index < key1.Length; index++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (key1.Substring(index, 1).Equals(matrix[0, col]))
                    {
                        for (int counter = col; counter < 25; counter++)
                        {
                            if (val == 100) val = 0;
                            matrix[index + 1, counter] = Convert.ToString(String.Format("{0:00.}",  val++));
                        }

                        for (int counter = 0; counter < col; counter++)
                        {
                            if (val == 100) val = 0;
                            matrix[index + 1, counter] = Convert.ToString(String.Format("{0:00.}", val++));
                        }
                    }
                }
            }

            showMatrix(matrix);
            return matrix;
        }

        public static String returnCryptedMessage(String[,] matrix, String text)
        {
            Random random = new Random();
            String message = "";
            for (int index = 0; index < text.Length; index++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (text.Substring(index, 1).Equals(matrix[0, col]))
                    {

                        int randomNumber = random.Next(1, matrix.GetLength(0));
                        message += matrix[randomNumber, col];
                    }

                }
            }
            Console.WriteLine(message);
            return message;

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

        #endregion

        #region DECRYPT

        public static String returnDecryptedMessage(String text, String key1)
        {
            String[,] matrix = Utils.buildMatrix(key1);
            String decryptedMessage = "";
            showMatrix(matrix);
            for (int index = 0; index < text.Length; index += 2)
            {
                String temp = text.Substring(index, 2);
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (temp.Equals(matrix[row,col]))
                        {
                            decryptedMessage += matrix[0, col];
                        }
                    }
                }
            }
            return decryptedMessage;
        }
        #endregion
    }
}
