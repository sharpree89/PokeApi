using System;
using System.Collections.Generic;
using ApiCaller;
using Nancy;

namespace PokeInfo
{
    public class PokeModule : NancyModule
    {
        public PokeModule()
        {
            Get("/", async args =>
            {
                string name = "";
                object species = "";
                long weight = 0;
                long height = 0;
                long exp = 0;

                await WebRequest.SendRequest("http://pokeapi.co/api/v2/pokemon/7", new Action<Dictionary<string, object>>( JsonResponse =>
                    {
                        name = (string)JsonResponse["name"];
                        species = (object)JsonResponse["species"];
                        weight = (long)JsonResponse["weight"];
                        height = (long)JsonResponse["height"];
                        exp = (long)JsonResponse["base_experience"];
                       
                        @ViewBag.name = name;
                        @ViewBag.species = species;
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