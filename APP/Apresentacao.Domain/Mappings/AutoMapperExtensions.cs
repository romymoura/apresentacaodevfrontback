using System.Collections.Generic;

namespace Apresentacao.Domain.Mappings
{
    public static class IoCAutoMapperExtensions
    {
        public static T MapTo<T>(this object value)
        {
            return AutoMapper.Mapper.Map<T>(value);
        }

        public static IEnumerable<T> EnumerableTo<T>(this object value)
        {
            return AutoMapper.Mapper.Map<IEnumerable<T>>(value);
        }
        public static ICollection<T> CollectionTo<T>(this object value)
        {
            return AutoMapper.Mapper.Map<ICollection<T>>(value);
        }
        public static IList<T> ListTo<T>(this object value)
        {
            return AutoMapper.Mapper.Map<IList<T>>(value);
        }
    }
}
