open System.Net

let getIpSet (hostname : string) =
    Dns.GetHostEntry(hostname).AddressList
    |> Seq.map (fun a -> a.GetAddressBytes())
    |> Set.ofSeq

let aOK nameToCheck targetname =
    try
        Set.isSubset (getIpSet targetname) (getIpSet nameToCheck)
    with
        | _ -> false
