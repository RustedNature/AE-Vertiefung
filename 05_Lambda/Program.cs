namespace _05_Lambda
{
    internal class Program
    {
        //Anonyme Methoden sind nur über delegaten aufrufbar. Für delegeaten => Buch Seite 221
        //Syntax:
        //<zugriffsmodifikator> delegate <rückgabetyp> <Delegatennamen>(<parameter>);
        //
        //<Delegatennamen> <Bezeichnung> = delegate(<parameter>){methodeninhalt}
        public delegate void Help();

        private delegate int ErrorCode(int code);

        private delegate string SucheBisLambda(bool da);

        private static void Main(string[] args)
        {
            Help help = delegate () { Console.WriteLine("Send Help"); };

            help();

            //Mit lambda =>
            ErrorCode errorCode = x => x * x;

            Console.WriteLine(errorCode(errorCode(45 * 45)));
        }
    }
}