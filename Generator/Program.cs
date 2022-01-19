// See https://aka.ms/new-console-template for more information

using NJsonSchema;
using NJsonSchema.CodeGeneration.TypeScript;
using OBS.Music.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

Console.WriteLine("Hello, World!");

var tsSetting = new TypeScriptGeneratorSettings { TypeStyle = TypeScriptTypeStyle.Interface };
var tsResolver = new TypeScriptTypeResolver(tsSetting);
var _baseSchema = new JsonSchema();
var dictionary = new Dictionary<string, JsonSchema>();

Assembly
    .GetAssembly(typeof(Entity))!
    .GetTypes()
    .Where(type => type.IsAssignableTo(typeof(Entity)))
    .Select(type => (name: type.Name!, schema: JsonSchema.FromType(type)))
    .ForEach(generated => dictionary.Add(generated.name, generated.schema));


foreach (var definition in dictionary)
{
    JsonSchema actualSchema = definition.Value.ActualSchema;

    foreach (var subDefinition in actualSchema.Definitions)
    {

    }
}

tsResolver.RegisterSchemaDefinitions(dictionary);

var tsGenerator = new TypeScriptGenerator(_baseSchema, tsSetting, tsResolver);
var artifacts = tsGenerator.GenerateTypes().ToList();
var codeFile = tsGenerator.GenerateFile();
var filePath = Path.Combine(".", "obs.music.ts");

File.WriteAllText(filePath, codeFile);