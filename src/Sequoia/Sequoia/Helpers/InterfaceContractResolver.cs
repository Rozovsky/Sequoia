﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sequoia.Helpers
{
    public class InterfaceContractResolver : DefaultContractResolver
    {
        private readonly Type _interfaceType;

        public InterfaceContractResolver(Type interfaceType)
        {
            _interfaceType = interfaceType;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            //IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            IList<JsonProperty> properties = base.CreateProperties(_interfaceType, memberSerialization);

            return properties;
        }
    }
}
