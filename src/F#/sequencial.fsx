module Sequencial

open System

let private gerador = Random()

let produzirDados () =
    Array.init 100 (fun _ -> gerador.Next(0, 111))

let consumirDados (dados: int array) =
    let resultado = Array.sum dados
    printfn "recebeu -> %d" resultado

let principal () =
    printfn "iniciou"
    let dados = produzirDados ()
    consumirDados dados
    printfn "finalizou"

if fsi.CommandLineArgs |> Array.contains "--run" then
    principal ()