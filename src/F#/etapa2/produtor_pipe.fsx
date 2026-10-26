open System

let gerador = Random()
let dados = Array.init 100 (fun _ -> gerador.Next(0, 111))

printfn "%s" (String.Join(" ", dados))