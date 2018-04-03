module onvif.utils.NetMaskHelper
    open System
    open System.Collections.Generic
    open System.Linq
    open System.Text
    open System.Net

    [<Sealed>]
    type ExecHelper() = class
    member val LastCall = new Nullable<DateTime>() with get, set

    member this.CanExecuteWithTimeLimit(timeSpan : TimeSpan) : bool =
            if not this.LastCall.HasValue then
                this.LastCall <- new Nullable<DateTime>(DateTime.Now)
                true
            else 
            let total = DateTime.Now.Subtract(this.LastCall.Value : DateTime).TotalSeconds
            if Math.Abs( total: double) >= timeSpan.TotalSeconds then
                this.LastCall <- new Nullable<DateTime>(DateTime.Now)
                true
            else
                false
    end

    type IpAddressHelper() = class
    static member private IsPrivateIp(myIpAddress:System.Net.IPAddress) : bool =
            let mutable result = false
            if myIpAddress <> null && myIpAddress.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork then
                let ipBytes = myIpAddress.GetAddressBytes()
                if ipBytes.[0] = (byte 10) then result <- true
                if ipBytes.[0] = (byte 172) && ipBytes.[1] = (byte 16) then result <- true
                if ipBytes.[0] = (byte 192) && ipBytes.[1] = (byte 168) then result <- true
                if ipBytes.[0] = (byte 169) && ipBytes.[1] = (byte 254) then result <- true
                result
            else
                false

    static member private IsLocalIpAddress(host:string) : bool =
            try
                // get host IP addresses
                let hostIPs = Dns.GetHostAddresses(host)
                // get local IP addresses
                let localIPs = Dns.GetHostAddresses(Dns.GetHostName())
                hostIPs.Any(fun hostIp -> IPAddress.IsLoopback(hostIp) || localIPs.Contains(hostIp))
            with _ -> false

    static member IsLocalAddress(ip:string) : bool =
            let host = ip;
            let mutable ipAddress : System.Net.IPAddress = null
            let result = System.Net.IPAddress.TryParse(ip, ref ipAddress)
            if result then IpAddressHelper.IsPrivateIp(ipAddress) else IpAddressHelper.IsLocalIpAddress(host)

    static member private getAsync (url:string) = 
            async {
                use httpClient = new System.Net.Http.HttpClient()
                let! response = httpClient.GetAsync(url) |> Async.AwaitTask
                response.EnsureSuccessStatusCode () |> ignore
                let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
                return content
            }

     static member private getString (url:string) = 
                use httpClient = new System.Net.Http.HttpClient()
                httpClient.Timeout <- System.TimeSpan.FromSeconds(5.0)
                let response = httpClient.GetAsync(url).Result
                response.EnsureSuccessStatusCode () |> ignore
                let content = response.Content.ReadAsStringAsync().Result
                content

    static member private Trim (value:string) = 
           value.TrimEnd('\n').Trim() 

    static member GetExternalIpAddress() : string =
            try
                let result = IpAddressHelper.getString("http://icanhazip.com/")
                IpAddressHelper.Trim(result)
            with _-> 
            try
                let result = IpAddressHelper.getString("http://bot.whatismyipaddress.com")
                IpAddressHelper.Trim(result)
            with _ ->
            try
                let result = IpAddressHelper.getString("http://ipinfo.io/ip")
                IpAddressHelper.Trim(result)
             with _ -> 
            try
                let result = IpAddressHelper.getString("https://api.ipify.org")
                IpAddressHelper.Trim(result)
            with _ -> null
    end

    type private MB = {
        mask:byte
        bits:int
        next: list<MB>
    }

    let CidrToIpMask(cidrMask:Int32):IPAddress = 
        if cidrMask > 32 then failwith "invalid argument - cidrMask"
        if cidrMask < 0 then failwith "invalid argument - cidrMask"
        let rec GetBytes(cidrMask, cnt) = 
            if cnt = 0 then
                []
            else if cidrMask > 8 then
                255uy::GetBytes(cidrMask-8, cnt-1)
            else if cidrMask>0 then
                (255uy <<< 8-cidrMask)::GetBytes(cidrMask-8, cnt-1)
            else
                0uy::GetBytes(0, cnt-1)

        new IPAddress(GetBytes(cidrMask,4) |> List.toArray)


    let IpToCidrMask(ipMask:IPAddress):Int32 = 
        let mutable cidrMask = 0
        let bytes = ipMask.GetAddressBytes()
        
        let rec zero_m = [{mask=0uy; bits=0; next=zero_m}]
        let rec any_m = [
            {mask=255uy; bits=8; next=any_m}; 
            {mask=254uy; bits=7; next=zero_m};
            {mask=252uy; bits=6; next=zero_m};
            {mask=248uy; bits=5; next=zero_m};
            {mask=240uy; bits=4; next=zero_m};
            {mask=224uy; bits=3; next=zero_m};
            {mask=192uy; bits=2; next=zero_m};
            {mask=128uy; bits=1; next=zero_m};
            {mask=0uy; bits=0; next=zero_m}
        ]
        
        let rec find_m v lst = 
            match lst with
            |h::t -> 
                if h.mask = v then
                    Some h
                elif h.mask<v then
                    None
                else
                    find_m v t
            |[] -> None
        
        let cidrMask, s = bytes |> ((0, any_m) |> Array.fold (fun (acc, pos) x -> 
            match find_m x pos with
            |Some v -> (acc+v.bits, v.next)
            |None -> failwith "invalid ip mask"
        ))
        cidrMask