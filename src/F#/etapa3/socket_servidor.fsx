open System
open System.IO
open System.Net
open System.Net.Sockets

let argumentos = fsi.CommandLineArgs |> Array.skip 1
let porta = if argumentos.Length > 0 then Int32.Parse argumentos[0] else 5000

let servidor = TcpListener(IPAddress.Any, porta)
servidor.Start()
printfn "servidor aguardando na porta %d" porta

use cliente = servidor.AcceptTcpClient()
use fluxo = cliente.GetStream()
use leitor = new StreamReader(fluxo)
use escritor = new StreamWriter(fluxo, AutoFlush = true)

let entrada = leitor.ReadToEnd().Trim()
let dados =
    entrada.Split([| ' '; '\r'; '\n'; '\t' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map Int32.Parse

let resultado = Array.sum dados
escritor.WriteLine(sprintf "resultado -> %d" resultado)
printfn "cliente atendido: %d valores" dados.Length

servidor.Stop()