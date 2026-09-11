# ISO 20022 Financial Message Parser & Validator — .NET / C# SDK

[![NuGet version](https://img.shields.io/nuget/v/StanzaApi.Iso20022Parser.svg)](https://www.nuget.org/packages/StanzaApi.Iso20022Parser/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Stanza API](https://img.shields.io/badge/Powered%20by-Stanza-blue)](https://stanzaapi.com)

> SWIFT ISO 20022 XML-to-JSON parser and compliance engine for pacs.008, camt.053, and pain.001 with sub-5ms edge latency.

Official high-performance .NET client library for **ISO 20022 Financial Message Parser & Validator**, built on the [Stanza Micro-API Network](https://stanzaapi.com). Fully compatible with .NET Standard 2.0, .NET 6.0, .NET 7.0, and .NET 8.0+.

* 🌐 **Online Interactive Sandbox:** [Test your inputs live](https://stanzaapi.com/tools/iso20022-parser)
* 📚 **API Reference & Schemas:** [View documentation on Stanza](https://stanzaapi.com/tools/iso20022-parser)
* ⚡ **Platform Overview:** [Explore the Stanza Developer Network](https://stanzaapi.com)

---

## 📦 Installation

```bash
dotnet add package StanzaApi.Iso20022Parser
```

---

## 🚀 Quickstart

```csharp
using System;
using System.Threading.Tasks;
using StanzaApi.Iso20022Parser;

class Program
{
    static async Task Main()
    {
        // Initialize client (reads STANZA_API_KEY from environment if not passed)
        var client = new Iso20022ParserClient();

        // Perform deterministic verification
        string responseJson = await client.ValidateAsync("<Document xmlns=\"urn:iso:std:iso:20022:tech:xsd:pacs.008.001.08\">...</Document>");
        Console.WriteLine(responseJson);
    }
}
```

---

## 📄 Example Response

```json
{
  "success": true,
  "data": {
    "message_type": "pacs.008.001.08",
    "settlement_amount": 150000,
    "currency": "EUR",
    "instruction_id": "INSTR-2026-0982"
  }
}
```

---

## ⚙️ Configuration

Pass options directly to the `Iso20022ParserClient` constructor:

```csharp
var client = new Iso20022ParserClient(
    apiKey: "your_api_key_here",
    baseUrl: "https://api.stanzaapi.com/iso20022-parser"
);
```

---

## 🔗 Useful Links

* [ISO 20022 Financial Message Parser & Validator Interactive Sandbox](https://stanzaapi.com/tools/iso20022-parser)
* [Stanza Developer Directory](https://stanzaapi.com)
* [Source Code & Issue Tracker](https://github.com/StanzaAPI/iso20022-parser-csharp)

## 📄 License

MIT © Stanza — Powered by [Stanza](https://stanzaapi.com).
