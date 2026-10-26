open System

let entrada = Console.In.ReadToEnd().Trim()

if String.IsNullOrWhiteSpace entrada then
    failwith "Nenhum dado foi recebido pelo pipe."

let dados =
    entrada.Split([| ' '; '\r'; '\n'; '\t' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map Int32.Parse

printfn "entrada: %d valores recebidos" dados.Length
printfn "resultado -> %d" (Array.sum dados)