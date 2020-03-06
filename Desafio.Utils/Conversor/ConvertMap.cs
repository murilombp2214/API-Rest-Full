using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Desafio.Utils.Conversor
{
    public static class ConvertMap
    {
        /// <summary>
        /// Converte de Source Para Target utilizando Mapper 
        /// </summary>
        /// <typeparam name="TypeBase"></typeparam>
        /// <typeparam name="TypeRetorno"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TypeRetorno Converta<TypeBase, TypeRetorno>(TypeBase source)
        {
            return new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TypeBase, TypeRetorno>())).Map<TypeRetorno>(source);
        }

        public static void Convert<Source, Target>(Source source, in Target target)
        {
            foreach (var item in source.GetType().GetProperties())
            {
                if (target.GetType().GetProperties().Contains(item))
                {
                    PropertyInfo propety = target.GetType().GetProperty(item.Name);
                    object value = propety.GetValue(source);
                    propety.SetValue(target, value);
                }
            }
        }
    }
}
