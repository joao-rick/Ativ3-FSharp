open System
open System.Threading

let gerador = Random()
let mutable dados: int array = [||]

let produzirDados () =
    printfn "# produzir - iniciado"
    dados <- Array.init 100 (fun _ -> gerador.Next(0, 111))
    printfn "# produzir %A" dados
    printfn "# produzir - terminado"
    dados

let consumirDados () =
    printfn "### consumir - iniciado"
    printfn "### dados -> %A" dados
    let resultado = Array.sum dados
    printfn "### resultado -> %d" resultado
    printfn "### consumir - terminado"

let principal () =
    printfn "iniciou"

    let threadProdutor = Thread(ThreadStart(fun () -> produzirDados () |> ignore))
    let threadConsumidor = Thread(ThreadStart(fun () -> consumirDados ()))

    threadProdutor.Start()
    threadConsumidor.Start()

    printfn "finalizou"

if fsi.CommandLineArgs |> Array.contains "--run" then
    principal ()