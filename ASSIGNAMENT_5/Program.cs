#!/usr/bin/env dotnet

#:package CsvHelper@33.1.0

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

public record HistoricoTransitoVehiculos
{
    public long Id { get; init; }
    public string Matricula { get; set; }
    public string LinkImagenVehiculo1 { get; set; }
    public string LinkImagenVehiculo2 { get; set; }
}


var fileInfo = new FileInfo("historico-transito-vehiculos.csv");
using var fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
using var streamReader = new StreamReader(fileStream);
using var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true, Delimiter = ","});
await foreach(var record in csvReader.GetRecordsAsync<HistoricoTransitoVehiculos>())
{
    Console.Out.WriteLine(record.Id);
}

Console.WriteLine("Hello shebang!");
