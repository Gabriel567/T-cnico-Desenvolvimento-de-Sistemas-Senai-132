using System.Collections.Generic;

namespace ZooLogico.Models
{
    public class Arca
    {
        public static Dictionary <int, Animais> ArcaNoé = new Dictionary<int, Animais>() {
            {1, new TubaraoMartelo()},
            {2, new Tucano()},
            {3, new Arara()},
            {4, new Leão()},
            {5, new Orangotango()},
            {6, new Chimpanzé()},
            {7, new Pinguim()},
            {8, new Tartaruga()},
            {9, new Golfinho()}
        };
    }
}