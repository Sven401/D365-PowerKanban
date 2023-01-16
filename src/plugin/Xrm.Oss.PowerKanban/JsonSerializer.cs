﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.Oss.PowerKanban
{
    public static class JsonSerializer
    {
        public static string Serialize<T>(T result) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });

            using (var memoryStream = new MemoryStream())
            {
                serializer.WriteObject(memoryStream, result);

                memoryStream.Position = 0;

                using (var streamReader = new StreamReader(memoryStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
