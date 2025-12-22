#!/usr/bin/env dotnet

#:package CsvHelper@33.1.0

public record HistoricoTransitoVehiculos
{
    public long Id { get; init; }
    public string Matricula { get; set; }
    public string LinkImagenVehiculo1 { get; set; }
    public string LinkImagenVehiculo2 { get; set; }
}

Console.WriteLine("Hello shebang!");
