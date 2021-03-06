using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using JsonApiDotNetCore.Internal.Contracts;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Serialization;
using JsonApiDotNetCore.Serialization.Server;
using Newtonsoft.Json;

namespace Benchmarks.Serialization
{
    [MarkdownExporter]
    public class JsonApiDeserializerBenchmarks
    {
        private static readonly string Content = JsonConvert.SerializeObject(new Document
        {
            Data = new ResourceObject
            {
                Type = BenchmarkResourcePublicNames.Type,
                Id = "1",
                Attributes = new Dictionary<string, object>
                {
                    {
                        "name",
                        Guid.NewGuid().ToString()
                    }
                }
            }
        });

        private readonly IJsonApiDeserializer _jsonApiDeserializer;

        public JsonApiDeserializerBenchmarks()
        {
            IResourceGraph resourceGraph = DependencyFactory.CreateResourceGraph();
            var targetedFields = new TargetedFields();

            _jsonApiDeserializer = new RequestDeserializer(resourceGraph, targetedFields);
        }

        [Benchmark]
        public object DeserializeSimpleObject() => _jsonApiDeserializer.Deserialize(Content);
    }
}
