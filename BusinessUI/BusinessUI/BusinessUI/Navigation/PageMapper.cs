using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace BusinessUI.Navigation
{
    public sealed class PageMapper
    {

        private readonly ConcurrentDictionary<object, Type> _associateToType = new ConcurrentDictionary<object, Type>();

        public void AddMapping(Type type, object associatedSource)
        {
            _associateToType.TryAdd(associatedSource, type);
        }

        public Type GetTypeSource(object associatedSource)
        {
            Type typeSource;
            _associateToType.TryGetValue(associatedSource, out typeSource);

            return typeSource;
        }


    }
}
