using System;

namespace CreateTable
{
    public static class CreateTableString
    {
        /// <summary>
        /// Создание текстового заполнения ТП и ТВ
        /// </summary>
        /// <param name="CountInputI"></param>
        /// <param name="CountOutputI"></param>
        /// <param name="CountCycleI"></param>
        /// <param name="CountJumpI"></param>
        /// <returns></returns>
        public static string[,] StringTable(int CountInputI, int CountOutputI, int CountCycleI, int CountJumpI)
        {
            string[,] TableS = new string[CountJumpI, Convert.ToInt32(Math.Pow(2, CountInputI))];
            int jumpStep = 0;
            string exitV = "";
            string exitVOne = "";
            // Create ~ Array
            for (int i = 0; i < CountJumpI; i++)
            {

                for (int j = 0; j < Math.Pow(2, CountInputI); j++)
                {
                    TableS[i, j] = "~";
                }
            }
            // Create Array Table Exit
            for (int w = 1; w <= CountCycleI; w++)
            {
                for (int i = 0; i < CountJumpI; i++)
                {
                    if (w == 1 && i == 0)
                    {
                        exitV = ExitValueText(CountOutputI);
                        TableS[i, 0] = "(1), " + exitV;
                        exitVOne = exitV;
                    }
                    if (i != 0)
                    {
                        TableS[i, jumpStep] = "(" + (i + 1).ToString() + "), " + exitV;
                    }
                    if (i < CountJumpI - 1)
                    {
                        do
                        {
                            exitV = ExitValueText(CountOutputI);
                            jumpStep = JumpStepText(CountInputI);
                        } while (TableS[i, jumpStep] != "~");
                        TableS[i, jumpStep] = i + 2 + ", " + exitV;
                    }
                    if (i == CountJumpI - 1)
                    {
                        TableS[i, 0] = "1, " + exitVOne;
                    }
                }
            }
            return TableS;
        }
        /// <summary>
        /// Создание перехода в другое состояние входов
        /// </summary>
        /// <param name="CountInputI"></param>
        /// <returns></returns>
        private static int JumpStepText(int CountInputI)
        {
            Random rnd = new Random();
            int valueStep;
            valueStep = rnd.Next(0, (Convert.ToInt32(Math.Pow(2, CountInputI))));
            return valueStep;
        }

        /// <summary>
        /// Создание значений выходных переменных
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static int[] RandomExit(int CountOutputI)
        {
            int[] valueExitArray = new int[CountOutputI];
            Random rnd = new Random();
            int valueExit;
            for (int i = 0; i < CountOutputI; i++)
            {
                valueExit = rnd.Next(0, 2);
                valueExitArray[i] = valueExit;
            }
            return valueExitArray;
        }
        /// <summary>
        /// Формирование строки выходных переменных
        /// </summary>
        /// <returns></returns>
        public static string ExitValueText(int CountOutputI)
        {
            string ExitStringText = "";
            int[] rndExit;
            rndExit = RandomExit(CountOutputI);
            foreach (var i in rndExit)
            {
                ExitStringText += rndExit[i].ToString();
            }
            return ExitStringText;
        }

    }
}
