using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Web_Grundlagen.Models;

namespace Web_Grundlagen.Extensions
{
    public static class Sessionextension
    {
        public static void Set<User>(this ISession session, string key, User value) {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static User? Get<User>(this ISession session, string key) {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<User>(value);
        }

    }
}
