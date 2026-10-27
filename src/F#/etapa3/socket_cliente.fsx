open System
open System.IO
open System.Net.Sockets

let argumentos = fsi.CommandLineArgs |> Array.skip 1
let endereco = if argumentos.Length > 0 then argumentos[0] else "127.0.0.1"
let porta = if argumentos.Length > 1 then Int32.Parse argumentos[1] else 5000

let principal () =
    let gerador = Random()
    let dados = Array.init 100 (fun _ -> gerador.Next(0, 111))

    use cliente = new TcpClient()
    cliente.Connect(endereco, porta)
    use fluxo = cliente.GetStream()
    use escritor = new StreamWriter(fluxo, AutoFlush = true)
    use leitor = new StreamReader(fluxo)

    escritor.WriteLine(String.Join(" ", dados))
    cliente.Client.Shutdown(SocketShutdown.Send)

    printfn "servidor: %s" (leitor.ReadLine())

principal ()