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
                long exp = 0;
                long weight = 0;
                long height = 0;

                // Our anonymous function is a parameter of type Action that returns a Dictionary
                await WebRequest.SendRequest("http://pokeapi.co/api/v2/pokemon/1", new Action<Dictionary<string, object>>( JsonResponse =>
                    {
                        name = (string)JsonResponse["name"];
                        species = (object)JsonResponse["species"];
                        weight = (long)JsonResponse["weight"];
                        height = (long)JsonResponse["height"];
                        exp = (long)JsonResponse["base_experience"];
                       
                        @ViewBag.name = name;
                        @ViewBag.weight = weight;
                        @ViewBag.height = height;
                        @ViewBag.species = species;
                        @ViewBag.exp = exp;
                       
                    }
                ));
                return View["poke.sshtml"];
            }); 
            //trying to push
       

        }
    }
}