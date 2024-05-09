using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Lab6_namespace
{

    public static class JsonHelperIndividuo
    {
        public static Individuo FromJson<Individuo>(string json)
        {
            Individuo individuo = JsonUtility.FromJson<Individuo>(json);
            return individuo;
        }

        public static string ToJson<Individuo>(Individuo individuo)
        {
            return JsonUtility.ToJson(individuo);
        }

        public static string ToJson<Individuo>(Individuo individuo, bool prettyPrint)
        {
            return JsonUtility.ToJson(individuo, prettyPrint);
        }
    }

}
    