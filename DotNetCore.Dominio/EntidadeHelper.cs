using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetCore.Dominio
{
    public static class StringExtention
    {
        public static bool NaoInformado(this string str)
        {
            return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
        }
        public static bool NaoInformado<T>(this T obj, string parameterName)
                where T : class
        {
            return NaoInformado(parameterName);
        }
    }

    public static class EntidadeHelper
    {
        public static bool ContemErros(this Entidade entidade)
        {
            var erros = Verificar(entidade, new List<int>());

            return erros.Any();
        }

        public static IList<Regra> TodosErros(this Entidade entidade)
        {
            var erros = Verificar(entidade, new List<int>());

            return erros;
        }

        private static List<Regra> Verificar(Entidade parent, IList<int> hashers)
        {
            var list = new List<Regra>();
            if (hashers.Contains(parent.GetHashCode()))
                return list;

            list.AddRange(parent.Erros);
            var properties = parent.GetType().GetRuntimeProperties();
            hashers.Add(parent.GetHashCode());
            foreach (var p in properties)
            {
                if (p.PropertyType != typeof(Entidade)) continue;
                var mget = p.GetGetMethod(false);
                if (mget == null) { continue; }
                var children = (Entidade)p.GetValue(parent, null);
                if (children == null) { continue; }
                list.AddRange(Verificar(children, hashers));
            }
            return list;
        }

        public static void AdicionarRegraQuebrada<T>(this Entidade entidade) where T : Regra, new()
        {
            entidade.AdicionarRegraQuebrada(new T());
        }
    }
}
