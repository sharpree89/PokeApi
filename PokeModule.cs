using System;
using System.Collections.Generic;
using ApiCaller;
using Nancy;
using System.Linq;

namespace PokeInfo
{
    public class PokeModule : NancyModule     
    {
        public PokeModule()
        {
            Get("/{id}", async args =>   
            {
                string name = "";
                long weight = 0;
                long height = 0;
                long exp = 0;

                string url = "http://pokeapi.co/api/v2/pokemon/";
                try
                {
                    url += (int)args.id;     
                }
                catch
                {
                    url += "151";    
                }

                await WebRequest.SendRequest(url, new Action<Dictionary<string, object>>( JsonResponse =>
                    {
                        name = (string)JsonResponse["name"];
                        weight = (long)JsonResponse["weight"];
                        height = (long)JsonResponse["height"];
                        exp = (long)JsonResponse["base_experience"];
 
                        @ViewBag.name = name;
                        @ViewBag.weight = weight;
                        @ViewBag.height = height;
                        @ViewBag.exp = exp; 
                    }
                ));
                return View["poke.sshtml"];
            }); 
        }
    }
}