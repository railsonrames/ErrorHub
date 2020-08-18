using Newtonsoft.Json;

namespace ErrorHub.Domain.Utilities
{
    public static class Json
    {
        public static string Convert<T>(T obj)
        {
            if (obj == null)
                return null;

            return JsonConvert.SerializeObject(obj,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
