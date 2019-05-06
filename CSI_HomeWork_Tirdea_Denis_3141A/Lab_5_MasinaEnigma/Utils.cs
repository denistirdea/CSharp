using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasinaEnigma
{
    class Utils
    {
        /* 
         Crypt or decrypt for Enigma is the same
         No need of new function
        */
        public static String Encrypt_Decrypt(String textToBeEncrypted, int rotor1, int rotor2, int rotor3, int reflector)
        {
            String[,] matrix = Utils.buildMatrix(rotor1 + 1, rotor2 + 1, rotor3 + 1);
            textToBeEncrypted = Utils.inputFinderOnMatrix(matrix, textToBeEncrypted);
            Console.WriteLine("REFLECTAT: " + Utils.reflectString(reflector, textToBeEncrypted));
            String message = Utils.getCriptedMessage(matrix, reflectString(reflector + 1, textToBeEncrypted));
            Console.WriteLine("MESAJ FINAL: " + message);
            return Utils.getCriptedMessage(matrix, reflectString(reflector + 1, textToBeEncrypted));
        }

        public static String returnAlfabet()
        {
            String alfabet = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z ";
            return alfabet;
        }

        public static String returnRotor_1Row()
        {
            String rotor1 = "E K M F L G D Q V Z N T O W Y H X U S P A I B R C J ";
            return rotor1;
        }

        public static String returnRotor_2Row()
        {
            String rotor2 = "A J D K S I R U X B L H W T M C Q G Z N P Y F V O E ";
            return rotor2;
        }

        public static String returnRotor_3Row()
        {
            String rotor3 = "B D F H J L C P R T X V Z N Y E I W G A K M U S Q O ";
            return rotor3;
        }

        public static String returnReflectorB(String text)
        {
            String[,] reflectorB = new string[2, 13]
            { {"A", "B", "C", "D", "E", "F", "G", "I", "J", "K", "M", "T", "V" },
              {"Y", "R", "U", "H", "Q", "S", "L", "P", "X", "N", "O", "Z", "W"  }
            };

            for (int index = 0; index < text.Length; index++)
            {
                for (int col = 0; col < reflectorB.GetLength(1); col++)
                {
                    for (int row = 0; row < reflectorB.GetLength(0); row++)
                    {
                        if (text.Substring(index, 1).Equals(reflectorB[row, col]) && row == 0)
                        {
                            text = text.Remove(index, 1);
                            text = text.Insert(index, reflectorB[1, col]);
                            break;
                        }
                        if (text.Substring(index, 1).Equals(reflectorB[row, col]) && row == 1)
                        {
                            text = text.Remove(index, 1);
                            text = text.Insert(index, reflectorB[0, col]);
                            break;
                        }
                    }
                }
            }
            return text;
        }
        public static String returnReflectorC(String text)
        {
            String[,] reflectorC = new string[2, 13]
            { {"A", "B", "C", "D", "E", "G", "H", "K", "L", "M", "N", "T", "S" },
             {"F", "B", "P", "J", "I", "O", "Y", "R", "Z", "X", "W", "Q", "U"}
            };

            for (int index = 0; index < text.Length; index++)
            {
                for (int col = 0; col < reflectorC.GetLength(1); col++)
                {
                    for (int row = 0; row < reflectorC.GetLength(0); row++)
                    {
                        if (text.Substring(index, 1).Equals(reflectorC[row, col]) && row == 0)
                        {
                            text = text.Remove(index, 1);
                            text = text.Insert(index, reflectorC[1, col]);
                            break;
                        }
                        if (text.Substring(index, 1).Equals(reflectorC[row, col]) && row == 1)
                        {
                            text = text.Remove(index, 1);
                            text = text.Insert(index, reflectorC[0, col]);
                            break;
                        }
                    }
                }
            }
            return text;
        }

        public static String[,] buildMatrix(int firstRotor, int secondRotor, int thirdRotor)
        {
            String[,] matrix = new String[4, 26];
            int[] rotors = new int[3] { firstRotor, secondRotor, thirdRotor };
            String line = "";
            String[] temp = new String[4 * 26];
            int index = 0;
            line += returnAlfabet();

            for (int counter = 0; counter < rotors.Length; counter++)
            {
                switch (rotors[counter])
                {
                    case 1:
                        line += returnRotor_1Row();
                        break;
                    case 2:
                        line += returnRotor_2Row();
                        break;
                    case 3:
                        line += returnRotor_3Row();
                        break;
                    default:
                        Console.WriteLine("Error, closing app...");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
            temp = line.Trim().Split(' ');

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = temp[index++];
                }
            }
            showMatrix(matrix);
            return matrix;
        }

        public static String inputFinderOnMatrix(String[,] matrix, String textToEncrypt)
        {
            for (int counterInText = 0; counterInText < textToEncrypt.Length; counterInText++)
            {
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    for (int indexInAlfabet = 0; indexInAlfabet < matrix.GetLength(1); indexInAlfabet++)
                    {
                        if (textToEncrypt.Substring(counterInText, 1).Equals(matrix[0, indexInAlfabet]))
                        {
                            textToEncrypt = textToEncrypt.Remove(counterInText, 1);
                            textToEncrypt = textToEncrypt.Insert(counterInText, matrix[row, indexInAlfabet]);
                            break;
                        }
                    }
                }
            }
            return textToEncrypt;
        }

        public static String getCriptedMessage(String[,] matrix, String reflectedText)
        {
            for (int counterInText = 0; counterInText < reflectedText.Length; counterInText++)
            {
                for (int row = 3; row > 0; row--)
                {
                    for (int indexInAlfabet = 0; indexInAlfabet < matrix.GetLength(1); indexInAlfabet++)
                    {
                        if (reflectedText.Substring(counterInText, 1).Equals(matrix[row, indexInAlfabet]))
                        {
                            reflectedText = reflectedText.Remove(counterInText, 1);
                            reflectedText = reflectedText.Insert(counterInText, matrix[0, indexInAlfabet]);
                            break;
                        }
                    }
                }
            }
            return reflectedText;
        }

        public static String reflectString(int value, String text)
        {
            switch (value)
            {
                case 1:
                    text = returnReflectorB(text);
                    break;
                case 2:
                    text = returnReflectorC(text);
                    break;
            }
            return text;
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
    }
}
