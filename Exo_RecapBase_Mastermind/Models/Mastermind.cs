using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exo_RecapBase_Mastermind.Models
{
    public enum MastermindState
    {
        NotInitialized = 0,
        Running = 1,
        Loose = 2,
        Win = 3
    }

    public struct MastermindResult
    {
        public int WellPlaced;
        public int WrongPlaced;
    }

    public struct Mastermind
    {
        public const int MIN_VALUE = 0;
        public const int MAX_VALUE = 9;

        public List<int> MysteryValue;
        public int NbElement;
        public int NbMaxTry;
        public int CurrentTry;
        public MastermindState State;

        public void Initialize()
        {
            State = MastermindState.Running;
            CurrentTry = 0;
            NbMaxTry = 12;
            NbElement = 4;
            GenerateMystery();
        }

        private void GenerateMystery()
        {
            MysteryValue = new List<int>();
            Random rng = new Random();

            for (int i = 0; i < NbElement; i++)
            {
                // Génération de la valeur
                int val = rng.Next(MIN_VALUE, MAX_VALUE + 1);

                // Ajout dans la liste des valeurs a trouvé
                MysteryValue.Add(val);
            }
        }
    
        public MastermindResult Play(List<int> UserValue)
        {
            CurrentTry++;

            MastermindResult result = Compare(UserValue);

            if(result.WellPlaced == NbElement)
            {
                State = MastermindState.Win;
            }
            else if (CurrentTry == NbMaxTry)
            {
                State = MastermindState.Loose;
            }

            return result;
        }

        private MastermindResult Compare(List<int> userValue)
        {
            MastermindResult result;
            result.WellPlaced = 0;
            result.WrongPlaced = 0;

            // Copie des elements de l'utilisateur pour pouvoir les manipuler
            // L'opérateur spread (Syntaxe « .. » avec une collection) permet de décomposé un élément
            List<int?> userTry = [..userValue]; // ..values => 1, 2, 3

            for(int indexMystery = 0; indexMystery < MysteryValue.Count; indexMystery++)
            {
                if (MysteryValue[indexMystery] == userTry[indexMystery])
                {
                    result.WellPlaced++;
                    userTry[indexMystery] = null;
                }
                else
                {
                    bool valFound = false;
                    for (int indexTry = 0; !valFound && indexTry < userTry.Count; indexTry++)
                    {
                        if (userTry[indexTry] != null 
                            && userTry[indexTry] == MysteryValue[indexMystery]
                            && userTry[indexTry] != MysteryValue[indexTry])
                        {
                            result.WrongPlaced++;
                            userTry[indexTry] = null;
                            valFound = true;
                        }
                    }
                }
            }

            return result;
        }
    }
}
