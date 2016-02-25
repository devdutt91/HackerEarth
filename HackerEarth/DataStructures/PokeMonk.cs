using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerearth.DataStructures
{
    /// <summary>
    /// Monk has to visit a land where strange creatures, known as Pokemons, roam around in the wild. 
    /// Each Pokemon in the land will attack any visitor. They can only be pacified by feeding them their favorite food.
    ///The Pokemon of type X eats one food item of type X.
    ///Monk knows that he will encounter N ponds on the way. At each pond, he will find a food item and then encounter a Pokemon. 
    /// The i'th pond has the food item of type Ai and the Pokemon of type Bi.
    ///The monk can feed the item at the i'th pond to the Pokemon at the pond if the type matches. 
    /// Monk may have to carry some food items with him before leaving so as to feed all the Pokemons. 
    /// Help him find the number of items he must carry, to be to able to pass through the land safely.
    ///Input:
    ///The first line contains T, denoting the number of test cases. Then, T test cases follow.
    ///The first line of each test case contains an integer N. Then, N lines follow.
    ///Each line consists of 2 space-separated integers Ai and Bi.
    ///Output: For each test case, print the answer in a new line.
    /// </summary>
    public class PokeMonk
    {
        public PokeMonk()
        {
            //Accept the inputs
            var t = Convert.ToInt64(Console.ReadLine());
            var pok = new List<int>();
            var food = new List<int>();
            var noOfInputs = new List<int>();
            for (var i = 0; i < t; i++)
            {
                var n = (Convert.ToInt32(Console.ReadLine()));
                noOfInputs.Add(n);
                for (var j = 0; j < n; j++)
                {
                    var inp = Console.ReadLine().Split(' ');
                    pok.Add(Convert.ToInt32(inp[0]));
                    food.Add(Convert.ToInt32(inp[1]));
                }
            }

            var start = 0;
            //For t test cases
            for (var iter = 0; iter < t; iter++)
            {
                var extraPok = new Dictionary<int, int>();
                var extraFood = new Dictionary<int, int>();
                if (iter != 0)
                    start += (noOfInputs[iter - 1]);
                //Exclude the already considered pokemons
                for (var i = start; i < start + noOfInputs[iter]; i++)
                {
                    var p = pok[i];
                    var f = food[i];
                    //Keep count of pokemon
                    if (!extraPok.ContainsKey(p))
                        extraPok.Add(p, 1);
                    else
                        extraPok[p]++;
                    //Kepp count of food
                    if (!extraFood.ContainsKey(f))
                        extraFood.Add(f, 1);
                    else
                        extraFood[f]++;
                }

                var count = 0;
                foreach (var ep in extraPok)
                {
                    //If food for pokemon does not exist
                    if (!extraFood.ContainsKey(ep.Key))
                        count += ep.Value;
                    //If food is short
                    else if (ep.Value - extraFood[ep.Key] > 0)
                        count++;
                }
                Console.WriteLine(count);
            }
        }
    }
}
