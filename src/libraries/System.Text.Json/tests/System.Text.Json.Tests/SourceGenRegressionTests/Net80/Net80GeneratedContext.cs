﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// Source files represent a source generated JsonSerializerContext as produced by the .NET 8 SDK.
// Used to validate correctness of contexts generated by previous SDKs against the current System.Text.Json runtime components.
// Unless absolutely necessary DO NOT MODIFY any of these files -- it would invalidate the purpose of the regression tests.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace System.Text.Json.Tests.SourceGenRegressionTests.Net80
{
    //[JsonSerializable(typeof(WeatherForecastWithPOCOs))]
    //[JsonSerializable(typeof(ClassWithCustomConverter))]
    //[JsonSerializable(typeof(MyLinkedList))]
    public partial class Net80GeneratedContext : JsonSerializerContext {}

    public class WeatherForecastWithPOCOs
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
        public string? SummaryField;
        public List<DateTimeOffset>? DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
        public string[]? SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }

    public class MyLinkedList
    {
        public MyLinkedList(int value, MyLinkedList? nested)
        {
            Value = value;
            Nested = nested;
        }

        public int Value { get; set; }
        public MyLinkedList? Nested { get; set; }
    }

    [JsonConverter(typeof(CustomConverter))]
    public class ClassWithCustomConverter
    {
        public int Value { get; set; }

        public class CustomConverter : JsonConverter<ClassWithCustomConverter>
        {
            public override ClassWithCustomConverter? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => new ClassWithCustomConverter { Value = reader.GetInt32() - 1 };

            public override void Write(Utf8JsonWriter writer, ClassWithCustomConverter value, JsonSerializerOptions options)
                => writer.WriteNumberValue(value.Value + 1);
        }
    }
}
