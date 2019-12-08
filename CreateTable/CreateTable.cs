using System;

namespace CreateTable
{
    public static class CreateTableString
    {
        //public string[][] StringTable()
        //{
        //    string[][] TableS;


        //    return TableS;
        //}
        public static string[,] StringTable(int CountInputI, int CountOutputI, int CountCycleI, int CountJumpI)
        {
            string [,] TableS = new string [CountJumpI, Convert.ToInt32(Math.Pow(2, CountInputI))];
            for (int i = 0; i < CountJumpI; i++)
            {

                for (int j = 0; j < Math.Pow(2, CountInputI); j++)
                {
                    TableS[i, j] = "~";
                }
            }
            //for (int w = 1; w <= CountCycleI; w++)
            //{
            //    for (int i = 1; i <= CountJumpI; i++)
            //    {
            //        for (int j = 1; j <= Math.Pow(2, CountInputI); j++)
            //        {
            //            if (w == 1 && i == 1 && j == 1)
            //            {
            //                TableS[i, j] = "(1)" + "";
            //            }
            //        }
            //    }
            //}
            return TableS;
        }

    }
}
